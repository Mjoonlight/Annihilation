using System;
using Annihilation.Items.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs
{
    public class DoomSpinner : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doom Spinner");
        }

        public override void SetDefaults()
        {
            npc.width = 42;
            npc.height = 48;
            npc.damage = 25;
            npc.lifeMax = 80;
            npc.defense = 11;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = Item.buyPrice(0, 0, 1, 5);
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.noGravity = true;
            npc.boss = false;
            npc.netAlways = true;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
            npc.noTileCollide = true;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //3hi31mg
            var clr = new Color(255, 255, 255, 255); // full white
            var drawPos = npc.Center - Main.screenPosition;
            var origTexture = Main.npcTexture[npc.type];
            var texture = mod.GetTexture("NPCs/DoomSpinner_Glow");
            var eyetexture = mod.GetTexture("NPCs/DoomSpinner_Eye");
            var orig = npc.frame.Size() / 2f;

            Main.spriteBatch.Draw(origTexture, drawPos, npc.frame, lightColor, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(texture, drawPos, npc.frame, clr, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(eyetexture, drawPos, npc.frame, clr, 0, orig, npc.scale, SpriteEffects.None, 0f);
            return false;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedBoss1)
            {
                return SpawnCondition.OverworldNight.Chance * 0.05f;
            }
            return 0;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            base.HitEffect(hitDirection, damage);
            if (npc.life <= 0)
            {
                for (int i = 0; i < Main.rand.Next(5, 8); i++)
                {
                    var gore = Terraria.Main.gore[Gore.NewGore(npc.Center, Vector2.Zero, 61, 1)];
                }

                for (int i = 0; i < Main.rand.Next(7, 10); i++)
                {
                        var dust = Terraria.Main.dust[Dust.NewDust(npc.position + Utils.NextVector2Square(Main.rand, -1, 1) * npc.frame.Size(), npc.frame.Width, npc.frame.Height, DustID.Fire, 0, 0, 0, default, 2)];
                }
            }
        }
        public void Aim()
        {
            npc.rotation += npc.velocity.Length() * 0.11f;
        }
        int state = 0;
        public override void AI()
        {
            Aim();
            npc.TargetClosest();
            var target = Main.player[npc.target];
           switch (state)
           {
                case 0:
                    npc.velocity = -(npc.Center - target.Center).SafeNormalize(Vector2.UnitX) * 2;
                    if (Vector2.Distance(npc.Center, target.Center) < 16)
                    {
                        state = 1;
                    }
                    break;
                case 1:
                    npc.velocity = -(npc.Center - target.Center).SafeNormalize(Vector2.UnitX) * 6;
                    if (Vector2.Distance(npc.Center, target.Center) > 16)
                    {
                        state = 2;
                    }
                    break;
                case 2:
                    npc.velocity = (npc.Center - target.Center).SafeNormalize(Vector2.UnitX) * 2;
                    if (Vector2.Distance(npc.Center, target.Center) > 64)
                    {
                        state = 0;
                    }
                    break;
           }


            Dust dust;
            dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 0, new Color(255, 255, 255), 3f)];
            dust.noGravity = true;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 150);
        }
        public override void NPCLoot()
        {
            int ammount = Main.rand.Next(0, 2) + 3;
            Item.NewItem(npc.getRect(), ModContent.ItemType<ChaosFragment>(), ammount);
        }
    }
}