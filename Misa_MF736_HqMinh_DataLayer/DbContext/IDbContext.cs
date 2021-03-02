using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_DataLayer.DbContext
{
    public interface IDbContext<T>
    {
        /// <summary>
        /// Lấy tết cả dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <returns>Object</returns>
        Task<IEnumerable<T>> GetAllData();
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Task<T> GetAllDataByID(int id);
        /// <summary>
        /// Xóa dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Trả về 1 : Xóa thành công ; Trả về 0 : Xóa thất bại</returns>
        Task<int> DeleteByID(int id);
        /// <summary>
        /// Thêm mới dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về 1 : Thêm mới thành công ; Trả về 0 : Thêm mới thất bại</returns>
        Task<int> Insert(T entity);
        /// <summary>
        /// Chỉnh sửa dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về 1 : Chỉnh sửa thành công ; Trả về 0 : Chỉnh sửa thất bại</returns>
        Task<int> Update(T entity);
        /// <summary>
        /// Check trùng tên update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> CheckNameExitUpdate(string name, int id);
        /// <summary>
        /// Check trùng tên thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> CheckNameExitInsert(string name);

        Task<IEnumerable<T>> GetAllDataOrderBy();
        Task<bool> Login(string username, string password);
    }
}
