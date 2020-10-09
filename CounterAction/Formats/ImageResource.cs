namespace CounterAction.Formats
{
	using System.Drawing;
	using System.IO;

	public class ImageResource : Resource
	{
		public ImageResource(BinaryReader reader)
			: base(reader)
		{
		}

		public override void Extract(string path)
		{
			if (this.Reader.BaseStream.Length == 0)
				return;

			var height = this.Reader.ReadUInt16();
			var width = this.Reader.ReadUInt16();

			var bitmap = new Bitmap(width, height);

			for (var y = 0; y < height; y++)
			for (var x = 0; x < width; x++)
			{
				var index = this.Reader.ReadByte();
				bitmap.SetPixel(x, y, PaletteResource.Palette[index]);
			}

			bitmap.Save($"{path}.png");
		}
	}
}
