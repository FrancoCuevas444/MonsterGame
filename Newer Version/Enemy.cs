using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonsterGame
{
    enum EnemyState
    {
        RUNNING,
        CHASING,
        ATTACKING,
        SHOOTING
    }

    class Enemy : DrawableEntity
    {
        Player player;
        Cooldown sword, bullet, changeState, changeDirection;
        bool facingRight = true, runningRight = true;
        SpriteEffects effect;
        EnemyState state;
        Random stateSelector;
        Shuriken shuri;
        public Enemy(Player player) : base (ResourceLoader.enemy, new Point(0, MonsterGame.screenHeight - 64 - ResourceLoader.enemy.Height))
        {
            this.player = player;
            sword = new Cooldown(0.5f);
            bullet = new Cooldown(2);
            changeState = new Cooldown(2);
            changeDirection = new Cooldown(0.5f);
            stateSelector = new Random();
            state = EnemyState.CHASING;
        }

        public override void Update(GameTime gameTime)
        {
            changeDirection.Update(gameTime);
            changeState.Update(gameTime);
            sword.Update(gameTime);
            if (runningRight) facingRight = true;
            else facingRight = false;
            if (facingRight) effect = SpriteEffects.None;
            if (!facingRight) effect = SpriteEffects.FlipHorizontally;
            SelectingState();
            AI();
            if (Keyboard.GetState().IsKeyDown(Keys.P) && shuri == null)
            {
                System.Console.WriteLine("SHOOT!");
                shuri = new Shuriken(rect.Center, player.Rect.Center);
            }
            if (shuri != null)
                shuri.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rect, new Rectangle(new Point(0 ,0), new Point(tex.Width, tex.Height)), color, 0.0f, new Vector2(0, 0), effect, 0);
            if (shuri != null) shuri.Draw(sb);
        }

        public void SelectingState()
        {
            switch (player.State)
            {
                case PlayerState.NORMAL:
                    if (rect.Intersects(player.Rect))
                    {
                        state = EnemyState.ATTACKING;
                        sword.Reset();
                    }else if (state == EnemyState.ATTACKING && !rect.Intersects(player.Rect) && sword.IsReady)
                    {
                        state = (EnemyState)stateSelector.Next(2);
                        changeState.Reset();
                    }else if (changeState.IsReady)
                    {
                        state = (EnemyState)stateSelector.Next(2);
                        changeState.Reset();
                    }
                    return;
                case PlayerState.LEVITATING:

                    return;
                case PlayerState.FALLING:
                    state = EnemyState.RUNNING;
                    return;
            }
        }

        public void AI()
        {
            switch (state)
            {
                case EnemyState.RUNNING:
                    tex = ResourceLoader.enemy;
                    Running();
                    Movement();
                    return;
                case EnemyState.CHASING:
                    tex = ResourceLoader.enemy;
                    if (changeDirection.IsReady)
                    {
                        GoingToEnemy();
                        changeDirection.Reset();
                    }
                    Movement();
                    return;
                case EnemyState.ATTACKING:
                    tex = ResourceLoader.enemySword;
                    return;
                case EnemyState.SHOOTING:
                    return;
            }
        }

        public void GoingToEnemy()
        {
            if(X < player.X && changeDirection.IsReady)
            {
                runningRight = true;
            }
            else if(X > player.Y)
            {
                runningRight = false;
            }
        }

        public void Running()
        {
            if(X < 10)
            {
                runningRight = true;
            }else if(X> MonsterGame.screenWidth - 100)
            {
                runningRight = false;
            }
        }

        public void SwordAttack()
        {
        }

        public void Movement()
        {
            if (runningRight) X += 10;
            else if (!runningRight) X -= 10;
        }

    }
}
