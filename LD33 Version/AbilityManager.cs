using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonsterGame
{
    class AbilityManager : Entity
    {
        Player player;

        public const int qEnergy = 30, wEnergy = 25, eEnergy = 45;

        bool startedFalling = false, hasFalled = false;
        public bool qIsOn = false, eIsOn = false;

        public Cooldown firstAbility, levitating, secondAbility, thirdAbility, falling;

        BallAttack ballAttack;
        Selector selector;
        Cloud cloud;

        public AbilityManager(Player player)
        {
            this.player = player;
            levitating = new Cooldown(10);
            firstAbility = new Cooldown(15);
            secondAbility = new Cooldown(8);
            falling = new Cooldown(4);
            thirdAbility = new Cooldown(20);

            selector = new Selector(player);
            cloud = new Cloud(player.Rect.Location);
        }

        public override void Update(GameTime gameTime)
        {
            StateUpdate(gameTime);
            UpdateCooldowns(gameTime);

            if (ballAttack != null && !ballAttack.IsEmpty) ballAttack.Update(gameTime);
            if (player.State == PlayerState.FALLING) selector.Update(gameTime);
            if (player.State == PlayerState.LEVITATING)
            {
                cloud.Update(gameTime, player.Rect.Location);
                System.Console.WriteLine("XPlayer : " + player.X + " XCloud: " + (cloud.X + 20));
                System.Console.WriteLine("YPlayer : " + player.Y + " YCloud: " + (cloud.Y - 110));
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (ballAttack != null && !ballAttack.IsEmpty) ballAttack.Draw(sb);
            if (player.State == PlayerState.FALLING) selector.Draw(sb);
            if (player.State == PlayerState.LEVITATING) cloud.Draw(sb);
        }

        public void Q()
        {
            if (firstAbility.IsReady && levitating.IsReady && !startedFalling && player.State != PlayerState.FALLING && player.Energy > qEnergy)
            {
                qIsOn = true;
                player.movementController.CanJump = false;
                player.State = PlayerState.LEVITATING;
                levitating.Reset();
                player.Energy -= qEnergy;
                return;
            }
        }

        public void W()
        {
            if (secondAbility.IsReady && !startedFalling && player.State != PlayerState.FALLING && player.Energy > wEnergy)
            {
                secondAbility.Reset();
                ballAttack = new BallAttack(new Point(player.X + player.Rect.Width / 2, player.Y + player.Rect.Height / 2));
                player.Energy -= wEnergy;
            }
        }

        public void E()
        {
            if (!startedFalling && thirdAbility.IsReady && player.State != PlayerState.LEVITATING && player.Energy > eEnergy)
            {
                eIsOn = true;
                startedFalling = true;
                player.movementController.CanJump = false;
                player.Gravity = false;
                player.ForceOrange = true;
                player.Energy -= eEnergy;
            }
        }

        private void StateUpdate(GameTime gameTime)
        {
            switch (player.State)
            {
                case PlayerState.NORMAL:
                    if (hasFalled && player.IsGrounded)
                    {
                        eIsOn = false;
                        thirdAbility.Reset();
                        hasFalled = false;
                        player.ForceOrange = false;
                        player.movementController.CanMove = true;
                    }
                    if (startedFalling) GoingUp(gameTime);
                    return;

                case PlayerState.LEVITATING:
                    Levitating(gameTime);
                    return;

                case PlayerState.FALLING:
                    Falling(gameTime);
                    return;
            }
        }

        private void Levitating(GameTime gameTime)
        {
            player.Y = 130;
            player.Gravity = false;

            if (levitating.IsReady)
            {
                qIsOn = false;
                player.movementController.CanJump = true;
                player.Gravity = true;
                firstAbility.Reset();
                player.State = PlayerState.NORMAL;
            }
        }

        private void GoingUp(GameTime gameTime)
        {
            if (player.Y > -player.Rect.Height)
            {
                player.Y -= 40;
            }
            else
            {
                startedFalling = false;
                player.Gravity = false;
                falling.Reset();
                player.State = PlayerState.FALLING;

            }
        }

        private void Falling(GameTime gameTime)
        {
            if (falling.IsReady)
            {
                player.State = PlayerState.NORMAL;
                player.movementController.CanJump = true;
                player.movementController.CanMove = false;
                player.Gravity = true;
                player.physics.ForceYSpeed(80);
                hasFalled = true;
            }
        }

        private void UpdateCooldowns(GameTime gameTime)
        {
            levitating.Update(gameTime);
            firstAbility.Update(gameTime);
            secondAbility.Update(gameTime);
            falling.Update(gameTime);
            thirdAbility.Update(gameTime);
        }
    }
}
