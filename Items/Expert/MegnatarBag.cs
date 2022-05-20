using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Annihilation.Items.Materials;
using Annihilation.Items.Magic;
using Annihilation.Items.Summoner;
using Annihilation.Items.Vanity;
using Annihilation.Items.Accessories;

namespace Annihilation.Items.Expert
{
	public class MegnatarBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Consumable\nRight Click to open");
		}


		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.rare = -2;

			item.maxStack = 30;

			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}
		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(2, 5));
			player.QuickSpawnItem(ModContent.ItemType<ChaosFragment>(), Main.rand.Next(13, 36));

			int[] lootTable = {
				ModContent.ItemType<TheBlackout>(),
				ModContent.ItemType<ChaosCore>(),
				ModContent.ItemType<UmbraBlaster>(),
				ModContent.ItemType<DestroyerRemnant>()
			};
			int loot = Main.rand.Next(lootTable.Length);
			player.QuickSpawnItem(lootTable[loot]);

			if (Main.rand.NextDouble() < 1d / 7)
				player.QuickSpawnItem(ModContent.ItemType<MegnatarMask>());
		}
	}
}
