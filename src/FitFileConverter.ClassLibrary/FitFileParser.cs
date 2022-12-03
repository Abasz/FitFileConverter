using System.Reflection.Metadata;
using File = System.IO.File;

namespace FitFileConverter.ClassLibrary;

public class FitFileParser
{
    private FitFileParser() { }

    public IEnumerable<FileIdMesg> FileIdMesgs { get; private set; } = new List<FileIdMesg>();
    public IEnumerable<FileCreatorMesg> FileCreatorMesgs { get; private set; } = new List<FileCreatorMesg>();
    public IEnumerable<TimestampCorrelationMesg> TimestampCorrelationMesgs { get; private set; } = new List<TimestampCorrelationMesg>();
    public IEnumerable<SoftwareMesg> SoftwareMesgs { get; private set; } = new List<SoftwareMesg>();
    public IEnumerable<SlaveDeviceMesg> SlaveDeviceMesgs { get; private set; } = new List<SlaveDeviceMesg>();
    public IEnumerable<CapabilitiesMesg> CapabilitiesMesgs { get; private set; } = new List<CapabilitiesMesg>();
    public IEnumerable<FileCapabilitiesMesg> FileCapabilitiesMesgs { get; private set; } = new List<FileCapabilitiesMesg>();
    public IEnumerable<MesgCapabilitiesMesg> MesgCapabilitiesMesgs { get; private set; } = new List<MesgCapabilitiesMesg>();
    public IEnumerable<FieldCapabilitiesMesg> FieldCapabilitiesMesgs { get; private set; } = new List<FieldCapabilitiesMesg>();
    public IEnumerable<DeviceSettingsMesg> DeviceSettingsMesgs { get; private set; } = new List<DeviceSettingsMesg>();
    public IEnumerable<UserProfileMesg> UserProfileMesgs { get; private set; } = new List<UserProfileMesg>();
    public IEnumerable<HrmProfileMesg> HrmProfileMesgs { get; private set; } = new List<HrmProfileMesg>();
    public IEnumerable<SdmProfileMesg> SdmProfileMesgs { get; private set; } = new List<SdmProfileMesg>();
    public IEnumerable<BikeProfileMesg> BikeProfileMesgs { get; private set; } = new List<BikeProfileMesg>();
    public IEnumerable<ConnectivityMesg> ConnectivityMesgs { get; private set; } = new List<ConnectivityMesg>();
    public IEnumerable<WatchfaceSettingsMesg> WatchfaceSettingsMesgs { get; private set; } = new List<WatchfaceSettingsMesg>();
    public IEnumerable<OhrSettingsMesg> OhrSettingsMesgs { get; private set; } = new List<OhrSettingsMesg>();
    public IEnumerable<ZonesTargetMesg> ZonesTargetMesgs { get; private set; } = new List<ZonesTargetMesg>();
    public IEnumerable<SportMesg> SportMesgs { get; private set; } = new List<SportMesg>();
    public IEnumerable<HrZoneMesg> HrZoneMesgs { get; private set; } = new List<HrZoneMesg>();
    public IEnumerable<SpeedZoneMesg> SpeedZoneMesgs { get; private set; } = new List<SpeedZoneMesg>();
    public IEnumerable<CadenceZoneMesg> CadenceZoneMesgs { get; private set; } = new List<CadenceZoneMesg>();
    public IEnumerable<PowerZoneMesg> PowerZoneMesgs { get; private set; } = new List<PowerZoneMesg>();
    public IEnumerable<MetZoneMesg> MetZoneMesgs { get; private set; } = new List<MetZoneMesg>();
    public IEnumerable<DiveSettingsMesg> DiveSettingsMesgs { get; private set; } = new List<DiveSettingsMesg>();
    public IEnumerable<DiveAlarmMesg> DiveAlarmMesgs { get; private set; } = new List<DiveAlarmMesg>();
    public IEnumerable<DiveGasMesg> DiveGasMesgs { get; private set; } = new List<DiveGasMesg>();
    public IEnumerable<GoalMesg> GoalMesgs { get; private set; } = new List<GoalMesg>();
    public IEnumerable<ActivityMesg> ActivityMesgs { get; private set; } = new List<ActivityMesg>();
    public IEnumerable<SessionMesg> SessionMesgs { get; private set; } = new List<SessionMesg>();
    public IEnumerable<LapMesg> LapMesgs { get; private set; } = new List<LapMesg>();
    public IEnumerable<LengthMesg> LengthMesgs { get; private set; } = new List<LengthMesg>();
    public IEnumerable<RecordMesg> RecordMesgs { get; private set; } = new List<RecordMesg>();
    public IEnumerable<EventMesg> EventMesgs { get; private set; } = new List<EventMesg>();
    public IEnumerable<DeviceInfoMesg> DeviceInfoMesgs { get; private set; } = new List<DeviceInfoMesg>();
    public IEnumerable<TrainingFileMesg> TrainingFileMesgs { get; private set; } = new List<TrainingFileMesg>();
    public IEnumerable<HrvMesg> HrvMesgs { get; private set; } = new List<HrvMesg>();
    public IEnumerable<WeatherConditionsMesg> WeatherConditionsMesgs { get; private set; } = new List<WeatherConditionsMesg>();
    public IEnumerable<WeatherAlertMesg> WeatherAlertMesgs { get; private set; } = new List<WeatherAlertMesg>();
    public IEnumerable<GpsMetadataMesg> GpsMetadataMesgs { get; private set; } = new List<GpsMetadataMesg>();
    public IEnumerable<CameraEventMesg> CameraEventMesgs { get; private set; } = new List<CameraEventMesg>();
    public IEnumerable<GyroscopeDataMesg> GyroscopeDataMesgs { get; private set; } = new List<GyroscopeDataMesg>();
    public IEnumerable<AccelerometerDataMesg> AccelerometerDataMesgs { get; private set; } = new List<AccelerometerDataMesg>();
    public IEnumerable<MagnetometerDataMesg> MagnetometerDataMesgs { get; private set; } = new List<MagnetometerDataMesg>();
    public IEnumerable<BarometerDataMesg> BarometerDataMesgs { get; private set; } = new List<BarometerDataMesg>();
    public IEnumerable<ThreeDSensorCalibrationMesg> ThreeDSensorCalibrationMesgs { get; private set; } = new List<ThreeDSensorCalibrationMesg>();
    public IEnumerable<OneDSensorCalibrationMesg> OneDSensorCalibrationMesgs { get; private set; } = new List<OneDSensorCalibrationMesg>();
    public IEnumerable<VideoFrameMesg> VideoFrameMesgs { get; private set; } = new List<VideoFrameMesg>();
    public IEnumerable<ObdiiDataMesg> ObdiiDataMesgs { get; private set; } = new List<ObdiiDataMesg>();
    public IEnumerable<NmeaSentenceMesg> NmeaSentenceMesgs { get; private set; } = new List<NmeaSentenceMesg>();
    public IEnumerable<AviationAttitudeMesg> AviationAttitudeMesgs { get; private set; } = new List<AviationAttitudeMesg>();
    public IEnumerable<VideoMesg> VideoMesgs { get; private set; } = new List<VideoMesg>();
    public IEnumerable<VideoTitleMesg> VideoTitleMesgs { get; private set; } = new List<VideoTitleMesg>();
    public IEnumerable<VideoDescriptionMesg> VideoDescriptionMesgs { get; private set; } = new List<VideoDescriptionMesg>();
    public IEnumerable<VideoClipMesg> VideoClipMesgs { get; private set; } = new List<VideoClipMesg>();
    public IEnumerable<SetMesg> SetMesgs { get; private set; } = new List<SetMesg>();
    public IEnumerable<JumpMesg> JumpMesgs { get; private set; } = new List<JumpMesg>();
    public IEnumerable<CourseMesg> CourseMesgs { get; private set; } = new List<CourseMesg>();
    public IEnumerable<CoursePointMesg> CoursePointMesgs { get; private set; } = new List<CoursePointMesg>();
    public IEnumerable<SegmentIdMesg> SegmentIdMesgs { get; private set; } = new List<SegmentIdMesg>();
    public IEnumerable<SegmentLeaderboardEntryMesg> SegmentLeaderboardEntryMesgs { get; private set; } = new List<SegmentLeaderboardEntryMesg>();
    public IEnumerable<SegmentPointMesg> SegmentPointMesgs { get; private set; } = new List<SegmentPointMesg>();
    public IEnumerable<SegmentLapMesg> SegmentLapMesgs { get; private set; } = new List<SegmentLapMesg>();
    public IEnumerable<SegmentFileMesg> SegmentFileMesgs { get; private set; } = new List<SegmentFileMesg>();
    public IEnumerable<WorkoutMesg> WorkoutMesgs { get; private set; } = new List<WorkoutMesg>();
    public IEnumerable<WorkoutSessionMesg> WorkoutSessionMesgs { get; private set; } = new List<WorkoutSessionMesg>();
    public IEnumerable<WorkoutStepMesg> WorkoutStepMesgs { get; private set; } = new List<WorkoutStepMesg>();
    public IEnumerable<ExerciseTitleMesg> ExerciseTitleMesgs { get; private set; } = new List<ExerciseTitleMesg>();
    public IEnumerable<ScheduleMesg> ScheduleMesgs { get; private set; } = new List<ScheduleMesg>();
    public IEnumerable<TotalsMesg> TotalsMesgs { get; private set; } = new List<TotalsMesg>();
    public IEnumerable<WeightScaleMesg> WeightScaleMesgs { get; private set; } = new List<WeightScaleMesg>();
    public IEnumerable<BloodPressureMesg> BloodPressureMesgs { get; private set; } = new List<BloodPressureMesg>();
    public IEnumerable<MonitoringInfoMesg> MonitoringInfoMesgs { get; private set; } = new List<MonitoringInfoMesg>();
    public IEnumerable<MonitoringMesg> MonitoringMesgs { get; private set; } = new List<MonitoringMesg>();
    public IEnumerable<HrMesg> HrMesgs { get; private set; } = new List<HrMesg>();
    public IEnumerable<StressLevelMesg> StressLevelMesgs { get; private set; } = new List<StressLevelMesg>();
    public IEnumerable<MemoGlobMesg> MemoGlobMesgs { get; private set; } = new List<MemoGlobMesg>();
    public IEnumerable<AntChannelIdMesg> AntChannelIdMesgs { get; private set; } = new List<AntChannelIdMesg>();
    public IEnumerable<AntRxMesg> AntRxMesgs { get; private set; } = new List<AntRxMesg>();
    public IEnumerable<AntTxMesg> AntTxMesgs { get; private set; } = new List<AntTxMesg>();
    public IEnumerable<ExdScreenConfigurationMesg> ExdScreenConfigurationMesgs { get; private set; } = new List<ExdScreenConfigurationMesg>();
    public IEnumerable<ExdDataFieldConfigurationMesg> ExdDataFieldConfigurationMesgs { get; private set; } = new List<ExdDataFieldConfigurationMesg>();
    public IEnumerable<ExdDataConceptConfigurationMesg> ExdDataConceptConfigurationMesgs { get; private set; } = new List<ExdDataConceptConfigurationMesg>();
    public IEnumerable<FieldDescriptionMesg> FieldDescriptionMesgs { get; private set; } = new List<FieldDescriptionMesg>();
    public IEnumerable<DeveloperDataIdMesg> DeveloperDataIdMesgs { get; private set; } = new List<DeveloperDataIdMesg>();
    public IEnumerable<DiveSummaryMesg> DiveSummaryMesgs { get; private set; } = new List<DiveSummaryMesg>();
    public IEnumerable<ClimbProMesg> ClimbProMesgs { get; private set; } = new List<ClimbProMesg>();
    public IEnumerable<PadMesg> PadMesgs { get; private set; } = new List<PadMesg>();
    public IEnumerable<Mesg> UnknownMesgs { get; private set; } = new List<Mesg>();

