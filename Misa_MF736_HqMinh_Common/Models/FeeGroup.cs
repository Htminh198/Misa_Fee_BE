using System;
using System.Collections.Generic;
using System.Text;

namespace Misa_MF736_HqMinh_Common.Models
{
    public class FeeGroup
    {
        /// <summary>
        /// ID nhóm phí
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public int FeeGroupID { get; set; }
        /// <summary>
        /// Tên nhóm phí
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public string FeeGroupName { get; set; }
        /// <summary>
        /// Là hệ thống
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public bool IsSystem { get; set; }
        /// <summary>
        /// Sự miêu tả
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo ra
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Ngày sửa đổi
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Được tạo bởi
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Được sửa đổi bởi
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// DÙNG THỬ
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public string TRIAL881 { get; set; }
    }
}
