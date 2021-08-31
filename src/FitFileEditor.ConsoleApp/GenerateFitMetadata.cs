using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using File = System.IO.File;

using Dynastream.Fit;

namespace FitFileEditor.ConsoleApp
{
    public static class GenerateFitMetadata
    {
        public static int Generate()
        {
            var importFit = new Mesg("Record", 20);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName!.Contains("Fit,")).ElementAt(0);

            var profiles = Mesgs().ToDictionary(mesg =>
            {
                if (assemblies.GetType($"Dynastream.Fit.{mesg}")is Type mesgType)
                {
                    return (string)mesgType.GetProperty("Name") !.GetValue(Activator.CreateInstance(mesgType)) !;
                }

                throw new InvalidOperationException($"Invalid Fit Mesg type: {mesg}");

            }, mesg =>
            {
                if (assemblies.GetType($"Dynastream.Fit.{mesg}")is Type mesgType)
                {
                    var mesgInstance = (Mesg)Activator.CreateInstance(mesgType) !;
                    var num = (ushort)mesgType.GetProperty("Num") !.GetValue(mesgInstance) !;
                    var fields = mesgType.GetNestedType("FieldDefNum") !.GetFields();

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
                }

                throw new InvalidOperationException($"Invalid Fit Mesg type: {mesg}");
            });

            var index = 0;
            var types = Types().ToDictionary(type => type, type =>
            {
                var fields = new Dictionary<string, long>();
                if (assemblies.GetType($"Dynastream.Fit.{type}")is Type mesgType)
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

            File.WriteAllText("profiles.json",
                JsonSerializer.Serialize(profiles, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                        PropertyNameCaseInsensitive = true,
                        IgnoreNullValues = true,
                        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                })
            );

            File.WriteAllText("types.json",
                JsonSerializer.Serialize(types, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                        PropertyNameCaseInsensitive = true,
                        IgnoreNullValues = true,
                        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                })
            );

            Console.WriteLine("profile.json and types.json have been generated");

            return 0;
        }

        static string[] Types()
        {
            return new string[]
            {
                "Enum",
                "Sint8",
                "Uint8",
                "Sint16",
                "Uint16",
                "Sint32",
                "Uint32",
                "String",
                "Float32",
                "Float64",
                "Uint8z",
                "Uint16z",
                "Uint32z",
                "Byte",
                "Sint64",
                "Uint64",
                "Uint64z",
                "Bool",
                "File",
                "MesgNum",
                "Checksum",
                "FileFlags",
                "MesgCount",
                "DateTime",
                "LocalDateTime",
                "MessageIndex",
                "DeviceIndex",
                "Gender",
                "Language",
                "LanguageBits0",
                "LanguageBits1",
                "LanguageBits2",
                "LanguageBits3",
                "LanguageBits4",
                "TimeZone",
                "DisplayMeasure",
                "DisplayHeart",
                "DisplayPower",
                "DisplayPosition",
                "Switch",
                "Sport",
                "SportBits0",
                "SportBits1",
                "SportBits2",
                "SportBits3",
                "SportBits4",
                "SportBits5",
                "SportBits6",
                "SubSport",
                "SportEvent",
                "Activity",
                "Intensity",
                "SessionTrigger",
                "AutolapTrigger",
                "LapTrigger",
                "TimeMode",
                "BacklightMode",
                "DateMode",
                "BacklightTimeout",
                "Event",
                "EventType",
                "TimerTrigger",
                "FitnessEquipmentState",
                "Tone",
                "Autoscroll",
                "ActivityClass",
                "HrZoneCalc",
                "PwrZoneCalc",
                "WktStepDuration",
                "WktStepTarget",
                "Goal",
                "GoalRecurrence",
                "GoalSource",
                "Schedule",
                "CoursePoint",
                "Manufacturer",
                "GarminProduct",
                "AntplusDeviceType",
                "AntNetwork",
                "WorkoutCapabilities",
                "BatteryStatus",
                "HrType",
                "CourseCapabilities",
                "Weight",
                "WorkoutHr",
                "WorkoutPower",
                "BpStatus",
                "UserLocalId",
                "SwimStroke",
                "ActivityType",
                "ActivitySubtype",
                "ActivityLevel",
                "Side",
                "LeftRightBalance",
                "LeftRightBalance100",
                "LengthType",
                "DayOfWeek",
                "ConnectivityCapabilities",
                "WeatherReport",
                "WeatherStatus",
                "WeatherSeverity",
                "WeatherSevereType",
                "TimeIntoDay",
                "LocaltimeIntoDay",
                "StrokeType",
                "BodyLocation",
                "SegmentLapStatus",
                "SegmentLeaderboardType",
                "SegmentDeleteStatus",
                "SegmentSelectionType",
                "SourceType",
                "LocalDeviceType",
                "DisplayOrientation",
                "WorkoutEquipment",
                "WatchfaceMode",
                "DigitalWatchfaceLayout",
                "AnalogWatchfaceLayout",
                "RiderPositionType",
                "PowerPhaseType",
                "CameraEventType",
                "SensorType",
                "BikeLightNetworkConfigType",
                "CommTimeoutType",
                "CameraOrientationType",
                "AttitudeStage",
                "AttitudeValidity",
                "AutoSyncFrequency",
                "ExdLayout",
                "ExdDisplayType",
                "ExdDataUnits",
                "ExdQualifiers",
                "ExdDescriptors",
                "AutoActivityDetect",
                "SupportedExdScreenLayouts",
                "FitBaseType",
                "TurnType",
                "BikeLightBeamAngleMode",
                "FitBaseUnit",
                "SetType",
                "ExerciseCategory",
                "BenchPressExerciseName",
                "CalfRaiseExerciseName",
                "CardioExerciseName",
                "CarryExerciseName",
                "ChopExerciseName",
                "CoreExerciseName",
                "CrunchExerciseName",
                "CurlExerciseName",
                "DeadliftExerciseName",
                "FlyeExerciseName",
                "HipRaiseExerciseName",
                "HipStabilityExerciseName",
                "HipSwingExerciseName",
                "HyperextensionExerciseName",
                "LateralRaiseExerciseName",
                "LegCurlExerciseName",
                "LegRaiseExerciseName",
                "LungeExerciseName",
                "OlympicLiftExerciseName",
                "PlankExerciseName",
                "PlyoExerciseName",
                "PullUpExerciseName",
                "PushUpExerciseName",
                "RowExerciseName",
                "ShoulderPressExerciseName",
                "ShoulderStabilityExerciseName",
                "ShrugExerciseName",
                "SitUpExerciseName",
                "SquatExerciseName",
                "TotalBodyExerciseName",
                "TricepsExtensionExerciseName",
                "WarmUpExerciseName",
                "RunExerciseName",
                "WaterType",
                "TissueModelType",
                "DiveGasStatus",
                "DiveAlarmType",
                "DiveBacklightMode",
                "FaveroProduct",
                "ClimbProEvent",
                "TapSensitivity",
                "RadarThreatLevelType",
                "NumType"
            };
        }

