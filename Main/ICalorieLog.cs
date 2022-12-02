using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public interface ICalorieLog
    {

        /// <summary>
        /// Reads the file into the CalorieLedger.
        /// </summary>
        void ReadFile();

        /// <summary>
        /// The list of elves that have their calories tracked.
        /// </summary>
        List<Elf> CalorieLedger { get; }

        /// <summary>
        /// The object that reads the file.
        /// </summary>
        IFileReader FileReader { get; }

        /// <summary>
        /// Calculates the total calories of the elf that has the most.
        /// </summary>
        /// <returns>The total calories of the elf that has the most.</returns>
        int CalculateMostCalorieElfTotal();

        /// <summary>
        /// Calculates the total calories of the top three elves (by how many calories they have).
        /// </summary>
        /// <returns>The total calories of the three elves that have the most.</returns>
        int CalculateTop3CalorieElfTotal();
    }
}
