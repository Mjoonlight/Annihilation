using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Accessories
{
    public class CrystArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Artifact");
            Tooltip.SetDefault("Summons upto 4 Crystiumites to protect you");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<Playaar>().Crystiumites = true;
        }
    }
}