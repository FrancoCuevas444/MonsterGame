using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    class AbilityIcon : DrawableEntity
    {
        bool onCooldown = false, running = false, forceOrange = false, gray;
        Cooldown actual, runningCD;
        public AbilityIcon(Texture2D tex, Point initialPos, Cooldown actual): base(tex, initialPos)
        {
            this.actual = actual;
            runningCD = null;
        }

        public AbilityIcon(Texture2D tex, Point initialPos, Cooldown actual, Cooldown running) : base(tex, initialPos)
        {
            this.actual = actual;
            runningCD = running;
            
        }

        public void Update(GameTime gameTime, bool forceOrange = false, bool gray = false)
        {
            this.forceOrange = forceOrange;
            this.gray = gray;
            if (actual.IsReady) onCooldown = false;
            if (!actual.IsReady) onCooldown = true;

            if(runningCD != null)
            {
                if (runningCD.IsReady) running = false;
                else running = true;
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            if (onCooldown)
            {
                color = Color.Aqua;
            }
            else if (running || forceOrange)
                color = Color.Orange;
            else if (gray)
            {
                color = Color.Gray;
            }
            else
                color = Color.White;

            base.Draw(sb);
            if (onCooldown) {
                Vector2 temp = ResourceLoader.font.MeasureString(actual.Current.ToString());
                sb.DrawString(ResourceLoader.font, actual.Current.ToString(), new Vector2(rect.Center.X - temp.X/2, rect.Center.Y - temp.Y/2), Color.White);
            }
            if (runningCD != null && running && !runningCD.IsReady)
            {
                Vector2 temp = ResourceLoader.font.MeasureString(runningCD.Current.ToString());
                sb.DrawString(ResourceLoader.font, runningCD.Current.ToString(), new Vector2(rect.Center.X - temp.X / 2, rect.Center.Y - temp.Y / 2), Color.White);
            }

        }

    }
}
