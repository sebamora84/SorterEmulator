﻿using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private readonly IMessageService _messageService;

        private Timer _addTrayTimer;
        private Timer _multiRemoteControlTimer;

        private readonly Dictionary<string, Queue<RemoteControlParcel>> _multiRemoteControlParcels= new Dictionary<string, Queue<RemoteControlParcel>>();

        public SorterService(
            ILogger<SorterService> logger, 
            IConfigurationManager configurationManager, 
            IPhysicsService physicsService,
            IParcelService parcelService, 
            INodesService nodesService, 
            IMessageService messageService)
        {
            _logger = logger;
            _configurationManager = configurationManager;
            _physicsService = physicsService;
            _parcelService = parcelService;
            _nodesService = nodesService;
            _messageService = messageService;
        }

        private SorterServiceConfig Config
        {
            get => _configurationManager.GetConfig<SorterServiceConfig>();
            set => _configurationManager.SaveConfig(value);
        }

        public void Start()
        {
            
            StartTraysActivity();
            StartMultiRemoteControlActivity();
        }

        

        public void Stop()
        {
            StopTraysActivity();
            StopMultiRemoteControlActivity();
        }
        

        private void StartTraysActivity()
        {
            _addTrayTimer = new Timer(5000);
            _addTrayTimer.Elapsed += AddTrayTimerElapsed;
        }

        private void AddTrayTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var node = _nodesService.GetNode(Config.TraysNode);
            var parcel = _parcelService.AddNewParcel(node);
            _physicsService.AddTracking(parcel.Pic,node.Id, 0);
        }
        private void StopTraysActivity()
        {
            _addTrayTimer.Stop();
            _addTrayTimer.Elapsed -= AddTrayTimerElapsed;
            _addTrayTimer.Dispose();
        }
        public void StartAddTray()
        {
            _addTrayTimer.Start();
        }

        public void StopAddTray()
        {
           _addTrayTimer.Stop();
        }

        private void StartMultiRemoteControlActivity()
        {
            _multiRemoteControlTimer = new Timer(1000);
            _multiRemoteControlTimer.Elapsed += SendMultiRemoteControlTimerElapsed;
            _multiRemoteControlTimer.Start();
        }

        private void StopMultiRemoteControlActivity()
        {
            _multiRemoteControlTimer.Stop();
        }

        private void SendMultiRemoteControlTimerElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var multiRemoteControl in _multiRemoteControlParcels)
            {
                if(multiRemoteControl.Value.Count==0)
                    continue;

                var multiName = multiRemoteControl.Key;
                var remoteControlParcel = multiRemoteControl.Value.Peek();

                if (!remoteControlParcel.Active && remoteControlParcel.Updated.AddSeconds(remoteControlParcel.ActivateDelay) < DateTime.Now)
                {
                    var message = $"CC|       {multiName}|attrval|        active|Y|3F";
                    Task.Run(() => _messageService.SendMessage(message));
                    remoteControlParcel.Active = true;
                    remoteControlParcel.Updated=DateTime.Now;
                }
                else if (remoteControlParcel.Active && remoteControlParcel.Updated.AddSeconds(remoteControlParcel.DeactivateDelay) < DateTime.Now)
                {
                    var message = $"CC|       {multiName}|attrval|        active|N|3F";
                    Task.Run(() => _messageService.SendMessage(message));
                    remoteControlParcel.Active = false;
                    remoteControlParcel.Updated = DateTime.Now;

                    multiRemoteControl.Value.Dequeue();
                    _parcelService.RemoveParcel(remoteControlParcel.Pic);
                    _physicsService.RemoveTrackingByPic(remoteControlParcel.Pic);
                }
            }
        }

        public void AddMultiRemoteControl(string multiName, int pic, int activateDelay, int deactivateDelay)
        {
            if (!_multiRemoteControlParcels.ContainsKey(multiName))
            {
                _multiRemoteControlParcels.Add(multiName,new Queue<RemoteControlParcel>());
            }
            _multiRemoteControlParcels[multiName].Enqueue(
                new RemoteControlParcel()
                {
                    Pic = pic,
                    Active = false,
                    ActivateDelay = activateDelay,
                    DeactivateDelay = deactivateDelay,
                    Updated = DateTime.Now,
                });
        }

        private class RemoteControlParcel
        {
            public int Pic { get; set; }
            public bool Active  { get; set; }
            public int ActivateDelay { get; set; }
            public int DeactivateDelay { get; set; }
            public DateTime Updated { get; set; }

        }

    }

    
}