using System;
using System.Collections;
using ConfigurationLoader;

internal class Program
{
    private static void Main(string[] args)
    {
        try {
            if (args.Length == 4) {
                IConfigurationSource json = new JsonSource(args[0], int.Parse(args[1]));
                IConfigurationSource yaml = new YamlSource(args[2], int.Parse(args[3]));
                
                Configuration config = new Configuration(json, yaml);
                Console.WriteLine($"{config.ToString()}");
            } else if (args[0] == "env") {
                Environment.SetEnvironmentVariable("ENV_VAR", "TRUE");
                IConfigurationSource EnvInterface = new EnvSource("ENV_VAR");

                Configuration env_config = new Configuration(EnvInterface);
                Console.WriteLine($"{env_config.ToString()}");
            } else {
                IConfigurationSource DataInterface;
                if (args[0].Contains("json"))
                    DataInterface = new JsonSource(args[0], 0);
                else
                    DataInterface = new YamlSource(args[0], 0);

                Configuration config = new Configuration(DataInterface);
                Console.WriteLine($"{config.ToString()}");
            }
        } catch {
            Console.WriteLine("Invalid data. Check your input and try again.");
        }
    }
}
