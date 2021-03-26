using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs.ProjectileNPCs
{
    class CrystiumShield : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Shield");
            Main.npcFrameCount[npc.type] = 16;
        }
        public override void SetDefaults()
        {
            npc.width = 52;
            npc.height = 52;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 1;
            npc.friendly = true;
            npc.immortal = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
        }
        public override void AI()
        {
            if (++npc.frameCounter >= 5)
            {
                npc.frameCounter = 0;
                npc.frame.Y += 52;
                if (npc.frame.Y >= 832)
                {
                    npc.immortal = false;
                    npc.life = 0;
                }
            }
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.hostile)
            {
                if (projectile.penetrate != -1)
                {
                    projectile.penetrate += 1;
                }
                projectile.friendly = true;
                projectile.hostile = false;
                projectile.damage = 21;
                projectile.velocity.X -= projectile.velocity.X * 2;
                projectile.velocity.Y -= projectile.velocity.Y * 2;
            }
        }
        public override bool PreNPCLoot()
        {
            return false;
        }
    }
}
