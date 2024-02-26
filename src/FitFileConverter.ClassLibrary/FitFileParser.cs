using File = System.IO.File;

namespace FitFileConverter.ClassLibrary;

public class FitFileParser
{
    private FitFileParser() { }

    public IEnumerable<AadAccelFeaturesMesg> AadAccelFeaturesMesgs { get; private set; } = [];
    public IEnumerable<AccelerometerDataMesg> AccelerometerDataMesgs { get; private set; } = [];
    public IEnumerable<ActivityMesg> ActivityMesgs { get; private set; } = [];
    public IEnumerable<AntChannelIdMesg> AntChannelIdMesgs { get; private set; } = [];
    public IEnumerable<AntRxMesg> AntRxMesgs { get; private set; } = [];
    public IEnumerable<AntTxMesg> AntTxMesgs { get; private set; } = [];
    public IEnumerable<AviationAttitudeMesg> AviationAttitudeMesgs { get; private set; } = [];
    public IEnumerable<BarometerDataMesg> BarometerDataMesgs { get; private set; } = [];
    public IEnumerable<BeatIntervalsMesg> BeatIntervalsMesgs { get; private set; } = [];
    public IEnumerable<BikeProfileMesg> BikeProfileMesgs { get; private set; } = [];
    public IEnumerable<BloodPressureMesg> BloodPressureMesgs { get; private set; } = [];
    public IEnumerable<CadenceZoneMesg> CadenceZoneMesgs { get; private set; } = [];
    public IEnumerable<CameraEventMesg> CameraEventMesgs { get; private set; } = [];
    public IEnumerable<CapabilitiesMesg> CapabilitiesMesgs { get; private set; } = [];
    public IEnumerable<ChronoShotDataMesg> ChronoShotDataMesgs { get; private set; } = [];
    public IEnumerable<ChronoShotSessionMesg> ChronoShotSessionMesgs { get; private set; } = [];
    public IEnumerable<ClimbProMesg> ClimbProMesgs { get; private set; } = [];
    public IEnumerable<ConnectivityMesg> ConnectivityMesgs { get; private set; } = [];
    public IEnumerable<CourseMesg> CourseMesgs { get; private set; } = [];
    public IEnumerable<CoursePointMesg> CoursePointMesgs { get; private set; } = [];
    public IEnumerable<DeveloperDataIdMesg> DeveloperDataIdMesgs { get; private set; } = [];
    public IEnumerable<DeviceAuxBatteryInfoMesg> DeviceAuxBatteryInfoMesgs { get; private set; } = [];
    public IEnumerable<DeviceInfoMesg> DeviceInfoMesgs { get; private set; } = [];
    public IEnumerable<DeviceSettingsMesg> DeviceSettingsMesgs { get; private set; } = [];
    public IEnumerable<DiveAlarmMesg> DiveAlarmMesgs { get; private set; } = [];
    public IEnumerable<DiveApneaAlarmMesg> DiveApneaAlarmMesgs { get; private set; } = [];
    public IEnumerable<DiveGasMesg> DiveGasMesgs { get; private set; } = [];
    public IEnumerable<DiveSettingsMesg> DiveSettingsMesgs { get; private set; } = [];
    public IEnumerable<DiveSummaryMesg> DiveSummaryMesgs { get; private set; } = [];
    public IEnumerable<EventMesg> EventMesgs { get; private set; } = [];
    public IEnumerable<ExdDataConceptConfigurationMesg> ExdDataConceptConfigurationMesgs { get; private set; } = [];
    public IEnumerable<ExdDataFieldConfigurationMesg> ExdDataFieldConfigurationMesgs { get; private set; } = [];
    public IEnumerable<ExdScreenConfigurationMesg> ExdScreenConfigurationMesgs { get; private set; } = [];
    public IEnumerable<ExerciseTitleMesg> ExerciseTitleMesgs { get; private set; } = [];
    public IEnumerable<FieldCapabilitiesMesg> FieldCapabilitiesMesgs { get; private set; } = [];
    public IEnumerable<FieldDescriptionMesg> FieldDescriptionMesgs { get; private set; } = [];
    public IEnumerable<FileCapabilitiesMesg> FileCapabilitiesMesgs { get; private set; } = [];
    public IEnumerable<FileCreatorMesg> FileCreatorMesgs { get; private set; } = [];
    public IEnumerable<FileIdMesg> FileIdMesgs { get; private set; } = [];
    public IEnumerable<GoalMesg> GoalMesgs { get; private set; } = [];
    public IEnumerable<GpsMetadataMesg> GpsMetadataMesgs { get; private set; } = [];
    public IEnumerable<GyroscopeDataMesg> GyroscopeDataMesgs { get; private set; } = [];
    public IEnumerable<HrMesg> HrMesgs { get; private set; } = [];
    public IEnumerable<HrmProfileMesg> HrmProfileMesgs { get; private set; } = [];
    public IEnumerable<HrvMesg> HrvMesgs { get; private set; } = [];
    public IEnumerable<HrvStatusSummaryMesg> HrvStatusSummaryMesgs { get; private set; } = [];
    public IEnumerable<HrvValueMesg> HrvValueMesgs { get; private set; } = [];
    public IEnumerable<HrZoneMesg> HrZoneMesgs { get; private set; } = [];
    public IEnumerable<HsaAccelerometerDataMesg> HsaAccelerometerDataMesgs { get; private set; } = [];
    public IEnumerable<HsaBodyBatteryDataMesg> HsaBodyBatteryDataMesgs { get; private set; } = [];
    public IEnumerable<HsaConfigurationDataMesg> HsaConfigurationDataMesgs { get; private set; } = [];
    public IEnumerable<HsaEventMesg> HsaEventMesgs { get; private set; } = [];
    public IEnumerable<HsaGyroscopeDataMesg> HsaGyroscopeDataMesgs { get; private set; } = [];
    public IEnumerable<HsaHeartRateDataMesg> HsaHeartRateDataMesgs { get; private set; } = [];
    public IEnumerable<HsaRespirationDataMesg> HsaRespirationDataMesgs { get; private set; } = [];
    public IEnumerable<HsaSpo2DataMesg> HsaSpo2DataMesgs { get; private set; } = [];
    public IEnumerable<HsaStepDataMesg> HsaStepDataMesgs { get; private set; } = [];
    public IEnumerable<HsaStressDataMesg> HsaStressDataMesgs { get; private set; } = [];
    public IEnumerable<HsaWristTemperatureDataMesg> HsaWristTemperatureDataMesgs { get; private set; } = [];
    public IEnumerable<JumpMesg> JumpMesgs { get; private set; } = [];
    public IEnumerable<LapMesg> LapMesgs { get; private set; } = [];
    public IEnumerable<LengthMesg> LengthMesgs { get; private set; } = [];
    public IEnumerable<MagnetometerDataMesg> MagnetometerDataMesgs { get; private set; } = [];
    public IEnumerable<MaxMetDataMesg> MaxMetDataMesgs { get; private set; } = [];
    public IEnumerable<MemoGlobMesg> MemoGlobMesgs { get; private set; } = [];
    public IEnumerable<MesgCapabilitiesMesg> MesgCapabilitiesMesgs { get; private set; } = [];
    public IEnumerable<MetZoneMesg> MetZoneMesgs { get; private set; } = [];
    public IEnumerable<MonitoringHrDataMesg> MonitoringHrDataMesgs { get; private set; } = [];
    public IEnumerable<MonitoringInfoMesg> MonitoringInfoMesgs { get; private set; } = [];
    public IEnumerable<MonitoringMesg> MonitoringMesgs { get; private set; } = [];
    public IEnumerable<NmeaSentenceMesg> NmeaSentenceMesgs { get; private set; } = [];
    public IEnumerable<ObdiiDataMesg> ObdiiDataMesgs { get; private set; } = [];
    public IEnumerable<OhrSettingsMesg> OhrSettingsMesgs { get; private set; } = [];
    public IEnumerable<OneDSensorCalibrationMesg> OneDSensorCalibrationMesgs { get; private set; } = [];
    public IEnumerable<PadMesg> PadMesgs { get; private set; } = [];
    public IEnumerable<PowerZoneMesg> PowerZoneMesgs { get; private set; } = [];
    public IEnumerable<RawBbiMesg> RawBbiMesgs { get; private set; } = [];
    public IEnumerable<RecordMesg> RecordMesgs { get; private set; } = [];
    public IEnumerable<RespirationRateMesg> RespirationRateMesgs { get; private set; } = [];
    public IEnumerable<ScheduleMesg> ScheduleMesgs { get; private set; } = [];
    public IEnumerable<SdmProfileMesg> SdmProfileMesgs { get; private set; } = [];
    public IEnumerable<SegmentFileMesg> SegmentFileMesgs { get; private set; } = [];
    public IEnumerable<SegmentIdMesg> SegmentIdMesgs { get; private set; } = [];
    public IEnumerable<SegmentLapMesg> SegmentLapMesgs { get; private set; } = [];
    public IEnumerable<SegmentLeaderboardEntryMesg> SegmentLeaderboardEntryMesgs { get; private set; } = [];
    public IEnumerable<SegmentPointMesg> SegmentPointMesgs { get; private set; } = [];
    public IEnumerable<SessionMesg> SessionMesgs { get; private set; } = [];
    public IEnumerable<SetMesg> SetMesgs { get; private set; } = [];
    public IEnumerable<SlaveDeviceMesg> SlaveDeviceMesgs { get; private set; } = [];
    public IEnumerable<SleepAssessmentMesg> SleepAssessmentMesgs { get; private set; } = [];
    public IEnumerable<SleepLevelMesg> SleepLevelMesgs { get; private set; } = [];
    public IEnumerable<SoftwareMesg> SoftwareMesgs { get; private set; } = [];
    public IEnumerable<SpeedZoneMesg> SpeedZoneMesgs { get; private set; } = [];
    public IEnumerable<SplitMesg> SplitMesgs { get; private set; } = [];
    public IEnumerable<SplitSummaryMesg> SplitSummaryMesgs { get; private set; } = [];
    public IEnumerable<Spo2DataMesg> Spo2DataMesgs { get; private set; } = [];
    public IEnumerable<SportMesg> SportMesgs { get; private set; } = [];
    public IEnumerable<StressLevelMesg> StressLevelMesgs { get; private set; } = [];
    public IEnumerable<TankSummaryMesg> TankSummaryMesgs { get; private set; } = [];
    public IEnumerable<TankUpdateMesg> TankUpdateMesgs { get; private set; } = [];
    public IEnumerable<ThreeDSensorCalibrationMesg> ThreeDSensorCalibrationMesgs { get; private set; } = [];
    public IEnumerable<TimeInZoneMesg> TimeInZoneMesgs { get; private set; } = [];
    public IEnumerable<TimestampCorrelationMesg> TimestampCorrelationMesgs { get; private set; } = [];
    public IEnumerable<TotalsMesg> TotalsMesgs { get; private set; } = [];
    public IEnumerable<TrainingFileMesg> TrainingFileMesgs { get; private set; } = [];
    public IEnumerable<UserProfileMesg> UserProfileMesgs { get; private set; } = [];
    public IEnumerable<VideoClipMesg> VideoClipMesgs { get; private set; } = [];
    public IEnumerable<VideoDescriptionMesg> VideoDescriptionMesgs { get; private set; } = [];
    public IEnumerable<VideoFrameMesg> VideoFrameMesgs { get; private set; } = [];
    public IEnumerable<VideoMesg> VideoMesgs { get; private set; } = [];
    public IEnumerable<VideoTitleMesg> VideoTitleMesgs { get; private set; } = [];
    public IEnumerable<WatchfaceSettingsMesg> WatchfaceSettingsMesgs { get; private set; } = [];
    public IEnumerable<WeatherAlertMesg> WeatherAlertMesgs { get; private set; } = [];
    public IEnumerable<WeatherConditionsMesg> WeatherConditionsMesgs { get; private set; } = [];
    public IEnumerable<WeightScaleMesg> WeightScaleMesgs { get; private set; } = [];
    public IEnumerable<WorkoutMesg> WorkoutMesgs { get; private set; } = [];
    public IEnumerable<WorkoutSessionMesg> WorkoutSessionMesgs { get; private set; } = [];
    public IEnumerable<WorkoutStepMesg> WorkoutStepMesgs { get; private set; } = [];
    public IEnumerable<ZonesTargetMesg> ZonesTargetMesgs { get; private set; } = [];

