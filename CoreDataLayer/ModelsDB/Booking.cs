using System;
using System.Collections.Generic;

namespace CoreDataLayer.ModelsDB
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? Cid { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? RoomId { get; set; }

        public Customers C { get; set; }
        public RoomType Room { get; set; }
    }
}
