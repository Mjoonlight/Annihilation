using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Accessories
{
    public class ChaosCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of Chaos");
            Tooltip.SetDefault("A Core that burns brighter then your hand" +
                "\nRaises Defense and Health at the cost of lighting you OnFire when hit" +
                "\nToggle Visuals for an opposite effect towards your enemies");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (hideVisual)
            {
                player.statDefense -= 10;
                player.statLifeMax2 -= 30;
                player.GetModPlayer<Playaar>().ChaosCoreF = true;
            }
            else
            {
                player.statDefense += 10;
                player.statLifeMax2 += 30;
                player.GetModPlayer<Playaar>().ChaosCoreT = true;
            }
        }
    }
}