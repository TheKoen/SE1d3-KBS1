using System;
using System.Windows.Threading;
using KBS1.Util;

namespace KBS1.LevelComponents
{
    public delegate void Update();

    public class Gameloop
    {
        private DispatcherTimer Timer { get; }
        private event Update UpdateEvent;

        public Gameloop()
        {
            Timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 9)
            };
            Timer.Tick += Update;
        }

        /// <summary>
        /// Starts the game loop
        /// </summary>
        public void Start()
        {
            Timer.Start();
        }

        /// <summary>
        /// Stops the game loop
        /// </summary>
        public void Stop()
        {
            Timer.Stop();
        }

        public void Subscribe(Update updateEvent)
        {
            UpdateEvent += updateEvent;
        }

        public void Unsubscribe(Update updateEvent)
        {
            UpdateEvent -= updateEvent;
        }

        private void Update(object sender, EventArgs args)
        {
            try
            {
                UpdateEvent?.Invoke();
            }
            catch (Exception e)
            {
                ExceptionManager.Catch(e);
            }
        }
    }
}