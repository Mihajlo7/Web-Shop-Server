using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Person.Core.Domain
{
public class Address : Entity
{
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set;}
    public string City { get; set; }
    public string PostalCode { get; set; }

    public virtual ICollection<BusinessEntityAdress> Adresses { get; set; }

    public Guid? CountryId { get; set; }
    public virtual Country? Country { get; set; }
}
}


