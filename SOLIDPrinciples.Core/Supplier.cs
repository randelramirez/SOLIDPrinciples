using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples.Core
{
    public class Supplier : BusinessPartner
    {
        public ICollection<Product> Products { get; set; }
    }
}
