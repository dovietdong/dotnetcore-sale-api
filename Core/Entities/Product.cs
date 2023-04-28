using Core.SaleAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        [NotEmpty]
        public Guid ProductId { get; set; }
        [NotEmpty]
        public string? ProductCode { get; set; }
        [NotEmpty]
        public string? ProductName { get; set; }
        [NotEmpty]
        public long? ProductPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
