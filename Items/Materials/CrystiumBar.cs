using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Materials
{
    public class CrystiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Bar");
            Tooltip.SetDefault("Crystals seem to grow out from the metallic bar");
        }
        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 28;
            item.maxStack = 999;
            item.value = 100;
            item.rare = ItemRarityID.Green;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CrystiumOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}