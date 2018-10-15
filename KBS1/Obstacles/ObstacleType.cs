using System;
using System.Collections.Generic;
using System.Windows.Controls;
using KBS1.Misc;
using KBS1.Obstacles.Controllers;
using KBS1.Obstacles.Controllers.Archer;
using KBS1.Util;

namespace KBS1.Obstacles
{
    public class ObstacleType
    {
        public static readonly List<ObstacleType> Types = new List<ObstacleType>();

        public int CollisionRadius { get; }
        public Image Sprite { get; }

        private readonly IControllerCreator _creator;

        public ObstacleType(IControllerCreator creator, int collisionRadius, Image sprite)
        {
            _creator = creator;
            CollisionRadius = collisionRadius;
            Sprite = sprite;
        }

        /// <summary>
        /// Creates a new <see cref="ObstacleController"/> for this <see cref="ObstacleType"/>
        /// </summary>
        /// <returns>ObstacleController for this ObstacleType</returns>
        public Controller.Controller CreateController(Obstacle obstacle) => _creator.Create(obstacle);

        /// <summary>
        /// Attempts to find an <see cref="ObstacleType"/> by it's name
        /// </summary>
        /// <param name="name">The name to find</param>
        /// <returns>The found <see cref="ObstacleType"/></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static ObstacleType Find(string name)
        {
            foreach (var obstacleType in Types)
            {
                var obstacleName = obstacleType._creator.GetType().Name;
                if (obstacleName == name)
                    return obstacleType;
            }

            throw new NullReferenceException($"ObstacleType {name} could not be found");
        }

        /// <summary>
        /// Initializes all <see cref="ObstacleType"/>s
        /// </summary>
        public static void Init()
        {
            // Runner
            Types.Add(new ObstacleType(new RunnerObstacle(), 24, ResourceManager.Instance.LoadImage("#runner.png")));
            // Creeper
            Types.Add(new ObstacleType(new CreeperObstacle(), 12, ResourceManager.Instance.LoadImage("#bomb.png")));
            // Archer
            Types.Add(new ObstacleType(new ArcherObstacle(), 24, ResourceManager.Instance.LoadImage("#turret.png")));
            // Trap
            Types.Add(new ObstacleType(new TrapObstacle(), 20, ResourceManager.Instance.LoadImage("#trap.png")));
            // Wall
            Types.Add(new ObstacleType(new WallObstacle(), 14, ResourceManager.Instance.LoadImage("#wall.png")));
            // Tree
            Types.Add(new ObstacleType(new TreeObstacle(), 14, ResourceManager.Instance.LoadImage("#tree.png")));
        }

        private class RunnerObstacle : IControllerCreator
        {
            public Controller.Controller Create(Obstacle obstacle) => new RunnerObstacleController(obstacle, obstacle);
        }

        private class TrapObstacle : IControllerCreator
        {
            public Controller.Controller Create(Obstacle obstacle) => new TrapObstacleController(obstacle, obstacle);
        }

        private class WallObstacle : IControllerCreator
        {
            public Controller.Controller Create(Obstacle obstacle) => new WallObstacleController(obstacle, obstacle);
        }

        private class TreeObstacle : IControllerCreator
        {
            public Controller.Controller Create(Obstacle obstacle) => new TreeObstacleController(obstacle, obstacle);
        }

        private class ArcherObstacle : IControllerCreator
        {
            public Controller.Controller Create(Obstacle obstacle) => new ArcherObstacleController(obstacle, obstacle);
        }

        private class CreeperObstacle : IControllerCreator
        {
            public Controller.Controller Create(Obstacle obstacle) => new CreeperObstacleController(obstacle, obstacle);
        }
    }
}