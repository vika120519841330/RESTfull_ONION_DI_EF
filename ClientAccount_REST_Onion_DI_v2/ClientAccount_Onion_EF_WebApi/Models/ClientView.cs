using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAccount_Onion_EF_WebApi.Models
{
    public class ClientView
    {
        public int? ClientId;
        public string ClientTitle { get; set; }
        public bool ClientMarkJuridical { get; set; }
        public string ClientTaxpayNum { get; set; }
        // все р/с, принадлежащие клиенту
        public IList<AccountView> AccountsOfClient{ get; set; }
    }
}