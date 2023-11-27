using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Image : BaseDomainModel
    {
        [Column(TypeName = "text")]
        public string? Url { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "text")]
        public string? PublicCode { get; set; }
        public virtual Product? Product { get; set; }
    }
}
