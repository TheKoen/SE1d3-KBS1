using System;
using System.Windows.Threading;

namespace KBS1
{
    public class Gameloop
    {
        private GameWindow Game { get; }
        private DispatcherTimer Timer { get; }

        public Gameloop(GameWindow game)
        {
            this.Game = game;
            this.Timer = new DispatcherTimer();
            this.Timer.Tick += Update;
        }

        public void Start()
        {
            this.Timer.Start();
        }

        public void Stop()
        {
            this.Timer.Stop();
        }

        private void Update(object sender, EventArgs args)
        {
            var level = this.Game.Loadedlevel;
            foreach (var gameObject in level.Objects)
            {
                gameObject.Controller?.Update();
            }
        }
    }
}
