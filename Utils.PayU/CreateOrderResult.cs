using SDK.PayU.DTO;
using System.Net.Http;

namespace SDK.PayU
{
    public class CreateOrderResult
    {
        public HttpResponseMessage ResponseMessage;
        public OrderCreateResponseDTO ResponseDTO;
    }
}
