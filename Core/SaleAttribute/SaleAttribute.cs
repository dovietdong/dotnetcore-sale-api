using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SaleAttribute
{
    /// <summary>
    /// trường không để trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmpty : Attribute
    {
    }
}
