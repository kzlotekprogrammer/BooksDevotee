using System;

namespace SDK.PayU.DTO
{
    public class ProductDTO
    {
        public string name { get; set; }
        public int unitPrice { get; set; }
        public int quantity { get; set; }
        public bool? @virtual { get; set; }
        public DateTime? listingDate { get; set; }
    }
}