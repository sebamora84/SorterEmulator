using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace eds.sorteremulator.configuration
{
    public  class ConfigurationManager : IConfigurationManager
    {
        private  ConcurrentDictionary<string,object> _configurations = new ConcurrentDictionary<string, object>();
        private readonly ILogger<ConfigurationManager> _logger;

        public ConfigurationManager(ILogger<ConfigurationManager>logger)
        {
            _logger = logger;
        }
       
        public  T GetConfig<T>() where T : class
        {
            return FindConfig<T>() ?? LoadConfig<T>();
        }
        private  T FindConfig<T>() where T : class
        {
            _configurations.TryGetValue(GetFileName<T>(), out var configuration);
            return (T)configuration;
        }
        private  T LoadConfig<T>() where T : class
        {
            var filename = GetFileName<T>();
            var config = Load<T>(filename);
            _configurations.TryAdd(filename, config);
            return config;
        }
        public  void SaveConfig<T>(T config) where T : class
        {
            _configurations.AddOrUpdate(GetFileName<T>(), key => config, (key, oldConfig) => config);
            Save(config, GetFileName<T>());
        }

        private  T Load<T>(string filename)
        {
            try
            {
                String dirPath = Path.GetDirectoryName(filename);
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                if (!File.Exists(filename))
                {
                    T instance = (T)Activator.CreateInstance(typeof(T));
                    Save<T>(instance, filename);
                }
                using (StreamReader file = File.OpenText(filename))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (T)serializer.Deserialize(file, typeof(T));
                }
            }
            catch
            {
                return default(T);
            }
        }
        private  bool Save<T>(T value, string filename)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filename)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                }
                using (StreamWriter file = File.CreateText(filename))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, value);
                }
                return true;
            }
            catch (Exception ex)
            {
                Exception x = new Exception("ConfigurationManager cannot be saved", ex);
                throw x;
            }
        }

        private  string GetFileName<T>()
        {
            return $"./Config/{typeof(T).Name}.config";
        }
        public  T Deserialize<T>(string xml, Type[] extraTypes)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T),extraTypes);
                var settings = new XmlReaderSettings();
                using (var textReader = new StringReader(xml))
                {
                    using (var xmlReader = XmlReader.Create(textReader, settings))
                    {
                        return (T)serializer.Deserialize(xmlReader);
                    }
                }
            }
            catch (Exception)
            {
                throw ;
            }
        }
        public  string Serialize<T>(T value, Type[] extraTypes) where T : class
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            emptyNamepsaces.Add("", "");

            var serializer = new XmlSerializer(typeof(T), extraTypes);
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamepsaces);
                return stream.ToString();
            }
        }
    }

}
