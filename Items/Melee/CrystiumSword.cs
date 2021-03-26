using Annihilation.Items.Materials;
using Annihilation.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Melee
{
	public class CrystiumSword : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Sword");
            Tooltip.SetDefault("Swings create a blast of crystals");

        }
		public override void SetDefaults()
        {
			item.damage = 16;
			item.melee = true;
			item.width = 46;
            item.height = 56;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = false;
			item.knockBack = 6f;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SwordCrystal>();
            item.shootSpeed = 8f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(80));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CrystiumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
