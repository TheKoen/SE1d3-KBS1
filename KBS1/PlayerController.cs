using System.Windows.Input;

namespace KBS1
{
    class PlayerController : Controller
    {
        private const int SPEED = 10;

        public Player Player { get; }

        public PlayerController(Player player) : base(player)
        {
            this.Player = player;
        }

        //method for the player when pressed a key
        public void KeyPress(object sender, KeyEventArgs args)
        {
            var vector = new Vector();

            switch (args.Key)
            {
                case Key.W:
                    vector.Y -= SPEED;
                    break;
                case Key.D:
                    vector.X += SPEED;
                    break;
                case Key.S:
                    vector.Y += SPEED;
                    break;
                case Key.A:
                    vector.X -= SPEED;
                    break;
            }
            
            this.Move(vector);
        }

        public override void Update()
        {
            
        }
    }
}