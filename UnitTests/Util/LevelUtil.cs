﻿using System;
using System.Collections.Generic;
using System.Linq;
using KBS1.Collider;
using KBS1.GameObjects;
using KBS1.LevelComponents;
using KBS1.Misc;
using KBS1.Util;

namespace UnitTests.Util
{
    public class LevelUtil
    {
        private static readonly Random Random = new Random();

        public static Level CreateLevel(List<GameObject> objects)
        {
            var level = new Level
            {
                Objects = objects,
                LevelCollider = new LevelCollider()
            };
            InstanceHelper.SetupForUnitTesting(level);
            return level;
        }

        public static Level CreateLevel(GameObject[] objectArray)
        {
            return CreateLevel(objectArray.ToList());
        }

        public static Level CreateLevel(int objectCount, int radius)
        {
            var objects = new List<GameObject>();
            for (var i = 0; i < objectCount; i++)
                objects.Add(new TestGameObject(radius, new Vector(Random.Next(1, 780), Random.Next(1, 600))));

            return CreateLevel(objects);
        }
    }
}