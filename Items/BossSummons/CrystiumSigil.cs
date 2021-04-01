using Annihilation.Items.Materials;
using Annihilation.NPCs.Ansolar;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.BossSummons
{
    public class CrystiumSigil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Sigil");
            Tooltip.SetDefault("Summons Ansolar, Crystium Guardian at Day");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }
        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 48;
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
            return Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<Ansolar>());
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Ansolar>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CrystiumBar>(), 20);
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddIngredient(ItemID.ManaCrystal, 3);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CrystiumBar>(), 20);
            recipe.AddIngredient(ItemID.LeadBar, 15);
            recipe.AddIngredient(ItemID.ManaCrystal, 3);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}