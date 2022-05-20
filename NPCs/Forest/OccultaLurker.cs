using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs.Forest
{
	public class OccultaLurker : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Occulta Lurker");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 42;
			npc.height = 42;
			npc.damage = 7;
			npc.defense = 3;
			npc.lifeMax = 75;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.SnowFlinx;
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			//3hi31mg
			var clr = new Color(255, 255, 255, 255); // full white
			var drawPos = npc.Center - Main.screenPosition;
			var origTexture = Main.npcTexture[npc.type];
			var texture = mod.GetTexture("NPCs/Forest/OccultaLurker_Glow");
			var orig = npc.frame.Size() / 2f;

			Main.spriteBatch.Draw(origTexture, drawPos, npc.frame, lightColor, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(texture, drawPos, npc.frame, clr, npc.rotation, orig, npc.scale, SpriteEffects.None, 0f);
			return false;
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDay.Chance * 0.25f;
		}
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.20f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
			}
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
		}
	}
}
