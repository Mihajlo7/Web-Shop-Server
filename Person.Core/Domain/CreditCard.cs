using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Person.Core.Domain
{
    public class CreditCard : Entity
    {
        public string Type { get; set; }
        public string Number { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }

        public Guid BussinessEntityCreditCardId { get; set; }
        public virtual BussinessEntitityCreditCard BussinessEntitityCreditCard { get; set; }
    }
}
