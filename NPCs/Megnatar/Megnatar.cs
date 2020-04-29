using Microsoft.Xna.Framework;
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
    [AutoloadBossHead]
    class Megnatar : ModNPC
    {
        private float moveCool
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }
        private int moveTimer = 300;
        private int moveTime = 60;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Megnatar, Chaos Bringer");
            Main.npcFrameCount[npc.type] = 7;
        }
        public override void SetDefaults()
        {
            npc.width = 142;
            npc.height = 128;
            npc.aiStyle = -1;
            npc.damage = 26;
            npc.defense = 10;
            npc.lifeMax = 3000;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
            npc.buffImmune[BuffID.Confused] = true;
            music = MusicID.Boss2;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
        private int TheUltimateMemeBec = 5;
        public override void FindFrame(int frameHeight)
        {
            TheUltimateMemeBec--;
            if (TheUltimateMemeBec == 0)
            {
                npc.frame.Y += 128;
                if (npc.frame.Y == 896)
                {
                    npc.frame.Y = 0;
                }
                TheUltimateMemeBec = 5;
            }
        }
        public override void AI()
        {
            if (Main.netMode != 1 && npc.localAI[0] == 0f)
            {
                Player player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.TargetClosest(false);
                    player = Main.player[npc.target];
                    if (!player.active || player.dead)
                    {
                        npc.velocity = new Vector2(0f, 10f);
                        if (npc.timeLeft > 10)
                        {
                            npc.timeLeft = 10;
                        }
                        return;
                    }
                }
                moveCool -= 1f;
                if (Main.netMode != 1 && moveCool <= 0f)
                {
                    npc.TargetClosest(false);
                    player = Main.player[npc.target];
                    moveCool = (float)moveTime + (float)Main.rand.Next(100);
                    npc.velocity.X = ((player.Center.X - (float)(Main.rand.Next(-100,100)))- npc.Center.X) / moveCool;
                    npc.velocity.Y = ((player.Center.Y - (float)(Main.rand.Next(200, 400))) - npc.Center.Y) / moveCool;
                    npc.netUpdate = true;
                }
                if (Vector2.Distance(Main.player[npc.target].position, npc.position) > 300f)
                {
                    moveTimer--;
                }
                else
                {
                    moveTimer += 10;
                    if (moveTime >= 300 && moveTimer > 60)
                    {
                        moveTimer = 60;
                    }
                }
                if (moveTimer <= 0)
                {
                    moveTimer += 60;
                    moveTime -= 10;
                    if (moveTime < 100)
                    {
                        moveTime = 100;
                        moveTimer = 0;
                    }
                    npc.netUpdate = true;
                }
                else if (moveTimer > 60)
                {
                    moveTimer -= 60;
                    moveTime += 10;
                    npc.netUpdate = true;
                }
            }
        }
    }
}
