using System;
using System.Collections.Generic;
using System.Linq;

using Dynastream.Fit;

namespace FitFileEditor.ConsoleApp
{
    public static class EditorExtensions
    {
        public static IEnumerable<LapMesg> MultiplyCadence(this IEnumerable<LapMesg> laps, uint multiplier = 2)
        {
            return laps.Select(lap =>
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
            });
        }

        public static IEnumerable<SessionMesg> MultiplyCadence(this IEnumerable<SessionMesg> sessions, uint multiplier = 2)
        {
            return sessions.Select(session =>
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
            });
        }

        public static IEnumerable<RecordMesg> MultiplyCadence(this IEnumerable<RecordMesg> records, uint multiplier = 2)
        {
            return records.Select(record =>
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
                    record.SetCadence256(cadence256 * 2);

                return record;
            });
        }

        public static IEnumerable<LapMesg> AddStrokeDistance(this IEnumerable<LapMesg> laps, System.DateTime initialDateTime, IEnumerable<RecordMesg> recordMesgs)
        {
            return laps.Select(lap =>
            {
                if (lap.GetAvgCadence()is not null)
                {
                    var recordsWithStrokeDist = recordMesgs.Where(
                        record =>
                        (record.GetStrokeDistance()is not null and > 0 and < 65535) &&
                        record.GetTimestamp().GetDateTime() > initialDateTime &&
                        record.GetTimestamp().GetDateTime() <= lap.GetTimestamp().GetDateTime()
                    );
                    var recordLength = recordsWithStrokeDist.Count();

                    if (recordLength > 0)
                    {
                        var avgStrokeDistance = recordsWithStrokeDist.Aggregate(0f, (x, y) =>
                            x + (y.GetStrokeDistance() ?? 0)) / recordLength;

                        lap.SetAvgStrokeDistance(avgStrokeDistance);
                    }
                    Console.WriteLine("Lap avgStrokeDist: {0}", lap.GetAvgStrokeDistance());
                    initialDateTime = lap.GetTimestamp().GetDateTime();
                }

                return lap;
            });
        }

        public static IEnumerable<SessionMesg> AddStrokeDistance(this IEnumerable<SessionMesg> sessions, IEnumerable<RecordMesg> recordMesgs)
        {
            return sessions.Select(session =>
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
                Console.WriteLine("Session avgStrokeDist: {0}", session.GetAvgStrokeDistance());

                return session;
            });
        }

        public static IEnumerable<RecordMesg> AddStrokeDistance(this IEnumerable<RecordMesg> records)
        {
            return records.Select(record =>
            {

                record.RemoveField(record.Fields.FirstOrDefault(field => field.Num == 87));

                var cadence = record.GetCadence();
                var speed = record.GetSpeed() * 60;
                var distPerStroke = speed / cadence;

                Console.WriteLine("Original stroke: {0}", record.GetStrokeDistance());

                if (distPerStroke is not null && distPerStroke > 0 && !float.IsInfinity(distPerStroke.Value) && !float.IsNaN(distPerStroke.Value))
                {
                    Console.WriteLine("Setting stroke: {0}", distPerStroke);

                    record.SetStrokeDistance(distPerStroke);
                }
                Console.WriteLine("Stroke is {0}", record.GetFieldValue(87));

                return record;
            });
        }
    }
}