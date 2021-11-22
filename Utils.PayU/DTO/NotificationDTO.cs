using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.PayU.DTO
{
    public class NotificationDTO
    {
        public OrderDTO order { get; set; }
        public List<NotificationDTO> properties { get; set; }
    }
}
