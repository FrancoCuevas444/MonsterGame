using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    class Bar : DrawableEntity
    {
        int maxValue, width;
        public Bar(Texture2D tex, Point point, int max) : base(tex, point)
        {
            maxValue = max;
        }

        public void Update(GameTime gameTime, int currentValue)
        {
            width = (currentValue * tex.Width) / maxValue;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, new Rectangle(rect.Location, new Point(width, tex.Height)), new Rectangle(0, 0, tex.Width, tex.Height) , Color.White);
        }
    }
}
