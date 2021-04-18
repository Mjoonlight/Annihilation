using Annihilation.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Annihilation.Tiles
{
	public class CrystiumOreTile : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 410;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Crystium Ore");
			AddMapEntry(new Color(152, 171, 198), name);
			dustType = 84;
			drop = ModContent.ItemType<CrystiumOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
		}
	}
}