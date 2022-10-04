using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class Service
    {
        public int PersonId { get; set; }
        public string Service1 { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual Person Person { get; set; } = null!;
    }
}
