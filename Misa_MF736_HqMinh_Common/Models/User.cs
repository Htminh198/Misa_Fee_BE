using System;
using System.Collections.Generic;
using System.Text;

namespace Misa_MF736_HqMinh_Common.Models
{
    public class User
    {
        /// <summary>
        /// ID người dùng
        /// Createby: MinnhHq - 02/03/2021
        /// </summary>
        public int UserID { get; set; }
        public string Account { get; set; }
        /// <summary>
        /// Mật khẩu tài khoản người dùng
        /// Createby: MinnhHq - 02/03/2021
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Tên đăng nhập tài khoản người dùng
        /// Createby: MinnhHq - 02/03/2021
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Ghi chú
        /// Createby: MinnhHq - 02/03/2021
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo tài khoản
        /// Createby: MinnhHq - 02/03/2021
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Ngày thay đổi thông tin tài khoản
        /// Createby: MinnhHq - 02/03/2021
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
