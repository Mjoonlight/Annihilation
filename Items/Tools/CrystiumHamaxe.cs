using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Annihilation.Items.Tools
{
	public class CrystiumHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystium Hamaxe");
			Tooltip.SetDefault("'It's heavy'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 36;
			Item.height = 34;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.axe = 10;
			Item.hammer = 50;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
	}
}