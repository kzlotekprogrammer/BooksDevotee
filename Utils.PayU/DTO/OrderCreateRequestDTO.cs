using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDK.PayU.DTO
{
    public class OrderCreateRequestDTO
    {
        public string extOrderId { get; set; }
        public string notifyUrl { get; set; }
        public string customerIp { get; set; }
        public int merchantPosId { get; set; }
        public int? validityTime { get; set; }
        public string description { get; set; }
        public string additionalDescription { get; set; }
        public string visibleDescription { get; set; }
        public string currencyCode { get; set; }
        public int totalAmount { get; set; }
        public string cardOnFile { get; set; }
        public string recurring { get; set; }
        public string continueUrl { get; set; }
        public BuyerDTO buyer { get; set; }
        public List<ProductDTO> products { get; set; }
        public PayMethodDTO payMethods { get; set; }
        public McpDataDTO mcpData { get; set; }
        public ThreeDsAuthenticationDTO threeDsAuthentication { get; set; }
        public CreditDTO credit { get; set; }
    }
}
