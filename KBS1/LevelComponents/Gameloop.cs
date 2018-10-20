using System;
using System.Windows.Threading;
using KBS1.Util;

namespace KBS1.LevelComponents
{
    public delegate void Update();

    public class Gameloop
    {
        /// <summary>
        ///     Gameloop is used to recall methodes every gametick
        /// </summary>
        public Gameloop()
        {
            Timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 9)
            };
            Timer.Tick += Update;
        }

        private DispatcherTimer Timer { get; }
        private event Update UpdateEvent;

        /// <summary>
        ///     Starts the game loop
        /// </summary>
        public void Start()
        {
            Timer.Start();
        }

        /// <summary>
        ///     Stops the game loop
        /// </summary>
        public void Stop()
        {
            Timer.Stop();
        }

        /// <summary>
        ///     Subscribe to the gametick
        /// </summary>
        /// <param name="updateEvent"></param>
        public void Subscribe(Update updateEvent)
        {
            UpdateEvent += updateEvent;
        }

        /// <summary>
        ///     Unsubscribe to the gametick
        /// </summary>
        /// <param name="updateEvent"></param>
        public void Unsubscribe(Update updateEvent)
        {
            UpdateEvent -= updateEvent;
        }

        /// <summary>
        ///     calling the event UpdateEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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