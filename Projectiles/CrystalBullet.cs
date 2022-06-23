using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Annihilation.Projectiles;

namespace Annihilation.Projectiles
{
	class CrystalBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Spike");
			Main.projFrames[Projectile.type] = 3;
		}
		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 32;
			Projectile.damage = 10;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = -1;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 600;
		}

		public int type = -1;
		private NPC targer = null;
		public override void AI()
		{
			if (type == -1)
			{
				type = Main.rand.Next(3);
			}
			if (Projectile.ai[0] == 0)
			{
				if (type == 0)
				{
					Projectile.damage -= 3;
					Projectile.frame += 2;
				}
				else if (type == 1)
				{
					Projectile.damage += 4;
					Projectile.frame += 1;
				}
				Projectile.ai[0] = 1;
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(-90f);
			if (killing && Projectile.timeLeft <= 1 && targer != null)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(targer.velocity.X, targer.velocity.Y), ModContent.ProjectileType<CrystalBulletStuck>(), 0, 0f, Projectile.owner, Projectile.whoAmI, targer.whoAmI);
				Projectile.timeLeft = 0;
				SoundEngine.PlaySound(SoundID.Item27, Projectile.Center);
			}
			else if (killing && Projectile.timeLeft <= 1)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(0f, 0f), ModContent.ProjectileType<CrystalBulletStuck>(), 0, 0f, Projectile.owner, Projectile.whoAmI, -1);
				Projectile.timeLeft = 0;
				SoundEngine.PlaySound(SoundID.Item27, Projectile.Center);
			}
		}

		private bool killing = false;
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (!killing)
			{
				Projectile.tileCollide = false;
				Projectile.timeLeft = 3;
				killing = true;
			}
			return false;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!killing)
			{
				targer = target;
				Projectile.timeLeft = 3;
				killing = true;
			}
		}
		public override bool PreKill(int timeLeft)
		{
			if (!killing)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, Projectile.owner, type);
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, Projectile.owner, type);
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, Projectile.owner, type);
			}
			return true;
		}
		public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
	}

	class CrystalBulletShard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Shard");
			Main.projFrames[Projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 20;
			Projectile.damage = 5;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 1;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 600;
		}

		private bool init = false;
		public override void AI()
		{
			if (!init)
			{
				if (Projectile.ai[0] == 0)
				{
					Projectile.frame += 2;
					Projectile.damage -= 1;
				}
				else if (Projectile.ai[0] == 1)
				{
					Projectile.frame += 1;
					Projectile.damage += 1;
				}
				init = true;
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(-90f);
		}
		public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
	}

	class CrystalBulletStuck : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 3;
		}
		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 26;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 120;
			Projectile.ignoreWater = true;
		}

		private bool init = false;
		public override void AI()
		{
			if (Main.projectile[(int)Projectile.ai[0]].modProjectile is CrystalBullet proj)
			{
				if (!init && proj != null)
				{
					if (proj.type == 0)
					{
						Projectile.frame += 2;
					}
					else if (proj.type == 1)
					{
						Projectile.frame += 1;
					}
					Projectile.rotation = proj.Projectile.rotation;
					init = true;
				}
			}
			if (Projectile.ai[1] != -1)
			{
				NPC nerp = Main.npc[(int)Projectile.ai[1]];
				Projectile.velocity = nerp.velocity;
			}
		}

		public override bool PreKill(int timeLeft)
		{
			if (Main.projectile[(int)Projectile.ai[0]].modProjectile is CrystalBullet proj)
			{
				if (proj != null)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromAI(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, Projectile.owner, proj.type);
					Projectile.NewProjectile(Projectile.GetSource_FromAI(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, Projectile.owner, proj.type);
					Projectile.NewProjectile(Projectile.GetSource_FromAI(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(Main.rand.Next(-90, 91), Main.rand.Next(-90, 91)) / 10f, ModContent.ProjectileType<CrystalBulletShard>(), 5, 4f, Projectile.owner, proj.type);
				}
			}
			return true;
		}
		public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 255);
	}
}
