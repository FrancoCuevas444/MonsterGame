using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    class BallAttack: Entity
    {
        Point initialPos;
        List<Ball> balls;

        public BallAttack(Point pos)
        {
            initialPos = pos;
            balls = new List<Ball>();
            initBalls();
        }

        public bool IsEmpty
        {
            get { return empty; }
        }
        bool empty = false;

        private void initBalls()
        {
            for(int i = 0; i<8; i++)
            {
                balls.Add(new Ball((BallDir)i, initialPos));
            }
        }

        public override void Update(GameTime gameTime)
        {
            System.Console.WriteLine(empty);
            if (balls.Count == 0) empty = true;
            for(int x = 0; x < balls.Count; x++)
            {
                balls[x].Update(gameTime);
                if (balls[x].IsOutside)
                {
                    balls.RemoveAt(x);
                    return;
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach(Ball ball in balls)
            {
                ball.Draw(sb);
            }
        }
    }
}
