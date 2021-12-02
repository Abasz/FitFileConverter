using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dynastream.Fit;

using FitFileEditor.ClassLibrary;

namespace FitFileEditor.ConsoleApp
{
    public static class EditorExtensions
    {
        public static FitFileParser Edit(this FitFileParser fitFileParser, bool shouldMultiplyCadence = true, uint multiplier = 2)
        {
            Console.WriteLine($"Applying changes to FIT data (shouldMultiply: {shouldMultiplyCadence}, multiplier: {multiplier})");

            fitFileParser.Edit(EditWorkoutMesgs());
            fitFileParser.Edit(EditWorkoutStepMesgs(shouldMultiplyCadence, multiplier));
            fitFileParser.Edit(EditSportMesgs());
            fitFileParser.Edit(EditRecordMesgs(shouldMultiplyCadence, multiplier));
            fitFileParser.Edit(EditSessionMesgs(fitFileParser.RecordMesgs, shouldMultiplyCadence, multiplier));
            fitFileParser.Edit(EditLapMesgs(fitFileParser.RecordMesgs, shouldMultiplyCadence, multiplier));

            return fitFileParser;
        }

        public static Func<WorkoutMesg, WorkoutMesg> EditWorkoutMesgs()
        {
            return workMesg =>
            {
                if (workMesg.GetSport() != Sport.Rowing)
                {
                    workMesg.SetSport(Sport.Rowing);
                    workMesg.SetSubSport(
                        workMesg.GetSubSport() == SubSport.IndoorCycling ?
                        SubSport.IndoorRowing : SubSport.Generic
                    );
                }
                return workMesg;
            };
        }

        public static Func<WorkoutStepMesg, WorkoutStepMesg> EditWorkoutStepMesgs(bool shouldMultiplyCadence = true, uint multiplier = 2)
        {
            return workoutStepMesg =>
            {
                if (shouldMultiplyCadence)
                {
                    workoutStepMesg.MultiplyCadence(multiplier);
                }

                return workoutStepMesg;
            };
        }

        public static Func<SportMesg, SportMesg> EditSportMesgs()
        {
            return sportMesg =>
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
            };
        }

        public static Func<RecordMesg, RecordMesg> EditRecordMesgs(bool shouldMultiplyCadence = true, uint multiplier = 2)
        {
            return recordMesg =>
            {
                if (shouldMultiplyCadence)
                {
                    recordMesg.MultiplyCadence(multiplier);
                }

                recordMesg.AddStrokeDistance();

                return recordMesg;
            };
        }

        public static Func<SessionMesg, SessionMesg> EditSessionMesgs(IEnumerable<RecordMesg> recordMesgs, bool shouldMultiplyCadence = true, uint multiplier = 2)
        {
            return sessionMesg =>
            {
                if (sessionMesg.GetSport() != Sport.Rowing)
                {
                    sessionMesg.SetSport(Sport.Rowing);
                    sessionMesg.SetSubSport(
                        sessionMesg.GetSubSport() == SubSport.IndoorCycling ?
                        SubSport.IndoorRowing : SubSport.Generic
                    );
                    sessionMesg.SetFieldValue(110, Encoding.UTF8.GetBytes("Row"));
                }
                sessionMesg.AddStrokeDistance(recordMesgs);

                if (shouldMultiplyCadence)
                {
                    sessionMesg.MultiplyCadence(multiplier);
                }

                return sessionMesg;
            };
        }

        public static Func<LapMesg, LapMesg> EditLapMesgs(IEnumerable<RecordMesg> recordMesgs, bool shouldMultiplyCadence = true, uint multiplier = 2)
        {
            return lapMesg =>
            {
                if (lapMesg.GetSport() != Sport.Rowing)
                {
                    lapMesg.SetSport(Sport.Rowing);
                    lapMesg.SetSubSport(
                        lapMesg.GetSubSport() == SubSport.IndoorCycling ?
                        SubSport.IndoorRowing : SubSport.Generic
                    );
                }
                lapMesg.AddStrokeDistance(recordMesgs);

                if (shouldMultiplyCadence)
                {
                    lapMesg.MultiplyCadence(multiplier);
                }

                return lapMesg;
            };
        }

        public static LapMesg MultiplyCadence(this LapMesg lap, uint multiplier = 2)
        {
            if (lap.GetAvgCadence()is byte avgCadence)
                lap.SetAvgCadence((byte)(avgCadence * multiplier));
            if (lap.GetMaxCadence()is byte maxCadence)
                lap.SetMaxCadence((byte)(maxCadence * multiplier));
            if (lap.GetAvgFractionalCadence()is float avgFractionalCadence)
                lap.SetAvgFractionalCadence(avgFractionalCadence * multiplier);
            if (lap.GetMaxFractionalCadence()is float maxFractionalCadence)
                lap.SetMaxFractionalCadence(maxFractionalCadence * multiplier);
            if (lap.GetTotalCycles()is uint totalCycles)
                lap.SetTotalCycles(totalCycles * multiplier);
            if (lap.GetTotalFractionalCycles()is float totalFractionalCycles)
                lap.SetTotalFractionalCycles(totalFractionalCycles * multiplier);

            return lap;
        }

