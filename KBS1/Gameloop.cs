using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Threading;

namespace KBS1
{
    public class Gameloop
    {
        private GameWindow Game { get; }
        private DispatcherTimer Timer { get; }

        public Gameloop(GameWindow game)
        {
            Game = game;
            Timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 10)};
            Timer.Tick += Update;
        }

        /// <summary>
        /// Starts the game loop
        /// </summary>
        public void Start()
        {
            var level = Game.Loadedlevel;
            foreach (var gameObject in level.Objects)
                gameObject.Init();
            Timer.Start();
        }

        /// <summary>
        /// Stops the game loop
        /// </summary>
        public void Stop()
        {
            Timer.Stop();
        }
        
        private void Update(object sender, EventArgs args)
        {
            var level = Game.Loadedlevel;
            foreach (var gameObject in level.Objects)
            {
                gameObject.Controller?.Update();
                gameObject.Renderer?.Update();
                level.score.Update();
            }
        }
    }
}
