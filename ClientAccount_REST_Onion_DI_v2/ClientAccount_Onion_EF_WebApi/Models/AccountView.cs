using System;

namespace ClientAccount_Onion_EF_WebApi.Models
{
    public class AccountView
    {
        public int? AccountId { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public int? ClientClientId { get; set; }
        // владелец р/с
        //public ClientView ClientOfAccount { get; set; }
    }
}