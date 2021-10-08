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

namespace Annihilation.Projectiles
{
    class DarkflameWave : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 18;
            projectile.damage = 16;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            projectile.rotation += 0.9f * (float)projectile.direction;
            projectile.velocity = projectile.velocity * 0.9f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(5) == 0)
            {
                target.AddBuff(BuffID.OnFire, 90);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 17; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 200, new Color(255, 255, 255), 2f);
                Main.dust[dust].velocity = Main.rand.NextVector2Unit() * 2f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);

    }
}
