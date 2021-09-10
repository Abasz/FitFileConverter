﻿using System;
using System.IO;

using CommandLine;

namespace FitFileEditor.ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            var parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<EditorOptions, ConverterOptions, SetupOptions>(args);

            return parserResult
                .MapResult(
                    (EditorOptions options) =>
                    {
                        if (!File.Exists(options.FitFilePath))
                            throw new FileNotFoundException("Invalid FIT file path");

                        var editor = new Editor(options.FitFilePath);

                        editor.Edit(options.Output, !options.NoMultiply);

                        if (options.Convert)
                        {
                            File.WriteAllText(options.Output ?? $"{Path.GetFileNameWithoutExtension(options.FitFilePath)}-edited.fit.json", editor.ToJson());
                        }

                        return 0;
                    },
                    (ConverterOptions options) =>
                    {
                        if (!File.Exists(options.FilePath))
                            throw new FileNotFoundException("Invalid file path");

                        var extention = Path.GetExtension(options.FilePath).ToLower();
                        if (extention == ".fit")
                        {
                            var parser = new FitFileParser();

                            parser.ReadFitFile(options.FilePath);

                            var path = options.Output ?? $"{Path.GetFileNameWithoutExtension(options.FilePath)}.json";
                            File.WriteAllText(path, parser.ToJson());

                            Console.WriteLine($"Converted to Json: ${path}");
                        }

                        if (extention == ".json")
                        {
                            var parser = new FitFileParser();
                            if (options.fromFit is not null)
                            {
                                if (!File.Exists(options.fromFit))
                                    throw new FileNotFoundException("Invalid input Fit file path");

                                Console.WriteLine($"Using \"${options.fromFit}\" for conversion");

                                parser.ReadFitFile(options.fromFit);
                            }

                            parser.FromJson(options.FilePath, options.Output);
                        }

                        return 0;
                    },
                    (SetupOptions options) => Setup(options),
                    errors =>
                    {
                        Console.WriteLine(HelperTextOptions.HelpText(parserResult));
                        return 1;
                    }
                );
        }

        private static int Setup(SetupOptions options)
        {
            if (!options.ShouldGenerateProfiles && !options.ShouldGenerateTypes)
            {
                options.ShouldGenerateProfiles = true;
                options.ShouldGenerateTypes = true;
            }

            GenerateFitMetadata.Generate(options.ShouldGenerateProfiles, options.ShouldGenerateTypes);

            return 0;
        }
    }
}