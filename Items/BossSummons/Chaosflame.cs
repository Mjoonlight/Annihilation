using Annihilation.Items.Materials;
using Annihilation.NPCs.Megnatar;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.BossSummons
{
    public class Chaosflame : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Flame");
            Tooltip.SetDefault("Summons Megnatar, Chaos Bringer at Night");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 36;
            item.maxStack = 30;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<Megnatar>());
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Megnatar>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 5);
            recipe.AddIngredient(ItemID.DemoniteOre, 10);
            recipe.AddIngredient(ModContent.ItemType<ChaosFragment>(), 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 5);
            recipe.AddIngredient(ModContent.ItemType<ChaosFragment>(), 10);
            recipe.AddIngredient(ItemID.CrimtaneOre, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}