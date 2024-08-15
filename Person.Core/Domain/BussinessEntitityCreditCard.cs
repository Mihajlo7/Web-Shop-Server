using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Person.Core.Domain
{
    public class BussinessEntitityCreditCard: Entity
    {
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        public Guid CreditCardId { get; set; }
        public virtual CreditCard CreditCard { get; set;}
    }
}


