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
        public List<Elf> CalorieLedger { get; internal set; } = new List<Elf>();

        /// <inheritdoc/>
        public IFileReader FileReader { get; internal set; }

        /// <inheritdoc/>
        public int CalculateMostCalorieElfTotal()
        {
            var maxCalorieElfTotal = 0;
            foreach (Elf elf in CalorieLedger)
            {
                var total = elf.CalculateCalorieTotal();
                if (total > maxCalorieElfTotal)
                {
                    maxCalorieElfTotal = total;
                }
            }

            return maxCalorieElfTotal;
        }

        /// <inheritdoc/>
        public int CalculateTop3CalorieElfTotal()
        {
            var elfTotals = new List<int>();
            foreach (Elf elf in CalorieLedger)
            {
                var total = elf.CalculateCalorieTotal();
                elfTotals.Add(total);
            }

            elfTotals.Sort();

            var topThreeTotal =
                elfTotals[^1] + elfTotals[^2] + elfTotals[^3];

            return topThreeTotal;
        }

        /// <inheritdoc/>
        public void ReadFile()
        {
            var lines = FileReader.ReadLines();
            var inConstructionElfLedger = new List<int>();
            foreach (string line in lines)
            {
                if (line == string.Empty)
                {
                    var elf = new Elf
                    {
                        Calories = inConstructionElfLedger
                    };
                    inConstructionElfLedger = new List<int>();
                    CalorieLedger.Add(elf);
                }
                else
                {
                    inConstructionElfLedger.Add(int.Parse(line));
                }
            }
            if (inConstructionElfLedger.Count != 0)
            {
                var elf = new Elf
                {
                    Calories = inConstructionElfLedger
                };
                CalorieLedger.Add(elf);
            }
        }
    }
}
