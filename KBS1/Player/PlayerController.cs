using System.Windows.Input;
using KBS1.Misc;
using KBS1.Windows;

namespace KBS1.Player
{
    class PlayerController : Controller.Controller
    {
        private const double Speed = 2.0;

        public KBS1.Player.Player Player { get; }

        public PlayerController(KBS1.Player.Player player) : base(player)
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

            //if (Keyboard.IsKeyDown(Key.LeftShift))
            //    speed = 10;

            // Lets the player noclip when NumPad 0 is pressed
            Object.Collider.Blocking = !Keyboard.IsKeyDown(Key.NumPad0);

            Move(direction.Normalize(Speed));
        }
    }
}