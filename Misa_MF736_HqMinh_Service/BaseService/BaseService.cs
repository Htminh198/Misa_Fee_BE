using Misa_MF736_HqMinh_Common.Common;
using Misa_MF736_HqMinh_DataLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Service.BaseService
{
    public class BaseService<T> : IBaseService<T>
    {
        IDbContext<T> _db;
        public BaseService(IDbContext<T> dbContext)
        {
            _db = dbContext;
        }
        /// <summary>
        /// Xóa dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<ServiceResult> DeleteDataByID(int id)
        {
            var service = new ServiceResult();
            service.Data = await _db.DeleteByID(id);
            return service;
        }
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> GetData()
        {
            var service = new ServiceResult();
            service.Data = await _db.GetAllData();
            return service;
        }
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> GetDataByID(int id)
        {
            var service = new ServiceResult();
            service.Data = await _db.GetAllDataByID(id);
            return service;
        }

        public virtual async Task<ServiceResult> GetDataOrderBy()
        {
            var service = new ServiceResult();
            service.Data = await _db.GetAllDataOrderBy();
            return service;
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> Insert(T entity)
        {
            var service = new ServiceResult();
            var errorMsg = new ErrorMsg();

            #region Validate dữ liệu
            var isValid = await ValidateDataInsert(entity, errorMsg);

            if (isValid == true)
            {
                var rs = await _db.Insert(entity);
                if (rs > 0)
                {
                    service.Success = true;
                    service.Data = Misa_MF736_HqMinh_Common.Properties.Resources.AddSuccess;
                    return service;
                }
                else
                {
                    service.Success = true;
                    service.Data = rs;
                    return service;
                }
            }
            else
            {
                service.Success = false;
                service.Data = errorMsg;
            }
            #endregion

            return service;
        }

        public virtual async Task<ServiceResult> Login(string username, string password)
        {
            var service = new ServiceResult();
            var errorMsg = new ErrorMsg();
            var isValid = await ValidateDataLogin(username, password, errorMsg);
            if (isValid == true)
            {
                var rs = await _db.Login(username, password);
                if (rs == true)
                {
                    service.Success = true;
                    service.Data = "Đăng nhập thành công";
                    return service;
                }
                else
                {
                    service.Success = true;
                    service.Data = rs;
                    return service;
                }
            }
            else
            {
                service.Success = false;
                service.Data = errorMsg;
            }

            return service;
        }

        /// <summary>
        /// Sửa thông tin dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> Update(T entity)
        {
            var service = new ServiceResult();
            var errorMsg = new ErrorMsg();

            #region Validate dữ liệu
            var isValid = await ValidateDataUpdate(entity, errorMsg);
            if (isValid == true)
            {
                var rs = await _db.Update(entity);
                if (rs > 0)
                {
                    service.Success = true;
                    service.Data = Misa_MF736_HqMinh_Common.Properties.Resources.UpdateSuccess;
                    return service;
                }
                else
                {
                    service.Success = true;
                    service.Data = rs;
                    return service;
                }
            }
            else
            {
                service.Success = false;
                service.Data = errorMsg;
            }
            #endregion

            return service;
        }
        /// <summary>
        /// Validate khi thêm mới
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true : Không trùng ; false : trùng</returns>
        protected virtual async Task<bool> ValidateDataInsert(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
        /// <summary>
        /// Validate khi chỉnh sửa
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true : Không trùng ; false : trùng</returns>
        protected virtual async Task<bool> ValidateDataUpdate(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
        protected virtual async Task<bool> ValidateDataLogin(string username, string password, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
