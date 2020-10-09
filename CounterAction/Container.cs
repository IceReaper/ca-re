namespace CounterAction
{
	using System;
	using System.Collections.Generic;
	using System.IO;

	public class Container : Resource
	{
		protected readonly List<Resource> Children = new List<Resource>();

		protected Container(BinaryReader reader)
			: base(reader)
		{
		}

		public Container(BinaryReader reader, Func<BinaryReader, Resource> populator)
			: base(reader)
		{
			var slices = this.Slice(true);

			foreach (var slice in slices)
				this.Children.Add(populator(slice));
		}

		public override void Extract(string path)
		{
			Directory.CreateDirectory(path);

			for (var i = 0; i < this.Children.Count; i++)
				this.Children[i].Extract($"{path}/{i}");
		}

		protected List<BinaryReader> Slice(bool hasAmount, bool isBrokenMusicDat = false)
		{
			var slices = new List<BinaryReader>();

			int numEntries;

			if (hasAmount)
			{
				numEntries = this.Reader.ReadInt32();

				if (isBrokenMusicDat)
					numEntries++;
			}
			else
			{
				var firstOffset = this.Reader.ReadInt32();
				numEntries = firstOffset / 4;
				this.Reader.BaseStream.Position -= 4;
			}

			for (var i = 0; i < numEntries; i++)
			{
				var offset = this.Reader.ReadInt32();
				var offsetNext = (int) this.Reader.BaseStream.Length;

				if (i + 1 < numEntries)
				{
					offsetNext = this.Reader.ReadInt32();
					this.Reader.BaseStream.Position -= 4;
				}

				var returnPosition = this.Reader.BaseStream.Position;
				this.Reader.BaseStream.Position = offset;

				if (hasAmount && !isBrokenMusicDat)
					this.Reader.BaseStream.Position += 4;

				slices.Add(new BinaryReader(new MemoryStream(this.Reader.ReadBytes(offsetNext - offset))));

				this.Reader.BaseStream.Position = returnPosition;
			}

			return slices;
		}
	}
}
