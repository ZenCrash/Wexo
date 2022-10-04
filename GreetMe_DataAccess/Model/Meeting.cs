using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class Meeting
    {
        public int Id { get; set; }
        public string MeetingCode { get; set; } = null!;
        public string MeetingTitle { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Status { get; set; } = null!;
        public string? Decription { get; set; }
        public string? PreparationDecription { get; set; }
        public int? MeetingRoomId { get; set; }

        public virtual MeetingRoom? MeetingRoom { get; set; }
    }
}
