namespace KBS1
{
    public class TrapObstacleController : ObstacleController
    {
        public TrapObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle)
        {
        }
        
        /// <summary>
        /// Methode called every gametick Checks if <see cref="Player"/> collides with the TrapObstacle.
        /// </summary>
        public override void Update()
        {
            var playerObject = FindPlayer();
            
            if (Object.Collider.Collides(playerObject.Collider))
                GameWindow.Instance.Lose();
        }
    }
}
