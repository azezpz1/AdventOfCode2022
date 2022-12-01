using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class FileReader : IFileReader
    {
        public FileReader(string path)
        {
            Path = path;
        }

        string Path { get; set; }
        
        IEnumerable<string> ReadLines() => File.ReadLines(Path);
    }
}
