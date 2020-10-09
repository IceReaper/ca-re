namespace CounterAction.Formats
{
	using System.Drawing;
	using System.IO;

	public class BlitResource : Resource
	{
		private readonly int width;
		private readonly int height;

		public BlitResource(BinaryReader reader, int width, int height)
			: base(reader)
		{
			this.width = width;
			this.height = height;
		}

		public override void Extract(string path)
		{
			if (this.Reader.BaseStream.Length == 0)
				return;

			var bitmap = new Bitmap(this.width, this.height);

			for (var y = 0; y < this.height; y++)
			for (var x = 0; x < this.width; x++)
			{
				var index = this.Reader.ReadByte();
				bitmap.SetPixel(x, y, PaletteResource.Palette[index]);
			}

			bitmap.Save($"{path}.png");
		}
	}
}
