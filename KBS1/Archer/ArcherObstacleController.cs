using System.Windows.Controls;

namespace KBS1.Archer
{
    public class ArcherObstacleController : ObstacleController
    {
        private const int Speed = 1;
        private const int Range = 200;
        private static readonly ObstacleType ARROW = 
            new ObstacleType(new ArrowObstacle(), 5, ResourceManager.Instance.LoadImage("arrow.png"));

        private int _wait = 0;
    
        public ArcherObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }

        /// <summary>
        /// TODO: Add proper summary
        /// </summary>
        public override void Update()
        {
            if (_wait-- > 0) return;

            var player = FindPlayer();
            var playerLocation = player.Location;

            if (playerLocation.Distance(Object.Location) > Range)
                return;

            var xDistance = playerLocation.AxisDistance(Object.Location, true);
            var yDistance = playerLocation.AxisDistance(Object.Location, false);
            var distance = playerLocation.Distance(Object.Location);

            var px = playerLocation.X;
            var py = playerLocation.Y;
            var ax = Object.Location.X;
            var ay = Object.Location.Y;
            
            var dx = xDistance / distance;
            var dy = yDistance / distance;

            var vector = new Vector((px < ax ? -dx : dx) * 2.0, (py < ay ? -dy : dy) * 2.0);

            var level = GameWindow.Instance.Loadedlevel;

            var arrow = new Arrow(ARROW, GameWindow.Instance.DrawingPanel, Object.Location, vector);
            level.Objects.Add(arrow);
            arrow.Init();
            _wait = 30;
        }

        private class Arrow : Obstacle
        {
            public Vector Direction { get; }

            public Arrow(ObstacleType type, Canvas canvas, Vector location, Vector direction) : base(type, canvas, location)
            {
                Direction = direction;
            }
        }

        public class ArrowObstacle : IControllerCreator
        {
            public Controller Create(Obstacle obstacle)
            {
                return new ArrowObstacleController(obstacle, obstacle, ((Arrow) obstacle).Direction);
            }
        }
    }
}
