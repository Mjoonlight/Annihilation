using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Tools
{
    public class CrystiumPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Pickaxe");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.width = 40;
            item.height = 36;
            item.useTime = 20;
            item.useAnimation = 20;
            item.pick = 80;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
    }
}