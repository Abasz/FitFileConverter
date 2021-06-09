using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

using Dynastream.Fit;

using FitFileEditor.Libs;

namespace FitFileEditor.ConsoleApp
{
    public class FitFileParser
    {
        public List<FileIdMesg> ? FileIdMesgs { get; private set; }
        public List<FileCreatorMesg> ? FileCreatorMesgs { get; private set; }
        public List<TimestampCorrelationMesg> ? TimestampCorrelationMesgs { get; private set; }
        public List<SoftwareMesg> ? SoftwareMesgs { get; private set; }
        public List<SlaveDeviceMesg> ? SlaveDeviceMesgs { get; private set; }
        public List<CapabilitiesMesg> ? CapabilitiesMesgs { get; private set; }
        public List<FileCapabilitiesMesg> ? FileCapabilitiesMesgs { get; private set; }
        public List<MesgCapabilitiesMesg> ? MesgCapabilitiesMesgs { get; private set; }
        public List<FieldCapabilitiesMesg> ? FieldCapabilitiesMesgs { get; private set; }
        public List<DeviceSettingsMesg> ? DeviceSettingsMesgs { get; private set; }
        public List<UserProfileMesg> ? UserProfileMesgs { get; private set; }
        public List<HrmProfileMesg> ? HrmProfileMesgs { get; private set; }
        public List<SdmProfileMesg> ? SdmProfileMesgs { get; private set; }
        public List<BikeProfileMesg> ? BikeProfileMesgs { get; private set; }
        public List<ConnectivityMesg> ? ConnectivityMesgs { get; private set; }
        public List<WatchfaceSettingsMesg> ? WatchfaceSettingsMesgs { get; private set; }
        public List<OhrSettingsMesg> ? OhrSettingsMesgs { get; private set; }
        public List<ZonesTargetMesg> ? ZonesTargetMesgs { get; private set; }
        public List<SportMesg> ? SportMesgs { get; private set; }
        public List<HrZoneMesg> ? HrZoneMesgs { get; private set; }
        public List<SpeedZoneMesg> ? SpeedZoneMesgs { get; private set; }
        public List<CadenceZoneMesg> ? CadenceZoneMesgs { get; private set; }
        public List<PowerZoneMesg> ? PowerZoneMesgs { get; private set; }
        public List<MetZoneMesg> ? MetZoneMesgs { get; private set; }
        public List<DiveSettingsMesg> ? DiveSettingsMesgs { get; private set; }
        public List<DiveAlarmMesg> ? DiveAlarmMesgs { get; private set; }
        public List<DiveGasMesg> ? DiveGasMesgs { get; private set; }
        public List<GoalMesg> ? GoalMesgs { get; private set; }
        public List<ActivityMesg> ? ActivityMesgs { get; private set; }
        public List<SessionMesg> ? SessionMesgs { get; private set; }
        public List<LapMesg> ? LapMesgs { get; private set; }
        public List<LengthMesg> ? LengthMesgs { get; private set; }
        public List<RecordMesg> ? RecordMesgs { get; private set; }
        public List<EventMesg> ? EventMesgs { get; private set; }
        public List<DeviceInfoMesg> ? DeviceInfoMesgs { get; private set; }
        public List<TrainingFileMesg> ? TrainingFileMesgs { get; private set; }
        public List<HrvMesg> ? HrvMesgs { get; private set; }
        public List<WeatherConditionsMesg> ? WeatherConditionsMesgs { get; private set; }
        public List<WeatherAlertMesg> ? WeatherAlertMesgs { get; private set; }
        public List<GpsMetadataMesg> ? GpsMetadataMesgs { get; private set; }
        public List<CameraEventMesg> ? CameraEventMesgs { get; private set; }
        public List<GyroscopeDataMesg> ? GyroscopeDataMesgs { get; private set; }
        public List<AccelerometerDataMesg> ? AccelerometerDataMesgs { get; private set; }
        public List<MagnetometerDataMesg> ? MagnetometerDataMesgs { get; private set; }
        public List<BarometerDataMesg> ? BarometerDataMesgs { get; private set; }
        public List<ThreeDSensorCalibrationMesg> ? ThreeDSensorCalibrationMesgs { get; private set; }
        public List<OneDSensorCalibrationMesg> ? OneDSensorCalibrationMesgs { get; private set; }
        public List<VideoFrameMesg> ? VideoFrameMesgs { get; private set; }
        public List<ObdiiDataMesg> ? ObdiiDataMesgs { get; private set; }
        public List<NmeaSentenceMesg> ? NmeaSentenceMesgs { get; private set; }
        public List<AviationAttitudeMesg> ? AviationAttitudeMesgs { get; private set; }
        public List<VideoMesg> ? VideoMesgs { get; private set; }
        public List<VideoTitleMesg> ? VideoTitleMesgs { get; private set; }
        public List<VideoDescriptionMesg> ? VideoDescriptionMesgs { get; private set; }
        public List<VideoClipMesg> ? VideoClipMesgs { get; private set; }
        public List<SetMesg> ? SetMesgs { get; private set; }
        public List<JumpMesg> ? JumpMesgs { get; private set; }
        public List<CourseMesg> ? CourseMesgs { get; private set; }
        public List<CoursePointMesg> ? CoursePointMesgs { get; private set; }
        public List<SegmentIdMesg> ? SegmentIdMesgs { get; private set; }
        public List<SegmentLeaderboardEntryMesg> ? SegmentLeaderboardEntryMesgs { get; private set; }
        public List<SegmentPointMesg> ? SegmentPointMesgs { get; private set; }
        public List<SegmentLapMesg> ? SegmentLapMesgs { get; private set; }
        public List<SegmentFileMesg> ? SegmentFileMesgs { get; private set; }
        public List<WorkoutMesg> ? WorkoutMesgs { get; private set; }
        public List<WorkoutSessionMesg> ? WorkoutSessionMesgs { get; private set; }
        public List<WorkoutStepMesg> ? WorkoutStepMesgs { get; private set; }
        public List<ExerciseTitleMesg> ? ExerciseTitleMesgs { get; private set; }
        public List<ScheduleMesg> ? ScheduleMesgs { get; private set; }
        public List<TotalsMesg> ? TotalsMesgs { get; private set; }
        public List<WeightScaleMesg> ? WeightScaleMesgs { get; private set; }
        public List<BloodPressureMesg> ? BloodPressureMesgs { get; private set; }
        public List<MonitoringInfoMesg> ? MonitoringInfoMesgs { get; private set; }
        public List<MonitoringMesg> ? MonitoringMesgs { get; private set; }
        public List<HrMesg> ? HrMesgs { get; private set; }
        public List<StressLevelMesg> ? StressLevelMesgs { get; private set; }
        public List<MemoGlobMesg> ? MemoGlobMesgs { get; private set; }
        public List<AntChannelIdMesg> ? AntChannelIdMesgs { get; private set; }
        public List<AntRxMesg> ? AntRxMesgs { get; private set; }
        public List<AntTxMesg> ? AntTxMesgs { get; private set; }
        public List<ExdScreenConfigurationMesg> ? ExdScreenConfigurationMesgs { get; private set; }
        public List<ExdDataFieldConfigurationMesg> ? ExdDataFieldConfigurationMesgs { get; private set; }
        public List<ExdDataConceptConfigurationMesg> ? ExdDataConceptConfigurationMesgs { get; private set; }
        public List<FieldDescriptionMesg> ? FieldDescriptionMesgs { get; private set; }
        public List<DeveloperDataIdMesg> ? DeveloperDataIdMesgs { get; private set; }
        public List<DiveSummaryMesg> ? DiveSummaryMesgs { get; private set; }
        public List<ClimbProMesg> ? ClimbProMesgs { get; private set; }
        public List<PadMesg> ? PadMesgs { get; private set; }
        public List<Mesg> ? UnknownMesgs { get; private set; }

