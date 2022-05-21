using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Annihilation.NPCs.ProjectileNPCs;
using Terraria.DataStructures;
using Terraria.ID;

namespace Annihilation
{
    class Playaar : ModPlayer
    {
        public bool ChaosCoreT = false;
        public bool ChaosCoreF = false;
        public bool Crystiumites = false;
        private int Crystiumite1 = 1;
        private int Crystiumite2 = 1;
        private int Crystiumite3 = 1;
        private int Crystiumite4 = 1;
        public override void PostUpdate()
        {
            DateTime now = DateTime.Today;
            if (now.Day == 1 && now.Month == 4)
            {
            }
            if (Crystiumites)
            {
                if (NPC.AnyNPCs(ModContent.NPCType<CrystiumiteArt1>()))
                {
                    Crystiumite1 = 300;
                }
                else
                {
                    Crystiumite1--;
                    if (Crystiumite1 <= 0)
                    {
                        NPC.NewNPC((int)(player.Center.X), (int)(player.Center.Y), ModContent.NPCType<CrystiumiteArt1>(), 0, Main.LocalPlayer.whoAmI);
                    }
                }
                if (NPC.AnyNPCs(ModContent.NPCType<CrystiumiteArt2>()))
                {
                    Crystiumite2 = 300;
                }
                else
                {
                    Crystiumite2--;
                    if (Crystiumite2 <= 0)
                    {
                        NPC.NewNPC((int)(player.Center.X), (int)(player.Center.Y), ModContent.NPCType<CrystiumiteArt2>(), 0, Main.LocalPlayer.whoAmI);
                    }
                }
                if (NPC.AnyNPCs(ModContent.NPCType<CrystiumiteArt3>()))
                {
                    Crystiumite3 = 300;
                }
                else
                {
                    Crystiumite3--;
                    if (Crystiumite3 <= 0)
                    {
                        NPC.NewNPC((int)(player.Center.X), (int)(player.Center.Y), ModContent.NPCType<CrystiumiteArt3>(), 0, Main.LocalPlayer.whoAmI);
                    }
                }
                if (NPC.AnyNPCs(ModContent.NPCType<CrystiumiteArt4>()))
                {
                    Crystiumite4 = 300;
                }
                else
                {
                    Crystiumite4--;
                    if (Crystiumite4 <= 0)
                    {
                        NPC.NewNPC((int)(player.Center.X), (int)(player.Center.Y), ModContent.NPCType<CrystiumiteArt4>(), 0, Main.LocalPlayer.whoAmI);
                    }
                }
            }
        }
        public override void ResetEffects()
        {
            ChaosCoreT = false;
            ChaosCoreF = false;
            Crystiumites = false;
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