    public static FitFileParser FromFit(string fitFilePath)
    {
        if (!File.Exists(fitFilePath))
            throw new FileNotFoundException("Invalid Fit file path");

        var fitFileModel = new FitFileParser();
        var fitFileReader = new Decode();
        fitFileReader.MesgEvent += fitFileModel.ProcessMesgs;

        var fitSource = new FileStream(fitFilePath, FileMode.Open);
        fitFileReader.Read(fitSource);
        fitSource.Close();

        Console.WriteLine($"Decoded FIT file \"{fitFilePath}\"");

        return fitFileModel;
    }

    public static Task<FitFileParser> FromJsonAsync(string path, string fitFilePath, string? outputPath = null)
    {
        var fitFileModel = FromFit(fitFilePath);
        return FromJsonAsync(path, fitFileModel, outputPath);
    }

    public static async Task<FitFileParser> FromJsonAsync(string path, FitFileParser? fitFileModel = null, string? outputPath = null)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Invalid Json file path");

        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly?.FullName?.Contains("Fit,") ?? false).ElementAt(0);

        if (assemblies is null)
        {
            throw new InvalidOperationException("Fit Assembly is not loaded");
        }

        var pathEdited = outputPath ?? $"{Path.GetFileNameWithoutExtension(path)}-edited.fit";
        var profilesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profiles.json");
        var typesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "types.json");

        var outputFile = new FileStream($"{pathEdited}", FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

        var fitFileWriter = new Encode(ProtocolVersion.V20);
        fitFileWriter.Open(outputFile);

        var fitJsonFile = await HelperMethods.DeserializeJsonFileAsync<Dictionary<string, List<Dictionary<string, object>>>>(path) ?? throw new JsonException("Fit json file is in an invalid format");

        if (!File.Exists(profilesPath))
            GenerateFitMetadata.Generate(ShouldGenerateProfiles: true);

        var profiles = await HelperMethods.DeserializeJsonFileAsync<Dictionary<string, ProfileMeta>>(profilesPath) ?? throw new JsonException("Profiles.json file is in an invalid format");

        if (!File.Exists(typesPath))
            GenerateFitMetadata.Generate(ShouldGenerateTypes: true);

        var types = await HelperMethods.DeserializeJsonFileAsync<Dictionary<string, TypeMeta>>(typesPath) ?? throw new JsonException("Types.json file is in an invalid format");

        var developerDataIdMesgs = fitJsonFile.ContainsKey("developerDataId") ?
            CreateDeveloperDataIdMesgs(fitJsonFile["developerDataId"], profiles) :
            new List<DeveloperDataIdMesg>();
        developerDataIdMesgs.ForEach(developerDataIdMesg => fitFileWriter.Write(developerDataIdMesg));

        var fieldDescriptionMesgs = fitJsonFile.ContainsKey("fieldDescription") ? CreateFieldDescriptionMesgs(fitJsonFile["fieldDescription"], profiles) :
        new List<FieldDescriptionMesg>();
        fieldDescriptionMesgs.ForEach(fieldDescriptionMesg => fitFileWriter.Write(fieldDescriptionMesg));

        foreach (var key in fitJsonFile.Keys)
        {
            if (key.Contains("fieldDescription") || key.Contains("developerDataId")) continue;

            var index = 0;
            foreach (var mesgItems in fitJsonFile[key])
            {
                Mesg mesg;
                if (key.Contains("unknown"))
                {
                    var mesgNum = Convert.ToUInt16(key.Replace("unknown-", ""));
                    var unknownMesgs = fitFileModel?.UnknownMesgs.Where(mesg => mesg.Num == mesgNum);
                    if (unknownMesgs is null)
                        continue;

                    mesg = unknownMesgs.ElementAt(index);
                }
                else
                {
                    mesg = new Mesg(key, profiles[key].Num);
                }

                foreach (var property in mesgItems)
                {
                    var propertyValue = property.Value?.ToString();
                    if (property.Key.Contains("unknown"))
                    {
                        IEnumerable<Mesg>? currentMesgs = null;
                        if (fitFileModel is not null)
                            currentMesgs = (IEnumerable<Mesg>?)typeof(FitFileParser)?.GetProperty($"{key.ToFirstUpper()}Mesgs")?.GetValue(fitFileModel);

                        if ((currentMesgs is not null && currentMesgs.Any()) || key.Contains("unknown"))
                        {
                            var unknownMesg = key.Contains("unknown") ? mesg : currentMesgs!.ElementAt(index);
                            var unknownField = unknownMesg.GetField(Convert.ToByte(property.Key.Replace("unknown-", "")));
                            var test = unknownField.GetValue(Convert.ToByte(property.Key.Replace("unknown-", "")));

                            if (unknownField.Type != types["string"].Num && long.TryParse(propertyValue, out long value))
                            {
                                unknownField.SetValue(value);
                                mesg.SetField(unknownField);

                                continue;
                            }

                            var data = Encoding.UTF8.GetBytes(propertyValue ?? "");
                            var zdata = new byte[data.Length + 1];
                            data.CopyTo(zdata, 0);

                            unknownField.SetValue(zdata);
                            mesg.SetField(unknownField);
                        }

                        continue;
                    }

                    if (property.Key.Contains("developerFields"))
                    {
                        if (!developerDataIdMesgs.Any() || !fieldDescriptionMesgs.Any()) continue;

                        var i = 0;
                        foreach (var developerField in ((JsonElement)mesgItems["developerFields"]).Deserialize<Dictionary<string, object>>()!)
                        {
                            var fieldDescription = fieldDescriptionMesgs.Find(mesg => mesg.GetFieldNameAsString(0).Trim('\0').ToCamelCase() == developerField.Key);

                            if (fieldDescription is null) continue;

                            var developerDataId = developerDataIdMesgs.Find(field => field.GetDeveloperDataIndex() == fieldDescription.GetDeveloperDataIndex());

                            if (developerDataId is null) continue;

                            var developerFieldMesg = new DeveloperField(fieldDescription, developerDataId);
                            i++;

                            var value = (JsonElement)developerField.Value;

                            if (developerFieldMesg.Type >= types["sint8"].Num && developerFieldMesg.Type <= types["uint32"].Num)
                            {
                                developerFieldMesg.SetValue(value.GetInt64());
                            }


                            if (developerFieldMesg.Type == types["string"].Num)
                            {
                                var data = Encoding.UTF8.GetBytes(value.GetString() ?? "");
                                var zdata = new byte[data.Length + 1];
                                data.CopyTo(zdata, 0);

                                developerFieldMesg.SetValue(zdata);
                            }

                            if (developerFieldMesg.Type >= types["float32"].Num && developerFieldMesg.Type <= types["float64"].Num)
                            {
                                developerFieldMesg.SetValue(value.GetDouble());
                            }

                            mesg.SetDeveloperField(developerFieldMesg);
                        }
                        continue;
                    }

                    var propertyMeta = profiles[key].Fields[property.Key];

                    if (propertyMeta.ProfileType == "Byte")
                    {
                        if (property.Value is JsonElement jsonElement)
                        {
                            var i = 0;
                            foreach (var byteData in jsonElement.Deserialize<short[]>()!)
                            {
                                mesg.SetFieldValue(propertyMeta.Num, i, (byte)byteData);
                                i++;
                            };

                            continue;
                        }
                    }

                    if (propertyMeta.ProfileType == "String")
                    {
                        var data = Encoding.UTF8.GetBytes(propertyValue ?? "");
                        var zdata = new byte[data.Length + 1];
                        data.CopyTo(zdata, 0);

                        mesg.SetFieldValue(propertyMeta.Num, zdata);

                        continue;
                    }

                    if (propertyMeta.ProfileType == "DateTime" || propertyMeta.ProfileType == "LocalDateTime")
                    {
                        mesg.SetFieldValue(
                            propertyMeta.Num,
                            new Dynastream.Fit.DateTime(
                                System.DateTime.Parse(propertyValue ?? "1990-01-01").ToUniversalTime()).GetTimeStamp()
                        );

                        continue;
                    }

                    if (propertyMeta.Units == "semicircles")
                    {
                        var degrees = Convert.ToDouble(propertyValue) * (Math.Pow(2, 31) / 180);

                        mesg.SetFieldValue(propertyMeta.Num, degrees);

                        continue;
                    }

                    if (propertyMeta.IsNumber)
                    {
                        mesg.SetFieldValue(propertyMeta.Num, propertyValue);

                        continue;
                    }

                    var type = assemblies.GetType($"Dynastream.Fit.{propertyMeta.ProfileType}");
                    if (type is null)
                    {
                        mesg.SetFieldValue(propertyMeta.Num, propertyValue);

                        continue;
                    }

                    Enum.TryParse(type!, propertyValue, true, out object? enumValue);
                    mesg.SetFieldValue(propertyMeta.Num, enumValue);
                }
                fitFileWriter.Write(mesg);
                index++;
            }
        }

        fitFileWriter.Close();
        outputFile.Close();
        Console.WriteLine($"Decoded \"{path}\" file to \"{pathEdited}\"");

        return FromFit(pathEdited);
    }

    private static List<FieldDescriptionMesg> CreateFieldDescriptionMesgs(List<Dictionary<string, object>> fieldDescriptionJsonMesgs, Dictionary<string, ProfileMeta> profiles)
    {
        var fieldDescriptionMesgs = new List<FieldDescriptionMesg>();
        foreach (var fieldDescriptionJsonMesg in fieldDescriptionJsonMesgs)
        {
            var fieldDescriptionMesg = new FieldDescriptionMesg();

            foreach (var key in fieldDescriptionJsonMesg.Keys)
            {
                var propertyMeta = profiles["fieldDescription"].Fields[key];
                switch (propertyMeta.ProfileType)
                {
                    case "String":
                        var fieldData = ((JsonElement)fieldDescriptionJsonMesg[key]).Deserialize<string>();
                        var data = Encoding.UTF8.GetBytes(fieldData ?? "");
                        var zdata = new byte[data.Length + 1];
                        data.CopyTo(zdata, 0);

                        fieldDescriptionMesg.SetFieldValue(propertyMeta.Num, zdata);
                        break;
                    default:
                        fieldDescriptionMesg.SetFieldValue(propertyMeta.Num, ((JsonElement)fieldDescriptionJsonMesg[key]).GetInt32()!);
                        break;
                }
            };

            fieldDescriptionMesgs.Add(fieldDescriptionMesg);
        }
        return fieldDescriptionMesgs;
    }

    private static List<DeveloperDataIdMesg> CreateDeveloperDataIdMesgs(List<Dictionary<string, object>> developerDataIdJsonMesgs, Dictionary<string, ProfileMeta> profiles)
    {
        var developerDataIdMesgs = new List<DeveloperDataIdMesg>();
        foreach (var developerDataIdJsonMesg in developerDataIdJsonMesgs)
        {
            var developerDataIdMesg = new DeveloperDataIdMesg();

            foreach (var key in developerDataIdJsonMesg.Keys)
            {
                var propertyMeta = profiles["developerDataId"].Fields[key];
                switch (propertyMeta.ProfileType)
                {
                    case "Byte":
                        var data = ((JsonElement)developerDataIdJsonMesg[key]).Deserialize<short[]>()!;
                        var i = 0;
                        foreach (var byteData in data)
                        {
                            developerDataIdMesg.SetFieldValue(propertyMeta.Num, i, byteData);
                            i++;
                        }
                        break;

                    default:
                        developerDataIdMesg.SetFieldValue(propertyMeta.Num, ((JsonElement)developerDataIdJsonMesg[key]).GetInt32()!);
                        break;
                };
            }

            developerDataIdMesgs.Add(developerDataIdMesg);
        }

        return developerDataIdMesgs;
    }

    private void ProcessMesgs(object sender, MesgEventArgs e)
    {
        switch (e.mesg.Num)
        {
            case MesgNum.FileId:
                FileIdMesgs = FileIdMesgs.Append(new FileIdMesg(e.mesg));
                break;

            case MesgNum.FileCreator:
                FileCreatorMesgs = FileCreatorMesgs.Append(new FileCreatorMesg(e.mesg));
                break;

            case MesgNum.TimestampCorrelation:
                TimestampCorrelationMesgs = TimestampCorrelationMesgs.Append(new TimestampCorrelationMesg(e.mesg));
                break;

            case MesgNum.Software:
                SoftwareMesgs = SoftwareMesgs.Append(new SoftwareMesg(e.mesg));
                break;

            case MesgNum.SlaveDevice:
                SlaveDeviceMesgs = SlaveDeviceMesgs.Append(new SlaveDeviceMesg(e.mesg));
                break;

            case MesgNum.Capabilities:
                CapabilitiesMesgs = CapabilitiesMesgs.Append(new CapabilitiesMesg(e.mesg));
                break;

            case MesgNum.FileCapabilities:
                FileCapabilitiesMesgs = FileCapabilitiesMesgs.Append(new FileCapabilitiesMesg(e.mesg));
                break;

            case MesgNum.MesgCapabilities:
                MesgCapabilitiesMesgs = MesgCapabilitiesMesgs.Append(new MesgCapabilitiesMesg(e.mesg));
                break;

            case MesgNum.FieldCapabilities:
                FieldCapabilitiesMesgs = FieldCapabilitiesMesgs.Append(new FieldCapabilitiesMesg(e.mesg));
                break;

            case MesgNum.DeviceSettings:
                DeviceSettingsMesgs = DeviceSettingsMesgs.Append(new DeviceSettingsMesg(e.mesg));
                break;

            case MesgNum.UserProfile:
                UserProfileMesgs = UserProfileMesgs.Append(new UserProfileMesg(e.mesg));
                break;

            case MesgNum.HrmProfile:
                HrmProfileMesgs = HrmProfileMesgs.Append(new HrmProfileMesg(e.mesg));
                break;

            case MesgNum.SdmProfile:
                SdmProfileMesgs = SdmProfileMesgs.Append(new SdmProfileMesg(e.mesg));
                break;

            case MesgNum.BikeProfile:
                BikeProfileMesgs = BikeProfileMesgs.Append(new BikeProfileMesg(e.mesg));
                break;

            case MesgNum.Connectivity:
                ConnectivityMesgs = ConnectivityMesgs.Append(new ConnectivityMesg(e.mesg));
                break;

            case MesgNum.WatchfaceSettings:
                WatchfaceSettingsMesgs = WatchfaceSettingsMesgs.Append(new WatchfaceSettingsMesg(e.mesg));
                break;

            case MesgNum.OhrSettings:
                OhrSettingsMesgs = OhrSettingsMesgs.Append(new OhrSettingsMesg(e.mesg));
                break;

            case MesgNum.ZonesTarget:
                ZonesTargetMesgs = ZonesTargetMesgs.Append(new ZonesTargetMesg(e.mesg));
                break;

            case MesgNum.Sport:
                SportMesgs = SportMesgs.Append(new SportMesg(e.mesg));
                break;

            case MesgNum.HrZone:
                HrZoneMesgs = HrZoneMesgs.Append(new HrZoneMesg(e.mesg));
                break;

            case MesgNum.SpeedZone:
                SpeedZoneMesgs = SpeedZoneMesgs.Append(new SpeedZoneMesg(e.mesg));
                break;

            case MesgNum.CadenceZone:
                CadenceZoneMesgs = CadenceZoneMesgs.Append(new CadenceZoneMesg(e.mesg));
                break;

            case MesgNum.PowerZone:
                PowerZoneMesgs = PowerZoneMesgs.Append(new PowerZoneMesg(e.mesg));
                break;

            case MesgNum.MetZone:
                MetZoneMesgs = MetZoneMesgs.Append(new MetZoneMesg(e.mesg));
                break;

            case MesgNum.DiveSettings:
                DiveSettingsMesgs = DiveSettingsMesgs.Append(new DiveSettingsMesg(e.mesg));
                break;

            case MesgNum.DiveAlarm:
                DiveAlarmMesgs = DiveAlarmMesgs.Append(new DiveAlarmMesg(e.mesg));
                break;

            case MesgNum.DiveGas:
                DiveGasMesgs = DiveGasMesgs.Append(new DiveGasMesg(e.mesg));
                break;

            case MesgNum.Goal:
                GoalMesgs = GoalMesgs.Append(new GoalMesg(e.mesg));
                break;

            case MesgNum.Activity:
                ActivityMesgs = ActivityMesgs.Append(new ActivityMesg(e.mesg));
                break;

            case MesgNum.Session:
                SessionMesgs = SessionMesgs.Append(new SessionMesg(e.mesg));
                break;

            case MesgNum.Lap:
                LapMesgs = LapMesgs.Append(new LapMesg(e.mesg));
                break;

            case MesgNum.Length:
                LengthMesgs = LengthMesgs.Append(new LengthMesg(e.mesg));
                break;

            case MesgNum.Record:
                RecordMesgs = RecordMesgs.Append(new RecordMesg(e.mesg));
                break;

            case MesgNum.Event:
                EventMesgs = EventMesgs.Append(new EventMesg(e.mesg));
                break;

            case MesgNum.DeviceInfo:
                DeviceInfoMesgs = DeviceInfoMesgs.Append(new DeviceInfoMesg(e.mesg));
                break;

            case MesgNum.TrainingFile:
                TrainingFileMesgs = TrainingFileMesgs.Append(new TrainingFileMesg(e.mesg));
                break;

            case MesgNum.Hrv:
                HrvMesgs = HrvMesgs.Append(new HrvMesg(e.mesg));
                break;

            case MesgNum.WeatherConditions:
                WeatherConditionsMesgs = WeatherConditionsMesgs.Append(new WeatherConditionsMesg(e.mesg));
                break;

            case MesgNum.WeatherAlert:
                WeatherAlertMesgs = WeatherAlertMesgs.Append(new WeatherAlertMesg(e.mesg));
                break;

            case MesgNum.GpsMetadata:
                GpsMetadataMesgs = GpsMetadataMesgs.Append(new GpsMetadataMesg(e.mesg));
                break;

            case MesgNum.CameraEvent:
                CameraEventMesgs = CameraEventMesgs.Append(new CameraEventMesg(e.mesg));
                break;

            case MesgNum.GyroscopeData:
                GyroscopeDataMesgs = GyroscopeDataMesgs.Append(new GyroscopeDataMesg(e.mesg));
                break;

            case MesgNum.AccelerometerData:
                AccelerometerDataMesgs = AccelerometerDataMesgs.Append(new AccelerometerDataMesg(e.mesg));
                break;

            case MesgNum.MagnetometerData:
                MagnetometerDataMesgs = MagnetometerDataMesgs.Append(new MagnetometerDataMesg(e.mesg));
                break;

            case MesgNum.BarometerData:
                BarometerDataMesgs = BarometerDataMesgs.Append(new BarometerDataMesg(e.mesg));
                break;

            case MesgNum.ThreeDSensorCalibration:
                ThreeDSensorCalibrationMesgs = ThreeDSensorCalibrationMesgs.Append(new ThreeDSensorCalibrationMesg(e.mesg));
                break;

            case MesgNum.OneDSensorCalibration:
                OneDSensorCalibrationMesgs = OneDSensorCalibrationMesgs.Append(new OneDSensorCalibrationMesg(e.mesg));
                break;

            case MesgNum.VideoFrame:
                VideoFrameMesgs = VideoFrameMesgs.Append(new VideoFrameMesg(e.mesg));
                break;

            case MesgNum.ObdiiData:
                ObdiiDataMesgs = ObdiiDataMesgs.Append(new ObdiiDataMesg(e.mesg));
                break;

            case MesgNum.NmeaSentence:
                NmeaSentenceMesgs = NmeaSentenceMesgs.Append(new NmeaSentenceMesg(e.mesg));
                break;

            case MesgNum.AviationAttitude:
                AviationAttitudeMesgs = AviationAttitudeMesgs.Append(new AviationAttitudeMesg(e.mesg));
                break;

            case MesgNum.Video:
                VideoMesgs = VideoMesgs.Append(new VideoMesg(e.mesg));
                break;

            case MesgNum.VideoTitle:
                VideoTitleMesgs = VideoTitleMesgs.Append(new VideoTitleMesg(e.mesg));
                break;

            case MesgNum.VideoDescription:
                VideoDescriptionMesgs = VideoDescriptionMesgs.Append(new VideoDescriptionMesg(e.mesg));
                break;

            case MesgNum.VideoClip:
                VideoClipMesgs = VideoClipMesgs.Append(new VideoClipMesg(e.mesg));
                break;

            case MesgNum.Set:
                SetMesgs = SetMesgs.Append(new SetMesg(e.mesg));
                break;

            case MesgNum.Jump:
                JumpMesgs = JumpMesgs.Append(new JumpMesg(e.mesg));
                break;

            case MesgNum.Course:
                CourseMesgs = CourseMesgs.Append(new CourseMesg(e.mesg));
                break;

            case MesgNum.CoursePoint:
                CoursePointMesgs = CoursePointMesgs.Append(new CoursePointMesg(e.mesg));
                break;

            case MesgNum.SegmentId:
                SegmentIdMesgs = SegmentIdMesgs.Append(new SegmentIdMesg(e.mesg));
                break;

            case MesgNum.SegmentLeaderboardEntry:
                SegmentLeaderboardEntryMesgs = SegmentLeaderboardEntryMesgs.Append(new SegmentLeaderboardEntryMesg(e.mesg));
                break;

            case MesgNum.SegmentPoint:
                SegmentPointMesgs = SegmentPointMesgs.Append(new SegmentPointMesg(e.mesg));
                break;

            case MesgNum.SegmentLap:
                SegmentLapMesgs = SegmentLapMesgs.Append(new SegmentLapMesg(e.mesg));
                break;

            case MesgNum.SegmentFile:
                SegmentFileMesgs = SegmentFileMesgs.Append(new SegmentFileMesg(e.mesg));
                break;

            case MesgNum.Workout:
                WorkoutMesgs = WorkoutMesgs.Append(new WorkoutMesg(e.mesg));
                break;

            case MesgNum.WorkoutSession:
                WorkoutSessionMesgs = WorkoutSessionMesgs.Append(new WorkoutSessionMesg(e.mesg));
                break;

            case MesgNum.WorkoutStep:
                WorkoutStepMesgs = WorkoutStepMesgs.Append(new WorkoutStepMesg(e.mesg));
                break;

            case MesgNum.ExerciseTitle:
                ExerciseTitleMesgs = ExerciseTitleMesgs.Append(new ExerciseTitleMesg(e.mesg));
                break;

            case MesgNum.Schedule:
                ScheduleMesgs = ScheduleMesgs.Append(new ScheduleMesg(e.mesg));
                break;

            case MesgNum.Totals:
                TotalsMesgs = TotalsMesgs.Append(new TotalsMesg(e.mesg));
                break;

            case MesgNum.WeightScale:
                WeightScaleMesgs = WeightScaleMesgs.Append(new WeightScaleMesg(e.mesg));
                break;

            case MesgNum.BloodPressure:
                BloodPressureMesgs = BloodPressureMesgs.Append(new BloodPressureMesg(e.mesg));
                break;

            case MesgNum.MonitoringInfo:
                MonitoringInfoMesgs = MonitoringInfoMesgs.Append(new MonitoringInfoMesg(e.mesg));
                break;

            case MesgNum.Monitoring:
                MonitoringMesgs = MonitoringMesgs.Append(new MonitoringMesg(e.mesg));
                break;

            case MesgNum.Hr:
                HrMesgs = HrMesgs.Append(new HrMesg(e.mesg));
                break;

            case MesgNum.StressLevel:
                StressLevelMesgs = StressLevelMesgs.Append(new StressLevelMesg(e.mesg));
                break;

            case MesgNum.MemoGlob:
                MemoGlobMesgs = MemoGlobMesgs.Append(new MemoGlobMesg(e.mesg));
                break;

            case MesgNum.AntChannelId:
                AntChannelIdMesgs = AntChannelIdMesgs.Append(new AntChannelIdMesg(e.mesg));
                break;

            case MesgNum.AntRx:
                AntRxMesgs = AntRxMesgs.Append(new AntRxMesg(e.mesg));
                break;

            case MesgNum.AntTx:
                AntTxMesgs = AntTxMesgs.Append(new AntTxMesg(e.mesg));
                break;

            case MesgNum.ExdScreenConfiguration:
                ExdScreenConfigurationMesgs = ExdScreenConfigurationMesgs.Append(new ExdScreenConfigurationMesg(e.mesg));
                break;

            case MesgNum.ExdDataFieldConfiguration:
                ExdDataFieldConfigurationMesgs = ExdDataFieldConfigurationMesgs.Append(new ExdDataFieldConfigurationMesg(e.mesg));
                break;

            case MesgNum.ExdDataConceptConfiguration:
                ExdDataConceptConfigurationMesgs = ExdDataConceptConfigurationMesgs.Append(new ExdDataConceptConfigurationMesg(e.mesg));
                break;

            case MesgNum.FieldDescription:
                FieldDescriptionMesgs = FieldDescriptionMesgs.Append(new FieldDescriptionMesg(e.mesg));
                break;

            case MesgNum.DeveloperDataId:
                DeveloperDataIdMesgs = DeveloperDataIdMesgs.Append(new DeveloperDataIdMesg(e.mesg));
                break;

            case MesgNum.DiveSummary:
                DiveSummaryMesgs = DiveSummaryMesgs.Append(new DiveSummaryMesg(e.mesg));
                break;

            case MesgNum.ClimbPro:
                ClimbProMesgs = ClimbProMesgs.Append(new ClimbProMesg(e.mesg));
                break;

            case MesgNum.Pad:
                PadMesgs = PadMesgs.Append(new PadMesg(e.mesg));
                break;
            default:
                UnknownMesgs = UnknownMesgs.Append(e.mesg);
                break;
        }
    }

    public void Edit<T>(Func<T, T> newMesgs) where T : Mesg
    {

        switch (typeof(T).Name)
        {
            case "FileIdMesg":
                FileIdMesgs = FileIdMesgs
                    .Select((Func<FileIdMesg, FileIdMesg>)Delegate.CreateDelegate(typeof(Func<FileIdMesg, FileIdMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "FileCreatorMesg":
                FileCreatorMesgs = FileCreatorMesgs.Select((Func<FileCreatorMesg, FileCreatorMesg>)Delegate.CreateDelegate(typeof(Func<FileCreatorMesg, FileCreatorMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "TimestampCorrelationMesg":
                TimestampCorrelationMesgs = TimestampCorrelationMesgs.Select((Func<TimestampCorrelationMesg, TimestampCorrelationMesg>)Delegate.CreateDelegate(typeof(Func<TimestampCorrelationMesg, TimestampCorrelationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SoftwareMesg":
                SoftwareMesgs = SoftwareMesgs.Select((Func<SoftwareMesg, SoftwareMesg>)Delegate.CreateDelegate(typeof(Func<SoftwareMesg, SoftwareMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SlaveDeviceMesg":
                SlaveDeviceMesgs = SlaveDeviceMesgs.Select((Func<SlaveDeviceMesg, SlaveDeviceMesg>)Delegate.CreateDelegate(typeof(Func<SlaveDeviceMesg, SlaveDeviceMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "CapabilitiesMesg":
                CapabilitiesMesgs = CapabilitiesMesgs.Select((Func<CapabilitiesMesg, CapabilitiesMesg>)Delegate.CreateDelegate(typeof(Func<CapabilitiesMesg, CapabilitiesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "FileCapabilitiesMesg":
                FileCapabilitiesMesgs = FileCapabilitiesMesgs.Select((Func<FileCapabilitiesMesg, FileCapabilitiesMesg>)Delegate.CreateDelegate(typeof(Func<FileCapabilitiesMesg, FileCapabilitiesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "MesgCapabilitiesMesg":
                MesgCapabilitiesMesgs = MesgCapabilitiesMesgs.Select((Func<MesgCapabilitiesMesg, MesgCapabilitiesMesg>)Delegate.CreateDelegate(typeof(Func<MesgCapabilitiesMesg, MesgCapabilitiesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "FieldCapabilitiesMesg":
                FieldCapabilitiesMesgs = FieldCapabilitiesMesgs.Select((Func<FieldCapabilitiesMesg, FieldCapabilitiesMesg>)Delegate.CreateDelegate(typeof(Func<FieldCapabilitiesMesg, FieldCapabilitiesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "DeviceSettingsMesg":
                DeviceSettingsMesgs = DeviceSettingsMesgs.Select((Func<DeviceSettingsMesg, DeviceSettingsMesg>)Delegate.CreateDelegate(typeof(Func<DeviceSettingsMesg, DeviceSettingsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "UserProfileMesg":
                UserProfileMesgs = UserProfileMesgs.Select((Func<UserProfileMesg, UserProfileMesg>)Delegate.CreateDelegate(typeof(Func<UserProfileMesg, UserProfileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "HrmProfileMesg":
                HrmProfileMesgs = HrmProfileMesgs.Select((Func<HrmProfileMesg, HrmProfileMesg>)Delegate.CreateDelegate(typeof(Func<HrmProfileMesg, HrmProfileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SdmProfileMesg":
                SdmProfileMesgs = SdmProfileMesgs.Select((Func<SdmProfileMesg, SdmProfileMesg>)Delegate.CreateDelegate(typeof(Func<SdmProfileMesg, SdmProfileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "BikeProfileMesg":
                BikeProfileMesgs = BikeProfileMesgs.Select((Func<BikeProfileMesg, BikeProfileMesg>)Delegate.CreateDelegate(typeof(Func<BikeProfileMesg, BikeProfileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ConnectivityMesg":
                ConnectivityMesgs = ConnectivityMesgs.Select((Func<ConnectivityMesg, ConnectivityMesg>)Delegate.CreateDelegate(typeof(Func<ConnectivityMesg, ConnectivityMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "WatchfaceSettingsMesg":
                WatchfaceSettingsMesgs = WatchfaceSettingsMesgs.Select((Func<WatchfaceSettingsMesg, WatchfaceSettingsMesg>)Delegate.CreateDelegate(typeof(Func<WatchfaceSettingsMesg, WatchfaceSettingsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "OhrSettingsMesg":
                OhrSettingsMesgs = OhrSettingsMesgs.Select((Func<OhrSettingsMesg, OhrSettingsMesg>)Delegate.CreateDelegate(typeof(Func<OhrSettingsMesg, OhrSettingsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ZonesTargetMesg":
                ZonesTargetMesgs = ZonesTargetMesgs.Select((Func<ZonesTargetMesg, ZonesTargetMesg>)Delegate.CreateDelegate(typeof(Func<ZonesTargetMesg, ZonesTargetMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SportMesg":
                SportMesgs = SportMesgs.Select((Func<SportMesg, SportMesg>)Delegate.CreateDelegate(typeof(Func<SportMesg, SportMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "HrZoneMesg":
                HrZoneMesgs = HrZoneMesgs.Select((Func<HrZoneMesg, HrZoneMesg>)Delegate.CreateDelegate(typeof(Func<HrZoneMesg, HrZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SpeedZoneMesg":
                SpeedZoneMesgs = SpeedZoneMesgs.Select((Func<SpeedZoneMesg, SpeedZoneMesg>)Delegate.CreateDelegate(typeof(Func<SpeedZoneMesg, SpeedZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "CadenceZoneMesg":
                CadenceZoneMesgs = CadenceZoneMesgs.Select((Func<CadenceZoneMesg, CadenceZoneMesg>)Delegate.CreateDelegate(typeof(Func<CadenceZoneMesg, CadenceZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "PowerZoneMesg":
                PowerZoneMesgs = PowerZoneMesgs.Select((Func<PowerZoneMesg, PowerZoneMesg>)Delegate.CreateDelegate(typeof(Func<PowerZoneMesg, PowerZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "MetZoneMesg":
                MetZoneMesgs = MetZoneMesgs.Select((Func<MetZoneMesg, MetZoneMesg>)Delegate.CreateDelegate(typeof(Func<MetZoneMesg, MetZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "DiveSettingsMesg":
                DiveSettingsMesgs = DiveSettingsMesgs.Select((Func<DiveSettingsMesg, DiveSettingsMesg>)Delegate.CreateDelegate(typeof(Func<DiveSettingsMesg, DiveSettingsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "DiveAlarmMesg":
                DiveAlarmMesgs = DiveAlarmMesgs.Select((Func<DiveAlarmMesg, DiveAlarmMesg>)Delegate.CreateDelegate(typeof(Func<DiveAlarmMesg, DiveAlarmMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "DiveGasMesg":
                DiveGasMesgs = DiveGasMesgs.Select((Func<DiveGasMesg, DiveGasMesg>)Delegate.CreateDelegate(typeof(Func<DiveGasMesg, DiveGasMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "GoalMesg":
                GoalMesgs = GoalMesgs.Select((Func<GoalMesg, GoalMesg>)Delegate.CreateDelegate(typeof(Func<GoalMesg, GoalMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ActivityMesg":
                ActivityMesgs = ActivityMesgs.Select((Func<ActivityMesg, ActivityMesg>)Delegate.CreateDelegate(typeof(Func<ActivityMesg, ActivityMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SessionMesg":
                SessionMesgs = SessionMesgs.Select((Func<SessionMesg, SessionMesg>)Delegate.CreateDelegate(typeof(Func<SessionMesg, SessionMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "LapMesg":
                LapMesgs = LapMesgs.Select((Func<LapMesg, LapMesg>)Delegate.CreateDelegate(typeof(Func<LapMesg, LapMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "LengthMesg":
                LengthMesgs = LengthMesgs.Select((Func<LengthMesg, LengthMesg>)Delegate.CreateDelegate(typeof(Func<LengthMesg, LengthMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "RecordMesg":
                RecordMesgs = RecordMesgs.Select((Func<RecordMesg, RecordMesg>)Delegate.CreateDelegate(typeof(Func<RecordMesg, RecordMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "EventMesg":
                EventMesgs = EventMesgs.Select((Func<EventMesg, EventMesg>)Delegate.CreateDelegate(typeof(Func<EventMesg, EventMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "DeviceInfoMesg":
                DeviceInfoMesgs = DeviceInfoMesgs.Select((Func<DeviceInfoMesg, DeviceInfoMesg>)Delegate.CreateDelegate(typeof(Func<DeviceInfoMesg, DeviceInfoMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "TrainingFileMesg":
                TrainingFileMesgs = TrainingFileMesgs.Select((Func<TrainingFileMesg, TrainingFileMesg>)Delegate.CreateDelegate(typeof(Func<TrainingFileMesg, TrainingFileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "HrvMesg":
                HrvMesgs = HrvMesgs.Select((Func<HrvMesg, HrvMesg>)Delegate.CreateDelegate(typeof(Func<HrvMesg, HrvMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "WeatherConditionsMesg":
                WeatherConditionsMesgs = WeatherConditionsMesgs.Select((Func<WeatherConditionsMesg, WeatherConditionsMesg>)Delegate.CreateDelegate(typeof(Func<WeatherConditionsMesg, WeatherConditionsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "WeatherAlertMesg":
                WeatherAlertMesgs = WeatherAlertMesgs.Select((Func<WeatherAlertMesg, WeatherAlertMesg>)Delegate.CreateDelegate(typeof(Func<WeatherAlertMesg, WeatherAlertMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "GpsMetadataMesg":
                GpsMetadataMesgs = GpsMetadataMesgs.Select((Func<GpsMetadataMesg, GpsMetadataMesg>)Delegate.CreateDelegate(typeof(Func<GpsMetadataMesg, GpsMetadataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "CameraEventMesg":
                CameraEventMesgs = CameraEventMesgs.Select((Func<CameraEventMesg, CameraEventMesg>)Delegate.CreateDelegate(typeof(Func<CameraEventMesg, CameraEventMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "GyroscopeDataMesg":
                GyroscopeDataMesgs = GyroscopeDataMesgs.Select((Func<GyroscopeDataMesg, GyroscopeDataMesg>)Delegate.CreateDelegate(typeof(Func<GyroscopeDataMesg, GyroscopeDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "AccelerometerDataMesg":
                AccelerometerDataMesgs = AccelerometerDataMesgs.Select((Func<AccelerometerDataMesg, AccelerometerDataMesg>)Delegate.CreateDelegate(typeof(Func<AccelerometerDataMesg, AccelerometerDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "MagnetometerDataMesg":
                MagnetometerDataMesgs = MagnetometerDataMesgs.Select((Func<MagnetometerDataMesg, MagnetometerDataMesg>)Delegate.CreateDelegate(typeof(Func<MagnetometerDataMesg, MagnetometerDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "BarometerDataMesg":
                BarometerDataMesgs = BarometerDataMesgs.Select((Func<BarometerDataMesg, BarometerDataMesg>)Delegate.CreateDelegate(typeof(Func<BarometerDataMesg, BarometerDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ThreeDSensorCalibrationMesg":
                ThreeDSensorCalibrationMesgs = ThreeDSensorCalibrationMesgs.Select((Func<ThreeDSensorCalibrationMesg, ThreeDSensorCalibrationMesg>)Delegate.CreateDelegate(typeof(Func<ThreeDSensorCalibrationMesg, ThreeDSensorCalibrationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "OneDSensorCalibrationMesg":
                OneDSensorCalibrationMesgs = OneDSensorCalibrationMesgs.Select((Func<OneDSensorCalibrationMesg, OneDSensorCalibrationMesg>)Delegate.CreateDelegate(typeof(Func<OneDSensorCalibrationMesg, OneDSensorCalibrationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "VideoFrameMesg":
                VideoFrameMesgs = VideoFrameMesgs.Select((Func<VideoFrameMesg, VideoFrameMesg>)Delegate.CreateDelegate(typeof(Func<VideoFrameMesg, VideoFrameMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ObdiiDataMesg":
                ObdiiDataMesgs = ObdiiDataMesgs.Select((Func<ObdiiDataMesg, ObdiiDataMesg>)Delegate.CreateDelegate(typeof(Func<ObdiiDataMesg, ObdiiDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "NmeaSentenceMesg":
                NmeaSentenceMesgs = NmeaSentenceMesgs.Select((Func<NmeaSentenceMesg, NmeaSentenceMesg>)Delegate.CreateDelegate(typeof(Func<NmeaSentenceMesg, NmeaSentenceMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "AviationAttitudeMesg":
                AviationAttitudeMesgs = AviationAttitudeMesgs.Select((Func<AviationAttitudeMesg, AviationAttitudeMesg>)Delegate.CreateDelegate(typeof(Func<AviationAttitudeMesg, AviationAttitudeMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "VideoMesg":
                VideoMesgs = VideoMesgs.Select((Func<VideoMesg, VideoMesg>)Delegate.CreateDelegate(typeof(Func<VideoMesg, VideoMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "VideoTitleMesg":
                VideoTitleMesgs = VideoTitleMesgs.Select((Func<VideoTitleMesg, VideoTitleMesg>)Delegate.CreateDelegate(typeof(Func<VideoTitleMesg, VideoTitleMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "VideoDescriptionMesg":
                VideoDescriptionMesgs = VideoDescriptionMesgs.Select((Func<VideoDescriptionMesg, VideoDescriptionMesg>)Delegate.CreateDelegate(typeof(Func<VideoDescriptionMesg, VideoDescriptionMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "VideoClipMesg":
                VideoClipMesgs = VideoClipMesgs.Select((Func<VideoClipMesg, VideoClipMesg>)Delegate.CreateDelegate(typeof(Func<VideoClipMesg, VideoClipMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SetMesg":
                SetMesgs = SetMesgs.Select((Func<SetMesg, SetMesg>)Delegate.CreateDelegate(typeof(Func<SetMesg, SetMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "JumpMesg":
                JumpMesgs = JumpMesgs.Select((Func<JumpMesg, JumpMesg>)Delegate.CreateDelegate(typeof(Func<JumpMesg, JumpMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "CourseMesg":
                CourseMesgs = CourseMesgs.Select((Func<CourseMesg, CourseMesg>)Delegate.CreateDelegate(typeof(Func<CourseMesg, CourseMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "CoursePointMesg":
                CoursePointMesgs = CoursePointMesgs.Select((Func<CoursePointMesg, CoursePointMesg>)Delegate.CreateDelegate(typeof(Func<CoursePointMesg, CoursePointMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SegmentIdMesg":
                SegmentIdMesgs = SegmentIdMesgs.Select((Func<SegmentIdMesg, SegmentIdMesg>)Delegate.CreateDelegate(typeof(Func<SegmentIdMesg, SegmentIdMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SegmentLeaderboardEntryMesg":
                SegmentLeaderboardEntryMesgs = SegmentLeaderboardEntryMesgs.Select((Func<SegmentLeaderboardEntryMesg, SegmentLeaderboardEntryMesg>)Delegate.CreateDelegate(typeof(Func<SegmentLeaderboardEntryMesg, SegmentLeaderboardEntryMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SegmentPointMesg":
                SegmentPointMesgs = SegmentPointMesgs.Select((Func<SegmentPointMesg, SegmentPointMesg>)Delegate.CreateDelegate(typeof(Func<SegmentPointMesg, SegmentPointMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SegmentLapMesg":
                SegmentLapMesgs = SegmentLapMesgs.Select((Func<SegmentLapMesg, SegmentLapMesg>)Delegate.CreateDelegate(typeof(Func<SegmentLapMesg, SegmentLapMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "SegmentFileMesg":
                SegmentFileMesgs = SegmentFileMesgs.Select((Func<SegmentFileMesg, SegmentFileMesg>)Delegate.CreateDelegate(typeof(Func<SegmentFileMesg, SegmentFileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "WorkoutMesg":
                WorkoutMesgs = WorkoutMesgs.Select((Func<WorkoutMesg, WorkoutMesg>)Delegate.CreateDelegate(typeof(Func<WorkoutMesg, WorkoutMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "WorkoutSessionMesg":
                WorkoutSessionMesgs = WorkoutSessionMesgs.Select((Func<WorkoutSessionMesg, WorkoutSessionMesg>)Delegate.CreateDelegate(typeof(Func<WorkoutSessionMesg, WorkoutSessionMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "WorkoutStepMesg":
                WorkoutStepMesgs = WorkoutStepMesgs.Select((Func<WorkoutStepMesg, WorkoutStepMesg>)Delegate.CreateDelegate(typeof(Func<WorkoutStepMesg, WorkoutStepMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ExerciseTitleMesg":
                ExerciseTitleMesgs = ExerciseTitleMesgs.Select((Func<ExerciseTitleMesg, ExerciseTitleMesg>)Delegate.CreateDelegate(typeof(Func<ExerciseTitleMesg, ExerciseTitleMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ScheduleMesg":
                ScheduleMesgs = ScheduleMesgs.Select((Func<ScheduleMesg, ScheduleMesg>)Delegate.CreateDelegate(typeof(Func<ScheduleMesg, ScheduleMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "TotalsMesg":
                TotalsMesgs = TotalsMesgs.Select((Func<TotalsMesg, TotalsMesg>)Delegate.CreateDelegate(typeof(Func<TotalsMesg, TotalsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "WeightScaleMesg":
                WeightScaleMesgs = WeightScaleMesgs.Select((Func<WeightScaleMesg, WeightScaleMesg>)Delegate.CreateDelegate(typeof(Func<WeightScaleMesg, WeightScaleMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "BloodPressureMesg":
                BloodPressureMesgs = BloodPressureMesgs.Select((Func<BloodPressureMesg, BloodPressureMesg>)Delegate.CreateDelegate(typeof(Func<BloodPressureMesg, BloodPressureMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "MonitoringInfoMesg":
                MonitoringInfoMesgs = MonitoringInfoMesgs.Select((Func<MonitoringInfoMesg, MonitoringInfoMesg>)Delegate.CreateDelegate(typeof(Func<MonitoringInfoMesg, MonitoringInfoMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "MonitoringMesg":
                MonitoringMesgs = MonitoringMesgs.Select((Func<MonitoringMesg, MonitoringMesg>)Delegate.CreateDelegate(typeof(Func<MonitoringMesg, MonitoringMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "HrMesg":
                HrMesgs = HrMesgs.Select((Func<HrMesg, HrMesg>)Delegate.CreateDelegate(typeof(Func<HrMesg, HrMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "StressLevelMesg":
                StressLevelMesgs = StressLevelMesgs.Select((Func<StressLevelMesg, StressLevelMesg>)Delegate.CreateDelegate(typeof(Func<StressLevelMesg, StressLevelMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "MemoGlobMesg":
                MemoGlobMesgs = MemoGlobMesgs.Select((Func<MemoGlobMesg, MemoGlobMesg>)Delegate.CreateDelegate(typeof(Func<MemoGlobMesg, MemoGlobMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "AntChannelIdMesg":
                AntChannelIdMesgs = AntChannelIdMesgs.Select((Func<AntChannelIdMesg, AntChannelIdMesg>)Delegate.CreateDelegate(typeof(Func<AntChannelIdMesg, AntChannelIdMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "AntRxMesg":
                AntRxMesgs = AntRxMesgs.Select((Func<AntRxMesg, AntRxMesg>)Delegate.CreateDelegate(typeof(Func<AntRxMesg, AntRxMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "AntTxMesg":
                AntTxMesgs = AntTxMesgs.Select((Func<AntTxMesg, AntTxMesg>)Delegate.CreateDelegate(typeof(Func<AntTxMesg, AntTxMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ExdScreenConfigurationMesg":
                ExdScreenConfigurationMesgs = ExdScreenConfigurationMesgs.Select((Func<ExdScreenConfigurationMesg, ExdScreenConfigurationMesg>)Delegate.CreateDelegate(typeof(Func<ExdScreenConfigurationMesg, ExdScreenConfigurationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ExdDataFieldConfigurationMesg":
                ExdDataFieldConfigurationMesgs = ExdDataFieldConfigurationMesgs.Select((Func<ExdDataFieldConfigurationMesg, ExdDataFieldConfigurationMesg>)Delegate.CreateDelegate(typeof(Func<ExdDataFieldConfigurationMesg, ExdDataFieldConfigurationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ExdDataConceptConfigurationMesg":
                ExdDataConceptConfigurationMesgs = ExdDataConceptConfigurationMesgs.Select((Func<ExdDataConceptConfigurationMesg, ExdDataConceptConfigurationMesg>)Delegate.CreateDelegate(typeof(Func<ExdDataConceptConfigurationMesg, ExdDataConceptConfigurationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "FieldDescriptionMesg":
                FieldDescriptionMesgs = FieldDescriptionMesgs.Select((Func<FieldDescriptionMesg, FieldDescriptionMesg>)Delegate.CreateDelegate(typeof(Func<FieldDescriptionMesg, FieldDescriptionMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "DeveloperDataIdMesg":
                DeveloperDataIdMesgs = DeveloperDataIdMesgs.Select((Func<DeveloperDataIdMesg, DeveloperDataIdMesg>)Delegate.CreateDelegate(typeof(Func<DeveloperDataIdMesg, DeveloperDataIdMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "DiveSummaryMesg":
                DiveSummaryMesgs = DiveSummaryMesgs.Select((Func<DiveSummaryMesg, DiveSummaryMesg>)Delegate.CreateDelegate(typeof(Func<DiveSummaryMesg, DiveSummaryMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "ClimbProMesg":
                ClimbProMesgs = ClimbProMesgs.Select((Func<ClimbProMesg, ClimbProMesg>)Delegate.CreateDelegate(typeof(Func<ClimbProMesg, ClimbProMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;

            case "PadMesg":
                PadMesgs = PadMesgs.Select((Func<PadMesg, PadMesg>)Delegate.CreateDelegate(typeof(Func<PadMesg, PadMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "Mesg":
                UnknownMesgs = UnknownMesgs.Select((Func<Mesg, Mesg>)Delegate.CreateDelegate(typeof(Func<Mesg, Mesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
        }
    }
}