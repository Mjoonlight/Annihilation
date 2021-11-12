using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Annihilation.Projectiles
{
    class CrystalSpikes : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Spikes");
            Main.projFrames[projectile.type] = 15;
        }
        public override void SetDefaults()
        {
            projectile.width = 48;
            projectile.height = 42;
            projectile.damage = 26;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (projectile.frame == 0 || projectile.frame == 15)
            {
                projectile.friendly = false;
            }
            else
            {
                projectile.friendly = true;
            }
            projectile.frameCounter++;
            if (projectile.frameCounter >= 10)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= 15)
                {
                    projectile.penetrate = 0;
                }
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
    }
}