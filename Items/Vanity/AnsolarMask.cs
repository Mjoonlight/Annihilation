using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Annihilation.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class AnsolarMask : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ansolar Mask");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 30;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.vanity = true;
		}
	}
}