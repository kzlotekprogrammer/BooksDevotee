using SDK.PayU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SDK.PayU
{
    public class CreateOrderResult
    {
        public HttpResponseMessage ResponseMessage;
        public OrderCreateResponseDTO ResponseDTO;
    }
}
