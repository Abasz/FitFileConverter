// using System.Collections.Generic;

// using Dynastream.Fit;

// namespace FitFileEditor.ConsoleApp
// {
//     public class FitFileModel
//     {
//         public List<Mesg> ? FileIdMesg { get; private set; }
//         public List<Mesg> ? FileCreatorMesg { get; private set; }
//         public List<Mesg> ? TimestampCorrelationMesg { get; private set; }
//         public List<Mesg> ? SoftwareMesg { get; private set; }
//         public List<Mesg> ? SlaveDeviceMesg { get; private set; }
//         public List<Mesg> ? CapabilitiesMesg { get; private set; }
//         public List<Mesg> ? FileCapabilitiesMesg { get; private set; }
//         public List<Mesg> ? MesgCapabilitiesMesg { get; private set; }
//         public List<Mesg> ? FieldCapabilitiesMesg { get; private set; }
//         public List<Mesg> ? DeviceSettingsMesg { get; private set; }
//         public List<Mesg> ? UserProfileMesg { get; private set; }
//         public List<Mesg> ? HrmProfileMesg { get; private set; }
//         public List<Mesg> ? SdmProfileMesg { get; private set; }
//         public List<Mesg> ? BikeProfileMesg { get; private set; }
//         public List<Mesg> ? ConnectivityMesg { get; private set; }
//         public List<Mesg> ? WatchfaceSettingsMesg { get; private set; }
//         public List<Mesg> ? OhrSettingsMesg { get; private set; }
//         public List<Mesg> ? ZonesTargetMesg { get; private set; }
//         public List<Mesg> ? SportMesg { get; private set; }
//         public List<Mesg> ? HrZoneMesg { get; private set; }
//         public List<Mesg> ? SpeedZoneMesg { get; private set; }
//         public List<Mesg> ? CadenceZoneMesg { get; private set; }
//         public List<Mesg> ? PowerZoneMesg { get; private set; }
//         public List<Mesg> ? MetZoneMesg { get; private set; }
//         public List<Mesg> ? DiveSettingsMesg { get; private set; }
//         public List<Mesg> ? DiveAlarmMesg { get; private set; }
//         public List<Mesg> ? DiveGasMesg { get; private set; }
//         public List<Mesg> ? GoalMesg { get; private set; }
//         public List<Mesg> ? ActivityMesg { get; private set; }
//         public List<Mesg> ? SessionMesg { get; private set; }
//         public List<Mesg> ? LapMesg { get; private set; }
//         public List<Mesg> ? LengthMesg { get; private set; }
//         public List<Mesg> ? RecordMesg { get; private set; }
//         public List<Mesg> ? EventMesg { get; private set; }
//         public List<Mesg> ? DeviceInfoMesg { get; private set; }
//         public List<Mesg> ? TrainingFileMesg { get; private set; }
//         public List<Mesg> ? HrvMesg { get; private set; }
//         public List<Mesg> ? WeatherConditionsMesg { get; private set; }
//         public List<Mesg> ? WeatherAlertMesg { get; private set; }
//         public List<Mesg> ? GpsMetadataMesg { get; private set; }
//         public List<Mesg> ? CameraEventMesg { get; private set; }
//         public List<Mesg> ? GyroscopeDataMesg { get; private set; }
//         public List<Mesg> ? AccelerometerDataMesg { get; private set; }
//         public List<Mesg> ? MagnetometerDataMesg { get; private set; }
//         public List<Mesg> ? BarometerDataMesg { get; private set; }
//         public List<Mesg> ? ThreeDSensorCalibrationMesg { get; private set; }
//         public List<Mesg> ? OneDSensorCalibrationMesg { get; private set; }
//         public List<Mesg> ? VideoFrameMesg { get; private set; }
//         public List<Mesg> ? ObdiiDataMesg { get; private set; }
//         public List<Mesg> ? NmeaSentenceMesg { get; private set; }
//         public List<Mesg> ? AviationAttitudeMesg { get; private set; }
//         public List<Mesg> ? VideoMesg { get; private set; }
//         public List<Mesg> ? VideoTitleMesg { get; private set; }
//         public List<Mesg> ? VideoDescriptionMesg { get; private set; }
//         public List<Mesg> ? VideoClipMesg { get; private set; }
//         public List<Mesg> ? SetMesg { get; private set; }
//         public List<Mesg> ? JumpMesg { get; private set; }
//         public List<Mesg> ? CourseMesg { get; private set; }
//         public List<Mesg> ? CoursePointMesg { get; private set; }
//         public List<Mesg> ? SegmentIdMesg { get; private set; }
//         public List<Mesg> ? SegmentLeaderboardEntryMesg { get; private set; }
//         public List<Mesg> ? SegmentPointMesg { get; private set; }
//         public List<Mesg> ? SegmentLapMesg { get; private set; }
//         public List<Mesg> ? SegmentFileMesg { get; private set; }
//         public List<Mesg> ? WorkoutMesg { get; private set; }
//         public List<Mesg> ? WorkoutSessionMesg { get; private set; }
//         public List<Mesg> ? WorkoutStepMesg { get; private set; }
//         public List<Mesg> ? ExerciseTitleMesg { get; private set; }
//         public List<Mesg> ? ScheduleMesg { get; private set; }
//         public List<Mesg> ? TotalsMesg { get; private set; }
//         public List<Mesg> ? WeightScaleMesg { get; private set; }
//         public List<Mesg> ? BloodPressureMesg { get; private set; }
//         public List<Mesg> ? MonitoringInfoMesg { get; private set; }
//         public List<Mesg> ? MonitoringMesg { get; private set; }
//         public List<Mesg> ? HrMesg { get; private set; }
//         public List<Mesg> ? StressLevelMesg { get; private set; }
//         public List<Mesg> ? MemoGlobMesg { get; private set; }
//         public List<Mesg> ? AntChannelIdMesg { get; private set; }
//         public List<Mesg> ? AntRxMesg { get; private set; }
//         public List<Mesg> ? AntTxMesg { get; private set; }
//         public List<Mesg> ? ExdScreenConfigurationMesg { get; private set; }
//         public List<Mesg> ? ExdDataFieldConfigurationMesg { get; private set; }
//         public List<Mesg> ? ExdDataConceptConfigurationMesg { get; private set; }
//         public List<Mesg> ? FieldDescriptionMesg { get; private set; }
//         public List<Mesg> ? DeveloperDataIdMesg { get; private set; }
//         public List<Mesg> ? DiveSummaryMesg { get; private set; }
//         public List<Mesg> ? ClimbProMesg { get; private set; }
//         public List<Mesg> ? PadMesg { get; private set; }
//         public List<Mesg> ? UnknownMesg { get; private set; }

