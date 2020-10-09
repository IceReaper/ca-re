namespace CounterAction.Files
{
	using Formats;
	using System.IO;

	public class TextesRus : Container
	{
		public TextesRus(string file)
			: base(new BinaryReader(File.OpenRead(file)))
		{
			var slices = this.Slice(false);

			for (var i = 0; i < slices.Count; i++)
			{
				var slice = slices[i];

				if (i == 0 || i == 1)
					this.Children.Add(new Container(slice, slice => new ImageResource(slice)));
				else
				{
					// TODO
					this.Children.Add(new Resource(slice));
				}
			}
		}
	}
}
