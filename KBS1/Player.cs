using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    class Player : GameObject
    {

        public Player player;

        //abstract method from abstract class GameObject to create a new Controller.
        protected override Controller createController()
        {
            return new PlayerController(player);
        }


    }
}
