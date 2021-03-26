using Annihilation.NPCs.ProjectileNPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Magic
{
    public class Crystiprism : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Shield Generator");
            Tooltip.SetDefault("Summons a shield that reflects projectiles");
        }
        public override void SetDefaults()
        {
            item.damage = 21;
            item.magic = true;
            item.width = 26;
            item.height = 34;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.value = 10000;
            item.knockBack = 0;
            item.rare = ItemRarityID.Green;
            item.mana = 20;
            item.consumable = false;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(BuffID.ManaSickness))
            {
                return false;
            }
            return true;
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)(Main.MouseScreen.X + Main.screenPosition.X), (int)(Main.MouseScreen.Y + Main.screenPosition.Y + 32), ModContent.NPCType<CrystiumShield>());
            return true;
        }
    }
}