namespace CounterAction.Formats
{
	using System.IO;
	using System.Text;

	public class SoundResource : Resource
	{
		private const int SampleBytes = 1;
		private const int SampleRate = 11025;

		private readonly int channels;

		public SoundResource(BinaryReader reader, int channels)
			: base(reader)
		{
			this.channels = channels;
		}

		public override void Extract(string path)
		{
			if (this.Reader.BaseStream.Length == 0)
				return;

			using var writer = new BinaryWriter(File.OpenWrite($"{path}.wav"));

			var sampleAmount = (int) this.Reader.BaseStream.Length / SoundResource.SampleBytes;
			var dataLength = (int) this.Reader.BaseStream.Length;

			writer.Write(Encoding.ASCII.GetBytes("RIFF"));
			writer.Write(36 + dataLength);
			writer.Write(Encoding.ASCII.GetBytes("WAVE"));
			writer.Write(Encoding.ASCII.GetBytes("fmt "));
			writer.Write(16);
			writer.Write((short) 1);
			writer.Write((short) this.channels);
			writer.Write(SoundResource.SampleRate);
			writer.Write(SoundResource.SampleRate * SoundResource.SampleBytes * this.channels);
			writer.Write((short) (SoundResource.SampleBytes * this.channels));
			writer.Write((short) (8 * SoundResource.SampleBytes));
			writer.Write((short) (sampleAmount * SoundResource.SampleBytes));
			writer.Write("data");
			writer.Write(dataLength);
			writer.Write(this.Reader.ReadBytes(dataLength));
		}
	}
}
