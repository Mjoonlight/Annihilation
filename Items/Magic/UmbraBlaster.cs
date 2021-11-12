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
            Tooltip.SetDefault("Hold to charge and shoot a powerful fireball that splits into more");
        }
        public override void SetDefaults()
        {
            item.damage = 26;
            item.magic = true;
            item.width = 28;
            item.height = 26;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.mana = 12;
            item.shoot = ModContent.ProjectileType<UmbraFlameCharge>();
            item.shootSpeed = 10f;
            item.channel = true;
        }
    }
}