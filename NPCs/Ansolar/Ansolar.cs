using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Annihilation.NPCs.Ansolar
{
    [AutoloadBossHead]
    class Ansolar : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ansolar, Crystium Guardian");
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 58;
            npc.aiStyle = -1;
            npc.damage = 34;
            npc.defense = 14;
            npc.lifeMax = 4200;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ansolar");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public static bool ThornsReflector = true; //Change to true; for a hard fight.
        private bool init = false;

        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Player player = Main.player[npc.target];
                if (!player.active || player.dead || !Main.dayTime)
                {
                    npc.TargetClosest(false);
                    player = Main.player[npc.target];
                    if (!player.active || player.dead || !Main.dayTime)
                    {
                        npc.velocity = new Vector2(0f, 10f);
                        if (npc.timeLeft > 10)
                        {
                            npc.timeLeft = 10;
                        }
                        return;
                    }
                }
                if (init == false)
                {

                    init = true;
                }
            }
        }

        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            if (ThornsReflector && damage > 1)
            {
                player.Hurt(PlayerDeathReason.ByCustomReason($"{player} was killed trying to hurt Ansolar... Wait this isn't Minecraft?"), npc.damage, 0);
            }
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (ThornsReflector && damage > 1 && projectile.owner == Main.myPlayer)
            {
                Main.player[projectile.owner].Hurt(PlayerDeathReason.ByCustomReason($"{Main.player[projectile.owner].name} was killed trying to hurt Ansolar... Wait this isn't Minecraft?"), npc.damage, 0);
            }
        }
    }
}