using System;
using System.Collections.Generic;

namespace SDK.PayU.DTO
{
    public class NotificationDTO
    {
        public OrderDTO order { get; set; }
        public DateTime localReceiptDateTime { get; set; }
        public List<PropertiesDTO> properties { get; set; }
    }
}
