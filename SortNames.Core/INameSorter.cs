using System.Collections.Generic;

namespace SortNames.Core
{
    public interface INameSorter
    {
        IEnumerable<Name> Sort(IEnumerable<Name> names);
    }
}
