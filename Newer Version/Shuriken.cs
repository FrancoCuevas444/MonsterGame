using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    class Shuriken : DrawableEntity
    {
        Point toward, initial;
        Vector2 velocity;
        public Shuriken(Point initial, Point toward) : base(ResourceLoader.shuriken, initial)
        {
            this.initial = initial;
            this.toward = toward;
            CalculateVel();
        }

        private void CalculateVel(){

            int width = toward.X - initial.X, height = toward.Y - initial.Y;
            velocity.X = 1 * (height / width);
            velocity.Y = 1 * (width / height);

        }

        public override void Update(GameTime gameTime)
        {
            rect.Location += velocity.ToPoint();
        }
    }
}
