using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    class PlayerCDManager : Entity
    {
        public Cooldown levitating, firstAbility, secondAbility, falling, thirdAbility, second;
        public PlayerCDManager()
        {
            levitating = new Cooldown(10);
            firstAbility = new Cooldown(15);
            secondAbility = new Cooldown(8);
            falling = new Cooldown(4);
            thirdAbility = new Cooldown(20);
            second = new Cooldown(1);
        }

        public override void Update(GameTime gameTime)
        {
            levitating.Update(gameTime);
            firstAbility.Update(gameTime);
            secondAbility.Update(gameTime);
            falling.Update(gameTime);
            thirdAbility.Update(gameTime);
            second.Update(gameTime);
        }
    }
}
