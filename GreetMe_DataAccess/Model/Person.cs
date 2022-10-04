using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public int? WorkPhoneNumber { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Login? Login { get; set; }
        public virtual Service? Service { get; set; }
    }
}
