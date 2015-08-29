using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    abstract class DrawableEntity : Entity
    {
        protected Texture2D tex;
        public Rectangle Rect
        {
            get{ return rect; }
            set { rect = value; }
        }
        protected Rectangle rect;
        public int X
        {
            get { return rect.X; }
            set { rect.X = value; }
        }
        public int Y
        {
            get { return rect.Y; }
            set { rect.Y = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        protected Color color;

        public DrawableEntity(Texture2D tex, Point initialPos , int size = 1)
        {
            this.tex = tex;
            color = Color.White;
            rect = new Rectangle(initialPos, new Point(tex.Width * size, tex.Height * size));
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rect, color);
        }
    }
}
