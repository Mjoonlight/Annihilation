using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Ranged
{
	public class CrystiumBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Bow");
        }
        public override void SetDefaults()
        {
			item.damage = 19;
			item.ranged = true;
            item.width = 36;
            item.height = 42;
			item.useTime = 16;
			item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
		}
	}
}
