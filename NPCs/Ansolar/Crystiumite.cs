using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    class Crystiumite : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystiumite");
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 34;
            npc.aiStyle = -1;
            npc.damage = 29;
            npc.defense = 6;
            npc.lifeMax = 120;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
        }
        private int bop = 0;
        private int aa = 300 + (Main.rand.Next(0, 61) * 10);
        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Player player = Main.player[npc.target];
                if (!player.active || player.dead || !Main.dayTime)
                {
                    npc.TargetClosest(false);
                    player = Main.player[npc.target];
                    if (!player.active || player.dead || !Main.dayTime)
                    {
                        npc.velocity = new Vector2(0f, 10f);
                        if (npc.timeLeft > 10)
                        {
                            npc.timeLeft = 10;
                        }
                        return;
                    }
                }
                if (!NPC.AnyNPCs(ModContent.NPCType<Ansolar>()))
                {
                    npc.life = 0;
                }
                aa--;
                int type = Main.rand.Next(0, 4);
                if (aa <= 0)
                {
                    if (type == 1)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y) / 60f, ModContent.ProjectileType<Spike1>(), npc.damage / 3, 1, 255, 1);
                    }
                    else if (type == 2)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y) / 60f, ModContent.ProjectileType<Spike2>(), npc.damage / 3, 1, 255, 1);
                    }
                    else
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(player.Center.X - npc.Center.X, player.Center.Y - npc.Center.Y) / 60f, ModContent.ProjectileType<Spike3>(), npc.damage / 3, 1, 255, 1);
                    }
                    aa = 300 + (Main.rand.Next(0, 61) * 10);
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 1)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 2)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 180;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 3)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 120;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 240;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 4)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 90;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 180;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = 270;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 5)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 72;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 144;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = 216;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = 288;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 6)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 60;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 120;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = 180;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = 240;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = 300;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 7)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = (360 / 7) * 1; 
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = (360 / 7) * 2;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = (360 / 7) * 3;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = (360 / 7) * 4;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = (360 / 7) * 5;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = (360 / 7) * 6;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 8)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 45;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 90;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = 135;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = 180;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = 225;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = 270;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = 315;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 9)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 40;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 80;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = 120;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = 160;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = 200;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = 240;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = 280;
                    }
                    if (npc.ai[0] == 9)
                    {
                        bop = 320;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 10)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 36;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 72;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = 108;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = 144;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = 180;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = 216;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = 252;
                    }
                    if (npc.ai[0] == 9)
                    {
                        bop = 298;
                    }
                    if (npc.ai[0] == 10)
                    {
                        bop = 324;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 11)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = (360 / 11) * 1;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = (360 / 11) * 2;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = (360 / 11) * 3;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = (360 / 11) * 4;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = (360 / 11) * 5;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = (360 / 11) * 6;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = (360 / 11) * 7;
                    }
                    if (npc.ai[0] == 9)
                    {
                        bop = (360 / 11) * 8;
                    }
                    if (npc.ai[0] == 10)
                    {
                        bop = (360 / 11) * 9;
                    }
                    if (npc.ai[0] == 11)
                    {
                        bop = (360 / 11) * 10;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 12)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 30;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 60;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = 90;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = 120;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = 150;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = 180;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = 210;
                    }
                    if (npc.ai[0] == 9)
                    {
                        bop = 240;
                    }
                    if (npc.ai[0] == 10)
                    {
                        bop = 270;
                    }
                    if (npc.ai[0] == 11)
                    {
                        bop = 300;
                    }
                    if (npc.ai[0] == 12)
                    {
                        bop = 330;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 13)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = (360 / 13) * 1;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = (360 / 13) * 2;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = (360 / 13) * 3;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = (360 / 13) * 4;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = (360 / 13) * 5;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = (360 / 13) * 6;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = (360 / 13) * 7;
                    }
                    if (npc.ai[0] == 9)
                    {
                        bop = (360 / 13) * 8;
                    }
                    if (npc.ai[0] == 10)
                    {
                        bop = (360 / 13) * 9;
                    }
                    if (npc.ai[0] == 11)
                    {
                        bop = (360 / 13) * 10;
                    }
                    if (npc.ai[0] == 12)
                    {
                        bop = (360 / 13) * 11;
                    }
                    if (npc.ai[0] == 13)
                    {
                        bop = (360 / 13) * 12;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 14)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = (360 / 14) * 1;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = (360 / 14) * 2;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = (360 / 14) * 3;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = (360 / 14) * 4;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = (360 / 14) * 5;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = (360 / 14) * 6;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = (360 / 14) * 7;
                    }
                    if (npc.ai[0] == 9)
                    {
                        bop = (360 / 14) * 8;
                    }
                    if (npc.ai[0] == 10)
                    {
                        bop = (360 / 14) * 9;
                    }
                    if (npc.ai[0] == 11)
                    {
                        bop = (360 / 14) * 10;
                    }
                    if (npc.ai[0] == 12)
                    {
                        bop = (360 / 14) * 11;
                    }
                    if (npc.ai[0] == 13)
                    {
                        bop = (360 / 14) * 12;
                    }
                    if (npc.ai[0] == 14)
                    {
                        bop = (360 / 14) * 13;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 15)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = 24;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = 48;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = 72;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = 96;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = 120;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = 144;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = 168;
                    }
                    if (npc.ai[0] == 9)
                    {
                        bop = 192;
                    }
                    if (npc.ai[0] == 10)
                    {
                        bop = 216;
                    }
                    if (npc.ai[0] == 11)
                    {
                        bop = 240;
                    }
                    if (npc.ai[0] == 12)
                    {
                        bop = 264;
                    }
                    if (npc.ai[0] == 13)
                    {
                        bop = 288;
                    }
                    if (npc.ai[0] == 14)
                    {
                        bop = 312;
                    }
                    if (npc.ai[0] == 15)
                    {
                        bop = 336;
                    }
                }
                if (NPC.CountNPCS(ModContent.NPCType<Crystiumite>()) == 16)
                {
                    if (npc.ai[0] == 1)
                    {
                        bop = 0;
                    }
                    if (npc.ai[0] == 2)
                    {
                        bop = (360 / 16) * 1;
                    }
                    if (npc.ai[0] == 3)
                    {
                        bop = (360 / 16) * 2;
                    }
                    if (npc.ai[0] == 4)
                    {
                        bop = (360 / 16) * 3;
                    }
                    if (npc.ai[0] == 5)
                    {
                        bop = (360 / 16) * 4;
                    }
                    if (npc.ai[0] == 6)
                    {
                        bop = (360 / 16) * 5;
                    }
                    if (npc.ai[0] == 7)
                    {
                        bop = (360 / 16) * 6;
                    }
                    if (npc.ai[0] == 8)
                    {
                        bop = (360 / 16) * 7;
                    }
                    if (npc.ai[0] == 9)
                    {
                        bop = (360 / 16) * 8;
                    }
                    if (npc.ai[0] == 10)
                    {
                        bop = (360 / 16) * 9;
                    }
                    if (npc.ai[0] == 11)
                    {
                        bop = (360 / 16) * 10;
                    }
                    if (npc.ai[0] == 12)
                    {
                        bop = (360 / 16) * 11;
                    }
                    if (npc.ai[0] == 13)
                    {
                        bop = (360 / 16) * 12;
                    }
                    if (npc.ai[0] == 14)
                    {
                        bop = (360 / 16) * 13;
                    }
                    if (npc.ai[0] == 15)
                    {
                        bop = (360 / 16) * 14;
                    }
                    if (npc.ai[0] == 1)
                    {
                        bop = (360 / 16) * 15;
                    }
                }
                NPC npcmain = Main.npc[(int)npc.ai[1]];
                if (npcmain != null)
                {
                    Ansolar ans = (Ansolar)npcmain.modNPC;
                    if (ans != null)
                    {
                        npc.Center = player.Center + Vector2.One.RotatedBy((0.025 * ans.DeltaTime) - (MathHelper.ToRadians(bop))) * 120f;
                    }
                }
            }
        }
    }
}
