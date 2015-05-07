using System.Collections.Generic;
using System.Linq;
using SortNames.Core;

namespace SortNames.Main 
{
    public class NameSorter: INameSorter
    {
        public IEnumerable<Name> Sort(IEnumerable<Name> names)
        {
            return names.OrderBy(n => n.First).ThenBy(n => n.Last).ToList();
        }
    }
}
