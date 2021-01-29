using Annihilation.NPCs.Megnatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Annihilation.NPCs.Ansolar;
using Terraria.DataStructures;

namespace Annihilation
{
    class Playaar : ModPlayer
    {
        public override void PostUpdate()
        {
            DateTime now = DateTime.Today;
            if (now.Day == 1 && now.Month == 4)
            {
                Megnatar.BulletHell = true;
                Ansolar.ThornsReflector = true;
            }
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            DateTime now = DateTime.Today;
            if (Main.rand.Next(0, 20) == 0 && now.Day == 1 && now.Month == 4)
            {
                damageSource = PlayerDeathReason.ByCustomReason($"{player.name} was legally murdered.");
            }
            return true;
        }
    }
}
