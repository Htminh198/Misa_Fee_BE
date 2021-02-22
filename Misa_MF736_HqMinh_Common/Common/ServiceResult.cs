using System;
using System.Collections.Generic;
using System.Text;

namespace Misa_MF736_HqMinh_Common.Common
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Success = true;
        }
        /// <summary>
        /// Trạng thái Service ( True : Thành công ; Failse : Thất bại)
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Data : Dữ liệu trả về
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public object Data { get; set; }
        public string MISACode { get; set; }
    }
}
