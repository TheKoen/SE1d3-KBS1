using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KBS1
{
    class PlayerController : Controller
    {

        public Player player;

        public PlayerController(Player p)
        {
            this.player = p;
        }

        //method for the player when pressed a key
        public void KeyPress(KeyEventArgs args)
        {
            Vector vector = new Vector();

            if(args.Key == Key.W)
            {
                vector.Y -= 1;
            }
            if(args.Key == Key.D)
            {
                vector.X += 1;
            }
            if(args.Key == Key.S)
            {
                vector.Y += 1;
            }
            if(args.Key == Key.A)
            {
                vector.X -= 1;
            }
            //Controller.move(); zoiets
        }

    }
}
