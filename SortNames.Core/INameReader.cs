using System.Collections.Generic;

namespace SortNames.Core
{
    public interface INameReader
    {
        /// <summary>
        /// Reads from file
        /// </summary>
        /// <returns>Name list</returns>
        IEnumerable<Name> ReadItems();
    }
}
