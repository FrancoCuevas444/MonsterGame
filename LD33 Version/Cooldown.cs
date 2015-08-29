using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonsterGame
{
    class Cooldown : Entity
    {
        double limit, current;
        public int Current
        {
            get { return (int)limit - (int)current; }
        }
        public bool IsReady
        {
            get { return ready; }
        }
        bool ready;

        public Cooldown(float limit)
        {
            this.limit = limit;
            current = limit;
            ready = true;
        }

        public void Reset()
        {
            current = 0;
            ready = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (current > 10000) current = limit;
            if (current > limit) ready = true;
            if (current < limit) ready = false;

            current += gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
