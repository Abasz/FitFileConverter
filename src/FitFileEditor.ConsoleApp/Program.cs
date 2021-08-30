using System;
using System.IO;
using System.Linq;

namespace FitFileEditor.ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args[0] == "generate")
            {
                return GenerateFitMetadata.Generate();
            }

            if (args.Length < 1 || !File.Exists(args[0]))
            {
                Console.WriteLine("Invalid FIT file path");

                return 1;
            }

            var shouldMultiplyCadence = true;
            if (args.Contains("--no-multiply"))
                shouldMultiplyCadence = false;

            var editor = new Editor(args[0]);

            if (args.Contains("--convert-only"))
            {
                File.WriteAllText($"{Path.GetFileNameWithoutExtension(args[0])}.fit.json", editor.ToJson());

                return 0;
            }

            editor.Edit(shouldMultiplyCadence);

            if (args.Contains("--convert"))
            {
                File.WriteAllText($"{Path.GetFileNameWithoutExtension(args[0])}-edited.fit.json", editor.ToJson());
            }

            return 0;
        }
    }
}