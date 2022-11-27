using CommandLine.Text;

namespace FitFileConverter.ConsoleApp;

[Verb("convert", isDefault: true, HelpText = "Json/Fit converter")]
public class ConverterOptions
{
    [Value(0, Required = true, MetaName = "PATH", HelpText = "Path to the file to be converted")]
    public string FilePath { get; set; } = null!;

    [Option('g', "from-fit", HelpText = "Path of the original Fit file for the edited json")]
    public string fromFit { get; set; } = null!;

    [Option('o', "output", HelpText = "Set edited output path and name")]
    public string? Output { get; set; }

    [Usage(ApplicationAlias = "FitFileConverter")]
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

    [Usage(ApplicationAlias = "FitFileConverter")]
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
    public static HelpText HelpText(ParserResult<object>? parserResult)
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
                    sb.AppendLine("        FitFileConverter [COMMAND] PATH [OPTIONS...]");
                    sb.AppendLine();
                    sb.AppendLine("DESCRIPTION:");
                    sb.Append("        FitFileConverter may be used to convert Garmin Fit files. It is capable of converting a Fit file to json and back without data loss(enable changing sport, potentially multiplying cadence, etc. in the json file)");
                    h.AddPreOptionsText(sb.ToString());

                    return CommandLine.Text.HelpText.DefaultParsingErrorsHandler(parserResult, h);
                },
                e => e,
                verbsIndex: true
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