using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.configuration
{
    public static class ConfigurationManager
    {
        private static readonly ILog Log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static ConcurrentDictionary<string,object> _configurations = new ConcurrentDictionary<string, object>();

        public static T GetConfig<T>() where T : class
        {
            return GetConfig<T>(new []{typeof(T)});
        }
        public static T GetConfig<T>(Type[] extraTypes) where T : class
        {
            return FindConfig<T>() ?? LoadConfig<T>(extraTypes);
        }
        private static T FindConfig<T>() where T : class
        {
            _configurations.TryGetValue(GetFileName<T>(), out var configuration);
            return (T)configuration;
        }
        private static T LoadConfig<T>(Type[] extraTypes) where T : class
        {
            var filename = GetFileName<T>();
            var config = Load<T>(filename, extraTypes);
            _configurations.TryAdd(filename, config);
            return config;
        }

        public static void SaveConfig<T>(T config) where T : class
        {

            SaveConfig(config, new[] { typeof(T) });
        }
        public static void SaveConfig<T>(T config, Type[] extraTypes) where T : class
        {
            _configurations.AddOrUpdate(GetFileName<T>(), key => config, (key, oldConfig) => config);
            Save(config, GetFileName<T>(), extraTypes);
        }

        private static T Load<T>(string filename, Type[] extraTypes)
        {
            try
            {
                T instance = (T)Activator.CreateInstance(typeof(T));

                String dirPath = Path.GetDirectoryName(filename);

                XmlSerializer ser = new XmlSerializer(typeof(T), extraTypes);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                if (!File.Exists(filename))
                {
                    //DefaultValues
                    //Preubo a guarda
                    Save<T>(instance, filename, extraTypes);
                    return instance;


                }
                else
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(filename))
                        {
                            XmlReader xml = XmlReader.Create(sr);
                            if (ser.CanDeserialize(xml))
                            {
                                instance = (T)ser.Deserialize(xml);
                                return instance;
                            }
                        }
                        return instance;
                    }
                    catch(Exception e)
                    {
                        Log.Error($"Error while loading {filename}", e);
                        return instance;
                    }
                }
            }
            catch 
            {
                return default(T);
            }
        }
        public static bool Save<T>(T value, string filename, Type[] extraTypes)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T), extraTypes);
                if (!Directory.Exists(Path.GetDirectoryName(filename)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    using (StreamWriter sw = new StreamWriter(ms))
                    {

                        ser.Serialize(sw, value);
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            ms.WriteTo(fs);
                        }
                    }
                    return true;
                }

            }
            catch (Exception ex)
            {
                Exception x = new Exception("ConfigurationManager cannot be saved", ex);
                throw x;
            }
        }

        public static string GetFileName<T>()
        {
            return $"./Config/{typeof(T).Name}.config";
        }
        public static T Deserialize<T>(string xml, Type[] extraTypes)
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
        public static string Serialize<T>(T value, Type[] extraTypes) where T : class
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
