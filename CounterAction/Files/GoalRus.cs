namespace CounterAction.Files
{
	using System.IO;

	public class GoalRus : Container
	{
		public GoalRus(string file)
			: base(new BinaryReader(File.OpenRead(file)))
		{
			var slices = this.Slice(false);

			for (var i = 0; i < slices.Count; i++)
			{
				var slice = slices[i];
				this.Children.Add(new Resource(slice));
			}
		}
	}
}
