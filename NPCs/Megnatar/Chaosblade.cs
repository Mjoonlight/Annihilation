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

namespace Annihilation.NPCs.Megnatar
{
    class Chaosblade1 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Blade");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 32;
            npc.aiStyle = -1;
            npc.damage = 26;
            npc.defense = 15;
            npc.lifeMax = 190;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.spriteDirection = 1;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
            npc.buffImmune[BuffID.Confused] = true;
        }
        private int TheUltimateMemeBec = 5;
        public override void FindFrame(int frameHeight)
        {
            TheUltimateMemeBec--;
            if (TheUltimateMemeBec == 0)
            {
                npc.frame.Y += 32;
                if (npc.frame.Y == 128)
                {
                    npc.frame.Y = 0;
                }
                TheUltimateMemeBec = 5;
            }
        }
        private int TIMER = 0;
        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                TIMER++;
                Player player = Main.player[npc.target];
                if (!player.active || player.dead || Main.dayTime)
                {
                    npc.TargetClosest(false);
                    player = Main.player[npc.target];
                    if (!player.active || player.dead || Main.dayTime)
                    {
                        npc.velocity = new Vector2(0f, 10f);
                        if (npc.timeLeft > 10)
                        {
                            npc.timeLeft = 10;
                        }
                        return;
                    }
                }
                if (TIMER == 90)
                {
                    npc.velocity.X = (player.Center.X - Main.rand.Next(-30, 30) - npc.Center.X) / 80f;
                    npc.velocity.Y = (player.Center.Y - Main.rand.Next(-30, 30) - npc.Center.Y) / 80f;
                    TIMER = 0;
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Vector2 vector12 = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
            Main.spriteBatch.Draw(mod.GetTexture("NPCs/Megnatar/Chaosblade_Glow"), npc.Bottom - Main.screenPosition + new Vector2((0f - (float)Main.npcTexture[npc.type].Width) * npc.scale / 2f + vector12.X * npc.scale, (0f - (float)Main.npcTexture[npc.type].Height) * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector12.Y * npc.scale + 0f + npc.gfxOffY), npc.frame, new Microsoft.Xna.Framework.Color(255 - npc.alpha, 255 - npc.alpha, 255 - npc.alpha, 255 - npc.alpha), npc.rotation, vector12, npc.scale, spriteEffects, 0f);
        }
    }
    class Chaosblade2 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Blade");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 32;
            npc.aiStyle = -1;
            npc.damage = 26;
            npc.defense = 15;
            npc.lifeMax = 190;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.spriteDirection = -1;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
            npc.buffImmune[BuffID.Confused] = true;
        }
        private int TheUltimateMemeBec = 5;
        public override void FindFrame(int frameHeight)
        {
            TheUltimateMemeBec--;
            if (TheUltimateMemeBec == 0)
            {
                npc.frame.Y += 32;
                if (npc.frame.Y == 128)
                {
                    npc.frame.Y = 0;
                }
                TheUltimateMemeBec = 5;
            }
        }
        private int TIMER = 0;
        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                TIMER++;
                Player player = Main.player[npc.target];
                if (!player.active || player.dead || Main.dayTime)
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
                if (TIMER == 90)
                {
                    npc.velocity.X = (player.Center.X - Main.rand.Next(-30, 30) - npc.Center.X) / 80f;
                    npc.velocity.Y = (player.Center.Y - Main.rand.Next(-30, 30) - npc.Center.Y) / 80f;
                    TIMER = 0;
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Vector2 vector12 = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
            Main.spriteBatch.Draw(mod.GetTexture("NPCs/Megnatar/Chaosblade_Glow"), npc.Bottom - Main.screenPosition + new Vector2((0f - (float)Main.npcTexture[npc.type].Width) * npc.scale / 2f + vector12.X * npc.scale, (0f - (float)Main.npcTexture[npc.type].Height) * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector12.Y * npc.scale + 0f + npc.gfxOffY), npc.frame, new Microsoft.Xna.Framework.Color(255 - npc.alpha, 255 - npc.alpha, 255 - npc.alpha, 255 - npc.alpha), npc.rotation, vector12, npc.scale, spriteEffects, 0f);
        }
    }
}
