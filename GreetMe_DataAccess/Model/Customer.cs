using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class Customer
    {
        public int PersonId { get; set; }
        public string? CompanyName { get; set; }
        public string Email { get; set; } = null!;

        public virtual Person Person { get; set; } = null!;
    }
}
