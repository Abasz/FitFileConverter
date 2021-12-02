# FitFileParser Class Library

This class library is capable of parsing a Fit file to C# objects (FIT SDK Messages) enables editing/manipulating of these via the FIT SDK C# API than convert it back to a Fit file. Also enables conversion from Fit file to json and back without data loss (enabling changing sport, potentially multiplying cadence, etc. in json and convert it back to Fit file) .

## Parsing from file

### *Parsing from Fit file*

```cs
public static FitFileParser FromFit(string fitFilePath)
```
*Example:*
```cs
var fitFileParser = FitFileParser.FromFit("path/to/file.fit");
```

### *Parsing from Json file optionally using a Fit file*

```cs
public static async Task<FitFileParser> FromJsonAsync(string path, FitFileParser? fitFileModel = null, string? outputPath = null)
```
*Example:*
```cs
    originalFitData = FitFileParser.FromFit("path/to/fit-file.fit");
    await FitFileParser.FromJsonAsync("path/to/json-file.json", originalFitData, "path/to/output-file.fit");
```

### *Editing FIT SDK Fit Messages in the FitFileParser class*

```cs
public void Edit<T>(Func<T, T> newMesgs)where T : Mesg
```
*Example:*
```cs
var fitFileParser = FitFileParser.FromFit("path/to/fit-file.fit");
fitFileParser.Edit((SportMesg sportMesg) =>
    {
        if (sportMesg.GetSport() != Sport.Rowing)
            {
                sportMesg.SetSport(Sport.Rowing);
            sportMesg.SetSubSport(
                sportMesg.GetSubSport() == SubSport.IndoorCycling ?
                SubSport.IndoorRowing : SubSport.Generic
            );

            sportMesg.SetName("Row");
            sportMesg.SetFieldValue(4, 29);
        }
        return sportMesg;
    });

```

## Export to file

### *Export to Json*

```cs
  public static void ToFit(this FitFileParser fitFileModel, string fitFilePath)
```
*Example:*
```cs
    fitFileParser = await FitFileParser.FromJsonAsync("path/to/fit-file.json");
    fitFileParser.ToFit("path/to/output-file.fit");
```

### *Export to Fit*

```cs
  public static void ToJson(this FitFileParser fitFileModel, string filePath)
```
*Example:*
```cs
    fitFileParser = FitFileParser.FromFit("path/to/fit-file.fit");
    fitFileParser.ToFit("path/to/output-file.json");
```

## Generate Fit Metadata for conversion

```cs
  public static void Generate(bool ShouldGenerateProfiles = true, bool ShouldGenerateTypes = true)
```
*Example:*
```cs
GenerateFitMetadata.Generate(true, true);
```