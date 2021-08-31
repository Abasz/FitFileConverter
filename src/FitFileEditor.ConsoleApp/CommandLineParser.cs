using CommandLine;

namespace FitFileEditor.ConsoleApp
{
    [Verb("edit", isDefault : true, HelpText = "Edit fit file")]
    public class EditorOptions
    {
        [Value(0, Required = true)]
        public string FitFilePath { get; set; } = null!;

        [Option('n', "no-multiply")]
        public bool NoMultiply { get; set; }

        [Option('c', "convert")]
        public bool Convert { get; set; }

        [Option('o', "output")]
        public string? Output { get; set; }
    }

    [Verb("convert", HelpText = "Json/Fit converter")]
    public class ConverterOptions
    {
        [Value(0, Required = true)]
        public string FilePath { get; set; } = null!;

        [Option('g', "from-fit")]
        public string fromFit { get; set; } = null!;

        [Option('o', "output")]
        public string? Output { get; set; }
    }

    [Verb("setup", HelpText = "Generate metadata for json to fit converter")]
    public class SetupOptions {}
}