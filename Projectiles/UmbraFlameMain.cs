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
    class UmbraFlameMain : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Umbra Flame Main");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 48;
            projectile.height = 18;
            projectile.damage = 25;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 90;
            projectile.penetrate = -1;
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
            projectile.velocity = projectile.velocity / 1.009f;
        }
        public override void Kill(int timeLeft)
        {
            float numberProjectiles = 8;
            float rotation = MathHelper.ToRadians(160);
            projectile.position += (new Vector2(projectile.velocity.X, projectile.velocity.Y));
            for (int i = 0; i < numberProjectiles; i++)
            {
                 Vector2 perturbedSpeed = new Vector2(projectile.velocity.X * 8, projectile.velocity.Y * 8).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                 Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X * 3, perturbedSpeed.Y * 3, ModContent.ProjectileType<UmbraFlameSplit>(), projectile.damage / 1, 1f, projectile.owner);
            }
            foreach (NPC noop in Main.npc)
            {
                 if (noop.Center.X >= projectile.Center.X - (5 * 16) && noop.Center.X <= projectile.Center.X + (5 * 16) && noop. Center.Y >= projectile.Center.Y - (5 * 16) && noop.Center.Y <= projectile.Center.Y + (5 * 16) && !noop.friendly)
                 {
                     noop.AddBuff(BuffID.OnFire, 600);
                 }
            }
            for (int i = 0; i < 17; i++)
            {   
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 200, new Color(255,255,255), 2f);
                Main.dust[dust].velocity = Main.rand.NextVector2Unit() + projectile.velocity * 1f;
            }
            var gore = Terraria.Main.gore[Gore.NewGore(projectile.Center, Vector2.Zero, 61, 1)];
            Main.PlaySound(SoundID.Item14);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(1) == 0)
            {
                target.AddBuff(BuffID.OnFire, 300);
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
    }
}
