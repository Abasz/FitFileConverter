using System.Reflection;
using File = System.IO.File;

namespace FitFileConverter.ClassLibrary;

public class GenerateFitMetadata
{
    private readonly Assembly _assemblies = Assembly.Load("Fit");

    private GenerateFitMetadata() {}

    public static void Generate(bool ShouldGenerateProfiles = true, bool ShouldGenerateTypes = true)
    {
        var generate = new GenerateFitMetadata();

        if (ShouldGenerateProfiles)
            generate.GenerateProfiles();

        if (ShouldGenerateTypes)
            generate.GenerateTypes();
    }

    private void GenerateTypes()
    {
        var index = 0;
        var types = Enum.GetNames(typeof(Profile.Type)).ToDictionary(type => type, type =>
        {
            var fields = new Dictionary<string, long>();
            if (_assemblies.GetType($"Dynastream.Fit.{type}")is Type mesgType)
            {
                if (mesgType is not null && mesgType.Name != "DateTime")
                {
                    if (mesgType.IsEnum)
                    {
                        foreach (object foo in Enum.GetValues(mesgType))
                        {
                            fields.TryAdd(foo.ToString() !, Convert.ToInt64(foo));
                        }
                    }
                    if (mesgType.IsClass)
                    {
                        fields = mesgType.GetFields().ToDictionary(
                            fieldMeta => fieldMeta.Name,
                            fieldMeta => Convert.ToInt64(fieldMeta.GetValue(null)) !
                        );
                    }
                }
            }

            return new TypeMeta
            {
                Num = index++,
                    Fields = fields
            };
        });

        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "types.json"),
            JsonSerializer.Serialize(types, HelperMethods.JsonSerializerOptions)
        );

        Console.WriteLine("types.json have been generated");
    }

    private void GenerateProfiles()
    {
        var mesgs = _assemblies.DefinedTypes.Where(type => Regex.IsMatch(type.Name, "^.+Mesg$"));

        var profiles = mesgs.ToDictionary(
            mesg => (string)mesg.GetProperty("Name") !.GetValue(Activator.CreateInstance(mesg)) !,
            mesg =>
            {
                var mesgInstance = (Mesg)Activator.CreateInstance(mesg) !;
                var num = (ushort)mesg.GetProperty("Num") !.GetValue(mesgInstance) !;
                var fields = mesg.GetNestedType("FieldDefNum") !.GetFields();

                return new ProfileMeta
                {
                    Num = num,
                        Fields =
                        fields.ToDictionary(field => field.Name,
                            field =>
                            {
                                var fieldNum = (byte)field.GetValue(mesgInstance) !;
                                mesgInstance.SetFieldValue(fieldNum, 0);
                                var fieldMeta = mesgInstance.GetField(fieldNum);
                                return new ProfileFieldMeta
                                {
                                    Num = fieldNum,
                                        ProfileType = fieldMeta.ProfileType.ToString(),
                                        Units = fieldMeta.Units,
                                        IsNumber = fieldMeta.IsNumeric()
                                };
                            })
                };
            });

        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profiles.json"),
            JsonSerializer.Serialize(profiles, HelperMethods.JsonSerializerOptions)
        );

        Console.WriteLine("profile.json have been generated");
    }

}

public class ProfileFieldMeta
{
    public byte Num { get; set; }
    public string ProfileType { get; set; } = null!;
    public string Units { get; set; } = "";
    public bool IsNumber { get; set; }
}

public class ProfileMeta
{
    public ushort Num { get; set; }
    public Dictionary<string, ProfileFieldMeta> Fields { get; set; } = new Dictionary<string, ProfileFieldMeta>();
}

public class TypeMeta
{
    public int Num { get; set; }
    public Dictionary<string, long> Fields { get; set; } = new Dictionary<string, long>();
}