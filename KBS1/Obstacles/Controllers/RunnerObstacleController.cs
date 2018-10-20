using KBS1.Misc;

namespace KBS1.Obstacles.Controllers
{
    public class RunnerObstacleController : ObstacleController
    {
        private const double Speed = 2.0;
        private const int Range = 300;

        private int _wait;

        public RunnerObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle)
        {
        }

        /// <summary>
        ///     TODO: Add proper summary
        /// </summary>
        public override void Update()
        {
            if (_wait-- > 0) return;

            _wait = 1;

            // Get information from Player
            var playerObject = FindPlayer();
            var player = playerObject.Location;

            // Kijken of de speler in range is
            if (player.Distance(Object.Location) > Range)
                return;

            // Move, eerst langste X of Y en die richting beweging
            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);

            if (xDistance > yDistance)
                Move(player.X < Object.Location.X ? new Vector(-Speed, 0) : new Vector(Speed, 0));
            else
                Move(player.Y < Object.Location.Y ? new Vector(0, -Speed) : new Vector(0, Speed));

            GameWindow.Instance.Sounds.Play("robot-walk.mp3");

            // Colliden met speler -> reset
            if (Object.Collider.Collides(playerObject.Collider))
                GameWindow.Instance.Lose();
        }
    }
}