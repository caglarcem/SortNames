using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace SortNames.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = ConfigurationManager.AppSettings["DefaultSourceFile"];
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]) && Path.IsPathRooted(inputFilePath))
            {
                inputFilePath = args[0];
            }
            
            var sortedFilePath = Path.GetDirectoryName(inputFilePath) + "\\"  + Path.GetFileNameWithoutExtension(inputFilePath) + "-sorted" 
                                    + Path.GetExtension(inputFilePath);
            try
            {
                    var nameSortManager = new NameSortManager(new NameReader(new FileHandler(inputFilePath))
                                                            , new NameWriter(new FileHandler(sortedFilePath))
                                                            , new NameSorter());
                    var nameList = nameSortManager.ReadItems();
                    if (nameList.Any())
                    {
                        var sortedList = nameSortManager.Sort(nameList).ToList();
                        nameSortManager.WriteItems( sortedList);
                        
                        // console output
                        foreach (var name in sortedList) Console.WriteLine(name.First + ConfigurationManager.AppSettings["Separator"] + " " + name.Last);
                        Console.WriteLine("Finished: created " + Path.GetFileNameWithoutExtension(inputFilePath) + "-sorted" + Path.GetExtension(inputFilePath));
                    }
                    else
                    {
                        Console.WriteLine("Source file does not contain any names.");
                    }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please check the source file exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex.Message);
            }

            Console.Write("Press any key to terminate...");
            Console.ReadKey();
        }
    }
}
