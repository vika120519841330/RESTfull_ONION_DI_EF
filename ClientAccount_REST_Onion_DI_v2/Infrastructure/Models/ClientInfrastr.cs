﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ClientInfrastr
    {
        public int? ClientId { get; set; }

        public string ClientTitle { get; set; }

        public bool ClientMarkJuridical { get; set; }

        public string ClientTaxpayNum { get; set; }

        // все р/с, принадлежащие клиенту
        public IList<AccountInfrastr> AccountsOfClient { get; set; }
    }
}
