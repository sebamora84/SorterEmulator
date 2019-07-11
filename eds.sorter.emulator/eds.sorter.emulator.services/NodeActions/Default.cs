﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.NodeActions.Base;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using log4net;

namespace eds.sorter.emulator.services.NodeActions
{
    public class Default: INodeAction
    {
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool Execute(Tracking tracking, NodeActionConfig nodeActionConfig)
        {
            return true;
        }
    }
}
