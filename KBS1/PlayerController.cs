using System.Windows.Input;

namespace KBS1
{
    class PlayerController : Controller
    {
        private const int SPEED = 2;

        public Player Player { get; }

        public PlayerController(Player player) : base(player)
        {
            this.Player = player;
        }

        //method for the player when pressed a key
        public void KeyPress(object sender, KeyEventArgs args)
        {
            
        }

        public override void Update()
        {
            var vector = new Vector();

            int count = 0;
            if (Keyboard.IsKeyDown(Key.W))
            {
                count++;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                count++;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                count++;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                count++;
            }

            var speed = count > 1 ? SPEED / 2 : SPEED;

            if (Keyboard.IsKeyDown(Key.W))
            {
                vector.Y -= speed;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                vector.X += speed;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                vector.Y += speed;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                vector.X -= speed;
            }

            this.Move(vector);
        }
    }
}