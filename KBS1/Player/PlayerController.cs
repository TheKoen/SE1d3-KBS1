using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using KBS1.Misc;
using KBS1.Util;
using KBS1.Windows;

namespace KBS1.Player
{
    class PlayerController : Controller.Controller
    {
        private const double Speed = 2.0;

        private readonly Image right = ResourceManager.Instance.LoadImage("player.png");
        private readonly Image left = ResourceManager.Instance.LoadImage("playerflipped.png");

        public Player Player { get; }

        public PlayerController(Player player) : base(player)
        //minecraft mode
        private int minecraftMode = 0;
        public static bool minecraftModeActivated = false;
        public event System.EventHandler MinecraftMode;

        public void Subscribe(System.EventHandler source)
        {
            MinecraftMode += source;
        }


        public PlayerController(KBS1.Player.Player player) : base(player)
        {
            Player = player;
        }

        /// <summary>
        /// Controller of the <see cref="Player"/> is executed every game tick
        /// </summary>
        public override void Update()
        {
            var direction = new Vector();

            if (Keyboard.IsKeyDown(OptionMenu.Pause)) GameWindow.Instance.PauseGame();
            if (Keyboard.IsKeyDown(OptionMenu.Retry)) GameWindow.Instance.Reset();

            if (Keyboard.IsKeyDown(OptionMenu.Up)) direction.Y = -1;
            if (Keyboard.IsKeyDown(OptionMenu.Right)) direction.X = 1;
            if (Keyboard.IsKeyDown(OptionMenu.Down)) direction.Y = 1;
            if (Keyboard.IsKeyDown(OptionMenu.Left)) direction.X = -1;

            if (Math.Abs(direction.X - 1) < 0.01)
                Object.Renderer.ChangeSprite((BitmapImage) right.Source);
            else if (Math.Abs(direction.X - (-1)) < 0.01)
                Object.Renderer.ChangeSprite((BitmapImage) left.Source);

            // Minecraft EasterEgg
            CheckMinecraftMode();
            
            
           
            // Lets the player noclip when NumPad 0 is pressed
            Object.Collider.Blocking = !Keyboard.IsKeyDown(Key.NumPad0);

            Move(direction.Normalize(Speed));
        }

        //Minecraft EasterEgg
        public void CheckMinecraftMode()
        {
            if (Keyboard.IsKeyDown(Key.M))
            {
                minecraftMode++;

            }
            else if (Keyboard.IsKeyDown(Key.I) && minecraftMode == 1)
            {
                minecraftMode++;
            }
            else if (Keyboard.IsKeyDown(Key.N) && minecraftMode == 2)
            {
                minecraftMode++;
            }
            else if (Keyboard.IsKeyDown(Key.E) && minecraftMode == 3)
            {
                minecraftMode++;
            }
            else if (Keyboard.IsKeyDown(Key.C) && minecraftMode == 4)
            {
                minecraftMode++;
            }
            else if (Keyboard.IsKeyDown(Key.R) && minecraftMode == 5)
            {
                minecraftMode++;
            }
            else if (Keyboard.IsKeyDown(Key.A) && minecraftMode == 6)
            {
                minecraftMode++;
            }
            else if (Keyboard.IsKeyDown(Key.F) && minecraftMode == 7)
            {
                minecraftMode++;
            }
            else if (Keyboard.IsKeyDown(Key.T) && minecraftMode == 8)
            {
                MinecraftMode(this, System.EventArgs.Empty);
            }
        }
    }
}