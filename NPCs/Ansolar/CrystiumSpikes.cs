using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Annihilation.NPCs.Ansolar
{
    class CrystiumSpikes : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Spikes");
            Main.projFrames[projectile.type] = 13;
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 32;
            projectile.damage = 37;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (projectile.frame == 0 || projectile.frame == 13)
            {
                projectile.hostile = false;
            }
            else
            {
                projectile.hostile = true;
            }
            projectile.frameCounter++;
            if (projectile.frameCounter >= 10)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= 13)
                {
                    projectile.penetrate = 0;
                }
            }
        }
    }
}
