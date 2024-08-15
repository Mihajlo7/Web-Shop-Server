using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Core.Dto.Registration.Request
{
    public class CreditCardDTO
    {
        public string Type { get; set; }
        public string Number { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
    }
}
