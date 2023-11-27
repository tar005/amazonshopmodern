using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Category :BaseDomainModel
    {
        [Column (TypeName ="NVARCHAR(100)")]
        public string? Nombre { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