//         public void OnMesg(object sender, MesgEventArgs e)
//         {
//             switch (e.mesg.Num)
//             {

//                 case (ushort)MesgNum.FileId:
//                     if (FileIdMesg == null)
//                         FileIdMesg = new List<Mesg>();

//                     FileIdMesg.Add(e.mesg);

//                     break;

//                 case (ushort)MesgNum.FileCreator:
//                     if (FileCreatorMesg == null)
//                         FileCreatorMesg = new List<Mesg>();

//                     FileCreatorMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.TimestampCorrelation:
//                     if (TimestampCorrelationMesg == null)
//                         TimestampCorrelationMesg = new List<Mesg>();

//                     TimestampCorrelationMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Software:
//                     if (SoftwareMesg == null)
//                         SoftwareMesg = new List<Mesg>();

//                     SoftwareMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.SlaveDevice:
//                     if (SlaveDeviceMesg == null)
//                         SlaveDeviceMesg = new List<Mesg>();

//                     SlaveDeviceMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Capabilities:
//                     if (CapabilitiesMesg == null)
//                         CapabilitiesMesg = new List<Mesg>();

//                     CapabilitiesMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.FileCapabilities:
//                     if (FileCapabilitiesMesg == null)
//                         FileCapabilitiesMesg = new List<Mesg>();

//                     FileCapabilitiesMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.MesgCapabilities:
//                     if (MesgCapabilitiesMesg == null)
//                         MesgCapabilitiesMesg = new List<Mesg>();

//                     MesgCapabilitiesMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.FieldCapabilities:
//                     if (FieldCapabilitiesMesg == null)
//                         FieldCapabilitiesMesg = new List<Mesg>();

