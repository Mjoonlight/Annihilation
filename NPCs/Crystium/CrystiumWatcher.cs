using Annihilation.Items.Materials;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs.Crystium
{
    class CrystiumWatcher : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Watcher");
            Main.npcFrameCount[npc.type] = 3;
        }
        public override void SetDefaults()
        {
            npc.width = 54;
            npc.height = 30;
            npc.aiStyle = -1;
            npc.damage = 16;
            npc.defense = 8;
            npc.lifeMax = 85;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
        }
        private int timey = 0;
        private int timey2 = 0;
        private float beep = 560f;
        private int deltaTime = 0;
        private int finalTouch = 0;
        private float theValue = 0;
        private Vector2 fakePlayer = new Vector2(0, 0);
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
                        npc.velocity = new Vector2(0f, -10f);
                        if (npc.timeLeft > 10)
                        {
                            npc.timeLeft = 10;
                        }
                        return;
                    }
                }
                if (npc.ai[0] == 0)
                {
                    npc.ai[0] = 3;
                    npc.ai[1] = Main.rand.Next(8) + 1;
                }
                if (npc.ai[0] == 1)
                {
                    timey--;
                    deltaTime++;
                }
                if (npc.ai[0] == 2)
                {
                    timey++;
                    deltaTime++;
                }
                if (npc.ai[0] == 3 && beep >= 140f)
                {
                    if (beep > 140f)
                    {
                        beep -= 5f;
                    }
                    if (beep <= 140f && deltaTime == 0)
                    {
                        npc.ai[0] = Main.rand.Next(2) + 1;
                    }
                }
                else if (deltaTime >= 360 && npc.ai[0] != 3)
                {
                    npc.ai[0] = 4;
                    finalTouch++;
                    if (finalTouch >= 30)
                    {
                        beep -= 5f;
                        if (beep <= -560f)
                        {
                            finalTouch = 0;
                            deltaTime = 0;
                            npc.ai[0] = 3;
                            beep = 560;
                        }
                    }
                }
                if (npc.ai[1] == 1)
                {
                    timey2 = 0;
                }
                if (npc.ai[1] == 2)
                {
                    timey2 = 90;
                }
                if (npc.ai[1] == 3)
                {
                    timey2 = 180;
                }
                if (npc.ai[1] == 4)
                {
                    timey2 = 270;
                }
                if (npc.ai[1] == 5)
                {
                    timey2 = 45;
                }
                if (npc.ai[1] == 6)
                {
                    timey2 = 135;
                }
                if (npc.ai[1] == 7)
                {
                    timey2 = 225;
                }
                if (npc.ai[1] == 8)
                {
                    timey2 = 315;
                }
                if (finalTouch < 30)
                {
                    npc.rotation = (player.Center - npc.Center).ToRotation();
                    theValue = npc.rotation;
                    npc.Center = player.Center + Vector2.One.RotatedBy((0.0175 * timey) - (MathHelper.ToRadians(timey2))) * beep;
                    fakePlayer = player.Center;
                }
                else
                {
                    npc.rotation = theValue;
                    npc.Center = fakePlayer + Vector2.One.RotatedBy((0.0175 * timey) - (MathHelper.ToRadians(timey2))) * beep;
                }
                npc.frameCounter++;
                if (npc.frameCounter >= 5)
                {
                    npc.frameCounter = 0;
                    npc.frame.Y += 30;
                    if (npc.frame.Y == 90)
                    {
                        npc.frame.Y = 0;
                    }
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Cavern.Chance * 0.2f;
        }
        public override void NPCLoot()
        {
            int ammount = Main.rand.Next(0, 3) + 4;
            Item.NewItem(npc.getRect(), ModContent.ItemType<CrystiumOre>(), ammount);
        }
    }
}
