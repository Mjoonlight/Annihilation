using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Melee
{
	public class CrystiumSword : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A Sword made of metallic crystals");
		}

		public override void SetDefaults() {
			item.damage = 29; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = false; // sets the damage type to ranged
			item.width = 46; // hitbox width of the item
			item.height = 56; // hitbox height of the item
			item.useTime = 17; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 17; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.SwingThrow; // how you use the item (swinging, holding out, etc)
			item.noMelee = false; //so the item's animation doesn't do damage
			item.knockBack = 6; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item1; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 0; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 0; // the speed of the projectile (measured in pixels per frame)
	
		}

	}
}
