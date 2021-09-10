using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dynastream.Fit;

namespace FitFileEditor.ConsoleApp
{
    public static class EditorExtensions
    {
        public static FitFileParser Edit(this FitFileParser fitFileParser, bool shouldMultiplyCadence = true, uint multiplier = 2)
        {
            Console.WriteLine($"Applying changes to FIT data (shouldMultiply: {shouldMultiplyCadence}, multiplier: {multiplier})");

            fitFileParser.Edit(EditWorkoutMesgs(shouldMultiplyCadence));
            fitFileParser.Edit(EditWorkoutStepMesgs(shouldMultiplyCadence, multiplier));
            fitFileParser.Edit(EditSportMesgs());
            fitFileParser.Edit(EditRecordMesgs(shouldMultiplyCadence, multiplier));
            fitFileParser.Edit(EditSessionMesgs(fitFileParser.RecordMesgs, shouldMultiplyCadence, multiplier));
            fitFileParser.Edit(EditLapMesgs(fitFileParser.RecordMesgs, shouldMultiplyCadence, multiplier));

            return fitFileParser;
        }

        public static Func<WorkoutMesg, WorkoutMesg> EditWorkoutMesgs(bool shouldMultiplyCadence = true)
        {
            return workMesg =>
            {
                workMesg.SetSport(Sport.Rowing);
                workMesg.SetSubSport(SubSport.Generic);

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
                sportMesg.SetSport(Sport.Rowing);
                sportMesg.SetSubSport(SubSport.Generic);
                sportMesg.SetName("Row");
                sportMesg.SetFieldValue(4, 29);

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
                sessionMesg.SetSport(Sport.Rowing);
                sessionMesg.SetSubSport(SubSport.Generic);
                sessionMesg.SetFieldValue(110, Encoding.UTF8.GetBytes("Row"));
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
                lapMesg.SetSport(Sport.Rowing);
                lapMesg.SetSubSport(SubSport.Generic);
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
            if (record.GetCycles()is byte totalCycles)
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
                    record.GetTimestamp().GetDateTime() > lap.GetStartTime().GetDateTime() &&
                    record.GetTimestamp().GetDateTime() <= lap.GetTimestamp().GetDateTime()
                );
                var recordLength = recordsWithStrokeDist.Count();

                if (recordLength > 0)
                {
                    var avgStrokeDistance = recordsWithStrokeDist.Aggregate(0f, (x, y) =>
                        x + (y.GetStrokeDistance() ?? 0)) / recordLength;

                    lap.SetAvgStrokeDistance(avgStrokeDistance);
                }
                // Console.WriteLine("Lap avgStrokeDist: {0}", lap.GetAvgStrokeDistance());
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
            // Console.WriteLine("Session avgStrokeDist: {0}", session.GetAvgStrokeDistance());

            return session;
        }

        public static RecordMesg AddStrokeDistance(this RecordMesg record)
        {
            record.RemoveField(record.Fields.FirstOrDefault(field => field.Num == 87));

            var cadence = record.GetCadence();
            var speed = record.GetSpeed() * 60;
            var distPerStroke = speed / cadence;

            // Console.WriteLine("Original stroke: {0}", record.GetStrokeDistance());

            if (distPerStroke is not null && distPerStroke > 0 && !float.IsInfinity(distPerStroke.Value) && !float.IsNaN(distPerStroke.Value))
            {
                // Console.WriteLine("Setting stroke: {0}", distPerStroke);

                record.SetStrokeDistance(distPerStroke);
            }
            // Console.WriteLine("Stroke is {0}", record.GetFieldValue(87));

            return record;
        }
    }
}