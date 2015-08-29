using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonsterGame
{
    class Cloud : DrawableEntity
    {
        public Cloud(Point location) : base(ResourceLoader.cloud, location)
        {
        }

        public void Update(GameTime gameTime, Point location)
        {
            rect.Location = new Point(location.X - 20, location.Y + 110);
        }
    }
}
