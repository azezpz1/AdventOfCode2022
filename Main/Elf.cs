using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Elf : IElf
    {
        /// <inheritdoc/>
        public List<int> Calories {get; internal set;} = new List<int>();

        /// <inheritdoc/>
        public void AddCalorie(int calorieAmount)
        {
            Calories.Add(calorieAmount);
        }

        /// <inheritdoc/>
        public int CalculateCalorieTotal()
        {
            return Calories.Sum();
        }
    }
}
