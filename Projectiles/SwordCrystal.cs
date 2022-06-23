using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Annihilation.Projectiles
{
    class SwordCrystal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Spike");
            Main.projFrames[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 32;
            Projectile.damage = 10;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
	    Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
        }
        private int type = Main.rand.Next(3);
        public override void AI()
        {
            if (Projectile.ai[0] == 0)
            {
                if (type == 0)
                {
                    Projectile.damage -= 3;
                    Projectile.frame += 2;
                }
                else if (type == 1)
                {
                    Projectile.damage += 4;
                    Projectile.frame += 1;
                }
                Projectile.ai[0] = 1;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(-90f);
        }
        public override void Kill(int timeLeft)
        {
		SoundEngine.PlaySound(SoundID.Item27, Projectile.Center);
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
    }
}
