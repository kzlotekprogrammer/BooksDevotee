using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDK.PayU.DTO
{
    public class OrderCreateResponseDTO
    {
        public string redirectUri { get; set; }
        public string orderId { get; set; }
        public string extOrderId { get; set; }
        public StatusDTO status { get; set; }
    }
}
