using System.Collections;

namespace ConfigurationLoader
{
    class EnvSource : IConfigurationSource
    {
        public int Priority { get; private set; }

        public Hashtable LoadedData { get; set; }

        public void LoadData(string var)
        {
            LoadedData.Add(var, Environment.GetEnvironmentVariable(var));
            Priority = 0;
        }

        public EnvSource(string var)
        {
            LoadedData = new Hashtable();
            this.LoadData(var);
        }
    }
}