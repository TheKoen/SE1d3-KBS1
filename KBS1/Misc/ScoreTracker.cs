using System;
using KBS1.Util;

namespace KBS1.Misc
{
    public class ScoreTracker
    {
        public double SecondsRunning { get; private set; }
        public int Ticks { get; set; }

        public ScoreTracker()
        {
            InstanceHelper.GetGameLoop().Subscribe(Update);
        }

        /// <summary>
        /// Method called every gameTick eddits the the score of the level
        /// </summary>
        public void Update()
        {
            ++Ticks;
            SecondsRunning = GetSeconds();
            InstanceHelper.GetCurrentLevel().UpdateScore();
        }


        /// <summary>
        /// Calulates the elapsed amount of seconds of the game
        /// </summary>
        /// <returns>seconds in double</returns>
        public double GetSeconds()
        {
            return Math.Round(Ticks / 100.0, 2);
        }

        public double PublishScore(double score, string name)
        {
            return score;
        }
    }
}