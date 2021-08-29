using System;

namespace CinePDV.Gateway.Models
{
    public class PaymentInformationDto
    {
        public Guid CardNumbers { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime ValidThrough { get; set; }

        public Guid BasketId { get; set; }
    }
}
