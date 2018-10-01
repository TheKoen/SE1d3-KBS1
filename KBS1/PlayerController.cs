using System.Windows.Input;

namespace KBS1
{
    class PlayerController : Controller
    {
        public Player Player { get; }

        public PlayerController(Player player) : base(player)
        {
            this.Player = player;
        }

        //method for the player when pressed a key
        public void KeyPress(KeyEventArgs args)
        {
            var vector = new Vector();

            switch (args.Key)
            {
                case Key.W:
                    vector.Y -= 1;
                    break;
                case Key.D:
                    vector.X += 1;
                    break;
                case Key.S:
                    vector.Y += 1;
                    break;
                case Key.A:
                    vector.X -= 1;
                    break;
            }

            this.Move(vector);
        }

        public override void Update()
        {
            
        }
    }
}