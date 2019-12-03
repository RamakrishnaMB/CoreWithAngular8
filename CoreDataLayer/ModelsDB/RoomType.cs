using System;
using System.Collections.Generic;

namespace CoreDataLayer.ModelsDB
{
    public partial class RoomType
    {
        public RoomType()
        {
            Booking = new HashSet<Booking>();
        }

        public int RoomTypeId { get; set; }
        public string RoomType1 { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
