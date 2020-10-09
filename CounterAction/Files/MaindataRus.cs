namespace CounterAction.Files
{
	using Formats;
	using System.IO;

	public class MaindataRus : Container
	{
		public MaindataRus(string file)
			: base(new BinaryReader(File.OpenRead(file)))
		{
			var slices = this.Slice(false);

			for (var i = 0; i < slices.Count; i++)
			{
				var slice = slices[i];

				if (i == 0)
					this.Children.Add(new PaletteResource(slice, false));
				else if (i == 17)
					this.Children.Add(new Container(slice, slice => new SoundResource(slice, 2)));
				else
				{
					// TODO 7-16 are sounds in unknown format.
					this.Children.Add(new Resource(slice));
				}
			}
		}
	}
}
