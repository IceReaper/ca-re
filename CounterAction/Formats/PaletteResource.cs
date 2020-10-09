namespace CounterAction.Formats
{
	using System.Drawing;
	using System.IO;

	public class PaletteResource : Resource
	{
		public static Color[] Palette = new Color[256];

		public PaletteResource(BinaryReader reader, bool isPrimary)
			: base(reader)
		{
			// Hacked this in to read the palette first!
			if (!isPrimary)
				return;

			for (var y = 0; y < 16; y++)
			for (var x = 0; x < 16; x++)
			{
				var r = this.Reader.ReadByte();
				var g = this.Reader.ReadByte();
				var b = this.Reader.ReadByte();
				var a = 255;

				if (y == 0)
				{
					a = x * 17;
					r = g = b = 0;
				}

				var color = Color.FromArgb(a, r << 2, g << 2, b << 2);
				PaletteResource.Palette[y * 16 + x] = color;
			}

			this.Reader.BaseStream.Position = 0;
		}

		public override void Extract(string path)
		{
			if (this.Reader.BaseStream.Length == 0)
				return;

			var bitmap = new Bitmap(16, 16);

			for (var y = 0; y < 16; y++)
			for (var x = 0; x < 16; x++)
			{
				var r = this.Reader.ReadByte();
				var g = this.Reader.ReadByte();
				var b = this.Reader.ReadByte();

				bitmap.SetPixel(x, y, Color.FromArgb(255, r << 2, g << 2, b << 2));
			}

			bitmap.Save($"{path}.png");
		}
	}
}
