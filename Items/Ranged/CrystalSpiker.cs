using Annihilation.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Ranged
{
    public class CrystalSpiker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Spiker");
            Tooltip.SetDefault("Fires a Spike that sticks to tiles and Shatters into Smaller Crystals");
        }
        public override void SetDefaults()
        {
            item.damage = 23;
            item.ranged = true;
            item.width = 36;
            item.height = 42;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<CrystalBullet>();
            item.shootSpeed = 10f;
        }
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            mult *= player.bulletDamage;
        }
    }
}