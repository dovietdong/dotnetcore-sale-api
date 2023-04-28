using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
    }
}
