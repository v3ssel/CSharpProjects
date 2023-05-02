using System.Collections;
using System.Text.Json;

namespace ConfigurationLoader
{
    class JsonSource : IConfigurationSource
    {
        public int Priority { get; private set; }

        public Hashtable LoadedData { get; set; }

        public void LoadData(string file)
        {
            LoadedData = JsonDocument.Parse(new StreamReader(file).BaseStream).Deserialize<Hashtable>()!;
        }

        public JsonSource(string file, int priority)
        {
            LoadedData = new Hashtable();
            Priority = priority;
            this.LoadData(file);
        }
    }
}
