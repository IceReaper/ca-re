namespace CounterAction.Files
{
	using Formats;
	using System.IO;

	public class PlrDaw : Container
	{
		public PlrDaw(string file)
			: base(new BinaryReader(File.OpenRead(file)))
		{
			var slices = this.Slice(false);

			for (var i = 0; i < slices.Count; i++)
			{
				var slice = slices[i];

				if (i == 2 || i == 4)
					this.Children.Add(new Container(slice, slice => new ImageResource(slice)));
				else if (i == 3)
					this.Children.Add(new SpriteResource(slice));
				else if (i == 5)
					this.Children.Add(new Container(slice, slice => new SoundResource(slice, 1)));
				else
				{
					// TODO
					this.Children.Add(new Resource(slice));
				}
			}
		}
	}
}
