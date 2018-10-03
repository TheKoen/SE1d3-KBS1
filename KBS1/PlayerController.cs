using System;
using System.Windows.Input;

namespace KBS1
{
    class PlayerController : Controller
    {
        private const double SPEED = 1.5;

        public Player Player { get; }

        public PlayerController(Player player) : base(player)
        {
            this.Player = player;
        }

        public override void Update()
        {
            var direction = new Vector();

            if (Keyboard.IsKeyDown(Key.W))
            {
                direction.Y = -1;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                direction.X = 1;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                direction.Y = 1;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                direction.X = -1;
            }

            var speed = count > 1 ? SPEED / 2 : SPEED;

            if (Keyboard.IsKeyDown(Key.W))
            {
                vector.Y -= speed;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                vector.X += speed;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                vector.Y += speed;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                vector.X -= speed;
            }

            this.Move(vector);
        }
    }
}