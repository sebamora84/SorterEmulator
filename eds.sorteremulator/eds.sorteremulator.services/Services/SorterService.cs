using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;

namespace eds.sorteremulator.services.Services
{
    public class SorterService :ISorterService
    {
        private readonly ILogger<SorterService> _logger;
        private readonly IConfigurationManager _configurationManager;
        private readonly IPhysicsService _physicsService;
        private readonly IParcelService _parcelService;
        private readonly INodesService _nodesService;
        private readonly ConcurrentDictionary<string, List<ActionDelay>> _actionDelayGroup = new ConcurrentDictionary<string, List<ActionDelay>>();

        private Timer _actionDelayTimer;

        public SorterService(
            ILogger<SorterService> logger, 
            IConfigurationManager configurationManager, 
            IPhysicsService physicsService,
            IParcelService parcelService, 
            INodesService nodesService)
        {
            _logger = logger;
            _configurationManager = configurationManager;
            _physicsService = physicsService;
            _parcelService = parcelService;
            _nodesService = nodesService;
        }

        private SorterServiceConfig Config
        {
            get => _configurationManager.GetConfig<SorterServiceConfig>();
            set => _configurationManager.SaveConfig(value);
        }

        public void Start()
        {
            
            StartDelayedActionActivity();
        }

        

        public void Stop()
        {
            StopActionDelayActivity();
        }
        

        private void StartDelayedActionActivity()
        {
            _actionDelayTimer = new Timer(100);
            _actionDelayTimer.Elapsed += ExecuteActionDelay;
            _actionDelayTimer.Start();
        }

        private void ExecuteActionDelay(object sender, ElapsedEventArgs e)
        {
            _actionDelayTimer.Stop();
            foreach (var delaygroup in _actionDelayGroup.Values)
            {
                if (delaygroup.Count == 0)
                {
                    continue;
                }
                var actionDelays = delaygroup.Where(ad=>ad.ExecutionTime <= DateTime.Now).ToList();
                if(actionDelays.Count()==0)
                {
                    continue;
                }
                foreach(var actionDelay in actionDelays)
                {
                    delaygroup.Remove(actionDelay);
                    actionDelay.ManualAction.ExecuteManual(actionDelay.ActionConfig);
                }                              
            }
            _actionDelayTimer.Start();
        }
        private void StopActionDelayActivity()
        {
            _actionDelayTimer.Stop();
            _actionDelayTimer.Elapsed -= ExecuteActionDelay;
            _actionDelayTimer.Dispose();
        }

        public void AddActionDelay(string delayGroup, IManualAction manualAction, ActionConfig actionConfig, int delay)
        {

            if (!_actionDelayGroup.ContainsKey(delayGroup))
            {
                _actionDelayGroup.TryAdd(delayGroup, new List<ActionDelay>());
            }

            var lastExecutionTime = _actionDelayGroup[delayGroup].Count > 0
                                    ? _actionDelayGroup[delayGroup].Max(ad => ad.ExecutionTime)
                                    : DateTime.Now;

            _actionDelayGroup[delayGroup].Add(new ActionDelay { ManualAction = manualAction, ActionConfig= actionConfig, ExecutionTime = lastExecutionTime.AddMilliseconds(delay) });
        }

        private class ActionDelay
        {
            public IManualAction ManualAction { get; set; }
            public ActionConfig ActionConfig { get; set; }
            public DateTime ExecutionTime  { get; set; }
        }        
    }
}
