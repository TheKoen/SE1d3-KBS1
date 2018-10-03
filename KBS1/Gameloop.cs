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
            this.Timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 10)};
            this.Timer.Tick += Update;
        }

        public void Start()
        {
            var level = this.Game.Loadedlevel;
            foreach (var gameObject in level.Objects)
            {
                gameObject.Init();
            }
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
                gameObject.Renderer?.Update();
                level.score.Update();
            }
        }
    }
}
