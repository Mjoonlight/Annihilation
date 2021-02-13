using Annihilation.Buffs;
using Annihilation.Projectiles.Minions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Items.Summoner
{
    class TheBlackout : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Blackout");
            Tooltip.SetDefault("Summons a Mini Megnatar to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 13;
            item.summon = true;
            item.width = 40;
            item.height = 46;
            item.mana = 12;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<TheBlackoutPro>();
            item.buffType = ModContent.BuffType<BlackoutBuff>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2);
            position = Main.MouseWorld;
            return true;
        }
    }
}
