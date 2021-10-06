using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Projectiles
{
    class UmbraFlameCharge : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Umbra Flame Charge");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 24;
            projectile.damage = 16;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 3600;
            projectile.alpha = 255;
        }
        private int counter = 0;
        private int chargeLevel = 0;
        public override void AI()
        {
            Player player = Main.player[projectile.owner];

            float num = 1.57079637f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            projectile.ai[0] += 1f;
            int num2 = 0;
            if (projectile.ai[0] >= 30f)
            {
                num2++;
            }
            if (projectile.ai[0] >= 60f)
            {
                num2++;
            }
            if (projectile.ai[0] >= 90f)
            {
                num2++;
            }
            int num3 = 24;
            int num4 = 6;
            projectile.ai[1] += 1f;
            bool flag = false;
            if (projectile.ai[1] >= num3 - num4 * num2)
            {
                projectile.ai[1] = 0f;
                flag = true;
            }
            if (projectile.ai[1] == 1f && projectile.ai[0] != 1f)
            {
                Vector2 vector2 = Vector2.UnitX * 24f;
                vector2 = vector2.RotatedBy(projectile.rotation - 1.57079637f, default);
                Vector2 value = projectile.Center + vector2;
            }
            if (flag && Main.myPlayer == projectile.owner)
            {
                if (player.channel && !player.noItems && !player.CCed)
                {
                    float scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
                    Vector2 vector3 = vector;
                    Vector2 value2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - vector3;
                    if (player.gravDir == -1f)
                    {
                        value2.Y = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - vector3.Y;
                    }
                    Vector2 vector4 = Vector2.Normalize(value2);
                    if (float.IsNaN(vector4.X) || float.IsNaN(vector4.Y))
                    {
                        vector4 = -Vector2.UnitY;
                    }
                    vector4 *= scaleFactor;
                    if (vector4.X != projectile.velocity.X || vector4.Y != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity = vector4;
                }
            }
            projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
            projectile.rotation = projectile.velocity.ToRotation() + num;
            if (projectile.rotation >= MathHelper.ToRadians(360f))
            {
                projectile.rotation -= MathHelper.ToRadians(360f);
            }
            if (projectile.rotation < 0)
            {
                projectile.rotation += MathHelper.ToRadians(360f);
            }
            projectile.direction = projectile.rotation <= MathHelper.ToRadians(180f) && projectile.rotation >= MathHelper.ToRadians(0f) ? 1 : -1;
            projectile.spriteDirection = projectile.direction;
            projectile.timeLeft = 2;
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;

            float num1 = 12f;
            Vector2 vector5 = new Vector2(player.position.X + player.width * 0.5f, player.position.Y + player.height * 0.5f);
            float f1 = Main.mouseX + Main.screenPosition.X - vector5.X;
            float f2 = Main.mouseY + Main.screenPosition.Y - vector5.Y;
            if (player.gravDir == -1.0)
                f2 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector5.Y;
            float num8 = (float)Math.Sqrt(f1 * (double)f1 + f2 * (double)f2);
            float num9;
            if (float.IsNaN(f1) && float.IsNaN(f2) || f1 == 0.0 && f2 == 0.0)
            {
                f1 = player.direction;
                f2 = 0.0f;
                num9 = num1;
            }
            else
                num9 = num1 / num8;
            float SpeedX = f1 * num9;
            float SpeedY = f2 * num9;

            var Vloop = new Vector2(SpeedX, SpeedY).ToRotation() + (projectile.spriteDirection == 1 ? MathHelper.ToRadians(0f) : MathHelper.ToRadians(180f));

            player.itemRotation = Vloop;

            counter++;

            if (counter >= 90)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 93, 1, 1f);
                chargeLevel = 2;
            }

            else if (counter >= 10)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 13);
                chargeLevel = 1;
            }

            else if (counter >= 0)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 13, 1, -1f);
                chargeLevel = 0;
            }

            if (!player.channel)
            {
                projectile.Kill();
            }
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            if (projectile.owner == Main.myPlayer)
            {
                float num1 = 12f;
                Vector2 vector2 = new Vector2(player.position.X + player.width * 0.5f, player.position.Y + player.height * 0.5f);
                float f1 = Main.mouseX + Main.screenPosition.X - vector2.X;
                float f2 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
                if (player.gravDir == -1.0)
                    f2 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector2.Y;
                float num4 = (float)Math.Sqrt(f1 * (double)f1 + f2 * (double)f2);
                float num5;
                if (float.IsNaN(f1) && float.IsNaN(f2) || f1 == 0.0 && f2 == 0.0)
                {
                    f1 = player.direction;
                    f2 = 0.0f;
                    num5 = num1;
                }
                else
                    num5 = num1 / num4;
                float SpeedX = f1 * num5;
                float SpeedY = f2 * num5;
                switch (chargeLevel)
                {
                    case 1:
                        Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 89, 1, -1f);
                        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, ModContent.ProjectileType<UmbraFlameSplit>(), projectile.damage, 1f, player.whoAmI);
                        break;
                    case 2:
                        Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 89);
                        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX / 3, SpeedY / 3, ModContent.ProjectileType<UmbraFlameMain>(), projectile.damage, 1f, player.whoAmI);
                        break;
                }
            }
        }
    }
}
