using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.PayU.DTO
{
    public class AuthorizeResponseDTO
    {
        //ToDo pola przy błędzie
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string grant_type { get; set; }
    }
}
