﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs.Megnatar
{
    class Firelaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 18;
            projectile.damage = 25;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 90);
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
    }
}
