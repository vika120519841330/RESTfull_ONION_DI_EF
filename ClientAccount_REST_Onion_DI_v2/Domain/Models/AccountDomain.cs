using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AccountDomain
    {
        // Имя первичного ключа сущности - Идентификатор р/с
        public int? AccountId { get; set; }
        // Номер р/с
        public string AccountNumber { get; set; }
        // Баланс р/с
        public double AccountBalance { get; set; }
        // Внешний ключ - ID владельца р/с
        //[ForeignKey("ClientClientId")]
        public int? ClientClientId { get; set; }
        // Навигационное свойство - Клиент-владелец р/с
        // ClientDomain ClientOfAccount { get; set; }
    }
}