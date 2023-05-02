using System;
using System.Text.RegularExpressions;
using System.IO;

namespace LevensteinDistance
{
    public class Program
    {
        public static readonly string file_with_names = @"us.txt";

        public static void PrintAndOut(string msg)
        {
            Console.WriteLine(msg);
            System.Environment.Exit(0);
        }

        public static void GetNames(out HashSet<string> names)
        {
            if (!File.Exists(file_with_names))
                PrintAndOut(">Something went wrong. Check your input and retry.");

            names = new HashSet<string>();
            using (var stream = new StreamReader(file_with_names))
            {
                string? line;
                while ((line = stream.ReadLine()) != null) {
                    names.Add(line.ToLower());
                }
            }
        }

        public static void GetCorrectName(HashSet<string> names, string name)
        {
            foreach (var n in names)
            {
                var matrix = new int[name.Length + 1, n.Length + 1];

                for (var i = 0; i <= name.Length; matrix[i, 0] = i++) {}
                for (var i = 0; i <= n.Length; matrix[0, i] = i++) {}

                for (var i = 1; i <= name.Length; i++)
                {
                    for (var j = 1; j <= n.Length; j++)
                    {
                        var cost = (n[j - 1] == name[i - 1]) ? 0 : 1;

                        matrix[i, j] = Math.Min(
                            Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                            matrix[i - 1, j - 1] + cost
                        );
                    }
                }

                var distance = matrix[name.Length, n.Length];
                if (distance < 2)
                {
                    Console.WriteLine($">Did you mean “{n.Remove(1).ToUpper() + n.Substring(1)}”? Y/N");
                    
                    if (Console.ReadLine()!.ToLower() == "y")
                    {
                        PrintAndOut($">Hello, {n.Remove(1).ToUpper() + n.Substring(1)}!");
                        return;
                    }
                }
            }
            PrintAndOut(">Your name was not found.");
        }

        public static void Main() { 
            Console.WriteLine(">Enter name:");
            var name = Console.ReadLine();
            var regex = new Regex("^[a-zA-Z\\s-]+$");

            if (name == "")
                PrintAndOut(">Your name was not found.");

            if (name == null || !regex.IsMatch(name))
                PrintAndOut(">Something went wrong. Check your input and retry.");


            HashSet<string> names;
            GetNames(out names);
            name = name!.Trim().ToLower();

            if (names.Contains(name))
                PrintAndOut($">Hello, {name.Remove(1).ToUpper() + name.Substring(1)}!");
            else
                GetCorrectName(names, name);
        }
    }
}
