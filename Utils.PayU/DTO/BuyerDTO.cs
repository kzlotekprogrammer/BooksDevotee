namespace SDK.PayU.DTO
{
    public class BuyerDTO
    {
        public int? customerId { get; set; }
        public int? extCustomerId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nin { get; set; }
        public string language { get; set; }
        //ToDo
        //public string buyer.delivery { get; set; }
    }
}