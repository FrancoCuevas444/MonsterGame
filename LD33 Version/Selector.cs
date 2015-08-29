using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonsterGame
{
    class Selector : DrawableEntity
    {
        Player player;
        public Selector(Player player) : base(ResourceLoader.selector,  player.Rect.Location)
        {
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            rect.Location = player.Rect.Location;
        }
    }
}