    public IEnumerable<Mesg> UnknownMesgs { get; private set; } = [];

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

        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => assembly?.FullName?.Contains("Fit,") ?? false).ElementAt(0)
                ?? throw new InvalidOperationException("Fit Assembly is not loaded");

        var pathEdited = outputPath ?? $"{Path.GetFileNameWithoutExtension(path)}-edited.fit";
        var profilesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profiles.json");
        var typesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "types.json");

        var outputFile = new FileStream($"{pathEdited}", FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

        var fitFileWriter = new Encode(ProtocolVersion.V20);
        fitFileWriter.Open(outputFile);

        var fitJsonFile = await HelperMethods.DeserializeJsonFileAsync<Dictionary<string, List<Dictionary<string, object>>>>(path)
            ?? throw new JsonException("Fit json file is in an invalid format");

        if (!File.Exists(profilesPath))
            GenerateFitMetadata.Generate(ShouldGenerateProfiles: true);

        var profiles = await HelperMethods.DeserializeJsonFileAsync<Dictionary<string, ProfileMeta>>(profilesPath)
            ?? throw new JsonException("Profiles.json file is in an invalid format");

        if (!File.Exists(typesPath))
            GenerateFitMetadata.Generate(ShouldGenerateTypes: true);

        var types = await HelperMethods.DeserializeJsonFileAsync<Dictionary<string, TypeMeta>>(typesPath)
            ?? throw new JsonException("Types.json file is in an invalid format");

        var developerDataIdMesgs = fitJsonFile.TryGetValue("developerDataId", out List<Dictionary<string, object>>? developerDataIdValue) ?
            CreateDeveloperDataIdMesgs(developerDataIdValue, profiles) :
            [];
        developerDataIdMesgs.ForEach(fitFileWriter.Write);

        var fieldDescriptionMesgs = fitJsonFile.TryGetValue("fieldDescription", out List<Dictionary<string, object>>? fieldDescriptionValue) ? CreateFieldDescriptionMesgs(fieldDescriptionValue, profiles) :
        [];
        fieldDescriptionMesgs.ForEach(fitFileWriter.Write);

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
                    var propertyValue = property.Value.ToString() ?? "255";
                    if (property.Key.Contains("unknown"))
                    {
                        IEnumerable<Mesg>? currentMesgs = null;
                        if (fitFileModel is not null)
                            currentMesgs = (IEnumerable<Mesg>?)typeof(FitFileParser)?.GetProperty($"{key.ToFirstUpper()}Mesgs")?.GetValue(fitFileModel);

                        if ((currentMesgs is not null && currentMesgs.Any()) || key.Contains("unknown"))
                        {
                            var unknownMesg = key.Contains("unknown") ? mesg : currentMesgs!.ElementAt(index);
                            var unknownField = unknownMesg.GetField(Convert.ToByte(property.Key.Replace("unknown-", "")));

                            if (unknownField.Type != types["string"].Num && long.TryParse(propertyValue, out long value))
                            {
                                unknownField.SetValue(value);
                                mesg.SetField(unknownField);

                                continue;
                            }

                            if (property.Value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Array)
                            {
                                var i = 0;
                                foreach (var arrayData in jsonElement.Deserialize<double[]>()!)
                                {
                                    unknownField.SetValue(i, arrayData);
                                    i++;
                                };
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
                        if (developerDataIdMesgs.Count == 0 || fieldDescriptionMesgs.Count == 0) continue;

                        foreach (var developerField in ((JsonElement)mesgItems["developerFields"]).Deserialize<Dictionary<string, object>>()!)
                        {
                            var fieldDescription = fieldDescriptionMesgs.Find(mesg => mesg.GetFieldNameAsString(0).Trim('\0').ToCamelCase() == developerField.Key);

                            if (fieldDescription is null) continue;

                            var developerDataId = developerDataIdMesgs.Find(field => field.GetDeveloperDataIndex() == fieldDescription.GetDeveloperDataIndex());

                            if (developerDataId is null) continue;

                            var developerFieldMesg = new DeveloperField(fieldDescription, developerDataId);

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
                        if (property.Value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Array)
                        {
                            var i = 0;
                            foreach (var arrayData in jsonElement.Deserialize<double[]>()!)
                            {
                                mesg.SetFieldValue(propertyMeta.Num, i, arrayData);

                                i++;
                            };

                            continue;
                        }


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
                    mesg.SetFieldValue(propertyMeta.Num, enumValue ?? 255);
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
            case MesgNum.AadAccelFeatures:
                AadAccelFeaturesMesgs = AadAccelFeaturesMesgs.Append(new AadAccelFeaturesMesg(e.mesg));
                break;
            case MesgNum.AccelerometerData:
                AccelerometerDataMesgs = AccelerometerDataMesgs.Append(new AccelerometerDataMesg(e.mesg));
                break;
            case MesgNum.Activity:
                ActivityMesgs = ActivityMesgs.Append(new ActivityMesg(e.mesg));
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
            case MesgNum.AviationAttitude:
                AviationAttitudeMesgs = AviationAttitudeMesgs.Append(new AviationAttitudeMesg(e.mesg));
                break;
            case MesgNum.BarometerData:
                BarometerDataMesgs = BarometerDataMesgs.Append(new BarometerDataMesg(e.mesg));
                break;
            case MesgNum.BeatIntervals:
                BeatIntervalsMesgs = BeatIntervalsMesgs.Append(new BeatIntervalsMesg(e.mesg));
                break;
            case MesgNum.BikeProfile:
                BikeProfileMesgs = BikeProfileMesgs.Append(new BikeProfileMesg(e.mesg));
                break;
            case MesgNum.BloodPressure:
                BloodPressureMesgs = BloodPressureMesgs.Append(new BloodPressureMesg(e.mesg));
                break;
            case MesgNum.CadenceZone:
                CadenceZoneMesgs = CadenceZoneMesgs.Append(new CadenceZoneMesg(e.mesg));
                break;
            case MesgNum.CameraEvent:
                CameraEventMesgs = CameraEventMesgs.Append(new CameraEventMesg(e.mesg));
                break;
            case MesgNum.Capabilities:
                CapabilitiesMesgs = CapabilitiesMesgs.Append(new CapabilitiesMesg(e.mesg));
                break;
            case MesgNum.ChronoShotData:
                ChronoShotDataMesgs = ChronoShotDataMesgs.Append(new ChronoShotDataMesg(e.mesg));
                break;
            case MesgNum.ChronoShotSession:
                ChronoShotSessionMesgs = ChronoShotSessionMesgs.Append(new ChronoShotSessionMesg(e.mesg));
                break;
            case MesgNum.ClimbPro:
                ClimbProMesgs = ClimbProMesgs.Append(new ClimbProMesg(e.mesg));
                break;
            case MesgNum.Connectivity:
                ConnectivityMesgs = ConnectivityMesgs.Append(new ConnectivityMesg(e.mesg));
                break;
            case MesgNum.Course:
                CourseMesgs = CourseMesgs.Append(new CourseMesg(e.mesg));
                break;
            case MesgNum.CoursePoint:
                CoursePointMesgs = CoursePointMesgs.Append(new CoursePointMesg(e.mesg));
                break;
            case MesgNum.DeveloperDataId:
                DeveloperDataIdMesgs = DeveloperDataIdMesgs.Append(new DeveloperDataIdMesg(e.mesg));
                break;
            case MesgNum.DeviceAuxBatteryInfo:
                DeviceAuxBatteryInfoMesgs = DeviceAuxBatteryInfoMesgs.Append(new DeviceAuxBatteryInfoMesg(e.mesg));
                break;
            case MesgNum.DeviceInfo:
                DeviceInfoMesgs = DeviceInfoMesgs.Append(new DeviceInfoMesg(e.mesg));
                break;
            case MesgNum.DeviceSettings:
                DeviceSettingsMesgs = DeviceSettingsMesgs.Append(new DeviceSettingsMesg(e.mesg));
                break;
            case MesgNum.DiveAlarm:
                DiveAlarmMesgs = DiveAlarmMesgs.Append(new DiveAlarmMesg(e.mesg));
                break;
            case MesgNum.DiveApneaAlarm:
                DiveApneaAlarmMesgs = DiveApneaAlarmMesgs.Append(new DiveApneaAlarmMesg(e.mesg));
                break;
            case MesgNum.DiveGas:
                DiveGasMesgs = DiveGasMesgs.Append(new DiveGasMesg(e.mesg));
                break;
            case MesgNum.DiveSettings:
                DiveSettingsMesgs = DiveSettingsMesgs.Append(new DiveSettingsMesg(e.mesg));
                break;
            case MesgNum.DiveSummary:
                DiveSummaryMesgs = DiveSummaryMesgs.Append(new DiveSummaryMesg(e.mesg));
                break;
            case MesgNum.Event:
                EventMesgs = EventMesgs.Append(new EventMesg(e.mesg));
                break;
            case MesgNum.ExdDataConceptConfiguration:
                ExdDataConceptConfigurationMesgs = ExdDataConceptConfigurationMesgs.Append(new ExdDataConceptConfigurationMesg(e.mesg));
                break;
            case MesgNum.ExdDataFieldConfiguration:
                ExdDataFieldConfigurationMesgs = ExdDataFieldConfigurationMesgs.Append(new ExdDataFieldConfigurationMesg(e.mesg));
                break;
            case MesgNum.ExdScreenConfiguration:
                ExdScreenConfigurationMesgs = ExdScreenConfigurationMesgs.Append(new ExdScreenConfigurationMesg(e.mesg));
                break;
            case MesgNum.ExerciseTitle:
                ExerciseTitleMesgs = ExerciseTitleMesgs.Append(new ExerciseTitleMesg(e.mesg));
                break;
            case MesgNum.FieldCapabilities:
                FieldCapabilitiesMesgs = FieldCapabilitiesMesgs.Append(new FieldCapabilitiesMesg(e.mesg));
                break;
            case MesgNum.FieldDescription:
                FieldDescriptionMesgs = FieldDescriptionMesgs.Append(new FieldDescriptionMesg(e.mesg));
                break;
            case MesgNum.FileCapabilities:
                FileCapabilitiesMesgs = FileCapabilitiesMesgs.Append(new FileCapabilitiesMesg(e.mesg));
                break;
            case MesgNum.FileCreator:
                FileCreatorMesgs = FileCreatorMesgs.Append(new FileCreatorMesg(e.mesg));
                break;
            case MesgNum.FileId:
                FileIdMesgs = FileIdMesgs.Append(new FileIdMesg(e.mesg));
                break;
            case MesgNum.Goal:
                GoalMesgs = GoalMesgs.Append(new GoalMesg(e.mesg));
                break;
            case MesgNum.GpsMetadata:
                GpsMetadataMesgs = GpsMetadataMesgs.Append(new GpsMetadataMesg(e.mesg));
                break;
            case MesgNum.GyroscopeData:
                GyroscopeDataMesgs = GyroscopeDataMesgs.Append(new GyroscopeDataMesg(e.mesg));
                break;
            case MesgNum.Hr:
                HrMesgs = HrMesgs.Append(new HrMesg(e.mesg));
                break;
            case MesgNum.HrmProfile:
                HrmProfileMesgs = HrmProfileMesgs.Append(new HrmProfileMesg(e.mesg));
                break;
            case MesgNum.Hrv:
                HrvMesgs = HrvMesgs.Append(new HrvMesg(e.mesg));
                break;
            case MesgNum.HrvStatusSummary:
                HrvStatusSummaryMesgs = HrvStatusSummaryMesgs.Append(new HrvStatusSummaryMesg(e.mesg));
                break;
            case MesgNum.HrvValue:
                HrvValueMesgs = HrvValueMesgs.Append(new HrvValueMesg(e.mesg));
                break;
            case MesgNum.HrZone:
                HrZoneMesgs = HrZoneMesgs.Append(new HrZoneMesg(e.mesg));
                break;
            case MesgNum.HsaAccelerometerData:
                HsaAccelerometerDataMesgs = HsaAccelerometerDataMesgs.Append(new HsaAccelerometerDataMesg(e.mesg));
                break;
            case MesgNum.HsaBodyBatteryData:
                HsaBodyBatteryDataMesgs = HsaBodyBatteryDataMesgs.Append(new HsaBodyBatteryDataMesg(e.mesg));
                break;
            case MesgNum.HsaConfigurationData:
                HsaConfigurationDataMesgs = HsaConfigurationDataMesgs.Append(new HsaConfigurationDataMesg(e.mesg));
                break;
            case MesgNum.HsaEvent:
                HsaEventMesgs = HsaEventMesgs.Append(new HsaEventMesg(e.mesg));
                break;
            case MesgNum.HsaGyroscopeData:
                HsaGyroscopeDataMesgs = HsaGyroscopeDataMesgs.Append(new HsaGyroscopeDataMesg(e.mesg));
                break;
            case MesgNum.HsaHeartRateData:
                HsaHeartRateDataMesgs = HsaHeartRateDataMesgs.Append(new HsaHeartRateDataMesg(e.mesg));
                break;
            case MesgNum.HsaRespirationData:
                HsaRespirationDataMesgs = HsaRespirationDataMesgs.Append(new HsaRespirationDataMesg(e.mesg));
                break;
            case MesgNum.HsaSpo2Data:
                HsaSpo2DataMesgs = HsaSpo2DataMesgs.Append(new HsaSpo2DataMesg(e.mesg));
                break;
            case MesgNum.HsaStepData:
                HsaStepDataMesgs = HsaStepDataMesgs.Append(new HsaStepDataMesg(e.mesg));
                break;
            case MesgNum.HsaStressData:
                HsaStressDataMesgs = HsaStressDataMesgs.Append(new HsaStressDataMesg(e.mesg));
                break;
            case MesgNum.HsaWristTemperatureData:
                HsaWristTemperatureDataMesgs = HsaWristTemperatureDataMesgs.Append(new HsaWristTemperatureDataMesg(e.mesg));
                break;
            case MesgNum.Jump:
                JumpMesgs = JumpMesgs.Append(new JumpMesg(e.mesg));
                break;
            case MesgNum.Lap:
                LapMesgs = LapMesgs.Append(new LapMesg(e.mesg));
                break;
            case MesgNum.Length:
                LengthMesgs = LengthMesgs.Append(new LengthMesg(e.mesg));
                break;
            case MesgNum.MagnetometerData:
                MagnetometerDataMesgs = MagnetometerDataMesgs.Append(new MagnetometerDataMesg(e.mesg));
                break;
            case MesgNum.MaxMetData:
                MaxMetDataMesgs = MaxMetDataMesgs.Append(new MaxMetDataMesg(e.mesg));
                break;
            case MesgNum.MemoGlob:
                MemoGlobMesgs = MemoGlobMesgs.Append(new MemoGlobMesg(e.mesg));
                break;
            case MesgNum.MesgCapabilities:
                MesgCapabilitiesMesgs = MesgCapabilitiesMesgs.Append(new MesgCapabilitiesMesg(e.mesg));
                break;
            case MesgNum.MetZone:
                MetZoneMesgs = MetZoneMesgs.Append(new MetZoneMesg(e.mesg));
                break;
            case MesgNum.MonitoringHrData:
                MonitoringHrDataMesgs = MonitoringHrDataMesgs.Append(new MonitoringHrDataMesg(e.mesg));
                break;
            case MesgNum.MonitoringInfo:
                MonitoringInfoMesgs = MonitoringInfoMesgs.Append(new MonitoringInfoMesg(e.mesg));
                break;
            case MesgNum.Monitoring:
                MonitoringMesgs = MonitoringMesgs.Append(new MonitoringMesg(e.mesg));
                break;
            case MesgNum.NmeaSentence:
                NmeaSentenceMesgs = NmeaSentenceMesgs.Append(new NmeaSentenceMesg(e.mesg));
                break;
            case MesgNum.ObdiiData:
                ObdiiDataMesgs = ObdiiDataMesgs.Append(new ObdiiDataMesg(e.mesg));
                break;
            case MesgNum.OhrSettings:
                OhrSettingsMesgs = OhrSettingsMesgs.Append(new OhrSettingsMesg(e.mesg));
                break;
            case MesgNum.OneDSensorCalibration:
                OneDSensorCalibrationMesgs = OneDSensorCalibrationMesgs.Append(new OneDSensorCalibrationMesg(e.mesg));
                break;
            case MesgNum.Pad:
                PadMesgs = PadMesgs.Append(new PadMesg(e.mesg));
                break;
            case MesgNum.PowerZone:
                PowerZoneMesgs = PowerZoneMesgs.Append(new PowerZoneMesg(e.mesg));
                break;
            case MesgNum.RawBbi:
                RawBbiMesgs = RawBbiMesgs.Append(new RawBbiMesg(e.mesg));
                break;
            case MesgNum.Record:
                RecordMesgs = RecordMesgs.Append(new RecordMesg(e.mesg));
                break;
            case MesgNum.RespirationRate:
                RespirationRateMesgs = RespirationRateMesgs.Append(new RespirationRateMesg(e.mesg));
                break;
            case MesgNum.Schedule:
                ScheduleMesgs = ScheduleMesgs.Append(new ScheduleMesg(e.mesg));
                break;
            case MesgNum.SdmProfile:
                SdmProfileMesgs = SdmProfileMesgs.Append(new SdmProfileMesg(e.mesg));
                break;
            case MesgNum.SegmentFile:
                SegmentFileMesgs = SegmentFileMesgs.Append(new SegmentFileMesg(e.mesg));
                break;
            case MesgNum.SegmentId:
                SegmentIdMesgs = SegmentIdMesgs.Append(new SegmentIdMesg(e.mesg));
                break;
            case MesgNum.SegmentLap:
                SegmentLapMesgs = SegmentLapMesgs.Append(new SegmentLapMesg(e.mesg));
                break;
            case MesgNum.SegmentLeaderboardEntry:
                SegmentLeaderboardEntryMesgs = SegmentLeaderboardEntryMesgs.Append(new SegmentLeaderboardEntryMesg(e.mesg));
                break;
            case MesgNum.SegmentPoint:
                SegmentPointMesgs = SegmentPointMesgs.Append(new SegmentPointMesg(e.mesg));
                break;
            case MesgNum.Session:
                SessionMesgs = SessionMesgs.Append(new SessionMesg(e.mesg));
                break;
            case MesgNum.Set:
                SetMesgs = SetMesgs.Append(new SetMesg(e.mesg));
                break;
            case MesgNum.SlaveDevice:
                SlaveDeviceMesgs = SlaveDeviceMesgs.Append(new SlaveDeviceMesg(e.mesg));
                break;
            case MesgNum.SleepAssessment:
                SleepAssessmentMesgs = SleepAssessmentMesgs.Append(new SleepAssessmentMesg(e.mesg));
                break;
            case MesgNum.SleepLevel:
                SleepLevelMesgs = SleepLevelMesgs.Append(new SleepLevelMesg(e.mesg));
                break;
            case MesgNum.Software:
                SoftwareMesgs = SoftwareMesgs.Append(new SoftwareMesg(e.mesg));
                break;
            case MesgNum.SpeedZone:
                SpeedZoneMesgs = SpeedZoneMesgs.Append(new SpeedZoneMesg(e.mesg));
                break;
            case MesgNum.Split:
                SplitMesgs = SplitMesgs.Append(new SplitMesg(e.mesg));
                break;
            case MesgNum.SplitSummary:
                SplitSummaryMesgs = SplitSummaryMesgs.Append(new SplitSummaryMesg(e.mesg));
                break;
            case MesgNum.Spo2Data:
                Spo2DataMesgs = Spo2DataMesgs.Append(new Spo2DataMesg(e.mesg));
                break;
            case MesgNum.Sport:
                SportMesgs = SportMesgs.Append(new SportMesg(e.mesg));
                break;
            case MesgNum.StressLevel:
                StressLevelMesgs = StressLevelMesgs.Append(new StressLevelMesg(e.mesg));
                break;
            case MesgNum.TankSummary:
                TankSummaryMesgs = TankSummaryMesgs.Append(new TankSummaryMesg(e.mesg));
                break;
            case MesgNum.TankUpdate:
                TankUpdateMesgs = TankUpdateMesgs.Append(new TankUpdateMesg(e.mesg));
                break;
            case MesgNum.ThreeDSensorCalibration:
                ThreeDSensorCalibrationMesgs = ThreeDSensorCalibrationMesgs.Append(new ThreeDSensorCalibrationMesg(e.mesg));
                break;
            case MesgNum.TimeInZone:
                TimeInZoneMesgs = TimeInZoneMesgs.Append(new TimeInZoneMesg(e.mesg));
                break;
            case MesgNum.TimestampCorrelation:
                TimestampCorrelationMesgs = TimestampCorrelationMesgs.Append(new TimestampCorrelationMesg(e.mesg));
                break;
            case MesgNum.Totals:
                TotalsMesgs = TotalsMesgs.Append(new TotalsMesg(e.mesg));
                break;
            case MesgNum.TrainingFile:
                TrainingFileMesgs = TrainingFileMesgs.Append(new TrainingFileMesg(e.mesg));
                break;
            case MesgNum.UserProfile:
                UserProfileMesgs = UserProfileMesgs.Append(new UserProfileMesg(e.mesg));
                break;
            case MesgNum.VideoClip:
                VideoClipMesgs = VideoClipMesgs.Append(new VideoClipMesg(e.mesg));
                break;
            case MesgNum.VideoDescription:
                VideoDescriptionMesgs = VideoDescriptionMesgs.Append(new VideoDescriptionMesg(e.mesg));
                break;
            case MesgNum.VideoFrame:
                VideoFrameMesgs = VideoFrameMesgs.Append(new VideoFrameMesg(e.mesg));
                break;
            case MesgNum.Video:
                VideoMesgs = VideoMesgs.Append(new VideoMesg(e.mesg));
                break;
            case MesgNum.VideoTitle:
                VideoTitleMesgs = VideoTitleMesgs.Append(new VideoTitleMesg(e.mesg));
                break;
            case MesgNum.WatchfaceSettings:
                WatchfaceSettingsMesgs = WatchfaceSettingsMesgs.Append(new WatchfaceSettingsMesg(e.mesg));
                break;
            case MesgNum.WeatherAlert:
                WeatherAlertMesgs = WeatherAlertMesgs.Append(new WeatherAlertMesg(e.mesg));
                break;
            case MesgNum.WeatherConditions:
                WeatherConditionsMesgs = WeatherConditionsMesgs.Append(new WeatherConditionsMesg(e.mesg));
                break;
            case MesgNum.WeightScale:
                WeightScaleMesgs = WeightScaleMesgs.Append(new WeightScaleMesg(e.mesg));
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
            case MesgNum.ZonesTarget:
                ZonesTargetMesgs = ZonesTargetMesgs.Append(new ZonesTargetMesg(e.mesg));
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
            case "AadAccelFeaturesMesg":
                AadAccelFeaturesMesgs = AadAccelFeaturesMesgs.Select((Func<AadAccelFeaturesMesg, AadAccelFeaturesMesg>)Delegate.CreateDelegate(typeof(Func<AadAccelFeaturesMesg, AadAccelFeaturesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "AccelerometerDataMesg":
                AccelerometerDataMesgs = AccelerometerDataMesgs.Select((Func<AccelerometerDataMesg, AccelerometerDataMesg>)Delegate.CreateDelegate(typeof(Func<AccelerometerDataMesg, AccelerometerDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ActivityMesg":
                ActivityMesgs = ActivityMesgs.Select((Func<ActivityMesg, ActivityMesg>)Delegate.CreateDelegate(typeof(Func<ActivityMesg, ActivityMesg>), newMesgs.Target, newMesgs.Method)).ToList();
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
            case "AviationAttitudeMesg":
                AviationAttitudeMesgs = AviationAttitudeMesgs.Select((Func<AviationAttitudeMesg, AviationAttitudeMesg>)Delegate.CreateDelegate(typeof(Func<AviationAttitudeMesg, AviationAttitudeMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "BarometerDataMesg":
                BarometerDataMesgs = BarometerDataMesgs.Select((Func<BarometerDataMesg, BarometerDataMesg>)Delegate.CreateDelegate(typeof(Func<BarometerDataMesg, BarometerDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "BeatIntervalsMesg":
                BeatIntervalsMesgs = BeatIntervalsMesgs.Select((Func<BeatIntervalsMesg, BeatIntervalsMesg>)Delegate.CreateDelegate(typeof(Func<BeatIntervalsMesg, BeatIntervalsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "BikeProfileMesg":
                BikeProfileMesgs = BikeProfileMesgs.Select((Func<BikeProfileMesg, BikeProfileMesg>)Delegate.CreateDelegate(typeof(Func<BikeProfileMesg, BikeProfileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "BloodPressureMesg":
                BloodPressureMesgs = BloodPressureMesgs.Select((Func<BloodPressureMesg, BloodPressureMesg>)Delegate.CreateDelegate(typeof(Func<BloodPressureMesg, BloodPressureMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "CadenceZoneMesg":
                CadenceZoneMesgs = CadenceZoneMesgs.Select((Func<CadenceZoneMesg, CadenceZoneMesg>)Delegate.CreateDelegate(typeof(Func<CadenceZoneMesg, CadenceZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "CameraEventMesg":
                CameraEventMesgs = CameraEventMesgs.Select((Func<CameraEventMesg, CameraEventMesg>)Delegate.CreateDelegate(typeof(Func<CameraEventMesg, CameraEventMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "CapabilitiesMesg":
                CapabilitiesMesgs = CapabilitiesMesgs.Select((Func<CapabilitiesMesg, CapabilitiesMesg>)Delegate.CreateDelegate(typeof(Func<CapabilitiesMesg, CapabilitiesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ChronoShotDataMesg":
                ChronoShotDataMesgs = ChronoShotDataMesgs.Select((Func<ChronoShotDataMesg, ChronoShotDataMesg>)Delegate.CreateDelegate(typeof(Func<ChronoShotDataMesg, ChronoShotDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ChronoShotSessionMesg":
                ChronoShotSessionMesgs = ChronoShotSessionMesgs.Select((Func<ChronoShotSessionMesg, ChronoShotSessionMesg>)Delegate.CreateDelegate(typeof(Func<ChronoShotSessionMesg, ChronoShotSessionMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ClimbProMesg":
                ClimbProMesgs = ClimbProMesgs.Select((Func<ClimbProMesg, ClimbProMesg>)Delegate.CreateDelegate(typeof(Func<ClimbProMesg, ClimbProMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ConnectivityMesg":
                ConnectivityMesgs = ConnectivityMesgs.Select((Func<ConnectivityMesg, ConnectivityMesg>)Delegate.CreateDelegate(typeof(Func<ConnectivityMesg, ConnectivityMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "CourseMesg":
                CourseMesgs = CourseMesgs.Select((Func<CourseMesg, CourseMesg>)Delegate.CreateDelegate(typeof(Func<CourseMesg, CourseMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "CoursePointMesg":
                CoursePointMesgs = CoursePointMesgs.Select((Func<CoursePointMesg, CoursePointMesg>)Delegate.CreateDelegate(typeof(Func<CoursePointMesg, CoursePointMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DeveloperDataIdMesg":
                DeveloperDataIdMesgs = DeveloperDataIdMesgs.Select((Func<DeveloperDataIdMesg, DeveloperDataIdMesg>)Delegate.CreateDelegate(typeof(Func<DeveloperDataIdMesg, DeveloperDataIdMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DeviceAuxBatteryInfoMesg":
                DeviceAuxBatteryInfoMesgs = DeviceAuxBatteryInfoMesgs.Select((Func<DeviceAuxBatteryInfoMesg, DeviceAuxBatteryInfoMesg>)Delegate.CreateDelegate(typeof(Func<DeviceAuxBatteryInfoMesg, DeviceAuxBatteryInfoMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DeviceInfoMesg":
                DeviceInfoMesgs = DeviceInfoMesgs.Select((Func<DeviceInfoMesg, DeviceInfoMesg>)Delegate.CreateDelegate(typeof(Func<DeviceInfoMesg, DeviceInfoMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DeviceSettingsMesg":
                DeviceSettingsMesgs = DeviceSettingsMesgs.Select((Func<DeviceSettingsMesg, DeviceSettingsMesg>)Delegate.CreateDelegate(typeof(Func<DeviceSettingsMesg, DeviceSettingsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DiveAlarmMesg":
                DiveAlarmMesgs = DiveAlarmMesgs.Select((Func<DiveAlarmMesg, DiveAlarmMesg>)Delegate.CreateDelegate(typeof(Func<DiveAlarmMesg, DiveAlarmMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DiveApneaAlarmMesg":
                DiveApneaAlarmMesgs = DiveApneaAlarmMesgs.Select((Func<DiveApneaAlarmMesg, DiveApneaAlarmMesg>)Delegate.CreateDelegate(typeof(Func<DiveApneaAlarmMesg, DiveApneaAlarmMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DiveGasMesg":
                DiveGasMesgs = DiveGasMesgs.Select((Func<DiveGasMesg, DiveGasMesg>)Delegate.CreateDelegate(typeof(Func<DiveGasMesg, DiveGasMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DiveSettingsMesg":
                DiveSettingsMesgs = DiveSettingsMesgs.Select((Func<DiveSettingsMesg, DiveSettingsMesg>)Delegate.CreateDelegate(typeof(Func<DiveSettingsMesg, DiveSettingsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "DiveSummaryMesg":
                DiveSummaryMesgs = DiveSummaryMesgs.Select((Func<DiveSummaryMesg, DiveSummaryMesg>)Delegate.CreateDelegate(typeof(Func<DiveSummaryMesg, DiveSummaryMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "EventMesg":
                EventMesgs = EventMesgs.Select((Func<EventMesg, EventMesg>)Delegate.CreateDelegate(typeof(Func<EventMesg, EventMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ExdDataConceptConfigurationMesg":
                ExdDataConceptConfigurationMesgs = ExdDataConceptConfigurationMesgs.Select((Func<ExdDataConceptConfigurationMesg, ExdDataConceptConfigurationMesg>)Delegate.CreateDelegate(typeof(Func<ExdDataConceptConfigurationMesg, ExdDataConceptConfigurationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ExdDataFieldConfigurationMesg":
                ExdDataFieldConfigurationMesgs = ExdDataFieldConfigurationMesgs.Select((Func<ExdDataFieldConfigurationMesg, ExdDataFieldConfigurationMesg>)Delegate.CreateDelegate(typeof(Func<ExdDataFieldConfigurationMesg, ExdDataFieldConfigurationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ExdScreenConfigurationMesg":
                ExdScreenConfigurationMesgs = ExdScreenConfigurationMesgs.Select((Func<ExdScreenConfigurationMesg, ExdScreenConfigurationMesg>)Delegate.CreateDelegate(typeof(Func<ExdScreenConfigurationMesg, ExdScreenConfigurationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ExerciseTitleMesg":
                ExerciseTitleMesgs = ExerciseTitleMesgs.Select((Func<ExerciseTitleMesg, ExerciseTitleMesg>)Delegate.CreateDelegate(typeof(Func<ExerciseTitleMesg, ExerciseTitleMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "FieldCapabilitiesMesg":
                FieldCapabilitiesMesgs = FieldCapabilitiesMesgs.Select((Func<FieldCapabilitiesMesg, FieldCapabilitiesMesg>)Delegate.CreateDelegate(typeof(Func<FieldCapabilitiesMesg, FieldCapabilitiesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "FieldDescriptionMesg":
                FieldDescriptionMesgs = FieldDescriptionMesgs.Select((Func<FieldDescriptionMesg, FieldDescriptionMesg>)Delegate.CreateDelegate(typeof(Func<FieldDescriptionMesg, FieldDescriptionMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "FileCapabilitiesMesg":
                FileCapabilitiesMesgs = FileCapabilitiesMesgs.Select((Func<FileCapabilitiesMesg, FileCapabilitiesMesg>)Delegate.CreateDelegate(typeof(Func<FileCapabilitiesMesg, FileCapabilitiesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "FileCreatorMesg":
                FileCreatorMesgs = FileCreatorMesgs.Select((Func<FileCreatorMesg, FileCreatorMesg>)Delegate.CreateDelegate(typeof(Func<FileCreatorMesg, FileCreatorMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "FileIdMesg":
                FileIdMesgs = FileIdMesgs.Select((Func<FileIdMesg, FileIdMesg>)Delegate.CreateDelegate(typeof(Func<FileIdMesg, FileIdMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "GoalMesg":
                GoalMesgs = GoalMesgs.Select((Func<GoalMesg, GoalMesg>)Delegate.CreateDelegate(typeof(Func<GoalMesg, GoalMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "GpsMetadataMesg":
                GpsMetadataMesgs = GpsMetadataMesgs.Select((Func<GpsMetadataMesg, GpsMetadataMesg>)Delegate.CreateDelegate(typeof(Func<GpsMetadataMesg, GpsMetadataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "GyroscopeDataMesg":
                GyroscopeDataMesgs = GyroscopeDataMesgs.Select((Func<GyroscopeDataMesg, GyroscopeDataMesg>)Delegate.CreateDelegate(typeof(Func<GyroscopeDataMesg, GyroscopeDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HrMesg":
                HrMesgs = HrMesgs.Select((Func<HrMesg, HrMesg>)Delegate.CreateDelegate(typeof(Func<HrMesg, HrMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HrmProfileMesg":
                HrmProfileMesgs = HrmProfileMesgs.Select((Func<HrmProfileMesg, HrmProfileMesg>)Delegate.CreateDelegate(typeof(Func<HrmProfileMesg, HrmProfileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HrvMesg":
                HrvMesgs = HrvMesgs.Select((Func<HrvMesg, HrvMesg>)Delegate.CreateDelegate(typeof(Func<HrvMesg, HrvMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HrvStatusSummaryMesg":
                HrvStatusSummaryMesgs = HrvStatusSummaryMesgs.Select((Func<HrvStatusSummaryMesg, HrvStatusSummaryMesg>)Delegate.CreateDelegate(typeof(Func<HrvStatusSummaryMesg, HrvStatusSummaryMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HrvValueMesg":
                HrvValueMesgs = HrvValueMesgs.Select((Func<HrvValueMesg, HrvValueMesg>)Delegate.CreateDelegate(typeof(Func<HrvValueMesg, HrvValueMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HrZoneMesg":
                HrZoneMesgs = HrZoneMesgs.Select((Func<HrZoneMesg, HrZoneMesg>)Delegate.CreateDelegate(typeof(Func<HrZoneMesg, HrZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaAccelerometerDataMesg":
                HsaAccelerometerDataMesgs = HsaAccelerometerDataMesgs.Select((Func<HsaAccelerometerDataMesg, HsaAccelerometerDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaAccelerometerDataMesg, HsaAccelerometerDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaBodyBatteryDataMesg":
                HsaBodyBatteryDataMesgs = HsaBodyBatteryDataMesgs.Select((Func<HsaBodyBatteryDataMesg, HsaBodyBatteryDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaBodyBatteryDataMesg, HsaBodyBatteryDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaConfigurationDataMesg":
                HsaConfigurationDataMesgs = HsaConfigurationDataMesgs.Select((Func<HsaConfigurationDataMesg, HsaConfigurationDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaConfigurationDataMesg, HsaConfigurationDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaEventMesg":
                HsaEventMesgs = HsaEventMesgs.Select((Func<HsaEventMesg, HsaEventMesg>)Delegate.CreateDelegate(typeof(Func<HsaEventMesg, HsaEventMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaGyroscopeDataMesg":
                HsaGyroscopeDataMesgs = HsaGyroscopeDataMesgs.Select((Func<HsaGyroscopeDataMesg, HsaGyroscopeDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaGyroscopeDataMesg, HsaGyroscopeDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaHeartRateDataMesg":
                HsaHeartRateDataMesgs = HsaHeartRateDataMesgs.Select((Func<HsaHeartRateDataMesg, HsaHeartRateDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaHeartRateDataMesg, HsaHeartRateDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaRespirationDataMesg":
                HsaRespirationDataMesgs = HsaRespirationDataMesgs.Select((Func<HsaRespirationDataMesg, HsaRespirationDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaRespirationDataMesg, HsaRespirationDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaSpo2DataMesg":
                HsaSpo2DataMesgs = HsaSpo2DataMesgs.Select((Func<HsaSpo2DataMesg, HsaSpo2DataMesg>)Delegate.CreateDelegate(typeof(Func<HsaSpo2DataMesg, HsaSpo2DataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaStepDataMesg":
                HsaStepDataMesgs = HsaStepDataMesgs.Select((Func<HsaStepDataMesg, HsaStepDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaStepDataMesg, HsaStepDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaStressDataMesg":
                HsaStressDataMesgs = HsaStressDataMesgs.Select((Func<HsaStressDataMesg, HsaStressDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaStressDataMesg, HsaStressDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "HsaWristTemperatureDataMesg":
                HsaWristTemperatureDataMesgs = HsaWristTemperatureDataMesgs.Select((Func<HsaWristTemperatureDataMesg, HsaWristTemperatureDataMesg>)Delegate.CreateDelegate(typeof(Func<HsaWristTemperatureDataMesg, HsaWristTemperatureDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "JumpMesg":
                JumpMesgs = JumpMesgs.Select((Func<JumpMesg, JumpMesg>)Delegate.CreateDelegate(typeof(Func<JumpMesg, JumpMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "LapMesg":
                LapMesgs = LapMesgs.Select((Func<LapMesg, LapMesg>)Delegate.CreateDelegate(typeof(Func<LapMesg, LapMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "LengthMesg":
                LengthMesgs = LengthMesgs.Select((Func<LengthMesg, LengthMesg>)Delegate.CreateDelegate(typeof(Func<LengthMesg, LengthMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "MagnetometerDataMesg":
                MagnetometerDataMesgs = MagnetometerDataMesgs.Select((Func<MagnetometerDataMesg, MagnetometerDataMesg>)Delegate.CreateDelegate(typeof(Func<MagnetometerDataMesg, MagnetometerDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "MaxMetDataMesg":
                MaxMetDataMesgs = MaxMetDataMesgs.Select((Func<MaxMetDataMesg, MaxMetDataMesg>)Delegate.CreateDelegate(typeof(Func<MaxMetDataMesg, MaxMetDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "MemoGlobMesg":
                MemoGlobMesgs = MemoGlobMesgs.Select((Func<MemoGlobMesg, MemoGlobMesg>)Delegate.CreateDelegate(typeof(Func<MemoGlobMesg, MemoGlobMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "MesgCapabilitiesMesg":
                MesgCapabilitiesMesgs = MesgCapabilitiesMesgs.Select((Func<MesgCapabilitiesMesg, MesgCapabilitiesMesg>)Delegate.CreateDelegate(typeof(Func<MesgCapabilitiesMesg, MesgCapabilitiesMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "MetZoneMesg":
                MetZoneMesgs = MetZoneMesgs.Select((Func<MetZoneMesg, MetZoneMesg>)Delegate.CreateDelegate(typeof(Func<MetZoneMesg, MetZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "MonitoringHrDataMesg":
                MonitoringHrDataMesgs = MonitoringHrDataMesgs.Select((Func<MonitoringHrDataMesg, MonitoringHrDataMesg>)Delegate.CreateDelegate(typeof(Func<MonitoringHrDataMesg, MonitoringHrDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "MonitoringInfoMesg":
                MonitoringInfoMesgs = MonitoringInfoMesgs.Select((Func<MonitoringInfoMesg, MonitoringInfoMesg>)Delegate.CreateDelegate(typeof(Func<MonitoringInfoMesg, MonitoringInfoMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "MonitoringMesg":
                MonitoringMesgs = MonitoringMesgs.Select((Func<MonitoringMesg, MonitoringMesg>)Delegate.CreateDelegate(typeof(Func<MonitoringMesg, MonitoringMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "NmeaSentenceMesg":
                NmeaSentenceMesgs = NmeaSentenceMesgs.Select((Func<NmeaSentenceMesg, NmeaSentenceMesg>)Delegate.CreateDelegate(typeof(Func<NmeaSentenceMesg, NmeaSentenceMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ObdiiDataMesg":
                ObdiiDataMesgs = ObdiiDataMesgs.Select((Func<ObdiiDataMesg, ObdiiDataMesg>)Delegate.CreateDelegate(typeof(Func<ObdiiDataMesg, ObdiiDataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "OhrSettingsMesg":
                OhrSettingsMesgs = OhrSettingsMesgs.Select((Func<OhrSettingsMesg, OhrSettingsMesg>)Delegate.CreateDelegate(typeof(Func<OhrSettingsMesg, OhrSettingsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "OneDSensorCalibrationMesg":
                OneDSensorCalibrationMesgs = OneDSensorCalibrationMesgs.Select((Func<OneDSensorCalibrationMesg, OneDSensorCalibrationMesg>)Delegate.CreateDelegate(typeof(Func<OneDSensorCalibrationMesg, OneDSensorCalibrationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "PadMesg":
                PadMesgs = PadMesgs.Select((Func<PadMesg, PadMesg>)Delegate.CreateDelegate(typeof(Func<PadMesg, PadMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "PowerZoneMesg":
                PowerZoneMesgs = PowerZoneMesgs.Select((Func<PowerZoneMesg, PowerZoneMesg>)Delegate.CreateDelegate(typeof(Func<PowerZoneMesg, PowerZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "RawBbiMesg":
                RawBbiMesgs = RawBbiMesgs.Select((Func<RawBbiMesg, RawBbiMesg>)Delegate.CreateDelegate(typeof(Func<RawBbiMesg, RawBbiMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "RecordMesg":
                RecordMesgs = RecordMesgs.Select((Func<RecordMesg, RecordMesg>)Delegate.CreateDelegate(typeof(Func<RecordMesg, RecordMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "RespirationRateMesg":
                RespirationRateMesgs = RespirationRateMesgs.Select((Func<RespirationRateMesg, RespirationRateMesg>)Delegate.CreateDelegate(typeof(Func<RespirationRateMesg, RespirationRateMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ScheduleMesg":
                ScheduleMesgs = ScheduleMesgs.Select((Func<ScheduleMesg, ScheduleMesg>)Delegate.CreateDelegate(typeof(Func<ScheduleMesg, ScheduleMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SdmProfileMesg":
                SdmProfileMesgs = SdmProfileMesgs.Select((Func<SdmProfileMesg, SdmProfileMesg>)Delegate.CreateDelegate(typeof(Func<SdmProfileMesg, SdmProfileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SegmentFileMesg":
                SegmentFileMesgs = SegmentFileMesgs.Select((Func<SegmentFileMesg, SegmentFileMesg>)Delegate.CreateDelegate(typeof(Func<SegmentFileMesg, SegmentFileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SegmentIdMesg":
                SegmentIdMesgs = SegmentIdMesgs.Select((Func<SegmentIdMesg, SegmentIdMesg>)Delegate.CreateDelegate(typeof(Func<SegmentIdMesg, SegmentIdMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SegmentLapMesg":
                SegmentLapMesgs = SegmentLapMesgs.Select((Func<SegmentLapMesg, SegmentLapMesg>)Delegate.CreateDelegate(typeof(Func<SegmentLapMesg, SegmentLapMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SegmentLeaderboardEntryMesg":
                SegmentLeaderboardEntryMesgs = SegmentLeaderboardEntryMesgs.Select((Func<SegmentLeaderboardEntryMesg, SegmentLeaderboardEntryMesg>)Delegate.CreateDelegate(typeof(Func<SegmentLeaderboardEntryMesg, SegmentLeaderboardEntryMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SegmentPointMesg":
                SegmentPointMesgs = SegmentPointMesgs.Select((Func<SegmentPointMesg, SegmentPointMesg>)Delegate.CreateDelegate(typeof(Func<SegmentPointMesg, SegmentPointMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SessionMesg":
                SessionMesgs = SessionMesgs.Select((Func<SessionMesg, SessionMesg>)Delegate.CreateDelegate(typeof(Func<SessionMesg, SessionMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SetMesg":
                SetMesgs = SetMesgs.Select((Func<SetMesg, SetMesg>)Delegate.CreateDelegate(typeof(Func<SetMesg, SetMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SlaveDeviceMesg":
                SlaveDeviceMesgs = SlaveDeviceMesgs.Select((Func<SlaveDeviceMesg, SlaveDeviceMesg>)Delegate.CreateDelegate(typeof(Func<SlaveDeviceMesg, SlaveDeviceMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SleepAssessmentMesg":
                SleepAssessmentMesgs = SleepAssessmentMesgs.Select((Func<SleepAssessmentMesg, SleepAssessmentMesg>)Delegate.CreateDelegate(typeof(Func<SleepAssessmentMesg, SleepAssessmentMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SleepLevelMesg":
                SleepLevelMesgs = SleepLevelMesgs.Select((Func<SleepLevelMesg, SleepLevelMesg>)Delegate.CreateDelegate(typeof(Func<SleepLevelMesg, SleepLevelMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SoftwareMesg":
                SoftwareMesgs = SoftwareMesgs.Select((Func<SoftwareMesg, SoftwareMesg>)Delegate.CreateDelegate(typeof(Func<SoftwareMesg, SoftwareMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SpeedZoneMesg":
                SpeedZoneMesgs = SpeedZoneMesgs.Select((Func<SpeedZoneMesg, SpeedZoneMesg>)Delegate.CreateDelegate(typeof(Func<SpeedZoneMesg, SpeedZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SplitMesg":
                SplitMesgs = SplitMesgs.Select((Func<SplitMesg, SplitMesg>)Delegate.CreateDelegate(typeof(Func<SplitMesg, SplitMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SplitSummaryMesg":
                SplitSummaryMesgs = SplitSummaryMesgs.Select((Func<SplitSummaryMesg, SplitSummaryMesg>)Delegate.CreateDelegate(typeof(Func<SplitSummaryMesg, SplitSummaryMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "Spo2DataMesg":
                Spo2DataMesgs = Spo2DataMesgs.Select((Func<Spo2DataMesg, Spo2DataMesg>)Delegate.CreateDelegate(typeof(Func<Spo2DataMesg, Spo2DataMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "SportMesg":
                SportMesgs = SportMesgs.Select((Func<SportMesg, SportMesg>)Delegate.CreateDelegate(typeof(Func<SportMesg, SportMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "StressLevelMesg":
                StressLevelMesgs = StressLevelMesgs.Select((Func<StressLevelMesg, StressLevelMesg>)Delegate.CreateDelegate(typeof(Func<StressLevelMesg, StressLevelMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "TankSummaryMesg":
                TankSummaryMesgs = TankSummaryMesgs.Select((Func<TankSummaryMesg, TankSummaryMesg>)Delegate.CreateDelegate(typeof(Func<TankSummaryMesg, TankSummaryMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "TankUpdateMesg":
                TankUpdateMesgs = TankUpdateMesgs.Select((Func<TankUpdateMesg, TankUpdateMesg>)Delegate.CreateDelegate(typeof(Func<TankUpdateMesg, TankUpdateMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "ThreeDSensorCalibrationMesg":
                ThreeDSensorCalibrationMesgs = ThreeDSensorCalibrationMesgs.Select((Func<ThreeDSensorCalibrationMesg, ThreeDSensorCalibrationMesg>)Delegate.CreateDelegate(typeof(Func<ThreeDSensorCalibrationMesg, ThreeDSensorCalibrationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "TimeInZoneMesg":
                TimeInZoneMesgs = TimeInZoneMesgs.Select((Func<TimeInZoneMesg, TimeInZoneMesg>)Delegate.CreateDelegate(typeof(Func<TimeInZoneMesg, TimeInZoneMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "TimestampCorrelationMesg":
                TimestampCorrelationMesgs = TimestampCorrelationMesgs.Select((Func<TimestampCorrelationMesg, TimestampCorrelationMesg>)Delegate.CreateDelegate(typeof(Func<TimestampCorrelationMesg, TimestampCorrelationMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "TotalsMesg":
                TotalsMesgs = TotalsMesgs.Select((Func<TotalsMesg, TotalsMesg>)Delegate.CreateDelegate(typeof(Func<TotalsMesg, TotalsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "TrainingFileMesg":
                TrainingFileMesgs = TrainingFileMesgs.Select((Func<TrainingFileMesg, TrainingFileMesg>)Delegate.CreateDelegate(typeof(Func<TrainingFileMesg, TrainingFileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "UserProfileMesg":
                UserProfileMesgs = UserProfileMesgs.Select((Func<UserProfileMesg, UserProfileMesg>)Delegate.CreateDelegate(typeof(Func<UserProfileMesg, UserProfileMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "VideoClipMesg":
                VideoClipMesgs = VideoClipMesgs.Select((Func<VideoClipMesg, VideoClipMesg>)Delegate.CreateDelegate(typeof(Func<VideoClipMesg, VideoClipMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "VideoDescriptionMesg":
                VideoDescriptionMesgs = VideoDescriptionMesgs.Select((Func<VideoDescriptionMesg, VideoDescriptionMesg>)Delegate.CreateDelegate(typeof(Func<VideoDescriptionMesg, VideoDescriptionMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "VideoFrameMesg":
                VideoFrameMesgs = VideoFrameMesgs.Select((Func<VideoFrameMesg, VideoFrameMesg>)Delegate.CreateDelegate(typeof(Func<VideoFrameMesg, VideoFrameMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "VideoMesg":
                VideoMesgs = VideoMesgs.Select((Func<VideoMesg, VideoMesg>)Delegate.CreateDelegate(typeof(Func<VideoMesg, VideoMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "VideoTitleMesg":
                VideoTitleMesgs = VideoTitleMesgs.Select((Func<VideoTitleMesg, VideoTitleMesg>)Delegate.CreateDelegate(typeof(Func<VideoTitleMesg, VideoTitleMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "WatchfaceSettingsMesg":
                WatchfaceSettingsMesgs = WatchfaceSettingsMesgs.Select((Func<WatchfaceSettingsMesg, WatchfaceSettingsMesg>)Delegate.CreateDelegate(typeof(Func<WatchfaceSettingsMesg, WatchfaceSettingsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "WeatherAlertMesg":
                WeatherAlertMesgs = WeatherAlertMesgs.Select((Func<WeatherAlertMesg, WeatherAlertMesg>)Delegate.CreateDelegate(typeof(Func<WeatherAlertMesg, WeatherAlertMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "WeatherConditionsMesg":
                WeatherConditionsMesgs = WeatherConditionsMesgs.Select((Func<WeatherConditionsMesg, WeatherConditionsMesg>)Delegate.CreateDelegate(typeof(Func<WeatherConditionsMesg, WeatherConditionsMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "WeightScaleMesg":
                WeightScaleMesgs = WeightScaleMesgs.Select((Func<WeightScaleMesg, WeightScaleMesg>)Delegate.CreateDelegate(typeof(Func<WeightScaleMesg, WeightScaleMesg>), newMesgs.Target, newMesgs.Method)).ToList();
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
            case "ZonesTargetMesg":
                ZonesTargetMesgs = ZonesTargetMesgs.Select((Func<ZonesTargetMesg, ZonesTargetMesg>)Delegate.CreateDelegate(typeof(Func<ZonesTargetMesg, ZonesTargetMesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
            case "Mesg":
                UnknownMesgs = UnknownMesgs.Select((Func<Mesg, Mesg>)Delegate.CreateDelegate(typeof(Func<Mesg, Mesg>), newMesgs.Target, newMesgs.Method)).ToList();
                break;
        }
    }
}