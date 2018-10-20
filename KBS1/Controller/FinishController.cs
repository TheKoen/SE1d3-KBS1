using KBS1.GameObjects;

namespace KBS1.Controller
{
    public class FinishController : Controller
    {
        public FinishController(GameObject gameObject, bool finish) : base(gameObject)
        {
            Finish = finish;
            Object.Collider.Blocking = false;
        }

        public bool Finish { get; }

        /// <summary>
        ///     Checks if the finished/collides with the finish object. Called every gametick
        /// </summary>
        public override void Update()
        {
            if (!Finish)
            {
                if (Object.Collider.Collides(FindPlayer().Collider) &&
                    GameWindow.Instance.Loadedlevel.Score.Ticks < 20)
                    GameWindow.Instance.Loadedlevel.Score.Ticks = 0;

                return;
            }

            var player = FindPlayer();
            if (player.Collider.Collides(Object.Collider))
                GameWindow.Instance.Win();
        }
    }
}