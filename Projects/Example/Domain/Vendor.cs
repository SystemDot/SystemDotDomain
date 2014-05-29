using System;
using SystemDot.Domain.Aggregation;

namespace Domain
{
    public class Vendor : AggregateRoot
    {
        public Vendor()
        {
        }

        public Vendor(string id) : base(id)
        {
        }

        public void Activate(string name)
        {
            AddEvent(new VendorActivated { VendorId = Id, VendorName = name });
        }
    }
}