using System.Collections.Generic;
using SortNames.Core;

namespace SortNames.Main
{
    /// <summary>
    /// Composition class for reader writer and sorter.
    /// </summary>
    public class NameSortManager
    {
        private readonly INameReader fileReader;
        private readonly INameWriter fileWriter;
        private readonly INameSorter nameSorter;

        public NameSortManager(INameReader fileReader, INameWriter fileWriter, INameSorter nameSorter)
        {
            this.fileReader = fileReader;
            this.fileWriter = fileWriter;
            this.nameSorter = nameSorter;
        }

        public IEnumerable<Name> ReadItems()
        {
            return fileReader.ReadItems();
        }

        public IEnumerable<Name> Sort(IEnumerable<Name> names)
        {
            return nameSorter.Sort(names);
        }

        public IEnumerable<string> WriteItems(IEnumerable<Name> itemsList)
        {
            return fileWriter.WriteItems(itemsList);
        }
    }
}
