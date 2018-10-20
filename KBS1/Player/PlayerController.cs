using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using KBS1.Misc;
using KBS1.Util;
using KBS1.Windows;

namespace KBS1.Player
{
    internal class PlayerController : Controller.Controller
    {
        private const double Speed = 2.0;
        private readonly Image left = ResourceManager.Instance.LoadImage("#playerflipped.png");
        private readonly Image leftwalk = ResourceManager.Instance.LoadImage("#playerwalkflipped.png");

        private readonly Image right = ResourceManager.Instance.LoadImage("#player.png");
        private readonly Image rightwalk = ResourceManager.Instance.LoadImage("#playerwalk.png");
        private int step;

        private bool walk;

        public PlayerController(Player player) : base(player)
        {
            Player = player;
        }

        public Player Player { get; }

        /// <summary>
        ///     Controller of the <see cref="Player" /> is executed every game tick
        /// </summary>
        public override void Update()
        {
            var direction = new Vector();

            if (Keyboard.IsKeyDown(OptionMenu.Pause)) GameWindow.Instance.PauseGame();
            if (Keyboard.IsKeyDown(OptionMenu.Retry)) GameWindow.Instance.Reset();

            if (Keyboard.IsKeyDown(OptionMenu.Up)) direction.Y = -1;
            if (Keyboard.IsKeyDown(OptionMenu.Right)) direction.X = 1;
            if (Keyboard.IsKeyDown(OptionMenu.Down)) direction.Y = 1;
            if (Keyboard.IsKeyDown(OptionMenu.Left)) direction.X = -1;

            if (step < 10)
            {
                step++;
                if (step == 10)
                {
                    step = 0;
                    walk = !walk;
                }
            }

            if (Math.Abs(direction.X - 1) < 0.01)
                Object.Renderer.ChangeSprite(walk ? (BitmapImage) rightwalk.Source : (BitmapImage) right.Source);
            else if (Math.Abs(direction.X) > 0.01 || Math.Abs(direction.Y) > 0.01)
                Object.Renderer.ChangeSprite(walk ? (BitmapImage) leftwalk.Source : (BitmapImage) left.Source);

            // Lets the player noclip when NumPad 0 is pressed
            Object.Collider.Blocking = !Keyboard.IsKeyDown(Key.NumPad0);

            Move(direction.Normalize(Speed));
        }
    }
}