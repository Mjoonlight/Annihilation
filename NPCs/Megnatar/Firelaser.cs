using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Annihilation.NPCs.Megnatar
{
    class Firelaser : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 10;
            projectile.damage = 26;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}
