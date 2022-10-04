using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class Employee
    {
        public int PersonId { get; set; }
        public string? Nickname { get; set; }
        public string Role { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime HiringDate { get; set; }
        public int CompanyAddressId { get; set; }

        public virtual CompanyAddress CompanyAddress { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
    }
}
