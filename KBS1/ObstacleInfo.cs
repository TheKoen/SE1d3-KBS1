namespace KBS1
{
    public class ObstacleInfo
    {
        public string Description { get; }

        public ObstacleInfo(string type)
        {
            switch (type)
            {
                case "runner":
                    Description = "A runner is fast as fuck";
                    break;
                case "creeper":
                    Description = "Watch out! A creeper can explode. It ain't very fast tho";
                    break;
                case "archer":
                    Description = "An archer can shoot sum arrows, but no worries, it's aim is sh*t";
                    break;
                case "trap":
                    Description = "A trap can be very deadly, so watch out where you walk";
                    break;
                default:
                    Description = "No description";
                    break;
            }
        }
        
    }
}
