using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Ranged
{
	public class Invendescant : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Invendesent");
            Tooltip.SetDefault("A Weapon that is Unfinished because the Owner can't think of a use for it" +
                "\nAlso Known As: The Fuck You Gun");
		}
		public override void SetDefaults() {
			item.damage = 10;
			item.ranged = true;
			item.width = 54;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 19f;
			item.useAmmo = AmmoID.Bullet;
		}
    }
}
