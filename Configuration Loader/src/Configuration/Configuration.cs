using System.Collections;
using System.Text;

namespace ConfigurationLoader
{
    public class Configuration
    {
        public Hashtable Params { get; private set; }

        private void ForEachOne(IConfigurationSource collection)
        {
            foreach(DictionaryEntry i in collection.LoadedData)
                try {
                    Params.Add(i.Key, i.Value);
                } catch {}
        }

        public Configuration(IConfigurationSource collection) 
        {
            Params = new Hashtable();
            ForEachOne(collection);
        }

        public Configuration(IConfigurationSource collection1, IConfigurationSource collection2) 
        {
            Params = new Hashtable();
            if (collection1.Priority >= collection2.Priority) { 
                ForEachOne(collection1);
                ForEachOne(collection2);
            } else {
                ForEachOne(collection2);
                ForEachOne(collection1);
            }
        }

        public override string ToString() {
            var config = new StringBuilder("Configuration\n");
            foreach (DictionaryEntry e in Params)
                    config.Append($"{e.Key}: {e.Value}\n");
            return config.ToString();
        }
    }
}
