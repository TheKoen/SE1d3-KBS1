using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KBS1
{
    abstract class GameObject : ILocatable
    {
        public SpriteRenderer renderer;
        public Collider collider;
        public Controller controller;

        //When making a new GameObject, a new SpriteRenderer will be made with it.
        public GameObject()
        {
            SpriteRenderer renderer = new SpriteRenderer();
        }

        //abstract method for creating a new Controller for a GameObject depending on what kind of GameObject.
        protected abstract Controller createController();

        //method for .... canvas
        public void Init(Canvas canvas)
        {
        }





    }
}
