using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KBS1
{
    class PlayerController : Controller
    {
        private const double SPEED = 1.5;

        public Player Player { get; }

        private Image[] image = ResourceManager.Instance.LoadImageSpritePlayer("playersprites.png");
        private bool runLeft, runRight, runUp, runDown = false;
        private int delayWalking = 5;

        public PlayerController(Player player) : base(player)
        {
            Player = player;
        }

        //wait delay for walking
        int wait = 0;
        public override void Update()
        {
            var direction = new Vector();
            if (Keyboard.IsKeyDown(Key.W))
            {
                direction.Y = -1;
                if(wait == delayWalking)
                {
                    if (runUp == false)
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)image[15].Source);
                        runUp = true;
                    }
                    else
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)image[12].Source);
                        runUp = false;
                    }
                    wait = 0;
                }
                else
                {
                    wait++;
                }
            }
                
            if (Keyboard.IsKeyDown(Key.D))
            {
                direction.X = 1;
                if(wait == delayWalking)
                {
                    if (runRight == false)
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)image[11].Source);
                        runRight = true;
                    }
                    else
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)image[9].Source);
                        runRight = false;
                    }
                    wait = 0;
                }
                else
                {
                    wait++;
                }
                
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                direction.Y = 1;
                if(wait == delayWalking)
                {
                    if (runDown == false)
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)image[3].Source);
                        runDown = true;
                    }
                    else
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)image[1].Source);
                        runDown = false;
                    }
                    wait = 0;
                }
                else
                {
                    wait++;
                }
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                direction.X = -1;
                if (wait == delayWalking)
                {
                    if (runLeft == false)
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)image[7].Source);
                        runLeft = true;
                    }
                    else
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)image[5].Source);
                        runLeft = false;
                    }
                    wait = 0;
                }
                else
                {
                    wait++;
                }                               
            }

            if (Keyboard.IsKeyDown(Key.Escape)) GameWindow.Instance.PauseGame();

            var speed = SPEED;

            if (Keyboard.IsKeyDown(Key.LeftShift))
                speed = 10;

            Move(direction.Normalize(speed));
        }
    }
}