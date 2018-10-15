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
                    Description = "";
                    break;
                case "bomb":
                    Description = "";
                    break;
                case "turret":
                    Description = "";
                    break;
                case "trap":
                    Description = "";
                    break;
                default:
                    Description = "";
                    break;
            }
        }
    }
}