using System.IO;
using System.Collections;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace ConfigurationLoader
{
    class YamlSource : IConfigurationSource
    {
        public int Priority { get; private set; }

        public Hashtable LoadedData { get; set; }

        public void LoadData(string file)
        {
            var deserializer = new DeserializerBuilder().Build();
            LoadedData = deserializer.Deserialize<Hashtable>(new StreamReader(file));
        }

        public YamlSource(string file, int priority)
        {
            LoadedData = new Hashtable();
            Priority = priority;
            this.LoadData(file);
        }
    }
}