using System.Windows.Controls;

namespace KBS1.Archer
{
    public class ArcherObstacleController : ObstacleController
    {
        private const int SPEED = 1;
        private const int RANGE = 200;
        private static readonly ObstacleType ARROW = 
            new ObstacleType(new ArrowObstacle(), 5, ResourceManager.Instance.LoadImage("arrow.png"));

        private int wait = 0;
    
        public ArcherObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }

        public override void Update()
        {
            if (wait > 0)
            {
                wait--;
                return;
            }

            var player = FindPlayer();
            var playerLocation = player.Location;

            if (playerLocation.Distance(Object.Location) > RANGE)
            {
                return;
            }

            var xDistance = playerLocation.AxisDistance(Object.Location, true);
            var yDistance = playerLocation.AxisDistance(Object.Location, false);
            var distance = playerLocation.Distance(Object.Location);

            var PX = playerLocation.X;
            var PY = playerLocation.Y;
            var AX = Object.Location.X;
            var AY = Object.Location.Y;
            
            var DX = xDistance / distance;
            var DY = yDistance / distance;

            var vector = new Vector((PX < AX ? -DX : DX) * 2.0, (PY < AY ? -DY : DY) * 2.0);

            var level = GameWindow.Instance.Loadedlevel;

            var arrow = new Arrow(ARROW, GameWindow.Instance.DrawingPanel, Object.Location, vector);
            level.Objects.Add(arrow);
            arrow.Init();
            wait = 30;
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
