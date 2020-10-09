namespace CounterAction.Files
{
	using Formats;
	using System.IO;

	public class MaindataDaw : Container
	{
		public MaindataDaw(string file)
			: base(new BinaryReader(File.OpenRead(file)))
		{
			var slices = this.Slice(false);

			for (var i = 0; i < slices.Count; i++)
			{
				var slice = slices[i];

				if (i == 1)
					this.Children.Add(new PaletteResource(slice, true));
				else if (i == 2
					|| i == 16
					|| i == 19
					|| i == 20
					|| i == 21
					|| i == 22
					|| i == 23
					|| i == 24
					|| i == 25
					|| i == 26
					|| i == 27
					|| i == 28
					|| i == 29
					|| i == 30
					|| i == 31
					|| i == 32
					|| i == 33
					|| i == 34
					|| i == 35
					|| i == 36
					|| i == 37
					|| i == 38
					|| i == 39
					|| i == 42
					|| i == 43
					|| i == 44
					|| i == 47
					|| i == 48
					|| i == 49
					|| i == 52
					|| i == 53
					|| i == 54
					|| i == 57
					|| i == 58
					|| i == 59
					|| i == 62
					|| i == 63
					|| i == 66
					|| i == 67
					|| i == 70
					|| i == 71
					|| i == 73
					|| i == 74
					|| i == 75
					|| i == 76
					|| i == 78
					|| i == 79
					|| i == 81
					|| i == 82
					|| i == 83
					|| i == 84
					|| i == 85
					|| i == 86
					|| i == 89
					|| i == 90
					|| i == 91
					|| i == 92
					|| i == 93
					|| i == 94
					|| i == 96
					|| i == 97
					|| i == 99
					|| i == 100
					|| i == 101
					|| i == 102)
					this.Children.Add(new Container(slice, slice => new SpriteResource(slice)));
				else if (i == 3)
					this.Children.Add(new BlitResource(slice, 640, 480));
				else if (i == 4 || i == 5 || i == 8 || i == 9 || i == 10 || i == 17)
					this.Children.Add(new Container(slice, slice => new ImageResource(slice)));
				else if (i == 12)
					this.Children.Add(new Container(slice, slice => new SoundResource(slice, 1)));
				else if (i == 14 || i == 105)
					this.Children.Add(new Container(slice, slice => new BlitResource(slice, 32, 32)));
				else
				{
					// TODO
					this.Children.Add(new Resource(slice));
				}
			}
		}
	}
}
