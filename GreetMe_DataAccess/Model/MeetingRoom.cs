using System;
using System.Collections.Generic;

namespace GreetMe_DataAccess.Model
{
    public partial class MeetingRoom
    {
        public MeetingRoom()
        {
            Meetings = new HashSet<Meeting>();
        }

        public int Id { get; set; }
        public string RoomName { get; set; } = null!;
        public string Decription { get; set; } = null!;
        public int Capacity { get; set; }
        public int CompanyAddressId { get; set; }

        public virtual CompanyAddress CompanyAddress { get; set; } = null!;
        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
