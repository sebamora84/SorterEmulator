﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Model;

namespace eds.sorteremulator.services.Extensions
{
    public static class NodeActionExtensions
    {
        public static T GetData<T>(this NodeActionConfig nodeActionConfig)
        {
            return (T) nodeActionConfig.Data;
        }
    }
}
