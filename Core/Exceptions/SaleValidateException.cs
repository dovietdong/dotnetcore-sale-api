using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class SaleValidateException : Exception
    {
        /// <summary>
        /// thông báo lỗi
        /// </summary>
        string? messageValidate = null;

        /// <summary>
        /// hàm khởi tạo 1 đối tượng thông báo lỗi
        /// </summary>
        /// <param name="message"></param>
        public SaleValidateException(string? message)
        {
            this.messageValidate = message;
        }

        /// <summary>
        /// ghi đè phương thức thông báo message của Exception
        /// </summary>
        public override string Message
        {
            get { return messageValidate; }
        }
    }
}
