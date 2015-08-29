using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    class BaseTile : DrawableEntity
    {
        public BaseTile(Point pos) : base(ResourceLoader.baseTile, new Point(0, MonsterGame.screenHeight - ResourceLoader.baseTile.Height))
        {
            rect.Location = pos;
        }

    }
}
