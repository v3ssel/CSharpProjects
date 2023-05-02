using System.Collections;

namespace ConfigurationLoader
{
    public interface IConfigurationSource
    {
        int Priority { get; }

        Hashtable LoadedData { get; set; }
        
        void LoadData(string file);
    }
}