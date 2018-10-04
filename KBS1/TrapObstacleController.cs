namespace KBS1
{
    public class TrapObstacleController : ObstacleController
    {
        public TrapObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle)
        {
        }

        public override void Update()
        {
            var playerObject = FindPlayer();
            
            if (Object.Collider.Collides(playerObject.Collider))
            {
                GameWindow.Current().Lose();
            }
        }
    }
}
