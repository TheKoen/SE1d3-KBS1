using System.Windows.Input;

namespace KBS1
{
    class PlayerController : Controller
    {
        private const double Speed = 2.0;

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

            if (Keyboard.IsKeyDown(Key.Escape)) GameWindow.Instance.PauseGame();
            
            if (Keyboard.IsKeyDown(Key.W)) direction.Y = -1;
            if (Keyboard.IsKeyDown(Key.D)) direction.X = 1;
            if (Keyboard.IsKeyDown(Key.S)) direction.Y = 1;
            if (Keyboard.IsKeyDown(Key.A)) direction.X = -1;

            //if (Keyboard.IsKeyDown(Key.LeftShift))
            //    speed = 10;

            // Lets the player noclip when NumPad 0 is pressed
            Object.Collider.Blocking = !Keyboard.IsKeyDown(Key.NumPad0);

            Move(direction.Normalize(Speed));
        }
    }
}