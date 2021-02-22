using Misa_MF736_HqMinh_Common.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Service.BaseService
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <returns>Object</returns>
        Task<ServiceResult> GetData();
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Task<ServiceResult> GetDataByID(int id);
        /// <summary>
        /// Xóa dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Trả về 1 : Xóa thành công ; Trả về 0 : Xóa thất bại</returns>
        Task<ServiceResult> DeleteDataByID(int id);
        /// <summary>
        /// Thêm mới dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về 1 : Thêm mới thành công ; Trả về 0 : Thêm mới thất bại</returns>
        Task<ServiceResult> Insert(T entity);
        /// <summary>
        /// Chỉnh sửa dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về 1 : Chỉnh sửa thành công ; Trả về 0 : Chỉnh sửa thất bại</returns>
        Task<ServiceResult> Update(T entity);
    }
}
