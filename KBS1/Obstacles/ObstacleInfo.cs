namespace KBS1.Obstacles
{
    public class ObstacleInfo
    {
        public string Description { get; }

        public ObstacleInfo(string type)
        {
            switch (type)
            {
                case "runner":
                    Description = "A runner will run try to catch you.";
                    break;
                case "bomb":
                    Description = "A bomber will try to bomb you.";
                    break;
                case "turret":
                    Description = "A turret shoots bullets";
                    break;
                case "trap":
                    Description = "A  trap ";
                    break;
                default:
                    Description = "";
                    break;
            }
        }
    }
}