using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs.ProjectileNPCs
{
    class CrystiumiteArt1 : ModNPC
    {
        public override string Texture => "Annihilation/NPCs/Ansolar/Crystiumite";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystiumite");
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 34;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 6;
            npc.lifeMax = 120;
            npc.friendly = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
        }
        private int deltaTime = 0;
        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Player player = Main.player[(int)(npc.ai[0])];
                if (player.dead || !player.active || !player.GetModPlayer<Playaar>().Crystiumites)
                {
                    npc.life = 0;
                }
                deltaTime++;
                npc.Center = player.Center + Vector2.One.RotatedBy((0.025 * deltaTime) - (MathHelper.ToRadians(0))) * 90f;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //3hi31mg
            var clr = new Color(255, 255, 255, 255); // full white
            var drawPos = npc.Center - Main.screenPosition;
            var origTexture = Main.npcTexture[npc.type];
            var texture = mod.GetTexture("NPCs/Ansolar/Crystiumite_Glow");
            var orig = npc.frame.Size() / 2f;

            Main.spriteBatch.Draw(origTexture, drawPos, npc.frame, lightColor, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(texture, drawPos, npc.frame, clr, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            if (projectile.hostile)
            {
                return true;
            }
            return false;
        }
        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return false;
        }
        public override bool PreNPCLoot()
        {
            return false;
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.hostile && damage >= 1)
            {
                projectile.penetrate = 0;
            }
        }
    }
    class CrystiumiteArt2 : ModNPC
    {
        public override string Texture => "Annihilation/NPCs/Ansolar/Crystiumite";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystiumite");
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 34;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 6;
            npc.lifeMax = 120;
            npc.friendly = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //3hi31mg
            var clr = new Color(255, 255, 255, 255); // full white
            var drawPos = npc.Center - Main.screenPosition;
            var origTexture = Main.npcTexture[npc.type];
            var texture = mod.GetTexture("NPCs/Ansolar/Crystiumite_Glow");
            var orig = npc.frame.Size() / 2f;

            Main.spriteBatch.Draw(origTexture, drawPos, npc.frame, lightColor, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(texture, drawPos, npc.frame, clr, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            return false;
        }
        private int deltaTime = 0;
        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Player player = Main.player[(int)(npc.ai[0])];
                if (player.dead || !player.active || !player.GetModPlayer<Playaar>().Crystiumites)
                {
                    npc.life = 0;
                }
                deltaTime++;
                npc.Center = player.Center + Vector2.One.RotatedBy((0.025 * deltaTime) - (MathHelper.ToRadians(90))) * 90f;
            }
        }
        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            if (projectile.hostile)
            {
                return true;
            }
            return false;
        }
        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return false;
        }
        public override bool PreNPCLoot()
        {
            return false;
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.hostile && damage >= 1)
            {
                projectile.penetrate = 0;
            }
        }
    }
    class CrystiumiteArt3 : ModNPC
    {
        public override string Texture => "Annihilation/NPCs/Ansolar/Crystiumite";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystiumite");
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 34;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 6;
            npc.lifeMax = 120;
            npc.friendly = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //3hi31mg
            var clr = new Color(255, 255, 255, 255); // full white
            var drawPos = npc.Center - Main.screenPosition;
            var origTexture = Main.npcTexture[npc.type];
            var texture = mod.GetTexture("NPCs/Ansolar/Crystiumite_Glow");
            var orig = npc.frame.Size() / 2f;

            Main.spriteBatch.Draw(origTexture, drawPos, npc.frame, lightColor, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(texture, drawPos, npc.frame, clr, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            return false;
        }
        private int deltaTime = 0;
        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Player player = Main.player[(int)(npc.ai[0])];
                if (player.dead || !player.active || !player.GetModPlayer<Playaar>().Crystiumites)
                {
                    npc.life = 0;
                }
                deltaTime++;
                npc.Center = player.Center + Vector2.One.RotatedBy((0.025 * deltaTime) - (MathHelper.ToRadians(180))) * 90f;
            }
        }
        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            if (projectile.hostile)
            {
                return true;
            }
            return false;
        }
        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return false;
        }
        public override bool PreNPCLoot()
        {
            return false;
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.hostile && damage >= 1)
            {
                projectile.penetrate = 0;
            }
        }
    }
    class CrystiumiteArt4 : ModNPC
    {
        public override string Texture => "Annihilation/NPCs/Ansolar/Crystiumite";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystiumite");
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 34;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 6;
            npc.lifeMax = 120;
            npc.friendly = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
        }
        private int deltaTime = 0;
        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Player player = Main.player[(int)(npc.ai[0])];
                if (player.dead || !player.active || !player.GetModPlayer<Playaar>().Crystiumites)
                {
                    npc.life = 0;
                }
                deltaTime++;
                npc.Center = player.Center + Vector2.One.RotatedBy((0.025 * deltaTime) - (MathHelper.ToRadians(270))) * 90f;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //3hi31mg
            var clr = new Color(255, 255, 255, 255); // full white
            var drawPos = npc.Center - Main.screenPosition;
            var origTexture = Main.npcTexture[npc.type];
            var texture = mod.GetTexture("NPCs/Ansolar/Crystiumite_Glow");
            var orig = npc.frame.Size() / 2f;

            Main.spriteBatch.Draw(origTexture, drawPos, npc.frame, lightColor, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(texture, drawPos, npc.frame, clr, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            if (projectile.hostile)
            {
                return true;
            }
            return false;
        }
        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return false;
        }
        public override bool PreNPCLoot()
        {
            return false;
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.hostile && damage >= 1)
            {
                projectile.penetrate = 0;
            }
        }
    }
}
