using Annihilation.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Materials
{
    public class CrystiumRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Rock");
            Tooltip.SetDefault("A crystalline metalic rock");
        }
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
            item.width = 22;
            item.height = 18;
            item.maxStack = 999;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.createTile = ModContent.TileType<CrystiumRockTile>();
        }
    }
}