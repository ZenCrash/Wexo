using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class MeetingsPerson
    {
        public int MeetingId { get; set; }
        public int PersonId { get; set; }

        public virtual Meeting Meeting { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
    }
}
