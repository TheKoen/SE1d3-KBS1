using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    /// <summary>
    /// creeper is a gameobject that explodes and follows you
    /// </summary>
    class Creeper : GameObject
    {
        

        public Creeper()
        {
            //creeper moet een controller createn createController();
        }

        protected override Controller createController()
        {
            throw new NotImplementedException();
        }
    }
}
