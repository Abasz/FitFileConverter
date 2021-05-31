// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Text;
// using System.Text.Json;

// using Dynastream.Fit;

// using FitFileEditor.Libs;

// namespace FitFileEditor.ConsoleApp
// {
//     public class Editor
//     {
//         private readonly bool _shouldMultiplyCadence;

//         public string FitFilePath { get; }
//         public List<RecordMesg> RecordMesgs { get; private set; } = new();
//         public List<LapMesg> LapMesgs { get; private set; } = new();
//         public List<SessionMesg> SessionMesgs { get; private set; } = new();
//         public List<SportMesg> SportMesgs { get; private set; } = new();
//         public List<Mesg> OtherMesgs { get; private set; } = new();
//         public List<FileIdMesg> FileIdMesgs { get; private set; } = new();
//         // public List<MesgDefinition> MesgDefinitions { get; private set; } = new();

//         public FitFileModel FitFileData { get; private set; } = new();

//         public Editor(string path, bool shouldMultiplyCadence = true)
//         {
//             FitFilePath = path;
//             _shouldMultiplyCadence = shouldMultiplyCadence;
//         }

//         public string ToJson()
//         {
//             var properties = typeof(FitFileModel).GetProperties();

//             var exportprop = properties.Where(prop => FitFileData.GetType().GetProperty(prop.Name)?.GetValue(FitFileData)is not null);

//             var newobject = new Dictionary<string, List<Dictionary<string, object?>>>();

//             var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName!.Contains("Fit,")).ElementAt(0);

//             newobject = exportprop.Select(prop => (List<Mesg>)FitFileData.GetType().GetProperty(prop.Name) !.GetValue(FitFileData) !).Aggregate(new List<List<Mesg>>(), (accumulator, mesgs) =>
//             {
//                 if (mesgs[0].Name.ToLower() == "unknown")
//                 {
//                     var unkownMesgGroups = mesgs.Select(mesg =>
//                     {
//                         mesg.Name = $"{mesg.Name}-{mesg.Num}";

//                         return mesg;
//                     }).GroupBy(mesg => mesg.Name);

//                     accumulator.AddRange(unkownMesgGroups.Select(group =>
//                         group
//                         .Aggregate(new List<Mesg>(), (accumulator, mesg) =>
//                         {
//                             accumulator.Add(mesg);
//                             return accumulator;
//                         })).ToList());
//                 }
//                 else
//                 {
//                     accumulator.Add(mesgs);
//                 }

//                 return accumulator;
//             }).ToDictionary(
//                 mesgs => mesgs[0].Name,
//                 mesgs => mesgs.Select(mesg =>
//                     mesg.Fields.ToDictionary(field =>
//                         field.Name.ToLower() == "unknown" ?
//                         $"{field.Name}-{field.Num}" : field.Name,
//                         field =>
//                         {
//                             var fieldValue = field.GetValue();
//                             var fieldType = new Field(field).ProfileType.ToString();

//                             if (fieldValue is byte[] stringValue)
//                                 return Encoding.UTF8.GetString(stringValue).TrimEnd('\0');

//                             if (field.IsNumeric())
//                             {
//                                 if (field.GetUnits() == "semicircles")
//                                 {
//                                     var degrees = (int)fieldValue * (180 / Math.Pow(2, 31));

//                                     return degrees;
//                                 }

//                                 if (fieldType == "DateTime" ||
//                                     fieldType == "LocalDateTime")
//                                 {
//                                     var date = DateTimeOffset.FromUnixTimeSeconds((uint)fieldValue + 631065600).UtcDateTime;

//                                     return date;
//                                 };

//                                 return fieldValue;
//                             }

//                             var enumValue = fieldValue ?? 0xFF;
//                             var type = assemblies.GetType($"Dynastream.Fit.{fieldType ?? "Enum"}");
//                             if (type is null)
//                             {
//                                 return fieldValue;
//                             }

//                             return Enum.ToObject(type!, enumValue)?.ToString()?.ToCamelCase() ?? fieldValue;
//                         }
//                     )
//                     .Concat(mesg.DeveloperFields.ToDictionary(field =>
//                         field.Name.ToLower() == "unknown" ? $"{field.Name}-{field.Num}" : field.Name, field => (object?)field.GetValue()))
//                     .ToDictionary(k => k.Key, k => k.Value))
//                 .ToList());

//             return JsonSerializer.Serialize(newobject, new JsonSerializerOptions()
//             {
//                 WriteIndented = true,
//                     PropertyNameCaseInsensitive = true,
//                     IgnoreNullValues = true,
//                     DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
//                     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//             });
//         }

//         public void Run()
//         {
//             Console.WriteLine($"Editing FIT file: {FitFilePath}");
//             MakeChanges();
//             WriteChanges();
//         }

//         public void ReadFile()
//         {
//             var fitFileReader = new Decode();
//             var mesgBroadcaster = new MesgBroadcaster();

