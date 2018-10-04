namespace KBS1
{
    public class FinishController : Controller
    {
        private bool Finish { get; }

        public FinishController(GameObject gameObject, bool finish) : base(gameObject)
        {
            Finish = finish;
            Object.Collider.Blocking = false;
        }

        public override void Update()
        {
            if (!Finish)
                return;

            var player = FindPlayer();
            if (player.Collider.Collides(Object.Collider))
            {
                GameWindow.Instance.Reset();
            }
        }
    }
}