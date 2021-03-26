using Annihilation.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Annihilation.Items.Magic
{
    public class CrystalTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Tome");
            Tooltip.SetDefault("Creates a Orb at the Cursor's position and " +
                "creates Rising Spikes upon contact with blocks");
        }
        public override void SetDefaults()
        {
            item.damage = 26;
            item.magic = true;
            item.width = 34;
            item.height = 28;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.value = 10000;
            item.knockBack = 2f;
            item.rare = ItemRarityID.Green;
            item.mana = 6;
            item.shoot = 10;
            item.shootSpeed = 3f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(new Vector2((Main.MouseScreen.X + Main.screenPosition.X + 5), (Main.MouseScreen.Y + Main.screenPosition.Y + 5)), new Vector2(0, 3), ModContent.ProjectileType<CrystalSpawner>(), 0, knockBack, player.whoAmI, damage);
            return false;
        }
    }
}