        public void ReadFitFile(string fitFilePath)
        {
            var fitFileReader = new Decode();
            fitFileReader.MesgEvent += OnMesg;

            var fitSource = new FileStream(fitFilePath, FileMode.Open);
            fitFileReader.Read(fitSource);
            fitSource.Close();
        }

        public void WriteFitFile(string fitFilePath)
        {
            var outputFile = new FileStream(fitFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            var fitFileWriter = new Encode(ProtocolVersion.V20);
            fitFileWriter.Open(outputFile);

            var properties = typeof(FitFileParser).GetProperties();
            foreach (var property in properties)
            {
                var mesgs = (IEnumerable<dynamic> ? )property.GetValue(this);
                if (mesgs is not null)
                    foreach (var mesg in mesgs)
                    {
                        fitFileWriter.Write(mesg);
                    }
            }

            fitFileWriter.Close();
            outputFile.Close();
            Console.WriteLine($"Encoded FIT file {fitFilePath}");
        }

        public string ToJson()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName!.Contains("Fit,")).ElementAt(0);

            var newobject = typeof(FitFileParser).GetProperties()
                .Where(prop => prop.GetValue(this)is not null)
                .Select(prop => ((IEnumerable<dynamic>)prop.GetValue(this) !)
                    .Select(mesg => new Mesg(mesg))
                    .ToList())
                .Aggregate(new List<List<Mesg>>(), (accumulator, mesgs) =>
                {
                    if (mesgs.ElementAt(0).Name.ToLower() == "unknown")
                    {
                        var unkownMesgGroups = mesgs.Select(mesg =>
                        {
                            mesg.Name = $"{mesg.Name}-{mesg.Num}";

                            return mesg;
                        }).GroupBy(mesg => mesg.Name);

                        accumulator.AddRange(unkownMesgGroups.Select(group =>
                            group
                            .Aggregate(new List<Mesg>(), (accumulator, mesg) =>
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
                            field.Name.ToLower() == "unknown" ?
                            $"{field.Name}-{field.Num}" : field.Name,
                            field =>
                            {
                                var fieldValue = field.GetValue();
                                var fieldType = new Field(field).ProfileType.ToString();

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

                                    return fieldValue;
                                }

                                var enumValue = fieldValue ?? 0xFF;
                                var type = assemblies.GetType($"Dynastream.Fit.{fieldType ?? "Enum"}");
                                if (type is null)
                                {
                                    return fieldValue;
                                }

                                return Enum.ToObject(type!, enumValue)?.ToString()?.ToCamelCase() ?? fieldValue;
                            }
                        )
                        .Concat(mesg.DeveloperFields.ToDictionary(field =>
                            field.Name.ToLower() == "unknown" ? $"{field.Name}-{field.Num}" : field.Name, field => (object?)field.GetValue()))
                        .ToDictionary(k => k.Key, k => k.Value))
                    .ToList());

            return JsonSerializer.Serialize(newobject, new JsonSerializerOptions()
            {
                WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                    IgnoreNullValues = true,
                    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public void OnMesg(object sender, MesgEventArgs e)
        {
            switch (e.mesg.Num)
            {
                case (ushort)MesgNum.FileId:
                    if (FileIdMesgs == null)
                        FileIdMesgs = new List<FileIdMesg>();

                    FileIdMesgs.Add(new FileIdMesg(e.mesg));
                    break;

                case (ushort)MesgNum.FileCreator:
                    if (FileCreatorMesgs == null)
                        FileCreatorMesgs = new List<FileCreatorMesg>();

                    FileCreatorMesgs.Add(new FileCreatorMesg(e.mesg));
                    break;

                case (ushort)MesgNum.TimestampCorrelation:
                    if (TimestampCorrelationMesgs == null)
                        TimestampCorrelationMesgs = new List<TimestampCorrelationMesg>();

                    TimestampCorrelationMesgs.Add(new TimestampCorrelationMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Software:
                    if (SoftwareMesgs == null)
                        SoftwareMesgs = new List<SoftwareMesg>();

                    SoftwareMesgs.Add(new SoftwareMesg(e.mesg));
                    break;

                case (ushort)MesgNum.SlaveDevice:
                    if (SlaveDeviceMesgs == null)
                        SlaveDeviceMesgs = new List<SlaveDeviceMesg>();

                    SlaveDeviceMesgs.Add(new SlaveDeviceMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Capabilities:
                    if (CapabilitiesMesgs == null)
                        CapabilitiesMesgs = new List<CapabilitiesMesg>();

                    CapabilitiesMesgs.Add(new CapabilitiesMesg(e.mesg));
                    break;

                case (ushort)MesgNum.FileCapabilities:
                    if (FileCapabilitiesMesgs == null)
                        FileCapabilitiesMesgs = new List<FileCapabilitiesMesg>();

                    FileCapabilitiesMesgs.Add(new FileCapabilitiesMesg(e.mesg));
                    break;

                case (ushort)MesgNum.MesgCapabilities:
                    if (MesgCapabilitiesMesgs == null)
                        MesgCapabilitiesMesgs = new List<MesgCapabilitiesMesg>();

                    MesgCapabilitiesMesgs.Add(new MesgCapabilitiesMesg(e.mesg));
                    break;

                case (ushort)MesgNum.FieldCapabilities:
                    if (FieldCapabilitiesMesgs == null)
                        FieldCapabilitiesMesgs = new List<FieldCapabilitiesMesg>();

                    FieldCapabilitiesMesgs.Add(new FieldCapabilitiesMesg(e.mesg));
                    break;

                case (ushort)MesgNum.DeviceSettings:
                    if (DeviceSettingsMesgs == null)
                        DeviceSettingsMesgs = new List<DeviceSettingsMesg>();

                    DeviceSettingsMesgs.Add(new DeviceSettingsMesg(e.mesg));
                    break;

                case (ushort)MesgNum.UserProfile:
                    if (UserProfileMesgs == null)
                        UserProfileMesgs = new List<UserProfileMesg>();

                    UserProfileMesgs.Add(new UserProfileMesg(e.mesg));
                    break;

                case (ushort)MesgNum.HrmProfile:
                    if (HrmProfileMesgs == null)
                        HrmProfileMesgs = new List<HrmProfileMesg>();

                    HrmProfileMesgs.Add(new HrmProfileMesg(e.mesg));
                    break;

                case (ushort)MesgNum.SdmProfile:
                    if (SdmProfileMesgs == null)
                        SdmProfileMesgs = new List<SdmProfileMesg>();

                    SdmProfileMesgs.Add(new SdmProfileMesg(e.mesg));
                    break;

                case (ushort)MesgNum.BikeProfile:
                    if (BikeProfileMesgs == null)
                        BikeProfileMesgs = new List<BikeProfileMesg>();

                    BikeProfileMesgs.Add(new BikeProfileMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Connectivity:
                    if (ConnectivityMesgs == null)
                        ConnectivityMesgs = new List<ConnectivityMesg>();

                    ConnectivityMesgs.Add(new ConnectivityMesg(e.mesg));
                    break;

                case (ushort)MesgNum.WatchfaceSettings:
                    if (WatchfaceSettingsMesgs == null)
                        WatchfaceSettingsMesgs = new List<WatchfaceSettingsMesg>();

                    WatchfaceSettingsMesgs.Add(new WatchfaceSettingsMesg(e.mesg));
                    break;

                case (ushort)MesgNum.OhrSettings:
                    if (OhrSettingsMesgs == null)
                        OhrSettingsMesgs = new List<OhrSettingsMesg>();

                    OhrSettingsMesgs.Add(new OhrSettingsMesg(e.mesg));
                    break;

                case (ushort)MesgNum.ZonesTarget:
                    if (ZonesTargetMesgs == null)
                        ZonesTargetMesgs = new List<ZonesTargetMesg>();

                    ZonesTargetMesgs.Add(new ZonesTargetMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Sport:
                    if (SportMesgs == null)
                        SportMesgs = new List<SportMesg>();

                    SportMesgs.Add(new SportMesg(e.mesg));
                    break;

                case (ushort)MesgNum.HrZone:
                    if (HrZoneMesgs == null)
                        HrZoneMesgs = new List<HrZoneMesg>();

                    HrZoneMesgs.Add(new HrZoneMesg(e.mesg));
                    break;

                case (ushort)MesgNum.SpeedZone:
                    if (SpeedZoneMesgs == null)
                        SpeedZoneMesgs = new List<SpeedZoneMesg>();

                    SpeedZoneMesgs.Add(new SpeedZoneMesg(e.mesg));
                    break;

                case (ushort)MesgNum.CadenceZone:
                    if (CadenceZoneMesgs == null)
                        CadenceZoneMesgs = new List<CadenceZoneMesg>();

                    CadenceZoneMesgs.Add(new CadenceZoneMesg(e.mesg));
                    break;

                case (ushort)MesgNum.PowerZone:
                    if (PowerZoneMesgs == null)
                        PowerZoneMesgs = new List<PowerZoneMesg>();

                    PowerZoneMesgs.Add(new PowerZoneMesg(e.mesg));
                    break;

                case (ushort)MesgNum.MetZone:
                    if (MetZoneMesgs == null)
                        MetZoneMesgs = new List<MetZoneMesg>();

                    MetZoneMesgs.Add(new MetZoneMesg(e.mesg));
                    break;

                case (ushort)MesgNum.DiveSettings:
                    if (DiveSettingsMesgs == null)
                        DiveSettingsMesgs = new List<DiveSettingsMesg>();

                    DiveSettingsMesgs.Add(new DiveSettingsMesg(e.mesg));
                    break;

                case (ushort)MesgNum.DiveAlarm:
                    if (DiveAlarmMesgs == null)
                        DiveAlarmMesgs = new List<DiveAlarmMesg>();

                    DiveAlarmMesgs.Add(new DiveAlarmMesg(e.mesg));
                    break;

                case (ushort)MesgNum.DiveGas:
                    if (DiveGasMesgs == null)
                        DiveGasMesgs = new List<DiveGasMesg>();

                    DiveGasMesgs.Add(new DiveGasMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Goal:
                    if (GoalMesgs == null)
                        GoalMesgs = new List<GoalMesg>();

                    GoalMesgs.Add(new GoalMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Activity:
                    if (ActivityMesgs == null)
                        ActivityMesgs = new List<ActivityMesg>();

                    ActivityMesgs.Add(new ActivityMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Session:
                    if (SessionMesgs == null)
                        SessionMesgs = new List<SessionMesg>();

                    SessionMesgs.Add(new SessionMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Lap:
                    if (LapMesgs == null)
                        LapMesgs = new List<LapMesg>();

                    LapMesgs.Add(new LapMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Length:
                    if (LengthMesgs == null)
                        LengthMesgs = new List<LengthMesg>();

                    LengthMesgs.Add(new LengthMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Record:
                    if (RecordMesgs == null)
                        RecordMesgs = new List<RecordMesg>();

                    RecordMesgs.Add(new RecordMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Event:
                    if (EventMesgs == null)
                        EventMesgs = new List<EventMesg>();

                    EventMesgs.Add(new EventMesg(e.mesg));
                    break;

                case (ushort)MesgNum.DeviceInfo:
                    if (DeviceInfoMesgs == null)
                        DeviceInfoMesgs = new List<DeviceInfoMesg>();

                    DeviceInfoMesgs.Add(new DeviceInfoMesg(e.mesg));
                    break;

                case (ushort)MesgNum.TrainingFile:
                    if (TrainingFileMesgs == null)
                        TrainingFileMesgs = new List<TrainingFileMesg>();

                    TrainingFileMesgs.Add(new TrainingFileMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Hrv:
                    if (HrvMesgs == null)
                        HrvMesgs = new List<HrvMesg>();

                    HrvMesgs.Add(new HrvMesg(e.mesg));
                    break;

                case (ushort)MesgNum.WeatherConditions:
                    if (WeatherConditionsMesgs == null)
                        WeatherConditionsMesgs = new List<WeatherConditionsMesg>();

                    WeatherConditionsMesgs.Add(new WeatherConditionsMesg(e.mesg));
                    break;

                case (ushort)MesgNum.WeatherAlert:
                    if (WeatherAlertMesgs == null)
                        WeatherAlertMesgs = new List<WeatherAlertMesg>();

                    WeatherAlertMesgs.Add(new WeatherAlertMesg(e.mesg));
                    break;

                case (ushort)MesgNum.GpsMetadata:
                    if (GpsMetadataMesgs == null)
                        GpsMetadataMesgs = new List<GpsMetadataMesg>();

                    GpsMetadataMesgs.Add(new GpsMetadataMesg(e.mesg));
                    break;

                case (ushort)MesgNum.CameraEvent:
                    if (CameraEventMesgs == null)
                        CameraEventMesgs = new List<CameraEventMesg>();

                    CameraEventMesgs.Add(new CameraEventMesg(e.mesg));
                    break;

                case (ushort)MesgNum.GyroscopeData:
                    if (GyroscopeDataMesgs == null)
                        GyroscopeDataMesgs = new List<GyroscopeDataMesg>();

                    GyroscopeDataMesgs.Add(new GyroscopeDataMesg(e.mesg));
                    break;

                case (ushort)MesgNum.AccelerometerData:
                    if (AccelerometerDataMesgs == null)
                        AccelerometerDataMesgs = new List<AccelerometerDataMesg>();

                    AccelerometerDataMesgs.Add(new AccelerometerDataMesg(e.mesg));
                    break;

                case (ushort)MesgNum.MagnetometerData:
                    if (MagnetometerDataMesgs == null)
                        MagnetometerDataMesgs = new List<MagnetometerDataMesg>();

                    MagnetometerDataMesgs.Add(new MagnetometerDataMesg(e.mesg));
                    break;

                case (ushort)MesgNum.BarometerData:
                    if (BarometerDataMesgs == null)
                        BarometerDataMesgs = new List<BarometerDataMesg>();

                    BarometerDataMesgs.Add(new BarometerDataMesg(e.mesg));
                    break;

                case (ushort)MesgNum.ThreeDSensorCalibration:
                    if (ThreeDSensorCalibrationMesgs == null)
                        ThreeDSensorCalibrationMesgs = new List<ThreeDSensorCalibrationMesg>();

                    ThreeDSensorCalibrationMesgs.Add(new ThreeDSensorCalibrationMesg(e.mesg));
                    break;

                case (ushort)MesgNum.OneDSensorCalibration:
                    if (OneDSensorCalibrationMesgs == null)
                        OneDSensorCalibrationMesgs = new List<OneDSensorCalibrationMesg>();

                    OneDSensorCalibrationMesgs.Add(new OneDSensorCalibrationMesg(e.mesg));
                    break;

                case (ushort)MesgNum.VideoFrame:
                    if (VideoFrameMesgs == null)
                        VideoFrameMesgs = new List<VideoFrameMesg>();

                    VideoFrameMesgs.Add(new VideoFrameMesg(e.mesg));
                    break;

                case (ushort)MesgNum.ObdiiData:
                    if (ObdiiDataMesgs == null)
                        ObdiiDataMesgs = new List<ObdiiDataMesg>();

                    ObdiiDataMesgs.Add(new ObdiiDataMesg(e.mesg));
                    break;

                case (ushort)MesgNum.NmeaSentence:
                    if (NmeaSentenceMesgs == null)
                        NmeaSentenceMesgs = new List<NmeaSentenceMesg>();

                    NmeaSentenceMesgs.Add(new NmeaSentenceMesg(e.mesg));
                    break;

                case (ushort)MesgNum.AviationAttitude:
                    if (AviationAttitudeMesgs == null)
                        AviationAttitudeMesgs = new List<AviationAttitudeMesg>();

                    AviationAttitudeMesgs.Add(new AviationAttitudeMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Video:
                    if (VideoMesgs == null)
                        VideoMesgs = new List<VideoMesg>();

                    VideoMesgs.Add(new VideoMesg(e.mesg));
                    break;

                case (ushort)MesgNum.VideoTitle:
                    if (VideoTitleMesgs == null)
                        VideoTitleMesgs = new List<VideoTitleMesg>();

                    VideoTitleMesgs.Add(new VideoTitleMesg(e.mesg));
                    break;

                case (ushort)MesgNum.VideoDescription:
                    if (VideoDescriptionMesgs == null)
                        VideoDescriptionMesgs = new List<VideoDescriptionMesg>();

                    VideoDescriptionMesgs.Add(new VideoDescriptionMesg(e.mesg));
                    break;

                case (ushort)MesgNum.VideoClip:
                    if (VideoClipMesgs == null)
                        VideoClipMesgs = new List<VideoClipMesg>();

                    VideoClipMesgs.Add(new VideoClipMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Set:
                    if (SetMesgs == null)
                        SetMesgs = new List<SetMesg>();

                    SetMesgs.Add(new SetMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Jump:
                    if (JumpMesgs == null)
                        JumpMesgs = new List<JumpMesg>();

                    JumpMesgs.Add(new JumpMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Course:
                    if (CourseMesgs == null)
                        CourseMesgs = new List<CourseMesg>();

                    CourseMesgs.Add(new CourseMesg(e.mesg));
                    break;

                case (ushort)MesgNum.CoursePoint:
                    if (CoursePointMesgs == null)
                        CoursePointMesgs = new List<CoursePointMesg>();

                    CoursePointMesgs.Add(new CoursePointMesg(e.mesg));
                    break;

                case (ushort)MesgNum.SegmentId:
                    if (SegmentIdMesgs == null)
                        SegmentIdMesgs = new List<SegmentIdMesg>();

                    SegmentIdMesgs.Add(new SegmentIdMesg(e.mesg));
                    break;

                case (ushort)MesgNum.SegmentLeaderboardEntry:
                    if (SegmentLeaderboardEntryMesgs == null)
                        SegmentLeaderboardEntryMesgs = new List<SegmentLeaderboardEntryMesg>();

                    SegmentLeaderboardEntryMesgs.Add(new SegmentLeaderboardEntryMesg(e.mesg));
                    break;

                case (ushort)MesgNum.SegmentPoint:
                    if (SegmentPointMesgs == null)
                        SegmentPointMesgs = new List<SegmentPointMesg>();

                    SegmentPointMesgs.Add(new SegmentPointMesg(e.mesg));
                    break;

                case (ushort)MesgNum.SegmentLap:
                    if (SegmentLapMesgs == null)
                        SegmentLapMesgs = new List<SegmentLapMesg>();

                    SegmentLapMesgs.Add(new SegmentLapMesg(e.mesg));
                    break;

                case (ushort)MesgNum.SegmentFile:
                    if (SegmentFileMesgs == null)
                        SegmentFileMesgs = new List<SegmentFileMesg>();

                    SegmentFileMesgs.Add(new SegmentFileMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Workout:
                    if (WorkoutMesgs == null)
                        WorkoutMesgs = new List<WorkoutMesg>();

                    WorkoutMesgs.Add(new WorkoutMesg(e.mesg));
                    break;

                case (ushort)MesgNum.WorkoutSession:
                    if (WorkoutSessionMesgs == null)
                        WorkoutSessionMesgs = new List<WorkoutSessionMesg>();

                    WorkoutSessionMesgs.Add(new WorkoutSessionMesg(e.mesg));
                    break;

                case (ushort)MesgNum.WorkoutStep:
                    if (WorkoutStepMesgs == null)
                        WorkoutStepMesgs = new List<WorkoutStepMesg>();

                    WorkoutStepMesgs.Add(new WorkoutStepMesg(e.mesg));
                    break;

                case (ushort)MesgNum.ExerciseTitle:
                    if (ExerciseTitleMesgs == null)
                        ExerciseTitleMesgs = new List<ExerciseTitleMesg>();

                    ExerciseTitleMesgs.Add(new ExerciseTitleMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Schedule:
                    if (ScheduleMesgs == null)
                        ScheduleMesgs = new List<ScheduleMesg>();

                    ScheduleMesgs.Add(new ScheduleMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Totals:
                    if (TotalsMesgs == null)
                        TotalsMesgs = new List<TotalsMesg>();

                    TotalsMesgs.Add(new TotalsMesg(e.mesg));
                    break;

                case (ushort)MesgNum.WeightScale:
                    if (WeightScaleMesgs == null)
                        WeightScaleMesgs = new List<WeightScaleMesg>();

                    WeightScaleMesgs.Add(new WeightScaleMesg(e.mesg));
                    break;

                case (ushort)MesgNum.BloodPressure:
                    if (BloodPressureMesgs == null)
                        BloodPressureMesgs = new List<BloodPressureMesg>();

                    BloodPressureMesgs.Add(new BloodPressureMesg(e.mesg));
                    break;

                case (ushort)MesgNum.MonitoringInfo:
                    if (MonitoringInfoMesgs == null)
                        MonitoringInfoMesgs = new List<MonitoringInfoMesg>();

                    MonitoringInfoMesgs.Add(new MonitoringInfoMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Monitoring:
                    if (MonitoringMesgs == null)
                        MonitoringMesgs = new List<MonitoringMesg>();

                    MonitoringMesgs.Add(new MonitoringMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Hr:
                    if (HrMesgs == null)
                        HrMesgs = new List<HrMesg>();

                    HrMesgs.Add(new HrMesg(e.mesg));
                    break;

                case (ushort)MesgNum.StressLevel:
                    if (StressLevelMesgs == null)
                        StressLevelMesgs = new List<StressLevelMesg>();

                    StressLevelMesgs.Add(new StressLevelMesg(e.mesg));
                    break;

                case (ushort)MesgNum.MemoGlob:
                    if (MemoGlobMesgs == null)
                        MemoGlobMesgs = new List<MemoGlobMesg>();

                    MemoGlobMesgs.Add(new MemoGlobMesg(e.mesg));
                    break;

                case (ushort)MesgNum.AntChannelId:
                    if (AntChannelIdMesgs == null)
                        AntChannelIdMesgs = new List<AntChannelIdMesg>();

                    AntChannelIdMesgs.Add(new AntChannelIdMesg(e.mesg));
                    break;

                case (ushort)MesgNum.AntRx:
                    if (AntRxMesgs == null)
                        AntRxMesgs = new List<AntRxMesg>();

                    AntRxMesgs.Add(new AntRxMesg(e.mesg));
                    break;

                case (ushort)MesgNum.AntTx:
                    if (AntTxMesgs == null)
                        AntTxMesgs = new List<AntTxMesg>();

                    AntTxMesgs.Add(new AntTxMesg(e.mesg));
                    break;

                case (ushort)MesgNum.ExdScreenConfiguration:
                    if (ExdScreenConfigurationMesgs == null)
                        ExdScreenConfigurationMesgs = new List<ExdScreenConfigurationMesg>();

                    ExdScreenConfigurationMesgs.Add(new ExdScreenConfigurationMesg(e.mesg));
                    break;

                case (ushort)MesgNum.ExdDataFieldConfiguration:
                    if (ExdDataFieldConfigurationMesgs == null)
                        ExdDataFieldConfigurationMesgs = new List<ExdDataFieldConfigurationMesg>();

                    ExdDataFieldConfigurationMesgs.Add(new ExdDataFieldConfigurationMesg(e.mesg));
                    break;

                case (ushort)MesgNum.ExdDataConceptConfiguration:
                    if (ExdDataConceptConfigurationMesgs == null)
                        ExdDataConceptConfigurationMesgs = new List<ExdDataConceptConfigurationMesg>();

                    ExdDataConceptConfigurationMesgs.Add(new ExdDataConceptConfigurationMesg(e.mesg));
                    break;

                case (ushort)MesgNum.FieldDescription:
                    if (FieldDescriptionMesgs == null)
                        FieldDescriptionMesgs = new List<FieldDescriptionMesg>();

                    FieldDescriptionMesgs.Add(new FieldDescriptionMesg(e.mesg));
                    break;

                case (ushort)MesgNum.DeveloperDataId:
                    if (DeveloperDataIdMesgs == null)
                        DeveloperDataIdMesgs = new List<DeveloperDataIdMesg>();

                    DeveloperDataIdMesgs.Add(new DeveloperDataIdMesg(e.mesg));
                    break;

                case (ushort)MesgNum.DiveSummary:
                    if (DiveSummaryMesgs == null)
                        DiveSummaryMesgs = new List<DiveSummaryMesg>();

                    DiveSummaryMesgs.Add(new DiveSummaryMesg(e.mesg));
                    break;

                case (ushort)MesgNum.ClimbPro:
                    if (ClimbProMesgs == null)
                        ClimbProMesgs = new List<ClimbProMesg>();

                    ClimbProMesgs.Add(new ClimbProMesg(e.mesg));
                    break;

                case (ushort)MesgNum.Pad:
                    if (PadMesgs == null)
                        PadMesgs = new List<PadMesg>();

                    PadMesgs.Add(new PadMesg(e.mesg));
                    break;
                default:
                    if (UnknownMesgs == null)
                        UnknownMesgs = new List<Mesg>();

                    UnknownMesgs.Add(e.mesg);
                    break;
            }
        }

        public void Edit<T>(List<T> newMesgs)where T : Mesg
        {
            switch (newMesgs)
            {
                case List<FileIdMesg> fileIdMesgs:
                    if (FileIdMesgs == null)
                        FileIdMesgs = new List<FileIdMesg>();

                    FileIdMesgs = fileIdMesgs;
                    break;

                case List<FileCreatorMesg> fileCreatorMesgs:
                    if (FileCreatorMesgs == null)
                        FileCreatorMesgs = new List<FileCreatorMesg>();

                    FileCreatorMesgs = fileCreatorMesgs;
                    break;

                case List<TimestampCorrelationMesg> timestampCorrelationMesgs:
                    if (TimestampCorrelationMesgs == null)
                        TimestampCorrelationMesgs = new List<TimestampCorrelationMesg>();

                    TimestampCorrelationMesgs = timestampCorrelationMesgs;
                    break;

                case List<SoftwareMesg> softwareMesgs:
                    if (SoftwareMesgs == null)
                        SoftwareMesgs = new List<SoftwareMesg>();

                    SoftwareMesgs = softwareMesgs;
                    break;

                case List<SlaveDeviceMesg> slaveDeviceMesgs:
                    if (SlaveDeviceMesgs == null)
                        SlaveDeviceMesgs = new List<SlaveDeviceMesg>();

                    SlaveDeviceMesgs = slaveDeviceMesgs;
                    break;

                case List<CapabilitiesMesg> capabilitiesMesgs:
                    if (CapabilitiesMesgs == null)
                        CapabilitiesMesgs = new List<CapabilitiesMesg>();

                    CapabilitiesMesgs = capabilitiesMesgs;
                    break;

                case List<FileCapabilitiesMesg> fileCapabilitiesMesgs:
                    if (FileCapabilitiesMesgs == null)
                        FileCapabilitiesMesgs = new List<FileCapabilitiesMesg>();

                    FileCapabilitiesMesgs = fileCapabilitiesMesgs;
                    break;

                case List<MesgCapabilitiesMesg> mesgCapabilitiesMesgs:
                    if (MesgCapabilitiesMesgs == null)
                        MesgCapabilitiesMesgs = new List<MesgCapabilitiesMesg>();

                    MesgCapabilitiesMesgs = mesgCapabilitiesMesgs;
                    break;

                case List<FieldCapabilitiesMesg> fieldCapabilitiesMesgs:
                    if (FieldCapabilitiesMesgs == null)
                        FieldCapabilitiesMesgs = new List<FieldCapabilitiesMesg>();

                    FieldCapabilitiesMesgs = fieldCapabilitiesMesgs;
                    break;

                case List<DeviceSettingsMesg> deviceSettingsMesgs:
                    if (DeviceSettingsMesgs == null)
                        DeviceSettingsMesgs = new List<DeviceSettingsMesg>();

                    DeviceSettingsMesgs = deviceSettingsMesgs;
                    break;

                case List<UserProfileMesg> userProfileMesgs:
                    if (UserProfileMesgs == null)
                        UserProfileMesgs = new List<UserProfileMesg>();

                    UserProfileMesgs = userProfileMesgs;
                    break;

                case List<HrmProfileMesg> hrmProfileMesgs:
                    if (HrmProfileMesgs == null)
                        HrmProfileMesgs = new List<HrmProfileMesg>();

                    HrmProfileMesgs = hrmProfileMesgs;
                    break;

                case List<SdmProfileMesg> sdmProfileMesgs:
                    if (SdmProfileMesgs == null)
                        SdmProfileMesgs = new List<SdmProfileMesg>();

                    SdmProfileMesgs = sdmProfileMesgs;
                    break;

                case List<BikeProfileMesg> bikeProfileMesgs:
                    if (BikeProfileMesgs == null)
                        BikeProfileMesgs = new List<BikeProfileMesg>();

                    BikeProfileMesgs = bikeProfileMesgs;
                    break;

                case List<ConnectivityMesg> connectivityMesgs:
                    if (ConnectivityMesgs == null)
                        ConnectivityMesgs = new List<ConnectivityMesg>();

                    ConnectivityMesgs = connectivityMesgs;
                    break;

                case List<WatchfaceSettingsMesg> watchfaceSettingsMesgs:
                    if (WatchfaceSettingsMesgs == null)
                        WatchfaceSettingsMesgs = new List<WatchfaceSettingsMesg>();

                    WatchfaceSettingsMesgs = watchfaceSettingsMesgs;
                    break;

                case List<OhrSettingsMesg> ohrSettingsMesgs:
                    if (OhrSettingsMesgs == null)
                        OhrSettingsMesgs = new List<OhrSettingsMesg>();

                    OhrSettingsMesgs = ohrSettingsMesgs;
                    break;

                case List<ZonesTargetMesg> zonesTargetMesgs:
                    if (ZonesTargetMesgs == null)
                        ZonesTargetMesgs = new List<ZonesTargetMesg>();

                    ZonesTargetMesgs = zonesTargetMesgs;
                    break;

                case List<SportMesg> sportMesgs:
                    if (SportMesgs == null)
                        SportMesgs = new List<SportMesg>();

                    SportMesgs = sportMesgs;
                    break;

                case List<HrZoneMesg> hrZoneMesgs:
                    if (HrZoneMesgs == null)
                        HrZoneMesgs = new List<HrZoneMesg>();

                    HrZoneMesgs = hrZoneMesgs;
                    break;

                case List<SpeedZoneMesg> speedZoneMesgs:
                    if (SpeedZoneMesgs == null)
                        SpeedZoneMesgs = new List<SpeedZoneMesg>();

                    SpeedZoneMesgs = speedZoneMesgs;
                    break;

                case List<CadenceZoneMesg> cadenceZoneMesgs:
                    if (CadenceZoneMesgs == null)
                        CadenceZoneMesgs = new List<CadenceZoneMesg>();

                    CadenceZoneMesgs = cadenceZoneMesgs;
                    break;

                case List<PowerZoneMesg> powerZoneMesgs:
                    if (PowerZoneMesgs == null)
                        PowerZoneMesgs = new List<PowerZoneMesg>();

                    PowerZoneMesgs = powerZoneMesgs;
                    break;

                case List<MetZoneMesg> metZoneMesgs:
                    if (MetZoneMesgs == null)
                        MetZoneMesgs = new List<MetZoneMesg>();

                    MetZoneMesgs = metZoneMesgs;
                    break;

                case List<DiveSettingsMesg> diveSettingsMesgs:
                    if (DiveSettingsMesgs == null)
                        DiveSettingsMesgs = new List<DiveSettingsMesg>();

                    DiveSettingsMesgs = diveSettingsMesgs;
                    break;

                case List<DiveAlarmMesg> diveAlarmMesgs:
                    if (DiveAlarmMesgs == null)
                        DiveAlarmMesgs = new List<DiveAlarmMesg>();

                    DiveAlarmMesgs = diveAlarmMesgs;
                    break;

                case List<DiveGasMesg> diveGasMesgs:
                    if (DiveGasMesgs == null)
                        DiveGasMesgs = new List<DiveGasMesg>();

                    DiveGasMesgs = diveGasMesgs;
                    break;

                case List<GoalMesg> goalMesgs:
                    if (GoalMesgs == null)
                        GoalMesgs = new List<GoalMesg>();

                    GoalMesgs = goalMesgs;
                    break;

                case List<ActivityMesg> activityMesgs:
                    if (ActivityMesgs == null)
                        ActivityMesgs = new List<ActivityMesg>();

                    ActivityMesgs = activityMesgs;
                    break;

                case List<SessionMesg> sessionMesgs:
                    if (SessionMesgs == null)
                        SessionMesgs = new List<SessionMesg>();

                    SessionMesgs = sessionMesgs;
                    break;

                case List<LapMesg> lapMesgs:
                    if (LapMesgs == null)
                        LapMesgs = new List<LapMesg>();

                    LapMesgs = lapMesgs;
                    break;

                case List<LengthMesg> lengthMesgs:
                    if (LengthMesgs == null)
                        LengthMesgs = new List<LengthMesg>();

                    LengthMesgs = lengthMesgs;
                    break;

                case List<RecordMesg> recordMesgs:
                    if (RecordMesgs == null)
                        RecordMesgs = new List<RecordMesg>();

                    RecordMesgs = recordMesgs;
                    break;

                case List<EventMesg> eventMesgs:
                    if (EventMesgs == null)
                        EventMesgs = new List<EventMesg>();

                    EventMesgs = eventMesgs;
                    break;

                case List<DeviceInfoMesg> deviceInfoMesgs:
                    if (DeviceInfoMesgs == null)
                        DeviceInfoMesgs = new List<DeviceInfoMesg>();

                    DeviceInfoMesgs = deviceInfoMesgs;
                    break;

                case List<TrainingFileMesg> trainingFileMesgs:
                    if (TrainingFileMesgs == null)
                        TrainingFileMesgs = new List<TrainingFileMesg>();

                    TrainingFileMesgs = trainingFileMesgs;
                    break;

                case List<HrvMesg> hrvMesgs:
                    if (HrvMesgs == null)
                        HrvMesgs = new List<HrvMesg>();

                    HrvMesgs = hrvMesgs;
                    break;

                case List<WeatherConditionsMesg> weatherConditionsMesgs:
                    if (WeatherConditionsMesgs == null)
                        WeatherConditionsMesgs = new List<WeatherConditionsMesg>();

                    WeatherConditionsMesgs = weatherConditionsMesgs;
                    break;

                case List<WeatherAlertMesg> weatherAlertMesgs:
                    if (WeatherAlertMesgs == null)
                        WeatherAlertMesgs = new List<WeatherAlertMesg>();

                    WeatherAlertMesgs = weatherAlertMesgs;
                    break;

                case List<GpsMetadataMesg> gpsMetadataMesgs:
                    if (GpsMetadataMesgs == null)
                        GpsMetadataMesgs = new List<GpsMetadataMesg>();

                    GpsMetadataMesgs = gpsMetadataMesgs;
                    break;

                case List<CameraEventMesg> cameraEventMesgs:
                    if (CameraEventMesgs == null)
                        CameraEventMesgs = new List<CameraEventMesg>();

                    CameraEventMesgs = cameraEventMesgs;
                    break;

                case List<GyroscopeDataMesg> gyroscopeDataMesgs:
                    if (GyroscopeDataMesgs == null)
                        GyroscopeDataMesgs = new List<GyroscopeDataMesg>();

                    GyroscopeDataMesgs = gyroscopeDataMesgs;
                    break;

                case List<AccelerometerDataMesg> accelerometerDataMesgs:
                    if (AccelerometerDataMesgs == null)
                        AccelerometerDataMesgs = new List<AccelerometerDataMesg>();

                    AccelerometerDataMesgs = accelerometerDataMesgs;
                    break;

                case List<MagnetometerDataMesg> magnetometerDataMesgs:
                    if (MagnetometerDataMesgs == null)
                        MagnetometerDataMesgs = new List<MagnetometerDataMesg>();

                    MagnetometerDataMesgs = magnetometerDataMesgs;
                    break;

                case List<BarometerDataMesg> barometerDataMesgs:
                    if (BarometerDataMesgs == null)
                        BarometerDataMesgs = new List<BarometerDataMesg>();

                    BarometerDataMesgs = barometerDataMesgs;
                    break;

                case List<ThreeDSensorCalibrationMesg> threeDSensorCalibrationMesgs:
                    if (ThreeDSensorCalibrationMesgs == null)
                        ThreeDSensorCalibrationMesgs = new List<ThreeDSensorCalibrationMesg>();

                    ThreeDSensorCalibrationMesgs = threeDSensorCalibrationMesgs;
                    break;

                case List<OneDSensorCalibrationMesg> oneDSensorCalibrationMesgs:
                    if (OneDSensorCalibrationMesgs == null)
                        OneDSensorCalibrationMesgs = new List<OneDSensorCalibrationMesg>();

                    OneDSensorCalibrationMesgs = oneDSensorCalibrationMesgs;
                    break;

                case List<VideoFrameMesg> videoFrameMesgs:
                    if (VideoFrameMesgs == null)
                        VideoFrameMesgs = new List<VideoFrameMesg>();

                    VideoFrameMesgs = videoFrameMesgs;
                    break;

                case List<ObdiiDataMesg> obdiiDataMesgs:
                    if (ObdiiDataMesgs == null)
                        ObdiiDataMesgs = new List<ObdiiDataMesg>();

                    ObdiiDataMesgs = obdiiDataMesgs;
                    break;

                case List<NmeaSentenceMesg> nmeaSentenceMesgs:
                    if (NmeaSentenceMesgs == null)
                        NmeaSentenceMesgs = new List<NmeaSentenceMesg>();

                    NmeaSentenceMesgs = nmeaSentenceMesgs;
                    break;

                case List<AviationAttitudeMesg> aviationAttitudeMesgs:
                    if (AviationAttitudeMesgs == null)
                        AviationAttitudeMesgs = new List<AviationAttitudeMesg>();

                    AviationAttitudeMesgs = aviationAttitudeMesgs;
                    break;

                case List<VideoMesg> videoMesgs:
                    if (VideoMesgs == null)
                        VideoMesgs = new List<VideoMesg>();

                    VideoMesgs = videoMesgs;
                    break;

                case List<VideoTitleMesg> videoTitleMesgs:
                    if (VideoTitleMesgs == null)
                        VideoTitleMesgs = new List<VideoTitleMesg>();

                    VideoTitleMesgs = videoTitleMesgs;
                    break;

                case List<VideoDescriptionMesg> videoDescriptionMesgs:
                    if (VideoDescriptionMesgs == null)
                        VideoDescriptionMesgs = new List<VideoDescriptionMesg>();

                    VideoDescriptionMesgs = videoDescriptionMesgs;
                    break;

                case List<VideoClipMesg> videoClipMesgs:
                    if (VideoClipMesgs == null)
                        VideoClipMesgs = new List<VideoClipMesg>();

                    VideoClipMesgs = videoClipMesgs;
                    break;

                case List<SetMesg> setMesgs:
                    if (SetMesgs == null)
                        SetMesgs = new List<SetMesg>();

                    SetMesgs = setMesgs;
                    break;

                case List<JumpMesg> jumpMesgs:
                    if (JumpMesgs == null)
                        JumpMesgs = new List<JumpMesg>();

                    JumpMesgs = jumpMesgs;
                    break;

                case List<CourseMesg> courseMesgs:
                    if (CourseMesgs == null)
                        CourseMesgs = new List<CourseMesg>();

                    CourseMesgs = courseMesgs;
                    break;

                case List<CoursePointMesg> coursePointMesgs:
                    if (CoursePointMesgs == null)
                        CoursePointMesgs = new List<CoursePointMesg>();

                    CoursePointMesgs = coursePointMesgs;
                    break;

                case List<SegmentIdMesg> segmentIdMesgs:
                    if (SegmentIdMesgs == null)
                        SegmentIdMesgs = new List<SegmentIdMesg>();

                    SegmentIdMesgs = segmentIdMesgs;
                    break;

                case List<SegmentLeaderboardEntryMesg> segmentLeaderboardEntryMesgs:
                    if (SegmentLeaderboardEntryMesgs == null)
                        SegmentLeaderboardEntryMesgs = new List<SegmentLeaderboardEntryMesg>();

                    SegmentLeaderboardEntryMesgs = segmentLeaderboardEntryMesgs;
                    break;

                case List<SegmentPointMesg> segmentPointMesgs:
                    if (SegmentPointMesgs == null)
                        SegmentPointMesgs = new List<SegmentPointMesg>();

                    SegmentPointMesgs = segmentPointMesgs;
                    break;

                case List<SegmentLapMesg> segmentLapMesgs:
                    if (SegmentLapMesgs == null)
                        SegmentLapMesgs = new List<SegmentLapMesg>();

                    SegmentLapMesgs = segmentLapMesgs;
                    break;

                case List<SegmentFileMesg> segmentFileMesgs:
                    if (SegmentFileMesgs == null)
                        SegmentFileMesgs = new List<SegmentFileMesg>();

                    SegmentFileMesgs = segmentFileMesgs;
                    break;

                case List<WorkoutMesg> workoutMesgs:
                    if (WorkoutMesgs == null)
                        WorkoutMesgs = new List<WorkoutMesg>();

                    WorkoutMesgs = workoutMesgs;
                    break;

                case List<WorkoutSessionMesg> workoutSessionMesgs:
                    if (WorkoutSessionMesgs == null)
                        WorkoutSessionMesgs = new List<WorkoutSessionMesg>();

                    WorkoutSessionMesgs = workoutSessionMesgs;
                    break;

                case List<WorkoutStepMesg> workoutStepMesgs:
                    if (WorkoutStepMesgs == null)
                        WorkoutStepMesgs = new List<WorkoutStepMesg>();

                    WorkoutStepMesgs = workoutStepMesgs;
                    break;

                case List<ExerciseTitleMesg> exerciseTitleMesgs:
                    if (ExerciseTitleMesgs == null)
                        ExerciseTitleMesgs = new List<ExerciseTitleMesg>();

                    ExerciseTitleMesgs = exerciseTitleMesgs;
                    break;

                case List<ScheduleMesg> scheduleMesgs:
                    if (ScheduleMesgs == null)
                        ScheduleMesgs = new List<ScheduleMesg>();

                    ScheduleMesgs = scheduleMesgs;
                    break;

                case List<TotalsMesg> totalsMesgs:
                    if (TotalsMesgs == null)
                        TotalsMesgs = new List<TotalsMesg>();

                    TotalsMesgs = totalsMesgs;
                    break;

                case List<WeightScaleMesg> weightScaleMesgs:
                    if (WeightScaleMesgs == null)
                        WeightScaleMesgs = new List<WeightScaleMesg>();

                    WeightScaleMesgs = weightScaleMesgs;
                    break;

                case List<BloodPressureMesg> bloodPressureMesgs:
                    if (BloodPressureMesgs == null)
                        BloodPressureMesgs = new List<BloodPressureMesg>();

                    BloodPressureMesgs = bloodPressureMesgs;
                    break;

                case List<MonitoringInfoMesg> monitoringInfoMesgs:
                    if (MonitoringInfoMesgs == null)
                        MonitoringInfoMesgs = new List<MonitoringInfoMesg>();

                    MonitoringInfoMesgs = monitoringInfoMesgs;
                    break;

                case List<MonitoringMesg> monitoringMesgs:
                    if (MonitoringMesgs == null)
                        MonitoringMesgs = new List<MonitoringMesg>();

                    MonitoringMesgs = monitoringMesgs;
                    break;

                case List<HrMesg> hrMesgs:
                    if (HrMesgs == null)
                        HrMesgs = new List<HrMesg>();

                    HrMesgs = hrMesgs;
                    break;

                case List<StressLevelMesg> stressLevelMesgs:
                    if (StressLevelMesgs == null)
                        StressLevelMesgs = new List<StressLevelMesg>();

                    StressLevelMesgs = stressLevelMesgs;
                    break;

                case List<MemoGlobMesg> memoGlobMesgs:
                    if (MemoGlobMesgs == null)
                        MemoGlobMesgs = new List<MemoGlobMesg>();

                    MemoGlobMesgs = memoGlobMesgs;
                    break;

                case List<AntChannelIdMesg> antChannelIdMesgs:
                    if (AntChannelIdMesgs == null)
                        AntChannelIdMesgs = new List<AntChannelIdMesg>();

                    AntChannelIdMesgs = antChannelIdMesgs;
                    break;

                case List<AntRxMesg> antRxMesgs:
                    if (AntRxMesgs == null)
                        AntRxMesgs = new List<AntRxMesg>();

                    AntRxMesgs = antRxMesgs;
                    break;

                case List<AntTxMesg> antTxMesgs:
                    if (AntTxMesgs == null)
                        AntTxMesgs = new List<AntTxMesg>();

                    AntTxMesgs = antTxMesgs;
                    break;

                case List<ExdScreenConfigurationMesg> exdScreenConfigurationMesgs:
                    if (ExdScreenConfigurationMesgs == null)
                        ExdScreenConfigurationMesgs = new List<ExdScreenConfigurationMesg>();

                    ExdScreenConfigurationMesgs = exdScreenConfigurationMesgs;
                    break;

                case List<ExdDataFieldConfigurationMesg> exdDataFieldConfigurationMesgs:
                    if (ExdDataFieldConfigurationMesgs == null)
                        ExdDataFieldConfigurationMesgs = new List<ExdDataFieldConfigurationMesg>();

                    ExdDataFieldConfigurationMesgs = exdDataFieldConfigurationMesgs;
                    break;

                case List<ExdDataConceptConfigurationMesg> exdDataConceptConfigurationMesgs:
                    if (ExdDataConceptConfigurationMesgs == null)
                        ExdDataConceptConfigurationMesgs = new List<ExdDataConceptConfigurationMesg>();

                    ExdDataConceptConfigurationMesgs = exdDataConceptConfigurationMesgs;
                    break;
                case List<FieldDescriptionMesg> fieldDescriptionMesgs:
                    if (FieldDescriptionMesgs == null)
                        FieldDescriptionMesgs = new List<FieldDescriptionMesg>();

                    FieldDescriptionMesgs = fieldDescriptionMesgs;
                    break;

                case List<DeveloperDataIdMesg> developerDataIdMesgs:
                    if (DeveloperDataIdMesgs == null)
                        DeveloperDataIdMesgs = new List<DeveloperDataIdMesg>();

                    DeveloperDataIdMesgs = developerDataIdMesgs;
                    break;

                case List<DiveSummaryMesg> diveSummaryMesgs:
                    if (DiveSummaryMesgs == null)
                        DiveSummaryMesgs = new List<DiveSummaryMesg>();

                    DiveSummaryMesgs = diveSummaryMesgs;
                    break;

                case List<ClimbProMesg> climbProMesgs:
                    if (ClimbProMesgs == null)
                        ClimbProMesgs = new List<ClimbProMesg>();

                    ClimbProMesgs = climbProMesgs;
                    break;

                case List<PadMesg> padMesgs:
                    if (PadMesgs == null)
                        PadMesgs = new List<PadMesg>();

                    PadMesgs = padMesgs;
                    break;

                    // default:
                    //     if (UnknownMesgs == null)
                    //         UnknownMesgs = new List<Mesg>();

                    //     UnknownMesgs = newMesgs;
                    //     break;
                case List<Mesg> mesgs:
                    if (UnknownMesgs == null)
                        UnknownMesgs = new List<Mesg>();

                    UnknownMesgs = mesgs;
                    break;
            }
        }
    }
}