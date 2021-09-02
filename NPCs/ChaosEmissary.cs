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
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 0, 1, 5);
            npc.knockBackResist = 0f;
            npc.aiStyle = 2;
            aiType = NPCID.DemonEye;
            animationType = NPCID.DemonEye;
            npc.noGravity = true;
            npc.boss = false;
            npc.netAlways = true;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 150);
        }
        public override void NPCLoot()
        {
            int ammount = Main.rand.Next(0, 3) + 4;
            Item.NewItem(npc.getRect(), ModContent.ItemType<ChaosFragment>(), ammount);
        }
    }
}