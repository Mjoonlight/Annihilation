using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Melee
{
	public class CrystiumSword : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Sword");
		}
		public override void SetDefaults()
        {
			item.damage = 24;
			item.melee = true;
			item.width = 46;
            item.height = 56;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = false;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = 0;
            item.shootSpeed = 4f;
		}
	}
}