        static string[] Mesgs()
        {
            return new string[]
            {
                "FileIdMesg",
                "FileCreatorMesg",
                "TimestampCorrelationMesg",
                "SoftwareMesg",
                "SlaveDeviceMesg",
                "CapabilitiesMesg",
                "FileCapabilitiesMesg",
                "MesgCapabilitiesMesg",
                "FieldCapabilitiesMesg",
                "DeviceSettingsMesg",
                "UserProfileMesg",
                "HrmProfileMesg",
                "SdmProfileMesg",
                "BikeProfileMesg",
                "ConnectivityMesg",
                "WatchfaceSettingsMesg",
                "OhrSettingsMesg",
                "ZonesTargetMesg",
                "SportMesg",
                "HrZoneMesg",
                "SpeedZoneMesg",
                "CadenceZoneMesg",
                "PowerZoneMesg",
                "MetZoneMesg",
                "DiveSettingsMesg",
                "DiveAlarmMesg",
                "DiveGasMesg",
                "GoalMesg",
                "ActivityMesg",
                "SessionMesg",
                "LapMesg",
                "LengthMesg",
                "RecordMesg",
                "EventMesg",
                "DeviceInfoMesg",
                "TrainingFileMesg",
                "HrvMesg",
                "WeatherConditionsMesg",
                "WeatherAlertMesg",
                "GpsMetadataMesg",
                "CameraEventMesg",
                "GyroscopeDataMesg",
                "AccelerometerDataMesg",
                "MagnetometerDataMesg",
                "BarometerDataMesg",
                "ThreeDSensorCalibrationMesg",
                "OneDSensorCalibrationMesg",
                "VideoFrameMesg",
                "ObdiiDataMesg",
                "NmeaSentenceMesg",
                "AviationAttitudeMesg",
                "VideoMesg",
                "VideoTitleMesg",
                "VideoDescriptionMesg",
                "VideoClipMesg",
                "SetMesg",
                "JumpMesg",
                "CourseMesg",
                "CoursePointMesg",
                "SegmentIdMesg",
                "SegmentLeaderboardEntryMesg",
                "SegmentPointMesg",
                "SegmentLapMesg",
                "SegmentFileMesg",
                "WorkoutMesg",
                "WorkoutSessionMesg",
                "WorkoutStepMesg",
                "ExerciseTitleMesg",
                "ScheduleMesg",
                "TotalsMesg",
                "WeightScaleMesg",
                "BloodPressureMesg",
                "MonitoringInfoMesg",
                "MonitoringMesg",
                "HrMesg",
                "StressLevelMesg",
                "MemoGlobMesg",
                "AntChannelIdMesg",
                "AntRxMesg",
                "AntTxMesg",
                "ExdScreenConfigurationMesg",
                "ExdDataFieldConfigurationMesg",
                "ExdDataConceptConfigurationMesg",
                "FieldDescriptionMesg",
                "DeveloperDataIdMesg",
                "DiveSummaryMesg",
                "ClimbProMesg",
                "PadMesg"
            };
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

}