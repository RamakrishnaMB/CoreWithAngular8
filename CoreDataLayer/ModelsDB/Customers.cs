using System;
using System.Collections.Generic;

namespace CoreDataLayer.ModelsDB
{
    public partial class Customers
    {
        public Customers()
        {
            Booking = new HashSet<Booking>();
        }

        public int Cid { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
