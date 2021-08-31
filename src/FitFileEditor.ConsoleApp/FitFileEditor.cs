using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Dynastream.Fit;

namespace FitFileEditor.ConsoleApp
{
    public class Editor
    {
        public string FitFilePath { get; }

        public FitFileParser FitFileParser { get; private set; } = new();

        public Editor(string path)
        {
            FitFilePath = path;
            FitFileParser.ReadFitFile(FitFilePath);
        }

        public void Edit(string? output, bool shouldMultiplyCadence = true)
        {
            Console.WriteLine($"Editing FIT file: {FitFilePath}");
            MakeChanges(shouldMultiplyCadence);
            FitFileParser.WriteFitFile(output ?? $"{Path.GetFileNameWithoutExtension(FitFilePath)}-edited.fit");
        }

        public string ToJson()
        {
            return FitFileParser.ToJson();
        }

        private void MakeChanges(bool shouldMultiplyCadence = false)
        {
            //WORKOUTMSG
            if (FitFileParser.WorkoutMesgs is not null)
                FitFileParser.Edit(FitFileParser.WorkoutMesgs.Select(workMesg =>
                {
                    workMesg.SetSport(Sport.Rowing);
                    workMesg.SetSubSport(SubSport.Generic);

                    return workMesg;
                }).ToList());

            //WORKOUTSTEPMSG
            if (FitFileParser.WorkoutStepMesgs is not null && shouldMultiplyCadence)
                FitFileParser.Edit(FitFileParser.WorkoutStepMesgs.MultiplyCadence(2).ToList());

            //SPORTEMSG
            if (FitFileParser.SportMesgs is not null)
                FitFileParser.Edit(FitFileParser.SportMesgs.Select(sportMesg =>
                {
                    sportMesg.SetSport(Sport.Rowing);
                    sportMesg.SetSubSport(SubSport.Generic);
                    sportMesg.SetName("Row");
                    sportMesg.SetFieldValue(4, 29);

                    return sportMesg;
                }).ToList());

            //RECORDMESG
            if (FitFileParser.RecordMesgs is not null)
            {
                IEnumerable<RecordMesg> editedRecordData = FitFileParser.RecordMesgs;
                if (shouldMultiplyCadence)
                {
                    editedRecordData = editedRecordData.MultiplyCadence(2);
                }
                FitFileParser.Edit(
                    editedRecordData.AddStrokeDistance().ToList()
                );

                //SESSIONMESG
                if (FitFileParser.SessionMesgs is not null)
                {
                    var editedSessionData = FitFileParser.SessionMesgs.Select(sessionMesg =>
                    {
                        sessionMesg.SetSport(Sport.Rowing);
                        sessionMesg.SetSubSport(SubSport.Generic);
                        sessionMesg.SetFieldValue(110, Encoding.UTF8.GetBytes("Row"));

                        return sessionMesg;
                    });
                    if (shouldMultiplyCadence)
                    {
                        editedSessionData = editedSessionData.MultiplyCadence(2);
                    }
                    FitFileParser.Edit(
                        editedSessionData.AddStrokeDistance(FitFileParser.RecordMesgs).ToList()
                    );
                }

                //LAPMESG
                if (FitFileParser.LapMesgs is not null)
                {
                    var editedLapData = FitFileParser.LapMesgs.Select(lap =>
                    {
                        lap.SetSport(Sport.Rowing);
                        lap.SetSubSport(SubSport.Generic);

                        return lap;
                    });
                    if (shouldMultiplyCadence)
                    {
                        editedLapData = editedLapData.MultiplyCadence(2);
                    }

                    FitFileParser.Edit(
                        editedLapData.AddStrokeDistance(FitFileParser.RecordMesgs[0].GetTimestamp().GetDateTime(), FitFileParser.RecordMesgs).ToList()
                    );
                }
            }
        }
    }
}