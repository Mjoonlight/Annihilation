using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs.Megnatar
{
    class Darkflame : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 10;
            projectile.damage = 22;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int startY = frameHeight * projectile.frame;
            Vector2 vector12 = new Vector2((float)(Main.projectileTexture[projectile.type].Width / 2), (float)(Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type] / 2));
            Main.spriteBatch.Draw(mod.GetTexture("NPCs/Megnatar/Darkflame_Glow"), projectile.Bottom - Main.screenPosition + new Vector2((0f - (float)Main.projectileTexture[projectile.type].Width) * projectile.scale / 2f + vector12.X * projectile.scale, (0f - (float)Main.projectileTexture[projectile.type].Height) * projectile.scale / (float)Main.projFrames[projectile.type] + 4f + vector12.Y * projectile.scale + 0f + projectile.gfxOffY), new Rectangle(0, startY, texture.Width, frameHeight), new Microsoft.Xna.Framework.Color(255 - projectile.alpha, 255 - projectile.alpha, 255 - projectile.alpha, 255 - projectile.alpha), projectile.rotation, vector12, projectile.scale, spriteEffects, 0f);
        }
    }
    class Darkflame2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.Name = "Darkflame";
            projectile.width = 22;
            projectile.height = 10;
            projectile.aiStyle = 68;
            projectile.damage = 26;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
            aiType = ProjectileID.MolotovFire;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int startY = frameHeight * projectile.frame;
            Vector2 vector12 = new Vector2((float)(Main.projectileTexture[projectile.type].Width / 2), (float)(Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type] / 2));
            Main.spriteBatch.Draw(mod.GetTexture("NPCs/Megnatar/Darkflame_Glow"), projectile.Bottom - Main.screenPosition + new Vector2((0f - (float)Main.projectileTexture[projectile.type].Width) * projectile.scale / 2f + vector12.X * projectile.scale, (0f - (float)Main.projectileTexture[projectile.type].Height) * projectile.scale / (float)Main.projFrames[projectile.type] + 4f + vector12.Y * projectile.scale + 0f + projectile.gfxOffY), new Rectangle(0, startY, texture.Width, frameHeight), new Microsoft.Xna.Framework.Color(255 - projectile.alpha, 255 - projectile.alpha, 255 - projectile.alpha, 255 - projectile.alpha), projectile.rotation, vector12, projectile.scale, spriteEffects, 0f);
        }
    }
}
