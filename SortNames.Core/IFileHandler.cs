using System.Collections.Generic;

namespace SortNames.Core
{
    /// <summary>
    /// File handling wrapper to enable mocking & unit testing
    /// </summary>
    public interface IFileHandler
    {
        IEnumerable<string> ReadAllLines();
        void WriteAllLines(IEnumerable<string> lines);
    }
}
