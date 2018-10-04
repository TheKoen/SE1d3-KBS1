using KBS1.Archer;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace KBS1
{
    public class ObstacleType
    {
        public static List<ObstacleType> Types = new List<ObstacleType>();

        public int CollisionRadius { get; }
        public Image Sprite { get; }

        private readonly IControllerCreator Creator;

        public ObstacleType(IControllerCreator creator, int collisionRadius, Image sprite)
        {
            Creator = creator;
            CollisionRadius = collisionRadius;
            Sprite = sprite;
        }

        /// <summary>
        /// Creates a new ObstacleController for this ObstacleType
        /// </summary>
        /// <returns>ObstacleController for this ObstacleType</returns>
        public Controller CreateController(Obstacle obstacle) => Creator.Create(obstacle);

        public static ObstacleType Find(string name)
        {
            foreach (var obstacleType in Types)
            {
                var obstacleName = obstacleType.Creator.GetType().Name;
                if (obstacleName == name)
                    return obstacleType;
            }
            throw new NullReferenceException($"ObstacleType {name} could not be found");
        }
        //create obstacle
        public static void Init()
        {
            // Runner
            Types.Add(new ObstacleType(new RunnerObstacle(), 24, ResourceManager.Instance.LoadImage("runner.png")));
            // Creeper
            Types.Add(new ObstacleType(new CreeperObstacle(), 24, ResourceManager.Instance.LoadImage("creeper.png")));
            // Archer
            Types.Add(new ObstacleType(new ArcherObstacle(), 24, ResourceManager.Instance.LoadImage("archer.png")));
            // Trap
            Types.Add(new ObstacleType(new TrapObstacle(), 14, ResourceManager.Instance.LoadImage("trap.png")));
            // Wall
            Types.Add(new ObstacleType(new WallObstacle(), 14, ResourceManager.Instance.LoadImage("wall.png")));
            // Tree
            Types.Add(new ObstacleType(new TreeObstacle(), 14, ResourceManager.Instance.LoadImage("tree.png")));

        }
        
        private class RunnerObstacle : IControllerCreator
        {
            public Controller Create(Obstacle obstacle) => new RunnerObstacleController(obstacle, obstacle);
        }

        private class TrapObstacle : IControllerCreator
        {
            public Controller Create(Obstacle obstacle)
            {
                return new TrapObstacleController(obstacle, obstacle);
            }
        }

        private class WallObstacle : IControllerCreator
        {
            public Controller Create(Obstacle obstacle)
            {
                return new WallObstacleController(obstacle, obstacle);
            }
        }

        private class TreeObstacle : IControllerCreator
        {
            public Controller Create(Obstacle obstacle)
            {
                return new TreeObstacleController(obstacle, obstacle);
            }
        }

        private class ArcherObstacle : IControllerCreator
        {
            public Controller Create(Obstacle obstacle)
            {
                return new ArcherObstacleController(obstacle, obstacle);
            }
        }

        private class CreeperObstacle : IControllerCreator
        {
            public Controller Create(Obstacle obstacle)
            {
                return new CreeperObstacleController(obstacle, obstacle);
            }
        }
    }
}
