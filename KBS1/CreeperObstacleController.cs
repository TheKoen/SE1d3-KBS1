namespace KBS1
{
    public class CreeperObstacleController : ObstacleController
    {
        private const int speed = 1;
        private const int range = 300;
        private const int explosionRadius = 100;
        private const int delayCreeper = 100;
        private int wait = 0;

        public CreeperObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }

        public override void Update()
        {
            // player object
            var playerObject = FindPlayer();

            // player location
            var player = playerObject.Location;

            if (wait > 0)
            {
                wait--;
                if (wait == 0 && Object.Location.Distance(player) < explosionRadius)
                {
                    GameWindow.Current().Lose();
                }
                return;
            } 
            

            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);

            if (player.Distance(Object.Location) > range)
            {
                return;
            }
            
            if (xDistance > yDistance)
            {
                if(player.X > Object.Location.X)
                {
                    Move(new Vector(speed, 0));
                }
                else
                {
                    Move(new Vector(-speed, 0));
                }
            }
            else
            { 
                if (player.Y > Object.Location.Y)
                {
                    Move(new Vector(0, speed));
                }
                else
                {
                    Move(new Vector(0, -speed));
                }  
            }
            // result if not moving/collided
            if(Object.Collider.Collides(playerObject.Collider))
            {
                wait = delayCreeper;
            }
        }
    }
}
