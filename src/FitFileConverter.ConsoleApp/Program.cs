using System;
using System.IO;
using System.Threading.Tasks;

using CommandLine;

using FitFileConverter.ClassLibrary;

namespace FitFileConverter.ConsoleApp
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            var parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<ConverterOptions, SetupOptions>(args);

            return parserResult
                .MapResult<ConverterOptions, SetupOptions, Task<int>>(
                    ConverterAsync,
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

        private static async Task<int> ConverterAsync(ConverterOptions options)
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

                await FitFileParser.FromJsonAsync(options.FilePath, originalFitData, fitPath);

                Console.WriteLine($"Converted to Fit: \"{fitPath}\"");
            }

            return 0;
        }
    }
}