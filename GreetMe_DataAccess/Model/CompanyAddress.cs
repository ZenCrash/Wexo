using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class CompanyAddress
    {
        public CompanyAddress()
        {
            Employees = new HashSet<Employee>();
            MeetingRooms = new HashSet<MeetingRoom>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public int StreetNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<MeetingRoom> MeetingRooms { get; set; }
    }
}
