using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    public class FinishController : Controller
    {
        private bool Finish { get; }

        public FinishController(GameObject gameObject, bool finish) : base(gameObject)
        {
            this.Finish = finish;
            this.Object.Collider.Blocking = false;
        }

        public override void Update()
        {
            if (!Finish)
            {
                return;
            }

            var player = FindPlayer();
            if (player.Collider.Collides(this.Object.Collider))
            {
                GameWindow.Current().Reset();
            }
        }
    }
}