﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace KBS1
{
    public class CreeperObstacleController : ObstacleController
    {
        private int speed = 1;
        private int range = 300;
        private int explosionRadius = 100;
        private int delayCreeper = 100;
        private int wait = 0;
        private Boolean red = false;

        public CreeperObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }

        public override void Update()
        {
            // player object
            var playerObject = FindPlayer();

            // player location
            var player = playerObject.Location;

            if (wait > 0)
            {
                wait--;


                if (wait % 5 == 0)
                {
                    // color chancing creeper if in explosion range
                    if (red == true)
                    {
                        var image = Level.LoadImage("creeper_red.png");
                        Object.Renderer.ChangeSprite((BitmapImage)image.Source);
                        red = false;
                    }
                    else if (red == false)
                    {
                        var image = Level.LoadImage("creeper.png");
                        Object.Renderer.ChangeSprite((BitmapImage)image.Source);
                        red = true;
                    }

                }

                //explode if player is in range and timer is out of time
                if (wait == 0 && Object.Location.Distance(player) < explosionRadius)
                {
                    GameWindow.Current().Reset();
                }
                // reset timer if player is out of range and set creeper back to green.
                else if(Object.Location.Distance(player) > explosionRadius)
                {
                    var image = Level.LoadImage("creeper.png");
                    Object.Renderer.ChangeSprite((BitmapImage)image.Source);
                    red = true;
                    wait = 0;
                }
                return;
            } 
            

            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);

            if (player.Distance(Object.Location) > range)
            {
                return;
            }

            var result = false;
            if (xDistance > yDistance)
            {
                if(player.X > Object.Location.X)
                {
                    result = Move(new Vector(speed, 0));
                }
                else
                {
                    result = Move(new Vector(-speed, 0));
                }
            }
            else
            { 
                if (player.Y > Object.Location.Y)
                {
                    result = Move(new Vector(0, speed));
                }
                else
                {
                    result = Move(new Vector(0, -speed));
                }  
            }
            // result if not moving/collided
            if(result == false)
            {
                wait = delayCreeper;
            }
            

        }
    }
}
