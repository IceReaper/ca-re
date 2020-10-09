namespace CounterAction
{
	using System.IO;

	public class Resource
	{
		protected readonly BinaryReader Reader;

		public Resource(BinaryReader reader)
		{
			this.Reader = reader;
		}

		public virtual void Extract(string path)
		{
			if (this.Reader.BaseStream.Length != 0)
				File.WriteAllBytes($"{path}", this.Reader.ReadBytes((int) this.Reader.BaseStream.Length));
		}
	}
}
