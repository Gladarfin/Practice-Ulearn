using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
    public class StatisticsTask
    {
        public static double GetMedianTimePerSlide(List<VisitRecord> visits, SlideType slideType)
        {
            return visits
                .OrderBy(visit => visit.DateTime)
                .GroupBy(visit => visit.UserId)
                .Select(group => group.Bigrams())
                .SelectMany(group => group.Where(bigram => bigram.Item1.SlideType == slideType))
                .Select(timeInterval =>
                        (timeInterval.Item2.DateTime - timeInterval.Item1.DateTime).TotalMinutes)
                .Where(time => (time >= 1 && time <= 120))
                .DefaultIfEmpty()
                .Median();
        }
    }
}