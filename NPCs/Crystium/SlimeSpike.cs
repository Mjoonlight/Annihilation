using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Annihilation.NPCs.Crystium
{
    class SlimeSpike : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Slime Spike");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 24;
            projectile.damage = 22;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
        }
        private int type = Main.rand.Next(3);
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                if (type == 0)
                {
                    projectile.damage -= 3;
                    projectile.frame += 2;
                }
                else if (type == 1)
                {
                    projectile.damage += 4;
                    projectile.frame += 1;
                }
                projectile.ai[0] = 1;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(-90f);
            projectile.velocity.Y += 0.15f;
        }
    }
}
