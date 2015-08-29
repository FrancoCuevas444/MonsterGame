using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    static class ResourceLoader
    {
        public static Texture2D playerTex, baseTile, ball, UItop, Qicon, Wicon, Eicon, lifeBar, energyBar, selector, cloud, enemy, enemySword, shuriken;
        public static SpriteFont font;
        public static void LoadResources(ContentManager content)
        {
            playerTex = content.Load<Texture2D>("Textures/Player");
            baseTile = content.Load<Texture2D>("Textures/baseTile");
            ball = content.Load<Texture2D>("Textures/ball");
            UItop = content.Load<Texture2D>("Textures/UItop");
            Qicon = content.Load<Texture2D>("Textures/Q");
            Wicon = content.Load<Texture2D>("Textures/W");
            Eicon = content.Load<Texture2D>("Textures/E");
            lifeBar = content.Load<Texture2D>("Textures/lifeBar");
            energyBar = content.Load<Texture2D>("Textures/energyBar");
            selector = content.Load<Texture2D>("Textures/selector");
            cloud = content.Load<Texture2D>("Textures/cloud");
            enemy = content.Load<Texture2D>("Textures/enemy");
            enemySword = content.Load<Texture2D>("Textures/enemy1");
            shuriken = content.Load<Texture2D>("Textures/shuriken");
            font = content.Load<SpriteFont>("myFont");
        }
    }
}
