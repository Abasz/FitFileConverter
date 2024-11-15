using File = System.IO.File;

namespace FitFileConverter.ClassLibrary;

public static class FitFileParserExtensions
{
    public static void ToFit(this FitFileParser fitFileModel, string fitFilePath)
    {
        var outputFile = new FileStream(fitFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
        var fitFileWriter = new Encode(ProtocolVersion.V20);
        fitFileWriter.Open(outputFile);

        var properties = typeof(FitFileParser).GetProperties();
        foreach (var property in properties)
        {
            var mesgs = (IEnumerable<dynamic>?)property.GetValue(fitFileModel);
            if (mesgs is not null)
            {
                fitFileWriter.Write(mesgs.Cast<Mesg>());
            }
        }

        fitFileWriter.Close();
        outputFile.Close();
        Console.WriteLine($"Encoded FIT file \"{fitFilePath}\"");
    }

    public static void ToJson(this FitFileParser fitFileModel, string filePath)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName!.Contains("Fit,")).ElementAt(0);

        var parsedFitFile = typeof(FitFileParser).GetProperties()
            .Where(prop =>
            {
                var value = prop.GetValue(fitFileModel);
                return value is not null && ((IEnumerable<dynamic>)value).Any();
            })
            .Select(prop => ((IEnumerable<dynamic>)prop.GetValue(fitFileModel)!)
                .Select(mesg => new Mesg(mesg))
                .ToList()
            )
            .Aggregate(new List<List<Mesg>>(), (accumulator, mesgs) =>
            {
                if (mesgs.ElementAt(0).Name.Equals("unknown", StringComparison.CurrentCultureIgnoreCase))
                {
                    var unknownMesgGroups = mesgs.Select(mesg =>
                    {
                        mesg.Name = $"{mesg.Name}-{mesg.Num}";

                        return mesg;
                    }).GroupBy(mesg => mesg.Name);

                    accumulator.AddRange(unknownMesgGroups.Select(group =>
                        group.Aggregate(new List<Mesg>(), (accumulator, mesg) =>
                        {
                            accumulator.Add(mesg);
                            return accumulator;
                        })).ToList());
                }
                else
                {
                    accumulator.Add(mesgs);
                }

                return accumulator;
            }).ToDictionary(
                mesgs => mesgs[0].Name,
                mesgs => mesgs.Select(mesg =>
                    mesg.Fields.ToDictionary(field =>
                        field.Name.Equals("unknown", StringComparison.CurrentCultureIgnoreCase) ?
                        $"{field.Name}-{field.Num}" : field.Name,
                        field =>
                        {
                            var fieldType = new Field(field).ProfileType.ToString();

                            if (fieldType == "Byte")
                            {
                                var numberOfBytes = field.GetNumValues();
                                var i = 0;
                                var byteList = new List<byte>();
                                while (numberOfBytes > i)
                                {
                                    byteList.Add((byte)field.GetRawValue(i));
                                    i++;
                                }

                                return byteList;
                            }

                            var fieldValue = field.GetValue();

                            if (fieldValue is byte[] stringValue)
                                return Encoding.UTF8.GetString(stringValue).TrimEnd('\0');

                            if (field.IsNumeric())
                            {
                                if (field.GetUnits() == "semicircles")
                                {
                                    var degrees = (int)fieldValue * (180 / Math.Pow(2, 31));

                                    return degrees;
                                }

                                if (fieldType == "DateTime" ||
                                    fieldType == "LocalDateTime")
                                {
                                    var date = DateTimeOffset.FromUnixTimeSeconds((uint)fieldValue + 631065600).UtcDateTime;

                                    return date;
                                };

                                if (field.IsArray())
                                {
                                    var fieldValues = new List<double>();
                                    var i = 0;
                                    while (i < field.GetNumValues())
                                    {
                                        fieldValues.Add(Convert.ToDouble(field.GetValue(i)));
                                        i++;
                                    }

                                    return fieldValues;
                                }

                                return fieldValue;
                            }

                            var type = assemblies.GetType($"Dynastream.Fit.{fieldType ?? "Enum"}");
                            if (type is null)
                            {
                                return fieldValue;
                            }

                            return Enum.ToObject(type!, fieldValue ?? 0xFF)?.ToString()?.ToCamelCase() ?? fieldValue;
                        }
                    )
                    .Concat(mesg.DeveloperFields.Any() ? new Dictionary<string, object?>
                    {
                        {
                            "DeveloperFields",
                            mesg.DeveloperFields.ToDictionary(field =>
                                field.Name.Equals("unknown", StringComparison.CurrentCultureIgnoreCase) ? $"{field.Name}-{field.Num}" : field.Name.Split(" ").ToCamelCase(), field => (object?)field.GetValue())
                        }
                    } : [])
                    .ToDictionary(k => k.Key, k => k.Value))
                .ToList());

        File.WriteAllText(filePath,
            JsonSerializer.Serialize(parsedFitFile, HelperMethods.JsonSerializerOptions)
        );
    }

    private static bool IsArray(this Field field)
    {
        return field.GetNumValues() > 1;
    }
}