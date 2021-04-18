using Annihilation.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Materials
{
    public class CrystiumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Ore");
            Tooltip.SetDefault("A strange metal with crystals forming out of it");
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
            item.width = 34;
            item.height = 26;
            item.maxStack = 999;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.createTile = ModContent.TileType<CrystiumOreTile>();
        }
    }
}