//                     FieldCapabilitiesMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.DeviceSettings:
//                     if (DeviceSettingsMesg == null)
//                         DeviceSettingsMesg = new List<Mesg>();

//                     DeviceSettingsMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.UserProfile:
//                     if (UserProfileMesg == null)
//                         UserProfileMesg = new List<Mesg>();

//                     UserProfileMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.HrmProfile:
//                     if (HrmProfileMesg == null)
//                         HrmProfileMesg = new List<Mesg>();

//                     HrmProfileMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.SdmProfile:
//                     if (SdmProfileMesg == null)
//                         SdmProfileMesg = new List<Mesg>();

//                     SdmProfileMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.BikeProfile:
//                     if (BikeProfileMesg == null)
//                         BikeProfileMesg = new List<Mesg>();

//                     BikeProfileMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Connectivity:
//                     if (ConnectivityMesg == null)
//                         ConnectivityMesg = new List<Mesg>();

//                     ConnectivityMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.WatchfaceSettings:
//                     if (WatchfaceSettingsMesg == null)
//                         WatchfaceSettingsMesg = new List<Mesg>();

//                     WatchfaceSettingsMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.OhrSettings:
//                     if (OhrSettingsMesg == null)
//                         OhrSettingsMesg = new List<Mesg>();

//                     OhrSettingsMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.ZonesTarget:
//                     if (ZonesTargetMesg == null)
//                         ZonesTargetMesg = new List<Mesg>();

//                     ZonesTargetMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Sport:
//                     if (SportMesg == null)
//                         SportMesg = new List<Mesg>();

//                     SportMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.HrZone:
//                     if (HrZoneMesg == null)
//                         HrZoneMesg = new List<Mesg>();

//                     HrZoneMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.SpeedZone:
//                     if (SpeedZoneMesg == null)
//                         SpeedZoneMesg = new List<Mesg>();

//                     SpeedZoneMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.CadenceZone:
//                     if (CadenceZoneMesg == null)
//                         CadenceZoneMesg = new List<Mesg>();

//                     CadenceZoneMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.PowerZone:
//                     if (PowerZoneMesg == null)
//                         PowerZoneMesg = new List<Mesg>();

//                     PowerZoneMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.MetZone:
//                     if (MetZoneMesg == null)
//                         MetZoneMesg = new List<Mesg>();

//                     MetZoneMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.DiveSettings:
//                     if (DiveSettingsMesg == null)
//                         DiveSettingsMesg = new List<Mesg>();

//                     DiveSettingsMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.DiveAlarm:
//                     if (DiveAlarmMesg == null)
//                         DiveAlarmMesg = new List<Mesg>();

//                     DiveAlarmMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.DiveGas:
//                     if (DiveGasMesg == null)
//                         DiveGasMesg = new List<Mesg>();

//                     DiveGasMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Goal:
//                     if (GoalMesg == null)
//                         GoalMesg = new List<Mesg>();

//                     GoalMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Activity:
//                     if (ActivityMesg == null)
//                         ActivityMesg = new List<Mesg>();

//                     ActivityMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Session:
//                     if (SessionMesg == null)
//                         SessionMesg = new List<Mesg>();

//                     SessionMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Lap:
//                     if (LapMesg == null)
//                         LapMesg = new List<Mesg>();

//                     LapMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Length:
//                     if (LengthMesg == null)
//                         LengthMesg = new List<Mesg>();

//                     LengthMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Record:
//                     if (RecordMesg == null)
//                         RecordMesg = new List<Mesg>();

//                     RecordMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Event:
//                     if (EventMesg == null)
//                         EventMesg = new List<Mesg>();

//                     EventMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.DeviceInfo:
//                     if (DeviceInfoMesg == null)
//                         DeviceInfoMesg = new List<Mesg>();

//                     DeviceInfoMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.TrainingFile:
//                     if (TrainingFileMesg == null)
//                         TrainingFileMesg = new List<Mesg>();

//                     TrainingFileMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Hrv:
//                     if (HrvMesg == null)
//                         HrvMesg = new List<Mesg>();

