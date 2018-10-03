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
        public Controller CreateController(Obstacle obstacle)
        {
            return Creator.Create(obstacle);
        }

        public static ObstacleType Find(string name)
        {
            foreach (var obstacleType in Types)
            {
                var obstacleName = obstacleType.Creator.GetType().Name;
                if (obstacleName == name)
                {
                    return obstacleType;
                }
            }
            throw new NullReferenceException($"ObstacleType {name} could not be found");
        }

        public static void Init()
        {
            Types.Add(new ObstacleType(new RunnerObstacle(), 24, Level.LoadImage("runner.png")));
            Types.Add(new ObstacleType(new TrapObstacle(), 14, Level.LoadImage("trap.png")));
            Types.Add(new ObstacleType(new WallObstacle(), 14, Level.LoadImage("wall.png")));
            Types.Add(new ObstacleType(new TreeObstacle(), 14, Level.LoadImage("tree.png")));

        }


        private class RunnerObstacle : IControllerCreator
        {
            public Controller Create(Obstacle obstacle)
            {
                return new RunnerObstacleController(obstacle, obstacle);
            }
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

    }
}
