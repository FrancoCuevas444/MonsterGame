using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterGame
{
    class Floor : Entity
    {
        public List<BaseTile> Tiles
        {
            get { return tiles; }
        }
        List<BaseTile> tiles;
        public Floor()
        {
            InitTiles();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (BaseTile tile in tiles) { tile.Update(gameTime); }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (BaseTile tile in tiles) { tile.Draw(sb); }
        }

        public void CheckGrounded(Player player)
        {
            foreach (BaseTile tile in tiles)
            {
                if (tile.Rect.Intersects(player.Rect))
                {
                    player.IsGrounded = true;
                    player.Y = tile.Rect.Y - player.Rect.Width;
                    return;

                }
            }
        }

        private void InitTiles()
        {
            tiles = new List<BaseTile>();
            for (int x = 0; x < 40; x++)
            {
                tiles.Add(new BaseTile(new Point(x * ResourceLoader.baseTile.Width, MonsterGame.screenHeight - ResourceLoader.baseTile.Height)));
            }
        }
    }
}
