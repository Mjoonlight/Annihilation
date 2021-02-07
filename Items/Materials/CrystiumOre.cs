using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Materials
{
    public class CrystiumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Ore");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 26;
            item.maxStack = 999;
            item.value = 100;
            item.rare = ItemRarityID.Green;
        }
    }
}