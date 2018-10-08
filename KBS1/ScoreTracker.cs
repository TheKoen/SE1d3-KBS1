using System;

namespace KBS1
{
    public class ScoreTracker
    {
        public double SecondsRunning;
        public int Ticks;
        private Level level;

        public ScoreTracker(Level l)
        {
            this.level = l;
        }

        public void Update()
        {
            Ticks++;
            SecondsRunning = GetSeconds();
            GameWindow.Instance.Loadedlevel.UpdateScore(SecondsRunning);
        }

        private double GetSeconds()
        {
            return Math.Round(Ticks / 100.0, 2);
        }
    }
}