//                     HrvMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.WeatherConditions:
//                     if (WeatherConditionsMesg == null)
//                         WeatherConditionsMesg = new List<Mesg>();

//                     WeatherConditionsMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.WeatherAlert:
//                     if (WeatherAlertMesg == null)
//                         WeatherAlertMesg = new List<Mesg>();

//                     WeatherAlertMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.GpsMetadata:
//                     if (GpsMetadataMesg == null)
//                         GpsMetadataMesg = new List<Mesg>();

//                     GpsMetadataMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.CameraEvent:
//                     if (CameraEventMesg == null)
//                         CameraEventMesg = new List<Mesg>();

//                     CameraEventMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.GyroscopeData:
//                     if (GyroscopeDataMesg == null)
//                         GyroscopeDataMesg = new List<Mesg>();

//                     GyroscopeDataMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.AccelerometerData:
//                     if (AccelerometerDataMesg == null)
//                         AccelerometerDataMesg = new List<Mesg>();

//                     AccelerometerDataMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.MagnetometerData:
//                     if (MagnetometerDataMesg == null)
//                         MagnetometerDataMesg = new List<Mesg>();

//                     MagnetometerDataMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.BarometerData:
//                     if (BarometerDataMesg == null)
//                         BarometerDataMesg = new List<Mesg>();

//                     BarometerDataMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.ThreeDSensorCalibration:
//                     if (ThreeDSensorCalibrationMesg == null)
//                         ThreeDSensorCalibrationMesg = new List<Mesg>();

//                     ThreeDSensorCalibrationMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.OneDSensorCalibration:
//                     if (OneDSensorCalibrationMesg == null)
//                         OneDSensorCalibrationMesg = new List<Mesg>();

//                     OneDSensorCalibrationMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.VideoFrame:
//                     if (VideoFrameMesg == null)
//                         VideoFrameMesg = new List<Mesg>();

//                     VideoFrameMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.ObdiiData:
//                     if (ObdiiDataMesg == null)
//                         ObdiiDataMesg = new List<Mesg>();

//                     ObdiiDataMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.NmeaSentence:
//                     if (NmeaSentenceMesg == null)
//                         NmeaSentenceMesg = new List<Mesg>();

//                     NmeaSentenceMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.AviationAttitude:
//                     if (AviationAttitudeMesg == null)
//                         AviationAttitudeMesg = new List<Mesg>();

//                     AviationAttitudeMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Video:
//                     if (VideoMesg == null)
//                         VideoMesg = new List<Mesg>();

//                     VideoMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.VideoTitle:
//                     if (VideoTitleMesg == null)
//                         VideoTitleMesg = new List<Mesg>();

//                     VideoTitleMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.VideoDescription:
//                     if (VideoDescriptionMesg == null)
//                         VideoDescriptionMesg = new List<Mesg>();

//                     VideoDescriptionMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.VideoClip:
//                     if (VideoClipMesg == null)
//                         VideoClipMesg = new List<Mesg>();

//                     VideoClipMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Set:
//                     if (SetMesg == null)
//                         SetMesg = new List<Mesg>();

//                     SetMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Jump:
//                     if (JumpMesg == null)
//                         JumpMesg = new List<Mesg>();

//                     JumpMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Course:
//                     if (CourseMesg == null)
//                         CourseMesg = new List<Mesg>();

//                     CourseMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.CoursePoint:
//                     if (CoursePointMesg == null)
//                         CoursePointMesg = new List<Mesg>();

//                     CoursePointMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.SegmentId:
//                     if (SegmentIdMesg == null)
//                         SegmentIdMesg = new List<Mesg>();

//                     SegmentIdMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.SegmentLeaderboardEntry:
//                     if (SegmentLeaderboardEntryMesg == null)
//                         SegmentLeaderboardEntryMesg = new List<Mesg>();

//                     SegmentLeaderboardEntryMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.SegmentPoint:
//                     if (SegmentPointMesg == null)
//                         SegmentPointMesg = new List<Mesg>();

//                     SegmentPointMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.SegmentLap:
//                     if (SegmentLapMesg == null)
//                         SegmentLapMesg = new List<Mesg>();

//                     SegmentLapMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.SegmentFile:
//                     if (SegmentFileMesg == null)
//                         SegmentFileMesg = new List<Mesg>();

