using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class Login
    {
        public int PersonId { get; set; }
        public string Username { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public string Salt { get; set; } = null!;

        public virtual Person Person { get; set; } = null!;
    }
}
