namespace KBS1
{
    public class FinishController : Controller
    {
        public bool Finish { get; }

        public FinishController(GameObject gameObject, bool finish) : base(gameObject)
        {
            Finish = finish;
            Object.Collider.Blocking = false;
        }

        /// <summary>
        /// Checks if the finished/collides with the finish object
        /// </summary>
        public override void Update()
        {
            if (!Finish)
            {
                if (Object.Collider.Collides(FindPlayer().Collider) && 
                    GameWindow.Instance.Loadedlevel.Score.Ticks < 20)
                {
                    GameWindow.Instance.Loadedlevel.Score.Ticks = 0;
                }
                return;
            }

            var player = FindPlayer();
            if (player.Collider.Collides(Object.Collider))
            {
                //Shows a win text
                GameWindow.Instance.Win();
            }
        }
    }
}