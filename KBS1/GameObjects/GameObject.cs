﻿using System.Windows.Controls;
using KBS1.Misc;

namespace KBS1.GameObjects
{
    public abstract class GameObject : ILocatable
    {
        public Vector Location { get; set; }
        public SpriteRenderer Renderer { get; }
        public Collider.Collider Collider { get; set; }
        public Controller.Controller Controller { get; private set; }

        //When making a new GameObject, a new SpriteRenderer will be made with it.
        protected GameObject(int radius, Image image, Canvas canvas, Vector location)
        {
            Location = location;
            if (image != null || canvas != null)
                Renderer = new SpriteRenderer(image, this, canvas);
            Collider = new Collider.Collider(radius, this);
        }

        //abstract method for creating a new Controller for a GameObject depending on what kind of GameObject.
        protected abstract Controller.Controller CreateController();

        /// <summary>
        /// Initializes the controller for the game
        /// </summary>
        public void Init()
        {
            Controller = CreateController();
        }
    }
}