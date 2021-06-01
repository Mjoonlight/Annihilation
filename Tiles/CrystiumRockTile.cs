using Annihilation.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Tiles
{
	public class CrystiumRockTile : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = false;
			Main.tileSpelunker[Type] = false;
			Main.tileValue[Type] = 410;
			Main.tileShine2[Type] = false;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = false;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Crystium Rock");
			AddMapEntry(new Color(142, 30, 70), name);
			dustType = 84;
			drop = ModContent.ItemType<CrystiumRock>();
			soundType = SoundID.Tink;
			soundStyle = 1;
		}
	}
}