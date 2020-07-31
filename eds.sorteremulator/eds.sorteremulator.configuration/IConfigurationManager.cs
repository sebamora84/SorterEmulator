using System;

namespace eds.sorteremulator.configuration
{
    public interface IConfigurationManager
    {
        public T GetConfig<T>() where T : class;
        public void SaveConfig<T>(T config) where T : class;
    }
}