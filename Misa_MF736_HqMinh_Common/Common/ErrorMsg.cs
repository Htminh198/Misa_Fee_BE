using System;
using System.Collections.Generic;
using System.Text;

namespace Misa_MF736_HqMinh_Common.Common
{
    public class ErrorMsg
    {
        /// <summary>
        /// Thông báo cho Dev
        /// </summary>
        public string DevMsg { get; set; }
        /// <summary>
        /// Thông báo co người dùng
        /// </summary>
        //public List<string> UserMsg { get; set; } = new List<string>();
        public string UserMsg { get; set; }
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }
        public string MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}
