namespace CounterAction
{
	using Files;
	using System.Collections.Generic;
	using System.IO;

	internal static class Program
	{
		private static void Main(string[] args)
		{
			if (args.Length == 0)
				return;

			var resources = new Dictionary<Resource, string>();

			foreach (var file in Directory.GetFiles(args[0]))
			{
				Resource resource;

				if (Path.GetFileName(file).ToLower() == "goal.rus")
					resource = new GoalRus(file);
				else if (Path.GetFileName(file).ToLower() == "maindata.daw")
					resource = new MaindataDaw(file);
				else if (Path.GetFileName(file).ToLower() == "maindata.rus")
					resource = new MaindataRus(file);
				else if (Path.GetFileName(file).ToLower() == "movie.daw")
					resource = new MovieDaw(file);
				else if (Path.GetFileName(file).ToLower() == "music.dat")
					resource = new MusicDat(file);
				else if (Path.GetFileName(file).ToLower() == "plrrus.daw")
					resource = new PlrDaw(file);
				else if (Path.GetFileName(file).ToLower() == "plrdeu.daw")
					resource = new PlrDaw(file);
				else if (Path.GetFileName(file).ToLower() == "textes.rus")
					resource = new TextesRus(file);
				else
					continue;

				resources.Add(resource, file + ".Content");
			}

			foreach (var (resource, path) in resources)
				resource.Extract(path);
		}
	}
}
