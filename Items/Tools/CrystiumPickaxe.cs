using Annihilation.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Tools
{
    public class CrystiumPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Pickaxe");
            Tooltip.SetDefault("It's sharp enough to cut meteorite");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.width = 40;
            item.height = 36;
            item.useTime = 20;
            item.useAnimation = 20;
            item.pick = 50;
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
            recipe.AddIngredient(ModContent.ItemType<CrystiumBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}