//             fitFileReader.MesgEvent += mesgBroadcaster.OnMesg;
//             // fitFileReader.MesgDefinitionEvent += mesgBroadcaster.OnMesgDefinition;
//             fitFileReader.MesgEvent += FitFileData.OnMesg;

//             mesgBroadcaster.MesgEvent += (object sender, MesgEventArgs e) =>
//             {
//                 if (e.mesg.Name.ToLower() != "session" && e.mesg.Name.ToLower() != "record" && e.mesg.Name.ToLower() != "lap" && e.mesg.Name.ToLower() != "sport" && e.mesg.Name.ToLower() != "fileid")
//                 {
//                     OtherMesgs.Add(e.mesg);
//                 }
//             };

//             mesgBroadcaster.RecordMesgEvent += (object sender, MesgEventArgs e) =>
//             {
//                 RecordMesgs.Add((RecordMesg)e.mesg);
//             };

//             mesgBroadcaster.SessionMesgEvent += (object sender, MesgEventArgs e) =>
//             {
//                 SessionMesgs.Add((SessionMesg)e.mesg);
//             };

//             mesgBroadcaster.LapMesgEvent += (object sender, MesgEventArgs e) =>
//             {
//                 LapMesgs.Add((LapMesg)e.mesg);
//             };

//             mesgBroadcaster.SportMesgEvent += (object sender, MesgEventArgs e) =>
//             {
//                 SportMesgs.Add((SportMesg)e.mesg);
//             };

//             mesgBroadcaster.FileIdMesgEvent += (object sender, MesgEventArgs e) =>
//             {
//                 FileIdMesgs.Add((FileIdMesg)e.mesg);
//             };

//             // mesgBroadcaster.MesgDefinitionEvent += (object sender, MesgDefinitionEventArgs e) =>
//             // {
//             //     MesgDefinitions.Add(e.mesgDef);
//             // };

//             var fitSource = new FileStream(FitFilePath, FileMode.Open);
//             fitFileReader.Read(fitSource);
//             fitSource.Close();
//         }

//         private void MakeChanges()
//         {

//             //SPORTEMSG
//             SportMesgs = SportMesgs.Select(sportMesg =>
//             {
//                 sportMesg.SetSport(Sport.Rowing);
//                 sportMesg.SetSubSport(SubSport.Generic);
//                 sportMesg.SetName("Row");

//                 return sportMesg;
//             }).ToList();

//             //RECORDMESG
//             IEnumerable<RecordMesg> editedRecordData = RecordMesgs;
//             if (_shouldMultiplyCadence)
//             {
//                 editedRecordData = editedRecordData.MultiplyCadence(2);
//             }
//             RecordMesgs = editedRecordData.AddStrokeDistance().ToList();

//             //SESSIONMESG
//             var editedSessionData = SessionMesgs.Select(sessionMesg =>
//             {
//                 sessionMesg.SetSport(Sport.Rowing);
//                 sessionMesg.SetSubSport(SubSport.Generic);
//                 sessionMesg.SetFieldValue(110, Encoding.UTF8.GetBytes("Row"));

//                 return sessionMesg;
//             });
//             if (_shouldMultiplyCadence)
//             {
//                 editedSessionData = editedSessionData.MultiplyCadence(2);
//             }
//             SessionMesgs = editedSessionData.AddStrokeDistance(RecordMesgs).ToList();

//             //LAPMESG
//             var editedLapData = LapMesgs.Select(lap =>
//             {
//                 lap.SetSport(Sport.Rowing);
//                 lap.SetSubSport(SubSport.Generic);

//                 return lap;
//             });
//             if (_shouldMultiplyCadence)
//             {
//                 editedLapData = editedLapData.MultiplyCadence(2);
//             }
//             LapMesgs = editedLapData.AddStrokeDistance(RecordMesgs[0].GetTimestamp().GetDateTime(), RecordMesgs).ToList();

//         }

//         private void WriteChanges()
//         {
//             var outPath = $"{Path.GetFileNameWithoutExtension(FitFilePath)}-edited.fit";
//             var outputFile = new FileStream(outPath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
//             var fitFileWriter = new Encode(ProtocolVersion.V20);
//             fitFileWriter.Open(outputFile);

//             // MesgDefinitions.ForEach(mesgDefinition => fitFileWriter.Write(mesgDefinition));
//             FileIdMesgs.ForEach(fileIdMesg => fitFileWriter.Write(fileIdMesg));
//             OtherMesgs.ForEach(otherMesg => fitFileWriter.Write(otherMesg));
//             SportMesgs.ForEach(sportMesg => fitFileWriter.Write(sportMesg));
//             LapMesgs.ForEach(lapMesg => fitFileWriter.Write(lapMesg));
//             RecordMesgs.ForEach(recordMesg => fitFileWriter.Write(recordMesg));
//             SessionMesgs.ForEach(sessionMesg => fitFileWriter.Write(sessionMesg));

//             fitFileWriter.Close();
//             outputFile.Close();
//             Console.WriteLine($"Encoded FIT file {outPath}");
//         }
//     }
// }