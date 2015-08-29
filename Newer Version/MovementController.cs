using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonsterGame
{
    class MovementController  : Entity
    {
        KeyboardState keyboard;
        Player player;
        public bool CanJump
        {
            get { return canJump; }
            set { canJump = value;}
        }
        public bool CanMove
        {
            get { return sidesMovement; }
            set { sidesMovement = value; }
        }
        bool sidesMovement = true, canJump = true;
        bool goingRight = false, goingLeft = false;
        double YSpeed = 0, XSpeed = 0;

        public MovementController(Player player)
        {
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            if (sidesMovement)
            {
                SideMovement(gameTime);
                player.X += (int)XSpeed;
            }

            if (canJump)
            {
                if (player.IsGrounded == true)
                {
                    YSpeed = 30;
                    player.IsJumping = true;
                    player.Gravity = false;
                    player.IsGrounded = false;
                }

                if (player.IsJumping)
                {
                    Jump(gameTime);
                }
            }
        }

        private void Jump(GameTime gameTime)
        {
            double secondCounter = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            if (YSpeed > 0)
            {
                YSpeed -= 80 / secondCounter;
                player.Y -= (int)YSpeed;
            }
            else
            {
                YSpeed = 0;
                player.IsJumping = false;
                player.Gravity = true;
            }
        }

        private void SideMovement(GameTime gameTime)
        {
            double secondCounter = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboard.IsKeyDown(Keys.Right))
            {
                if (goingRight == false) XSpeed = 4;
                if (XSpeed < 10) XSpeed += 30 / secondCounter;
                else XSpeed = 10;
                goingRight = true;
            }
            else if (keyboard.IsKeyDown(Keys.Left))
            {
                if (goingLeft == false) XSpeed = -4;
                if (XSpeed > -10) XSpeed -= 30 / secondCounter;
                else XSpeed = -10;
                goingLeft = true;
            }

            if (keyboard.IsKeyUp(Keys.Right) && goingRight)
            {
                if (XSpeed > 0) XSpeed -= 12 / secondCounter;
                else
                {
                    XSpeed = 0;
                    goingRight = false;
                }
            }
            else if (keyboard.IsKeyUp(Keys.Left) && goingLeft)
            {
                if (XSpeed < 0) XSpeed += 12 / secondCounter;
                else
                {
                    XSpeed = 0;
                    goingLeft = false;
                }
            }
        }
    }
}
