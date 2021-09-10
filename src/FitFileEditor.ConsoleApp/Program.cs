using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using CommandLine;

namespace FitFileEditor.ConsoleApp
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            var parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<EditorOptions, ConverterOptions, SetupOptions>(args);

            return parserResult
                .MapResult<EditorOptions, ConverterOptions, SetupOptions, Task<int>>(
                    Editor,
                    Converter,
                    Setup,
                    errors =>
                    {
                        Console.WriteLine(HelperTextOptions.HelpText(parserResult));
                        return Task.FromResult(1);
                    }
                );
        }

        private static Task<int> Setup(SetupOptions options)
        {
            if (!options.ShouldGenerateProfiles && !options.ShouldGenerateTypes)
            {
                options.ShouldGenerateProfiles = true;
                options.ShouldGenerateTypes = true;
            }

            GenerateFitMetadata.Generate(options.ShouldGenerateProfiles, options.ShouldGenerateTypes);

            return Task.FromResult(0);
        }

        private static async Task<int> Converter(ConverterOptions options)
        {
            var extention = Path.GetExtension(options.FilePath).ToLower();
            if (extention == ".fit")
            {
                var fitFileParser = FitFileParser.FromFit(options.FilePath);

                var jsonPath = options.Output ??
                    $"{Path.GetFileNameWithoutExtension(options.FilePath)}.json";

                fitFileParser.ToJson(jsonPath);

                Console.WriteLine($"Converted to Json: {jsonPath}");
            }

            if (extention == ".json")
            {
                FitFileParser? originalFitData = null;
                if (options.fromFit is not null)
                {
                    Console.WriteLine($"Using \"{options.fromFit}\" for conversion");

                    originalFitData = FitFileParser.FromFit(options.fromFit);
                }

                var fitPath = options.Output ??
                    $"{Path.GetFileNameWithoutExtension(options.FilePath)}.fit";

                await FitFileParser.FromJson(options.FilePath, originalFitData, fitPath);

                Console.WriteLine($"Converted to Fit: \"{fitPath}\"");
            }

            return 0;
        }

        private static Task<int> Editor(EditorOptions options)
        {
            var fitFileParser = FitFileParser.FromFit(options.FitFilePath);

            fitFileParser.Edit(!options.NoMultiply, 2);

            if (options.Convert)
            {
                var jsonPath = options.Output is not null ?
                    $"{Path.GetFileNameWithoutExtension(options.Output)}.json" :
                    $"{Path.GetFileNameWithoutExtension(options.FitFilePath)}-edited.json";
                fitFileParser.ToJson(jsonPath);
                Console.WriteLine($"Json file created: {jsonPath}");
            }

            var fitPath = options.Output is not null ?
                $"{Path.GetFileNameWithoutExtension(options.Output)}.fit" :
                $"{Path.GetFileNameWithoutExtension(options.FitFilePath)}-edited.fit";

            fitFileParser.ToFit(fitPath);
            Console.WriteLine($"Fit file created: {fitPath}");

            return Task.FromResult(0);
        }
    }
}