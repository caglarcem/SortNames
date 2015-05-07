using System.Collections.Generic;
using System.Configuration;
using SortNames.Core;

namespace SortNames.Main
{
    public class NameReader : INameReader
    {
        private readonly IFileHandler fileHandler;

        public NameReader(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
        }

        /// <summary>
        /// Reads from file
        /// </summary>
        /// <returns>Name list</returns>
        public IEnumerable<Name> ReadItems()
        {
            List<Name> names = new List<Name>();
            var lines = fileHandler.ReadAllLines();
            
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    // split and construct name object
                    var result = line.Split(ConfigurationManager.AppSettings["Separator"].ToCharArray());

                    // one or more separator. Assume first and last items in case of middle name.
                    if (result.Length > 1) names.Add(new Name(result[0].Trim(), result[result.Length - 1].Trim()));                        
                    // this is just the name
                    else if (result.Length == 1) names.Add(new Name {First = result[0].Trim()});
                }
            }
            

            return names;
        }
    }
}
