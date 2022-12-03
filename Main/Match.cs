using System;
namespace Main
{
    public class Match : IMatch
    {
        public Match(RockPaperScissorsOptions opponentPlay, RockPaperScissorsOptions myPlay)
        {
            OpponentPlay = opponentPlay;
            MyPlay = myPlay;
        }

        public RockPaperScissorsOptions OpponentPlay { get; private set; }

        public RockPaperScissorsOptions MyPlay { get; private set; }

        public int CalculateMyScore()
        {
            int winScore = 6;
            int drawScore = 3;
            int loseScore = 0;
            int myPlayScore = (int)MyPlay;

            var result = CalculateResults();
            if (result == MatchResults.Win)
            {
                return myPlayScore + winScore;
            }
            else if (result == MatchResults.Draw)
            {
                return myPlayScore + drawScore;
            }
            else
            {
                return myPlayScore + loseScore;
            }
        }

        private MatchResults CalculateResults()
        {
            if (OpponentPlay == MyPlay)
            {
                return MatchResults.Draw;
            }

            if (OpponentPlay == RockPaperScissorsOptions.Rock
                && MyPlay == RockPaperScissorsOptions.Scissors)
            {
                return MatchResults.Lose;
            }

            if (OpponentPlay == RockPaperScissorsOptions.Rock
                && MyPlay == RockPaperScissorsOptions.Paper)
            {
                return MatchResults.Win;
            }

            if (OpponentPlay == RockPaperScissorsOptions.Paper
                && MyPlay == RockPaperScissorsOptions.Rock)
            {
                return MatchResults.Lose;
            }

            if (OpponentPlay == RockPaperScissorsOptions.Paper
                && MyPlay == RockPaperScissorsOptions.Scissors)
            {
                return MatchResults.Win;
            }

            if (OpponentPlay == RockPaperScissorsOptions.Scissors
                && MyPlay == RockPaperScissorsOptions.Rock)
            {
                return MatchResults.Win;
            }

            // opponent is scissors
            // my play is paper
            return MatchResults.Lose;
        }

    }
}

