using System;
using Annihilation.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs
{
    public class ChaosEmissary : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Emissary");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 48;
            npc.height = 50;
            npc.damage = 25;
            npc.lifeMax = 80;
            npc.defense = 11;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = Item.buyPrice(0, 0, 1, 5);
            npc.knockBackResist = 0f;
            npc.aiStyle = 2;
            npc.noGravity = true;
            npc.boss = false;
            npc.netAlways = true;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedBoss1)
            {
                return SpawnCondition.OverworldNight.Chance * 0.05f;
            }
            return 0;
        }

        int ToInt(bool inp) => inp ? 1 : -1;
        const float frameInterval = 10;
        public void Animate()
        {
            var frames = Main.npcFrameCount[npc.type];
            npc.frameCounter += 1/frameInterval;
            int finalFrame = (int)(npc.frameCounter % frames);
            npc.frame.Y = finalFrame * npc.height;
            
            // dust
            Dust dust;
            for (int i = 0; i < 4; i++)
            {
                if (Main.rand.NextFloat() < .25f)
                {
                    dust = Dust.NewDustPerfect(npc.Center + new Vector2(-16, 0).RotatedBy(npc.velocity.ToRotation()) + new Vector2(0, 4) + Utils.NextVector2Unit(Main.rand) * new Vector2(8, 16), DustID.Fire, null, 0, default, 3);
                    dust.noGravity = true;
                }
            }
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
            npc.spriteDirection = ToInt(npc.velocity.X > 0);
            npc.rotation = npc.velocity.ToRotation() + MathHelper.Pi/2;
            Main.NewText(npc.rotation);
        }
        public override void AI()
        {
            Animate();
            Aim();
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