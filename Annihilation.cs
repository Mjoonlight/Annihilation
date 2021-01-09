using Annihilation.NPCs.Megnatar;
using Terraria;
using Terraria.ModLoader;

namespace Annihilation
{
	public class Annihilation : Mod
	{
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
            {
                return;
            }
        }
    }
}