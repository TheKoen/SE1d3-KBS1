using KBS1.LevelComponents;

namespace KBS1.Util
{
    public class InstanceHelper
    {
        private static bool UnitTesting = false;
        private static Level Level;
        public static Gameloop Loop;

        public static Level GetCurrentLevel()
        {
            return !UnitTesting ? GameWindow.Instance.Loadedlevel : Level;
        }

        public static Gameloop GetGameLoop()
        {
            return !UnitTesting ? GameWindow.Instance.Loop : Loop;
        }

        public static void SetupForUnitTesting(Level level)
        {
            UnitTesting = true;
            Level = level;
            Loop = new Gameloop();
        }
    }
}