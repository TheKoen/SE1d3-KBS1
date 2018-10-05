namespace KBS1
{
    public class LevelCollider : Collider
    {
        public LevelCollider() : base(0, null)
        {
        }
        
        public override bool Collides(Vector location, int radius)
        {
            return Blocking && (location.X < radius || location.X > GameWindow.Instance.DrawingPanel.ActualWidth - radius ||
                                location.Y < radius || location.Y > GameWindow.Instance.DrawingPanel.ActualHeight - radius);
        }
    }
}
