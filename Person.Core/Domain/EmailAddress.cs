using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Person.Core.Domain
{
    public class EmailAddress: Entity
    {
        public int EmailAddressPromotion { get; set; }
        public string Email {  get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
