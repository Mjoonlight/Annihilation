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
            projectile.damage = 26;
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
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
    }
    class Darkflame2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            DisplayName.SetDefault("Darkflame");
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.damage = 26;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
        }
        private bool init = false;
        public override void AI()
        {
            if (init == false)
            {
                init = true;
            }
            else
            {
                projectile.rotation = projectile.velocity.ToRotation();
            }
            projectile.timeLeft--;
            if (projectile.timeLeft <= 0)
            {
                projectile.Kill();
            }
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.velocity.Y < -5f)
            {
                projectile.velocity.Y *= 0.97f;
            }
            if (projectile.velocity.Y >= -5f && projectile.velocity.Y < 3f)
            {
                projectile.velocity.Y = 3f;
            }
            if (projectile.velocity.Y >= 3f)
            {
                projectile.velocity.Y *= 1.03f;
            }
        }
             public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255); 
    }
}
