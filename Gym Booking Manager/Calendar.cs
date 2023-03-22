// Placeholder name for file until we get a more complete grasp of classes in the system
// and the organisation thereof.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Calendar
    {
        private readonly List<Reservation> reservations;
        

        public Calendar()
        {
            this.reservations = new List<Reservation>();
        }

        public bool isAvailable(DateTime start, DateTime end)
        {
            // Check if there is a reservation that overlaps with the given start and end times.
            // If there is, return false.
            // If there isn't, return true.
            // This is a placeholder method for now. It will be replaced with a more efficient method later.
            foreach (Reservation reservation in this.reservations)
            {
                if (reservation.timeSlot.Start < end && reservation.timeSlot.End > start)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddReservation(Reservation reservation)
        {
            this.reservations.Add(reservation);
        }
        // Leaving this method for now. Idea being it may be useful to get entries within a "start" and "end" time/date range.
        // Need parameters if so.
        // Or maybe we'll come up with a better solution elsewhere.
        public List<Reservation> GetSlice()
        {
            return this.reservations; // Promise to implement or delete this later, please just compile.
        }
    }
}