using Annihilation.Items.Materials;
using Annihilation.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Ranged
{
	public class CrystiumBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Bow");
            Tooltip.SetDefault("Shoots a barage of Crystal Spikes every 5th shot");
        }
        public override void SetDefaults()
        {
			item.damage = 21;
			item.ranged = true;
            item.width = 36;
            item.height = 42;
			item.useTime = 32;
			item.useAnimation = 32;
            item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
		}
        private int shots = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            shots++;
            if (shots == 5)
            {
                int numberProjectiles = 2 + Main.rand.Next(3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(45));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<CrystalArrow>(), damage, knockBack, player.whoAmI);
                }
                shots = 0;
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CrystiumBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
