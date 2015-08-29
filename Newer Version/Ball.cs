using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    enum BallDir
    {
        UP,
        UPRIGHT,
        RIGHT,
        DOWNRIGHT,
        DOWN,
        DOWNLEFT,
        LEFT,
        UPLEFT
    }
    class Ball : DrawableEntity
    {
        BallDir dir;
        int actualSpeed = 25;
        Point speed;
        public Ball(BallDir dir, Point initial) : base(ResourceLoader.ball, initial)
        {
            this.dir = dir;
            speed = new Point(0, 0);
            CalculateSpeed();
        }

        public bool IsOutside
        {
            get { return CheckBounds(); }
        }

        public override void Update(GameTime gameTime)
        {
            rect.Location += speed;
        }

        private void CalculateSpeed()
        {
            switch (dir)
            {
                case BallDir.UP:
                    speed.Y = -actualSpeed;
                    speed.X = 0;
                    return;
                case BallDir.UPRIGHT:
                    speed.Y = -actualSpeed/2;
                    speed.X = actualSpeed/2;
                    return;
                case BallDir.RIGHT:
                    speed.Y = 0;
                    speed.X = actualSpeed;
                    return;
                case BallDir.DOWNRIGHT:
                    speed.Y = actualSpeed/2;
                    speed.X = actualSpeed/2;
                    return;
                case BallDir.DOWN:
                    speed.Y = actualSpeed;
                    speed.X = 0;
                    return;
                case BallDir.DOWNLEFT:
                    speed.Y = actualSpeed/2;
                    speed.X = -actualSpeed/2;
                    return;
                case BallDir.LEFT:
                    speed.Y = 0;
                    speed.X = -actualSpeed;
                    return;
                case BallDir.UPLEFT:
                    speed.Y = -actualSpeed/2;
                    speed.X = -actualSpeed/2;
                    return;
            }
        }

        private bool CheckBounds()
        {
            if (X >= MonsterGame.screenWidth || X <= -rect.Width) return true;
            if (Y >= MonsterGame.screenHeight || Y <= -rect.Height) return true;

            return false;
        }

    }
}
