using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.NPCs
{
    class CrystiumSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystium Slime");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 26;
            npc.aiStyle = -1;
            npc.damage = 18;
            npc.defense = 6;
            npc.lifeMax = 90;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit42;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
        }
        public override void AI()
        {
            bool flag = true;
            if (npc.localAI[0] > 0f)
            {
                npc.localAI[0] -= 1f;
            }
            if (!Main.player[npc.target].npcTypeNoAggro[npc.type])
            {
                Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num18 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector.X;
                float num19 = Main.player[npc.target].position.Y - vector.Y;
                float num2 = (float)Math.Sqrt(num18 * num18 + num19 * num19);
                if (Main.expertMode && num2 < 120f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && npc.velocity.Y == 0f)
                {
                    npc.ai[0] = -40f;
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity.X *= 0.9f;
                    }
                    if (Main.netMode != NetmodeID.MultiplayerClient && npc.localAI[0] == 0f)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Vector2 vector2 = new Vector2(i - 2, -4f);
                            vector2.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
                            vector2.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
                            vector2.Normalize();
                            vector2 *= 4f + (float)Main.rand.Next(-50, 51) * 0.01f;
                            Projectile.NewProjectile(vector.X, vector.Y, vector2.X, vector2.Y, ModContent.ProjectileType<SlimeSpike>(), 9, 0f, Main.myPlayer);
                            npc.localAI[0] = 30f;
                        }
                    }
                }
                else if (num2 < 200f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && npc.velocity.Y == 0f)
                {
                    npc.ai[0] = -40f;
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity.X *= 0.9f;
                    }
                    if (Main.netMode != NetmodeID.MultiplayerClient && npc.localAI[0] == 0f)
                    {
                        num19 = Main.player[npc.target].position.Y - vector.Y - (float)Main.rand.Next(0, 200);
                        num2 = (float)Math.Sqrt(num18 * num18 + num19 * num19);
                        num2 = 4.5f / num2;
                        num18 *= num2;
                        num19 *= num2;
                        npc.localAI[0] = 50f;
                        Projectile.NewProjectile(vector.X, vector.Y, num18, num19, ModContent.ProjectileType<SlimeSpike>(), 9, 0f, Main.myPlayer);
                    }
                }
            }
            if (npc.ai[2] > 1f)
            {
                npc.ai[2] -= 1f;
            }
            npc.aiAction = 0;
            if (npc.ai[2] == 0f)
            {
                npc.ai[0] = -100f;
                npc.ai[2] = 1f;
                npc.TargetClosest();
            }
            if (!npc.wet && npc.velocity.Y == 0f)
            {
                if (npc.collideY && npc.oldVelocity.Y != 0f && Collision.SolidCollision(npc.position, npc.width, npc.height))
                {
                    npc.position.X -= npc.velocity.X + (float)npc.direction;
                }
                if (npc.ai[3] == npc.position.X)
                {
                    npc.direction *= -1;
                    npc.ai[2] = 200f;
                }
                npc.ai[3] = 0f;
                npc.velocity.X *= 0.8f;
                if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
                {
                    npc.velocity.X = 0f;
                }
                if (flag)
                {
                    npc.ai[0] += 1f;
                }
                npc.ai[0] += 2f;
                int num11 = 0;
                if (npc.ai[0] >= 0f)
                {
                    num11 = 1;
                }
                if (npc.ai[0] >= -1000f && npc.ai[0] <= -500f)
                {
                    num11 = 2;
                }
                if (npc.ai[0] >= -2000f && npc.ai[0] <= -1500f)
                {
                    num11 = 3;
                }
                if (num11 > 0)
                {
                    npc.netUpdate = true;
                    if (flag && npc.ai[2] == 1f)
                    {
                        npc.TargetClosest();
                    }
                    if (num11 == 3)
                    {
                        npc.velocity.Y = -8f;
                        npc.velocity.X += 3 * npc.direction;
                        npc.ai[0] = -200f;
                        npc.ai[3] = npc.position.X;
                    }
                    else
                    {
                        npc.velocity.Y = -6f;
                        npc.velocity.X += 2 * npc.direction;
                        npc.ai[0] = -120f;
                        if (num11 == 1)
                        {
                            npc.ai[0] -= 1000f;
                        }
                        else
                        {
                            npc.ai[0] -= 2000f;
                        }
                    }
                }
                else if (npc.ai[0] >= -30f)
                {
                    npc.aiAction = 1;
                }
            }
            else if (!npc.wet && npc.target < 255 && ((npc.direction == 1 && npc.velocity.X < 3f) || (npc.direction == -1 && npc.velocity.X > -3f)))
            {
                if (npc.collideX && Math.Abs(npc.velocity.X) == 0.2f)
                {
                    npc.position.X -= 1.4f * (float)npc.direction;
                }
                if (npc.collideY && npc.oldVelocity.Y != 0f && Collision.SolidCollision(npc.position, npc.width, npc.height))
                {
                    npc.position.X -= npc.velocity.X + (float)npc.direction;
                }
                if ((npc.direction == -1 && (double)npc.velocity.X < 0.01) || (npc.direction == 1 && (double)npc.velocity.X > -0.01))
                {
                    npc.velocity.X += 0.2f * (float)npc.direction;
                }
                else
                {
                    npc.velocity.X *= 0.93f;
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            int num41 = 0;
            if (npc.aiAction == 0)
            {
                num41 = ((npc.velocity.Y < 0f) ? 2 : ((npc.velocity.Y > 0f) ? 3 : ((npc.velocity.X != 0f) ? 1 : 0)));
            }
            else if (npc.aiAction == 1)
            {
                num41 = 4;
            }
            if (!npc.wet)
            {
                npc.frameCounter += 1.0;
                if (num41 > 0)
                {
                    npc.frameCounter += 1.0;
                }
                if (num41 == 4)
                {
                    npc.frameCounter += 1.0;
                }
            }
            else
            {
                npc.frameCounter += 0.2;
                if (num41 > 0)
                {
                    npc.frameCounter += 0.2;
                }
                if (num41 == 4)
                {
                    npc.frameCounter += 0.2;
                }
            }
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y += frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }
    }
}
