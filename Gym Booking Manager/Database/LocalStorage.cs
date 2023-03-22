﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

// How to add a new dataset for new classes:
// 1. Add the private DbSet<T> attribute.
// 2. Add a private string attribute for the filepath that will be created and used for storage.
// 3. Initialize the DbSet in the LocalStorage() constructor.
// 4. Add a case to the switch-statement in the private GetDbSetReference() method.

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    // Local flat file scheme implementation.
    // Maybe we can make a different implementation, utilizing a proper database ín a later prototype?
    // We have attempted to hide this implementation from the main program,
    // and it would be fantastic if a Database implementation swap was seamless at the program level.
    // One can dream at least.
    internal partial class LocalStorage : IDatabase
    {

        public DbSet<Space> spaces;
        public DbSet<Customer> customer;
        public DbSet<Staff> staffs;
        public DbSet<Admin> admins;
        public DbSet<Service> service;
        public DbSet<Instructor> instructors;
        public DbSet<Equipment> equipments;
        // public DbSet<Equipment> gearscore; ?

        static private readonly char sep = Path.DirectorySeparatorChar;
        static private readonly string storage = $"GymDB{sep}storage";
        static private readonly string fpathSpace = $"{storage}{sep}space.csv";
        static private readonly string fpathCustomer = $"{storage}{sep}customer.csv";
        static private readonly string fpathStaff = $"{storage}{sep}staff.csv";
        static private readonly string fpathAdmin = $"{storage}{sep}admin.csv";
        static private readonly string fpathService = $"{storage}{sep}service.csv";
        static private readonly string fpathInstructor = $"{storage}{sep}instructor.csv";
        static private readonly string fpathEquipment = $"{storage}{sep}equipment.csv";
        // private filepath1, 2, 3 etc...

        public LocalStorage()
        {
            Directory.CreateDirectory(storage);
            this.spaces = new DbSet<Space>(fpathSpace);
            this.customer = new DbSet<Customer>(fpathCustomer);
            this.staffs = new DbSet<Staff>(fpathStaff);
            this.admins = new DbSet<Admin>(fpathAdmin);
            this.service = new DbSet<Service>(fpathService);
            this.instructors = new DbSet<Instructor>(fpathInstructor);
            this.equipments = new DbSet<Equipment>(fpathEquipment);
        }

        public bool Create<T>(T entity)
        {
            DbSet<T> dataset = (DbSet<T>)GetDbSetReference(typeof(T));
            return dataset.create(entity);
        }
        public List<T> Read<T>(String? field, String? value)
        {
            DbSet<T> dataset = (DbSet<T>)GetDbSetReference(typeof(T));
            return dataset.read(field, value);
        }
        public bool Update<T>(T newEntity, T oldEntity)
        {
            DbSet<T> dataset = (DbSet<T>)GetDbSetReference(typeof(T));
            return dataset.update(newEntity, oldEntity);
        }
        public bool Delete<T>(T entity)
        {
            DbSet<T> dataset = (DbSet<T>)GetDbSetReference(typeof(T));
            return dataset.delete(entity);
        }

        private object GetDbSetReference(Type type)
        {
            switch (type.Name)
            {
                case "Space":
                    return this.spaces;
                case "Customer":
                    return this.customer;
                case "Staff":
                    return this.staffs;
                case "Admin":
                    return this.admins;
                case "Service":
                    return this.service;
                case "Instructor":
                    return this.instructors;
                case "Equipment":
                    return this.equipments;
                // Add more cases for which DbSet<T> attributes exist within the class.
                default:
                    throw new ArgumentException("Dataset for the argument type does not exist.");
            }               
        }
    }
}
