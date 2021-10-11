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
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 11000;
			item.rare = 6;
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
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
}
	