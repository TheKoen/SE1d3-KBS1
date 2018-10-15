using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using KBS1.Misc;
using KBS1.Util;
using KBS1.Windows;

namespace KBS1.Player
{
    class PlayerController : Controller.Controller
    {
        private const double Speed = 2.0;

        private readonly Image right = ResourceManager.Instance.LoadImage("player.png");
        private readonly Image left = ResourceManager.Instance.LoadImage("playerflipped.png");

        public Player Player { get; }

        public PlayerController(Player player) : base(player)
        {
            Player = player;
        }

        /// <summary>
        /// Controller of the <see cref="Player"/> is executed every game tick
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

            if (Math.Abs(direction.X - 1) < 0.01)
                Object.Renderer.ChangeSprite((BitmapImage) right.Source);
            else if (Math.Abs(direction.X - (-1)) < 0.01)
                Object.Renderer.ChangeSprite((BitmapImage) left.Source);

            // Lets the player noclip when NumPad 0 is pressed
            Object.Collider.Blocking = !Keyboard.IsKeyDown(Key.NumPad0);

            Move(direction.Normalize(Speed));
        }
    }
}