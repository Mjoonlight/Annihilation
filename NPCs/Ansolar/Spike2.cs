using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs.Ansolar
{
    class Spike2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Shard");
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 28;
            projectile.damage = 38;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (projectile.ai[0] == 1)
            {
                projectile.damage = 19;
                projectile.ai[0] = 0;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(-90f);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27);
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
    }
}
