using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Annihilation.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class MegnatarMask : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Megnatar Mask");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
		}
	}
}