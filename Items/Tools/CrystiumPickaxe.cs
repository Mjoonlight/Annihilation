using Annihilation.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Annihilation.Items.Tools
{
	public class CrystiumPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystium Pickaxe");
			Tooltip.SetDefault("Can mine meteorite");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 36;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.pick = 50;
			Item.useStyle = ItemUseStyleID.SwingThrow;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
	}
}