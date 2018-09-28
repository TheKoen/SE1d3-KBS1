using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    class PlayerController : Controller
    {
        public Player Player { get; set; }

        public PlayerController(Player player, ILocatable locatable) : base(locatable)
        {
            Player = player;
        }
    }
}
