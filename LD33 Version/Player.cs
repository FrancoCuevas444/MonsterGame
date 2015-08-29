using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MonsterGame
{
    enum PlayerState
    {
        NORMAL,
        LEVITATING,
        FALLING
    }
    class Player : DrawableEntity
    {
        PlayerInput input;
        public PlayerPhysics physics;
        public MovementController movementController;
        public AbilityManager abilityManager;
        Cooldown second;

        public bool Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }
        bool gravity = true;

        public bool IsJumping
        {
            get { return isJumping; }
            set { isJumping = value;  }
        }
        bool isJumping = false;
        
        public bool IsGrounded
        {
            get { return isGrounded; }
            set { isGrounded = value; }
        }
        bool isGrounded = false;

        public bool ForceOrange
        {
            get { return forceOrange; }
            set { forceOrange = value; }
        }
        bool forceOrange = false;

        public PlayerState State
        {
            get { return state; }
            set { state = value; }
        }
        PlayerState state = PlayerState.NORMAL;

        public int Life
        {
            get { return life; }
        }

        public int Energy
        {
            get { return energy; }
            set { energy = value; }
        }
        int life = maxLife, energy = maxEnergy;
        public const int maxLife = 1000, maxEnergy = 200;

        public Player() : base(ResourceLoader.playerTex, new Point(0 ,0))
        {
            input = new PlayerInput(this);
            physics = new PlayerPhysics(this);
            movementController = new MovementController(this);
            abilityManager = new AbilityManager(this);

            second = new Cooldown(1);
            
        }

        public override void Update(GameTime gameTime)
        {
            input.Update(gameTime);
            if (gravity) physics.Update(gameTime);
            abilityManager.Update(gameTime);
            movementController.Update(gameTime);
            
            second.Update(gameTime);
            UpdateStats(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            abilityManager.Draw(sb);
        }

        public void Damage(int amount)
        {
            if(amount >= 0) life -= amount;
        }

        private void UpdateStats(GameTime gameTime)
        {
            if (life < 0) life = 0;
            if (energy < 0) energy = 0;

            if (energy > maxEnergy) energy = maxEnergy;

            if (energy != maxEnergy && second.IsReady)
            {
                energy += 1;
                second.Reset();
                forceOrange = false;
            }
        }
    }
}
