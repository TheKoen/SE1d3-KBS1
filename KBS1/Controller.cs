using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    class Controller
    {
        public ILocatable Locatable { get; set; }
        public GameObject Object { get; set; }

        public Controller(ILocatable locatable)
        {
            Locatable = locatable;
        }

        /// <summary>
        /// move the game object to Vector;
        /// </summary>
        /// <param name="vector">vector to move to</param>
        public void Move(Vector vector)
        {
            Locatable.Location.Add(vector);
        }

        public virtual void Update()
        {

        }
    }
}
