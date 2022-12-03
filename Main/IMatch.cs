using System;
namespace Main
{
    public interface IMatch
    {
        /// <summary>
        /// The play the opponent will play.
        /// </summary>
        RockPaperScissorsOptions OpponentPlay { get; }

        /// <summary>
        /// The play I should play.
        /// </summary>
        RockPaperScissorsOptions MyPlay { get; }

        /// <summary>
        /// Calculates how many points I received for the match.
        /// </summary>
        /// <returns>My score.</returns>
        int CalculateMyScore();
    }
}

