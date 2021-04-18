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
    class CrystalBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Spike");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 28;
            projectile.damage = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
        }
        public int type = -1;
        private NPC targer = null;
        public override void AI()
        {
            if (type == -1)
            {
                type = Main.rand.Next(3);
            }
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
            if (killing && projectile.timeLeft <= 1 && targer != null)
            {
                Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(targer.velocity.X, targer.velocity.Y), ModContent.ProjectileType<CrystalBulletStuck>(), 0, 0f, projectile.owner, projectile.whoAmI, targer.whoAmI);
                projectile.timeLeft = 0;
            }
            else if (killing && projectile.timeLeft <= 1)
            {
                Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(0f, 0f), ModContent.ProjectileType<CrystalBulletStuck>(), 0, 0f, projectile.owner, projectile.whoAmI, -1);
                projectile.timeLeft = 0;
            }
        }
        private bool killing = false;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!killing)
            {
                projectile.tileCollide = false;
                projectile.timeLeft = 3;
                killing = true;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!killing)
            {
                targer = target;
                projectile.timeLeft = 3;
                killing = true;
            }
        }
        public override bool PreKill(int timeLeft)
        {
            if (!killing)
            {
                Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, projectile.owner, type);
                Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, projectile.owner, type);
                Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, projectile.owner, type);
            }
            return true;
        }
    }
    class CrystalBulletShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Shard");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 14;
            projectile.damage = 5;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
        }
        private bool init = false;
        public override void AI()
        {
            if (!init)
            {
                if (projectile.ai[0] == 0)
                {
                    projectile.frame += 2;
                    projectile.damage -= 1;
                }
                else if (projectile.ai[0] == 1)
                {
                    projectile.frame += 1;
                    projectile.damage += 1;
                }
                init = true;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(-90f);
        }
    }
    class CrystalBulletStuck : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
        }
        private bool init = false;
        public override void AI()
        {
            if (Main.projectile[(int)projectile.ai[0]].modProjectile is CrystalBullet proj)
            {
                if (!init && proj != null)
                {
                    if (proj.type == 0)
                    {
                        projectile.frame += 2;
                    }
                    else if (proj.type == 1)
                    {
                        projectile.frame += 1;
                    }
                    projectile.rotation = proj.projectile.rotation;
                    init = true;
                }
            }
            if (projectile.ai[1] != -1)
            {
                NPC nerp = Main.npc[(int)projectile.ai[1]];
                projectile.velocity = nerp.velocity;
            }
        }
        public override bool PreKill(int timeLeft)
        {
            if (Main.projectile[(int)projectile.ai[0]].modProjectile is CrystalBullet proj)
            {
                if (proj != null)
                {
                    Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, projectile.owner, proj.type);
                    Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, projectile.owner, proj.type);
                    Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, projectile.owner, proj.type);
                }
            }
            return true;
        }
    }
}
