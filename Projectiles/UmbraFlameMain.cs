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
            projectile.damage = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 90;
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
        public override bool PreKill(int timeLeft)
        {
            if (timeLeft == 0)
            {
                float numberProjectiles = 5;
                float rotation = MathHelper.ToRadians(45);
                projectile.position += Vector2.Normalize(new Vector2(projectile.velocity.X * 3, projectile.velocity.Y * 3)) * 45f;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X * 3, projectile.velocity.Y * 3).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X * 3, perturbedSpeed.Y * 3, ModContent.ProjectileType<UmbraFlameSplit>(), 7, 1f, projectile.owner);
                }
            }
            return true;
        }
    }
}
