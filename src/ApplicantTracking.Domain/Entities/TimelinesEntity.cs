using System;
using ApplicantTracking.Domain.Enumerators;

namespace ApplicantTracking.Domain.Entities
{
    public class TimelinesEntity
    {
        public int IdTimeline { get; set; }
        public TimelineTypes IdTimelineType { get; set; }
        public int IdAggregateRoot { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
