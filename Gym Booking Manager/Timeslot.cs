using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    
    internal class TimeSlot : IComparable<TimeSlot>
    {
        private DateTime start;
        private DateTime end;

        public DateTime Start { get => start; }
        public DateTime End { get => end; }

        public TimeSlot(DateTime start)
        {
            this.start = start;
            this.end = start.AddHours(1);
        }
        public TimeSlot(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }
        override public string ToString()
        {
            return $"Time slot: {start.ToString("yy/MM/dd")} ({start.ToString("HH:mm")} - {end.ToString("HH:mm")})";
        }
        public int CompareTo(TimeSlot? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.start != other.start) return this.start.CompareTo(other.start);
            // When category is the same, sort on name.
            return this.end.CompareTo(other.end);
        }
    }
}
