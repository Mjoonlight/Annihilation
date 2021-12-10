using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Projectiles
{
    class UmbraFlameSplit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Umbra Flame Charge");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 10;
            projectile.damage = 15;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 3600;
            projectile.penetrate = 3;
        }
        public override void AI()
        {
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            projectile.rotation = projectile.velocity.ToRotation();
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, 0f, 200, new Color(255, 255, 255), 2f);
                Main.dust[dust].velocity = Main.rand.NextVector2Unit() + projectile.velocity * 0.3f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
    }
}
