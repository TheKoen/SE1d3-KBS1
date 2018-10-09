using System;

namespace KBS1
{
    public class ScoreTracker
    {
        public Level Loadedlevel { get; set; }

        public double SecondsRunning;
        public int Ticks;
        private Level level;

        public ScoreTracker(Level l)
        {
            this.level = l;
        }

        /// <summary>
        /// Method called every gameTick eddits the the score of the level
        /// </summary>
        public void Update()
        {
            Ticks++;
            SecondsRunning = GetSeconds();
            GameWindow.Instance.Loadedlevel.UpdateScore(SecondsRunning);
        }

        
        /// <summary>
        /// calulates the seconds of the game
        /// </summary>
        /// <returns>seconds in double</returns>
        public double GetSeconds()
        {
            return Math.Round(Ticks / 100.0, 2);
        }

        public double PublishScore()
        {

            double score = Loadedlevel.Score.SecondsRunning + 0.01;
            return score;

        }
    }
}
