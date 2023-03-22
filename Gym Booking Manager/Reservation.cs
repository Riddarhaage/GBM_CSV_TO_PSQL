using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Gym_Booking_Manager.LocalStorage;

namespace Gym_Booking_Manager
{
    internal class Reservation
    {
        private readonly IReservingEntity owner;
        private readonly object email;

        public TimeSlot timeSlot { get; set; }
        private Category category;
        private int quantity;

        public Reservation(Category category, IReservingEntity owner, TimeSlot time)
        {
            this.owner = owner;
            this.timeSlot = time;
            this.category = category;
            Console.WriteLine();
            Console.WriteLine($"Congrats, you just did a reservation!");
            Console.WriteLine();
        }
        public Reservation(Category category, int quantity ,IReservingEntity owner, TimeSlot time)
        {
            this.owner = owner;
            this.timeSlot = time;
            this.category = category;
            this.quantity = quantity;
            Console.WriteLine($"Congrats, you just did a reservation!");
        }
        public enum Category
        {
            Large_Equipment,
            Sports_Equipment,
            Space,
            Coach,
        }

        public override string ToString()
        {
            return $"==============================\nCategory:{category}\nreservation for:{owner}\n{timeSlot}\n==============================\n";
        }
    }
}