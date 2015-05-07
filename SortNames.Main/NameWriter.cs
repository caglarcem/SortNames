using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SortNames.Core;

namespace SortNames.Main
{
    public class NameWriter : INameWriter
    {
        private readonly IFileHandler fileHandler;

        public NameWriter(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
        }

        /// <summary>
        /// Writes to the file.
        /// </summary>
        /// <param name="itemsList"></param>
        /// <returns>The lines written as a string list</returns>
        public IEnumerable<string> WriteItems(IEnumerable<Name> itemsList)
        {
            var names = itemsList.Select(name => name.First + ConfigurationManager.AppSettings["Separator"] + " " + name.Last).ToList();

            fileHandler.WriteAllLines(names);

            return names;
        }
    }
}
