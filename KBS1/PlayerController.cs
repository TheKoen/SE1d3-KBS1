using System.Windows.Input;

namespace KBS1
{
    /// <summary>
    /// PlayerController extends the Controller
    /// </summary>
    class PlayerController : Controller
    {
        private const double SPEED = 2.0;

        public Player Player { get; }

        /// <summary>
        /// extends the base class Controller
        /// </summary>
        /// <param name="player">sets the prop player</param>
        public PlayerController(Player player) : base(player)
        {
            Player = player;
        }
        
        /// <summary>
        /// Controller of the player is executed every game tick.
        /// </summary>
        public override void Update()
        {
            var direction = new Vector();

            if (Keyboard.IsKeyDown(Key.W)) direction.Y = -1;
            if (Keyboard.IsKeyDown(Key.D)) direction.X = 1;
            if (Keyboard.IsKeyDown(Key.S)) direction.Y = 1;
            if (Keyboard.IsKeyDown(Key.A)) direction.X = -1;

            if (Keyboard.IsKeyDown(Key.Escape)) GameWindow.Instance.PauseGame();

            var speed = SPEED;

            //if (Keyboard.IsKeyDown(Key.LeftShift))
            //    speed = 10;

            Object.Collider.Blocking = !Keyboard.IsKeyDown(Key.NumPad0);

            Move(direction.Normalize(speed));
        }
    }
}