using System;

namespace CinePDV.Payments
{
    public class PaymentInformation
    {
        public Guid CardNumbers { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime ValidThrough { get; set; }

        public Guid BasketId { get; set; }
    }
}
