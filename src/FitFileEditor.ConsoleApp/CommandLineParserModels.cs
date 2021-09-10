using System;
using System.Collections.Generic;
using System.Text;

using CommandLine;
using CommandLine.Text;

namespace FitFileEditor.ConsoleApp
{
    [Verb("edit", isDefault : true, HelpText = "Edit fit file")]
    public class EditorOptions
    {
        [Value(0, Required = true, MetaName = "PATH", HelpText = "Path to the Fit file")]
        public string FitFilePath { get; set; } = null!;

        [Option('n', "no-multiply", HelpText = "Disable cadence multiplication")]
        public bool NoMultiply { get; set; }

        [Option('c', "convert", HelpText = "Convert the edited Fit file to json")]
        public bool Convert { get; set; }

        [Option('o', "output", HelpText = "Set edited Fit file output path and name")]
        public string? Output { get; set; }

        [Usage(ApplicationAlias = "FitFileEditor")]
        public static IEnumerable<Example> Examples
        {
            get
            {
            return new List<Example>()
            {
            new Example("Edit then convert \"file.fit\" to json", new EditorOptions { FitFilePath = "file.fit", Convert = true })
                };
            }
        }
    }

    [Verb("convert", HelpText = "Json/Fit converter")]
    public class ConverterOptions
    {
        [Value(0, Required = true, MetaName = "PATH", HelpText = "Path to the file to be converted")]
        public string FilePath { get; set; } = null!;

        [Option('g', "from-fit", HelpText = "Path of the original Fit file for the edited json")]
        public string fromFit { get; set; } = null!;

        [Option('o', "output", HelpText = "Set edited output path and name")]
        public string? Output { get; set; }

        [Usage(ApplicationAlias = "FitFileEditor")]
        public static IEnumerable<Example> Examples
        {
            get
            {
            return new List<Example>()
            {
            new Example("Edit \"file.fit\" with \"file.json\"", new ConverterOptions { FilePath = "file.json", fromFit = "file.fit" }),
            {
            new Example("Create Fit file from \"file.json\" to path \"random/path/new.fit\"", new ConverterOptions { FilePath = "file.fit", Output = "random/path/new.fit" })
            }
                };
            }
        }
    }

    [Verb("setup", HelpText = "Generate metadata for json to fit converter")]
    public class SetupOptions
    {
        [Option('p', "profiles", HelpText = "Generate profiles metadata")]
        public bool ShouldGenerateProfiles { get; set; }

        [Option('t', "types", HelpText = "Generate types metadata")]
        public bool ShouldGenerateTypes { get; set; }

        [Usage(ApplicationAlias = "FitFileEditor")]
        public static IEnumerable<Example> Examples
        {
            get
            {
            return new List<Example>()
            {
            new Example("Setup both types and profiles", new SetupOptions {}),
            {
            new Example("Setup only types", new SetupOptions { ShouldGenerateTypes = true })
            }
                };
            }
        }
    }

    public static class HelperTextOptions
    {
        public static HelpText HelpText(ParserResult<object> ? parserResult)
        {
            return CommandLine.Text.HelpText
                .AutoBuild(
                    parserResult,
                    h =>
                    {
                        h.AdditionalNewLineAfterOption = false;
                        h.AddNewLineBetweenHelpSections = true;
                        h.AddDashesToOption = true;
                        h.AutoHelp = true;
                        h.AutoVersion = true;
                        h.OptionComparison = VerbThanOptionsComparison;

                        var sb = new StringBuilder();
                        sb.AppendLine("SYNOPSIS:");
                        sb.AppendLine("        FitFileEditor [COMMAND] PATH [OPTIONS...]");
                        sb.AppendLine();
                        sb.AppendLine("DESCRIPTION:");
                        sb.Append("        FitFileEditor may be used to manipulate and/or convert Garmin Fit files. It is capable of converting a Fit file to json and back without data loss or do standard editing directly (changing sport, potentially multiplying cadence, etc.)");
                        h.AddPreOptionsText(sb.ToString());

                        return CommandLine.Text.HelpText.DefaultParsingErrorsHandler(parserResult, h);
                    },
                    e => e,
                    verbsIndex : true
                );
        }

        public static readonly Comparison<ComparableOption> VerbThanOptionsComparison = (ComparableOption attr1, ComparableOption attr2) =>
        {
            if (attr1.IsOption && attr2.IsOption)
            {
                if (attr1.Required && !attr2.Required)
                {
                    return -1;
                }

                if (!attr1.Required && attr2.Required)
                {
                    return 1;
                }

                if (string.IsNullOrEmpty(attr1.ShortName) && !string.IsNullOrEmpty(attr2.ShortName))
                {
                    return 1;
                }

                if (!string.IsNullOrEmpty(attr1.ShortName) && string.IsNullOrEmpty(attr2.ShortName))
                {
                    return -1;
                }

                return string.Compare(attr1.ShortName, attr2.ShortName, StringComparison.Ordinal);
            }

            if (attr1.IsValue && attr2.IsOption)
            {
                return -1;
            }

            return 1;
        };

    }
}