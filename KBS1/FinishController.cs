namespace KBS1
{
    public class FinishController : Controller
    {
        private bool Finish { get; }

        public FinishController(GameObject gameObject, bool finish) : base(gameObject) {
            Finish = finish;
        }

        public override void Update()
        {
            if (Finish)
            {
                var player = FindPlayer();
                if (player.Collider.Collides(Object.Collider))
                    GameWindow.Instance.Loop.Stop();
            }
        }
    }
}
