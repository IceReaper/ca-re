namespace CounterAction.Files
{
	using System.IO;

	public class MovieDaw : Container
	{
		public MovieDaw(string file)
			: base(new BinaryReader(File.OpenRead(file)))
		{
			foreach (var slice in this.Slice(false))
			{
				// TODO
				this.Children.Add(new Resource(slice));
			}
		}
	}
}