        public static SessionMesg MultiplyCadence(this SessionMesg session, uint multiplier = 2)
        {
            if (session.GetAvgCadence()is byte avgCadence)
                session.SetAvgCadence((byte)(avgCadence * multiplier));
            if (session.GetMaxCadence()is byte maxCadence)
                session.SetMaxCadence((byte)(maxCadence * multiplier));
            if (session.GetAvgFractionalCadence()is float avgFractionalCadence)
                session.SetAvgFractionalCadence(avgFractionalCadence * multiplier);
            if (session.GetMaxFractionalCadence()is float maxFractionalCadence)
                session.SetMaxFractionalCadence(maxFractionalCadence * multiplier);
            if (session.GetTotalCycles()is uint totalCycles)
                session.SetTotalCycles(totalCycles * multiplier);
            if (session.GetTotalFractionalCycles()is float totalFractionalCycles)
                session.SetTotalFractionalCycles(totalFractionalCycles * multiplier);

            return session;
        }

        public static RecordMesg MultiplyCadence(this RecordMesg record, uint multiplier = 2)
        {
            if (record.GetCadence()is byte cadence)
                record.SetCadence((byte)(cadence * multiplier));
            if (record.GetFractionalCadence()is float fractionalCadence)
                record.SetFractionalCadence(fractionalCadence * multiplier);
            if (record.GetTotalCycles()is uint totalCycles)
                record.SetTotalCycles(totalCycles * multiplier);
            if (record.GetCycles()is byte cycles)
                record.SetCycles((byte)(cycles * multiplier));
            if (record.GetCadence256()is float cadence256)
                record.SetCadence256(cadence256 * multiplier);

            return record;
        }

        public static WorkoutStepMesg MultiplyCadence(this WorkoutStepMesg wrkStep, uint multiplier = 2)
        {
            if (wrkStep.GetTargetType() == WktStepTarget.Cadence)
            {
                var targetLow = wrkStep.GetCustomTargetCadenceLow();
                var targetHigh = wrkStep.GetCustomTargetCadenceHigh();
                wrkStep.SetCustomTargetCadenceLow(targetLow * multiplier);
                wrkStep.SetCustomTargetCadenceHigh(targetHigh * multiplier);
            }

            return wrkStep;
        }

        public static LapMesg AddStrokeDistance(this LapMesg lap, IEnumerable<RecordMesg> recordMesgs)
        {
            if (lap.GetAvgCadence()is not null)
            {
                var recordsWithStrokeDist = recordMesgs.Where(
                    record =>
                    (record.GetStrokeDistance()is not null and > 0 and < 65535) &&
                    record.GetTimestamp().GetDateTime() >= lap.GetStartTime().GetDateTime() &&
                    record.GetTimestamp().GetDateTime() < lap.GetTimestamp().GetDateTime()
                );
                var recordLength = recordsWithStrokeDist.Count();

                if (recordLength > 0)
                {
                    var avgStrokeDistance = recordsWithStrokeDist.Aggregate(0f, (x, y) =>
                        x + (y.GetStrokeDistance() ?? 0)) / recordLength;

                    lap.SetAvgStrokeDistance(avgStrokeDistance);
                }
            }

            return lap;
        }

        public static SessionMesg AddStrokeDistance(this SessionMesg session, IEnumerable<RecordMesg> recordMesgs)
        {
            if (session.GetAvgCadence()is not null)
            {
                var recordsWithStrokeDist = recordMesgs.Where(record =>
                    record.GetStrokeDistance()is not null and > 0 and < 65535);

                var recordLength = recordsWithStrokeDist.Count();
                if (recordLength > 0)
                {
                    var avgStrokeDistance = recordsWithStrokeDist.Aggregate(0f, (x, y) =>
                        x + (y.GetStrokeDistance() ?? 0)) / recordLength;

                    session.SetAvgStrokeDistance(avgStrokeDistance);
                }
            }

            return session;
        }

        public static RecordMesg AddStrokeDistance(this RecordMesg record)
        {
            record.RemoveField(record.Fields.FirstOrDefault(field => field.Num == 87));

            var cadence = record.GetCadence();
            var speed = record.GetSpeed() * 60;
            var distPerStroke = speed / cadence;

            if (distPerStroke is not null && distPerStroke > 0 && !float.IsInfinity(distPerStroke.Value) && !float.IsNaN(distPerStroke.Value))
            {
                record.SetStrokeDistance(distPerStroke);
            }

            return record;
        }
    }
}