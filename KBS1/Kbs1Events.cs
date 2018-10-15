using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    class Kbs1Events
    {
        /**
         * MINECRAFT EASTEREGG EVENT
         */
        static private event EventHandler MinecraftMode;


        static public void SubScribeMinecraftMode(EventHandler methode)
        {
            MinecraftMode += methode;
        }

        public void TriggerMinecraftMode()
        {
            MinecraftMode?.Invoke(this, EventArgs.Empty);
        }
    }
}