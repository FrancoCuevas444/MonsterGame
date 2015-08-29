using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MonsterGame
{
    class UITop : DrawableEntity
    {
        AbilityIcon Qicon, Wicon, Eicon;
        Bar lifeBar, energyBar;
        Player player;
        public UITop(Player player) : base (ResourceLoader.UItop, new Microsoft.Xna.Framework.Point(MonsterGame.screenWidth / 2 - ResourceLoader.UItop.Width/2, 0))
        {
            this.player = player;
            Qicon = new AbilityIcon(ResourceLoader.Qicon, rect.Location + new Point(55, 9), player.abilityManager.firstAbility, player.abilityManager.levitating);
            Wicon = new AbilityIcon(ResourceLoader.Wicon, rect.Location + new Point(164, 9), player.abilityManager.secondAbility);
            Eicon = new AbilityIcon(ResourceLoader.Eicon, rect.Location + new Point(272, 9), player.abilityManager.thirdAbility, player.abilityManager.falling);
            lifeBar = new Bar(ResourceLoader.lifeBar, rect.Location + new Point(28, 82), Player.maxLife);
            energyBar = new Bar(ResourceLoader.energyBar, rect.Location + new Point(28, 107), Player.maxEnergy);
        }

        public override void Update(GameTime gameTime)
        {
            Qicon.Update(gameTime,false, (player.Energy <= AbilityManager.qEnergy));
            Wicon.Update(gameTime, false, (player.Energy <= AbilityManager.wEnergy));
            Eicon.Update(gameTime, player.ForceOrange, (player.Energy <= AbilityManager.eEnergy));
            lifeBar.Update(gameTime, player.Life);
            energyBar.Update(gameTime, player.Energy);
        }
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            Qicon.Draw(sb);
            Wicon.Draw(sb);
            Eicon.Draw(sb);
            lifeBar.Draw(sb);
            energyBar.Draw(sb);
        }
    }
}
