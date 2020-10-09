namespace CounterAction.Files
{
	using System.IO;

	public class MusicDat : Container
	{
		public MusicDat(string file)
			: base(new BinaryReader(File.OpenRead(file)))
		{
			foreach (var slice in this.Slice(true, true))
			{
				// TODO
				this.Children.Add(new Resource(slice));
			}
		}
	}
}
