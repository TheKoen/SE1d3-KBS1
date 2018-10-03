using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KBS1
{
    public class ScoreTracker
    {
        public double SecondsRunning;
        private int Ticks;
        private Level level;

        public ScoreTracker(Level l)
        {
            this.level = l;
        }

        public void Update()
        {
            Ticks++;
            SecondsRunning = GetSeconds();
            GameWindow.Current().Loadedlevel.UpdateScore(SecondsRunning);
        }

        private double GetSeconds()
        {
            return Math.Round(Ticks / 425.0, 2);
        }
    }
}
