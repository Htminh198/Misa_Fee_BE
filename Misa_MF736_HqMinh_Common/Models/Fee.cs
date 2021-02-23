using System;
using System.Collections.Generic;
using System.Text;

namespace Misa_MF736_HqMinh_Common.Models
{
    public class Fee
    {
        public int FeeID { get; set; }
        /// <summary>
        /// Tên phí
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public string FeeName { get; set; }
        /// <summary>
        /// ID tên nhóm phí
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public int? FeeGroupID { get; set; }
        /// <summary>
        /// Giá tiền
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Đơn vị
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public int? Unit { get; set; }
        /// <summary>
        /// Áp dụng đối tượng
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public string ApplyObject { get; set; }
        public int Property { get; set; }
        /// <summary>
        /// Khoảng thời gian - thời kì
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public int? Period { get; set; }
        public string PeriodName
        {
            get
            {
                switch (Period)
                {
                    case 1: return "Tháng";
                    case 2: return "Quý";
                    case 3: return "Học kì";
                    case 4: return "Năm học";
                    default: return "Không xác định";
                }
            }
        }
        /// <summary>
        /// Đang áp dụng loại bỏ
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public bool IsApplyRemisson { get; set; }
        /// <summary>
        /// Là yêu cầu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public bool IsRequire { get; set; }
        /// <summary>
        /// Cho phép Tạo hóa đơn
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public bool AllowCreateInvoice { get; set; }
        /// <summary>
        /// Cho phép tạo hóa đơn
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public bool AllowCreateReceipt { get; set; }
        /// <summary>
        /// trạng thái đang hoạt động
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Nội bộ
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public bool IsInternal { get; set; }
        /// <summary>
        /// Là hệ thống
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public bool IsSystem { get; set; }
        /// <summary>
        /// ngày tạo ra
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
        public string TRIAL871 { get; set; }
        #region Other
        /// <summary>
        /// Tên nhóm phí
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        public string FeeGroupName
        {
            get
            {
                switch (FeeGroupID)
                {
                    case 0: return "";
                    case 1: return "Học phí";
                    case 2: return "Bán trú";
                    case 3: return "Quỹ";
                    case 4: return "Đồng phục";
                    default: return "Không xác định";
                }
            }
        }
        #endregion
    }
}
