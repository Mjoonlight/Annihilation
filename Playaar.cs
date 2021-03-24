using Annihilation.NPCs.Megnatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Annihilation.NPCs.Ansolar;
using Terraria.DataStructures;
using Terraria.ID;

namespace Annihilation
{
    class Playaar : ModPlayer
    {
        public bool ChaosCoreT = false;
        public bool ChaosCoreF = false;
        public override void PostUpdate()
        {
            DateTime now = DateTime.Today;
            if (now.Day == 1 && now.Month == 4)
            {
                Megnatar.BulletHell = true;
                Ansolar.ThornsReflector = true;
            }
        }
        public override void ResetEffects()
        {
            ChaosCoreT = false;
            ChaosCoreF = false;
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            DateTime now = DateTime.Today;
            if (Main.rand.Next(0, 20) == 0 && now.Day == 1 && now.Month == 4)
            {
                damageSource = PlayerDeathReason.ByCustomReason($"{player.name} was legally murdered.");
            }
            return true;
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (ChaosCoreT && damage >= 1)
            {
                player.AddBuff(BuffID.OnFire, 180);
            }
            if (ChaosCoreF && damage >= 1)
            {
                foreach (NPC noop in Main.npc)
                {
                    if (noop.Center.X >= player.Center.X - (80 * 16) && noop.Center.X <= player.Center.X + (80 * 16) && noop.Center.Y >= player.Center.Y - (80 * 16) && noop.Center.Y <= player.Center.Y + (80 * 16))
                    {
                        noop.AddBuff(BuffID.OnFire, 180);
                    }
                }
            }
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (ChaosCoreT && damage >= 1)
            {
                player.AddBuff(BuffID.OnFire, 180);
            }
            if (ChaosCoreF && damage >= 1)
            {
                foreach (NPC noop in Main.npc)
                {
                    if (noop.Center.X >= player.Center.X - (80 * 16) && noop.Center.X <= player.Center.X + (80 * 16) && noop.Center.Y >= player.Center.Y - (80 * 16) && noop.Center.Y <= player.Center.Y + (80 * 16))
                    {
                        noop.AddBuff(BuffID.OnFire, 180);
                    }
                }
            }
        }
    }
}
