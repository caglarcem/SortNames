using System.Collections.Generic;
using System.IO;
using SortNames.Core;

namespace SortNames.Main
{
    /// <summary>
    /// Implements System.IO methods. It is a wrapper for enabling unit testing.
    /// </summary>
    class FileHandler : IFileHandler
    {
        private readonly string filePath;

        public FileHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<string> ReadAllLines()
        {
            return File.ReadLines(filePath);
        }

        public void WriteAllLines(IEnumerable<string> lines)
        {
            File.WriteAllLines(filePath, lines);
        }
    }
}
