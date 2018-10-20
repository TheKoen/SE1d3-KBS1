namespace KBS1.Obstacles
{
    public class ObstacleInfo
    {
        public ObstacleInfo(string type)
        {
            switch (type)
            {
                case "runner":
                    Description = "A runner will chase you. Quickly run away!";
                    break;
                case "bomb":
                    Description = "The bomb will go near you and explode. Get down!";
                    break;
                case "turret":
                    Description = "Dodge the bullets from the turret as they rapidly shoot them towards you!";
                    break;
                case "trap":
                    Description = "Watch out! Traps are dangerous and you rather not step in one.";
                    break;
                default:
                    Description = "";
                    break;
            }
        }

        public string Description { get; }
    }
}