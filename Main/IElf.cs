using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public interface IElf
    {
        /// <summary>
        /// Adds the provided calorie amount to the calorie list.
        /// </summary>
        /// <param name="calorieAmount">Amount to add to the calorie list.</param>
        void AddCalorie(int calorieAmount);

        /// <summary>
        /// The list of calories this elf has.
        /// </summary>
        List<int> Calories { get; }

        /// <summary>
        /// Calculates the total number of calories this elf has.
        /// </summary>
        /// <returns>The calorie total.</returns>
        int CalculateCalorieTotal();
    }
}
