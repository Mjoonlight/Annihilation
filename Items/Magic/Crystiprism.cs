using Annihilation.NPCs.ProjectileNPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Magic
{
    public class Crystiprism : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Shield Generator");
        }
        public override void SetDefaults()
        {
            item.damage = 21;
            item.magic = true;
            item.width = 36;
            item.height = 42;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.value = 10000;
            item.knockBack = 0;
            item.rare = ItemRarityID.Green;
            item.mana = 12;
            item.consumable = false;
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)(Main.MouseScreen.X + Main.screenPosition.X), (int)(Main.MouseScreen.Y + Main.screenPosition.Y + 32), ModContent.NPCType<CrystiumShield>());
            return true;
        }
    }
}