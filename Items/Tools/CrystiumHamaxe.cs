using Annihilation.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Tools
{
    public class CrystiumHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Hamaxe");
            Tooltip.SetDefault("It's heavy");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.width = 36;
            item.height = 34;
            item.useTime = 20;
            item.useAnimation = 20;
            item.axe = 10;
            item.hammer = 50;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CrystiumBar>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}