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
            npc.width = 50;
            npc.height = 48;
            npc.damage = 25;
            npc.lifeMax = 80;
            npc.defense = 11;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = Item.buyPrice(0, 0, 1, 5);
            npc.knockBackResist = 0f;
            npc.aiStyle = 2;
            animationType = NPCID.DemonEye;
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
<<<<<<< Updated upstream
            {
                return SpawnCondition.Cavern.Chance * 0.05f;
            }
=======
                return SpawnCondition.OverworldNight.Chance * 0.05f;
>>>>>>> Stashed changes
            return 0;
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