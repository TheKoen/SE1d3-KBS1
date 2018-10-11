using KBS1.Misc;

namespace KBS1.Obstacles.Controllers.Archer
{
    public class ArrowObstacleController : ObstacleController
    {
        private readonly Vector _direction;

        private int _lifetime = 500;

        public ArrowObstacleController(ILocatable locatable, Obstacle obstacle, Vector direction) : base(locatable,
            obstacle)
        {
            Object.Collider.Blocking = false;
            _direction = direction;
        }

        /// <summary>
        /// TODO: Add proper summary
        /// </summary>
        public override void Update()
        {
            if (_lifetime > 0) _lifetime--;
            else
            {
                GameWindow.Instance.Loadedlevel.Objects.Remove(Object);
                Object.Renderer.Destroy();
                Object.Controller.Destroy();
            }

            var player = FindPlayer();

            Move(_direction);

            if (GameWindow.Instance.Loadedlevel.LevelCollider.Collides(Object.Collider))
            {
                GameWindow.Instance.Loadedlevel.Objects.Remove(Object);
                Object.Renderer.Destroy();
                Object.Controller.Destroy();
                return;
            }

            if (Object.Collider.Collides(player.Collider))
            {
                GameWindow.Instance.Sounds.Play("BoomHeadshot.mp3");
                GameWindow.Instance.Lose();
        }
    }
}