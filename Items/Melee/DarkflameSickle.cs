using Annihilation.Items.Materials;
using Annihilation.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Annihilation.Items.Melee
{
	public class DarkflameSickle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkflame Sickle");
			Tooltip.SetDefault("Cut enemies with flaming waves");
		}

		public override void SetDefaults()
		{
			item.damage = 17;
			item.melee = true;
			item.width = 40;
			item.height = 34;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 11000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<DarkflameWave>();
			item.shootSpeed = 30f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ChaosFragment>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
}
	