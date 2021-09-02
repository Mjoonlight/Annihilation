using Annihilation.Items.Materials;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Annihilation.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CrystiumHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Unfinished");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 7;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Testing";
			player.allDamage -= 0.3f;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CrystiumBar>(), 24);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}