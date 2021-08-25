using System;
using System.IO;

namespace CSVCreator
{
    class Program
    {
        static string csvLOC = "";
        static string csvName = "DirIndex.csv";
        static string line = "";
        static int count = 0;
        static void Main(string[] args)
        {
            Console.Write("Please input the csv save point (Do not include a file just directory): ");
            csvLOC = Console.ReadLine();
            
            Console.Write("Please input the start point (DO NOT INCLUDE \\): ");
            string path = Console.ReadLine();
            DirectoryInfo start = new DirectoryInfo(path);
            DirSearch(start);
            Console.WriteLine($"Saving file to {csvLOC}\\{csvName}...");
            File.WriteAllText($"{csvLOC}\\{csvName}", line);
            Console.WriteLine($"File Saved To: {csvLOC}\\{csvName}... Press any key to exit");
            Console.ReadKey();
        }

        private static void DirSearch(DirectoryInfo source)
        {
            count++;
            Console.WriteLine($"Directory Count: {count}");
            line += $"\n{source.FullName}";
            try
            {
                foreach (FileInfo file in source.GetFiles())
                    line += $",{file.Name}";
            
            foreach (DirectoryInfo dir in source.GetDirectories())
                DirSearch(dir);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Access Forbidden! {source.FullName}");
            }
        }
    }
}
