using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class CalorieLog : ICalorieLog
    {
        public CalorieLog(IFileReader fileReader)
        {
            FileReader = fileReader;
        }

        /// <inheritdoc/>
        public List<Elf> CalorieLedger => throw new NotImplementedException();

        /// <inheritdoc/>
        public IFileReader FileReader { get; internal set; }

        /// <inheritdoc/>
        public void ReadFile()
        {
            FileReader.ReadLines();
        }
    }
}
