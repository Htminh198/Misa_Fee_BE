using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_DataLayer.DbContext
{
    public class DbContext<T> : IDbContext<T>
    {
        /// <summary>
        /// Khởi tạo chuỗi kết nối connectString
        /// </summary>
        protected string connectString;
        protected IDbConnection _db;
        public DbContext()
        {
            //connectString = "User Id=dev;host=47.241.69.179;Database=Misa.MF736_HqMinh;port=3306;password=12345678;character Set=utf8";
            connectString = "User Id=dev;host=47.241.69.179;Database=MISA.FeeManagement_MF736_HqMinh;port=3306;password=12345678;character Set=utf8";
            _db = new MySqlConnection(connectString);
        }
        /// <summary>
        /// Check trùng tên
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> CheckNameExitInsert(string name)
        {
            var tableName = typeof(T).Name;
            var sel = $"{tableName}Name";
            var sql = $"SELECT {sel} FROM {tableName} WHERE LOWER({tableName}.{sel}) = LOWER('{name}')";
            var rs = _db.Query<string>(sql, commandType: CommandType.Text).FirstOrDefault();
            if (rs != null)
            {
                return false;
            }
            return true;
        }
        public virtual async Task<bool> CheckNameExitUpdate(string name, int id)
        {
            var tableName = typeof(T).Name;
            var sel = $"{tableName}Name";
            var sql = $"SELECT {sel} FROM {tableName} WHERE LOWER({tableName}.{sel}) = LOWER('{name}') AND {tableName}ID = {id}";
            var rs = _db.Query<string>(sql, commandType: CommandType.Text).FirstOrDefault();
            if (rs != null)
            {
                if (rs != name)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// Xóa bản ghi theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns>trả về 1 : xóa thành công ; 0 : xóa thất bại</returns>
        public virtual async Task<int> DeleteByID(int id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}ByID";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}ID", id);

            return _db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Lấy tất cả dữ liệu trong database
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <returns>object</returns>
        public virtual async Task<IEnumerable<T>> GetAllData()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}";
            var rs = _db.Query<T>(storeName, commandType: CommandType.StoredProcedure).ToList();
            return rs;
        }
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns>object</returns>
        public virtual async Task<T> GetAllDataByID(int id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ByID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}ID", id);
            var rs = _db.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return rs;
        }
        /// <summary>
        /// Thêm mới dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>trả về 1 : thành công ; 0 : thất bại</returns>
        public virtual async Task<int> Insert(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Insert{tableName}";

             var porperties = typeof(T).GetProperties();

            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var property in porperties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            return _db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Chỉnh sửa dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>trả về 1 : chỉnh sửa thành công ; 0 : chỉnh sửa thất bại</returns>
        public virtual async Task<int> Update(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}ByID";

            var porperties = typeof(T).GetProperties();

            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var property in porperties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            return _db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        public virtual async Task<IEnumerable<T>> GetAllDataOrderBy()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}OrderBy";
            var rs = _db.Query<T>(storeName, commandType: CommandType.StoredProcedure).ToList();
            return rs;
        }
    }
}
