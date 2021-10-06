using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Accessories
{
    public class DestroyerRemnant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Destroyer Remnant");
            Tooltip.SetDefault("Provides a boost based on the current held item's damage type" +
                "\nMelee gives you Health and Defense" +
                "\nRanged gives you Movement and Jump Speed" +
                "\nMagic gives you Life Regen and Mana Regen" +
                "\nSummon gives you Extra Minions and Turrets");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 34;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.HeldItem.melee)
            {
                player.statDefense += 5;
                player.statLifeMax2 += 15;
            }
            if (player.HeldItem.ranged)
            {
                player.moveSpeed *= 1.25f;
                player.jumpSpeedBoost *= 1.25f;
            }
            if (player.HeldItem.magic)
            {
                player.lifeRegen += 10;
                player.manaRegen += 10;
            }
            if (player.HeldItem.summon)
            {
                player.maxMinions += 2;
                player.maxTurrets += 2;
            }
        }
    }
}