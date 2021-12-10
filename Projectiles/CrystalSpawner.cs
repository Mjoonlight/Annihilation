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
    class CrystalSpawner : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Spawner");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.damage = 0;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 3600;
        }
        private bool tileColider = false;
        public override void AI()
        {
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 2)
                {
                    projectile.frame = 0;
                }
            }
            projectile.velocity.Y = 16f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            tileColider = true;
            return true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27);
            if (tileColider)
            {
                Projectile.NewProjectile(new Vector2(projectile.Center.X + (projectile.width / 2) + 16, projectile.Center.Y - 4), new Vector2(0, 0), ModContent.ProjectileType<CrystalSpikes>(), (int)(projectile.ai[0]) / 3, 2f, projectile.owner);
                Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y - 4), new Vector2(0, 0), ModContent.ProjectileType<CrystalSpikes>(), (int)(projectile.ai[0]) / 3, 2f, projectile.owner);
                Projectile.NewProjectile(new Vector2(projectile.Center.X - (projectile.width / 2) - 16, projectile.Center.Y - 4), new Vector2(0, 0), ModContent.ProjectileType<CrystalSpikes>(), (int)(projectile.ai[0]) / 3, 2f, projectile.owner);
            }
        }
    }
}