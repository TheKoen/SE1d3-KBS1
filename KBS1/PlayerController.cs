using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void KeyPress(EventArgs args)
        {
            //if (*klikt op pijltje omhoog*)
            //{
            //    beweegVooruit();
            //}
        }

    }
}
