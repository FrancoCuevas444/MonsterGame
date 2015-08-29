using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonsterGame
{
    class PlayerInput : Entity
    {
        Player player;   
        KeyboardState keyboard;

        public PlayerInput(Player player)
        {
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Q))
            {
                player.abilityManager.Q();
            }

            if (keyboard.IsKeyDown(Keys.W))
            {
                player.abilityManager.W();
            }

            if (keyboard.IsKeyDown(Keys.E))
            {
                player.abilityManager.E();
            }

        }
        
    }
}
