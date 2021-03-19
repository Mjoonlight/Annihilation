using Annihilation.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Magic
{
    public class UmbraBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Umbra Flame Blaster");
        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.magic = true;
            item.width = 36;
            item.height = 42;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.shoot = ModContent.ProjectileType<UmbraFlameCharge>();
            item.shootSpeed = 10f;
            item.channel = true;
        }
    }
}