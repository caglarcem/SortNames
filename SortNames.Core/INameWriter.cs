using System.Collections.Generic;

namespace SortNames.Core
{
    public interface INameWriter
    {
        /// <summary>
        /// Writes to the file.
        /// </summary>
        /// <param name="itemsList"></param>
        /// <returns>The lines written as a string list</returns>
        IEnumerable<string> WriteItems(IEnumerable<Name> itemsList);
    }
}
