using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonsterGame
{
    class PlayerPhysics : Entity
    {
        Player player;
        double secondCounter;
        double YSpeed;

        public PlayerPhysics(Player player)
        {
            this.player = player;
            YSpeed = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (!player.IsGrounded)
            {
                Gravity(gameTime);
            }
            else
            {
                YSpeed = 0;
            }

        }

        public void ForceYSpeed(int amount)
        {
            YSpeed = amount;
        }
        private void Gravity(GameTime gameTime)
        {
            secondCounter = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            YSpeed += 60 / secondCounter;
            player.Y += (int)YSpeed;
        }

    }
}