//                     SegmentFileMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Workout:
//                     if (WorkoutMesg == null)
//                         WorkoutMesg = new List<Mesg>();

//                     WorkoutMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.WorkoutSession:
//                     if (WorkoutSessionMesg == null)
//                         WorkoutSessionMesg = new List<Mesg>();

//                     WorkoutSessionMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.WorkoutStep:
//                     if (WorkoutStepMesg == null)
//                         WorkoutStepMesg = new List<Mesg>();

//                     WorkoutStepMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.ExerciseTitle:
//                     if (ExerciseTitleMesg == null)
//                         ExerciseTitleMesg = new List<Mesg>();

//                     ExerciseTitleMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Schedule:
//                     if (ScheduleMesg == null)
//                         ScheduleMesg = new List<Mesg>();

//                     ScheduleMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Totals:
//                     if (TotalsMesg == null)
//                         TotalsMesg = new List<Mesg>();

//                     TotalsMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.WeightScale:
//                     if (WeightScaleMesg == null)
//                         WeightScaleMesg = new List<Mesg>();

//                     WeightScaleMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.BloodPressure:
//                     if (BloodPressureMesg == null)
//                         BloodPressureMesg = new List<Mesg>();

//                     BloodPressureMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.MonitoringInfo:
//                     if (MonitoringInfoMesg == null)
//                         MonitoringInfoMesg = new List<Mesg>();

//                     MonitoringInfoMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Monitoring:
//                     if (MonitoringMesg == null)
//                         MonitoringMesg = new List<Mesg>();

//                     MonitoringMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Hr:
//                     if (HrMesg is null)
//                         HrMesg = new List<Mesg>();

//                     HrMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.StressLevel:
//                     if (StressLevelMesg == null)
//                         StressLevelMesg = new List<Mesg>();

//                     StressLevelMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.MemoGlob:
//                     if (MemoGlobMesg == null)
//                         MemoGlobMesg = new List<Mesg>();

//                     MemoGlobMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.AntChannelId:
//                     if (AntChannelIdMesg == null)
//                         AntChannelIdMesg = new List<Mesg>();

//                     AntChannelIdMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.AntRx:
//                     if (AntRxMesg == null)
//                         AntRxMesg = new List<Mesg>();

//                     AntRxMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.AntTx:
//                     if (AntTxMesg == null)
//                         AntTxMesg = new List<Mesg>();

//                     AntTxMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.ExdScreenConfiguration:
//                     if (ExdScreenConfigurationMesg == null)
//                         ExdScreenConfigurationMesg = new List<Mesg>();

//                     ExdScreenConfigurationMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.ExdDataFieldConfiguration:
//                     if (ExdDataFieldConfigurationMesg == null)
//                         ExdDataFieldConfigurationMesg = new List<Mesg>();

//                     ExdDataFieldConfigurationMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.ExdDataConceptConfiguration:
//                     if (ExdDataConceptConfigurationMesg == null)
//                         ExdDataConceptConfigurationMesg = new List<Mesg>();

//                     ExdDataConceptConfigurationMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.FieldDescription:
//                     if (FieldDescriptionMesg == null)
//                         FieldDescriptionMesg = new List<Mesg>();

//                     FieldDescriptionMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.DeveloperDataId:
//                     if (DeveloperDataIdMesg == null)
//                         DeveloperDataIdMesg = new List<Mesg>();

//                     DeveloperDataIdMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.DiveSummary:
//                     if (DiveSummaryMesg == null)
//                         DiveSummaryMesg = new List<Mesg>();

//                     DiveSummaryMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.ClimbPro:
//                     if (ClimbProMesg == null)
//                         ClimbProMesg = new List<Mesg>();

//                     ClimbProMesg.Add(e.mesg);
//                     break;

//                 case (ushort)MesgNum.Pad:
//                     if (PadMesg == null)
//                         PadMesg = new List<Mesg>();

//                     PadMesg.Add(e.mesg);
//                     break;
//                 default:
//                     if (UnknownMesg == null)
//                         UnknownMesg = new List<Mesg>();

//                     UnknownMesg.Add(e.mesg);
//                     break;
//             }
//         }
//     }
// }