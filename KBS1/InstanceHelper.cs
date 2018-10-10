namespace KBS1
{
    public class InstanceHelper
    {
        private static bool UnitTesting = false;
        private static Level Level;

        public static Level GetCurrentLevel()
        {
            return !UnitTesting ? GameWindow.Instance.Loadedlevel : Level;
        }

        public static void SetupForUnitTesting(Level level)
        {
            UnitTesting = true;
            Level = level;
        }
    }
}
