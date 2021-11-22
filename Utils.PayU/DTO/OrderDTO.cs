using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.PayU.DTO
{
    public class OrderDTO
    {
        public string orderId { get; set; }
        public string extOrderId { get; set; }
        public DateTime orderCreateDate { get; set; }
        public string notifyUrl { get; set; }
        public string customerIp { get; set; }
        public int merchantPosId { get; set; }
        public DateTime validityTime { get; set; }
        public string description { get; set; }
        public string additionalDescription { get; set; }
        public string currencyCode { get; set; }
        public int totalAmount { get; set; }
        public string status { get; set; }
        BuyerDTO buyer { get; set; }
        List<ProductDTO> products { get; set; }
    }
}
