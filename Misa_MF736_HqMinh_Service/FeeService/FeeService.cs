using Misa_MF736_HqMinh_Common.Common;
using Misa_MF736_HqMinh_Common.Models;
using Misa_MF736_HqMinh_DataLayer.FeeDataLayer;
using Misa_MF736_HqMinh_Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Service.FeeService
{
    public class FeeService : BaseService<Fee>, IFeeService
    {
        IFeeDataLayer _feeDataLayer;
        public FeeService(IFeeDataLayer feeDataLayer) : base(feeDataLayer)
        {
            _feeDataLayer = feeDataLayer;
        }
        /// <summary>
        /// Validate dữ liệu thêm mới
        /// CreateBy: MinhHq - 19/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMsg"></param>
        /// <returns>True : không trùng ; False : trùng tên khoản thu hoặc dữ liệu để trống</returns>
        protected override async Task<bool> ValidateDataInsert(Fee entity, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            var isValid = true;

            #region kiểm tra tên khoản thu có để trống hay không?
            if (entity.FeeName == null || entity.FeeName == string.Empty)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeeName);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra giá tiền có để trống hay không?
            if (entity.Price == null || entity.Price == decimal.Zero)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeePrice);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra đơn vị tính có để trống hay không?
            if (entity.Unit == null || entity.Unit == decimal.Zero)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeeUnit);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra phạm vi thu có để trống hay không?
            if (entity.ApplyObject == null || entity.ApplyObject == string.Empty)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeeApplyObject);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra kì thu có để trống hay không?
            if (entity.Period == null || entity.Period == decimal.Zero)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeePeriod);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng tên khoản thu
            var isExitByCode = await _feeDataLayer.CheckNameExitInsert(entity.FeeName);
            if (isExitByCode == false)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_DuplicateFeeName);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            return isValid;
        }
        /// <summary>
        /// Validate chỉnh xửa dữ liệu
        /// CreateBy: MinhHq - 19/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMsg"></param>
        /// <returns>True : không trùng ; False : trùng tên khoản thu hoặc dữ liệu để trống</returns>
        protected override async Task<bool> ValidateDataUpdate(Fee entity, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            var isValid = true;

            #region kiểm tra tên khoản thu có để trống hay không?
            if (entity.FeeName == null || entity.FeeName == string.Empty)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeeName);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra giá tiền có để trống hay không?
            if (entity.Price == null || entity.Price == decimal.Zero)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeePrice);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra đơn vị tính có để trống hay không?
            if (entity.Unit == null || entity.Unit == decimal.Zero)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeeUnit);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra phạm vi thu có để trống hay không?
            if (entity.ApplyObject == null || entity.ApplyObject == string.Empty)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeeApplyObject);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra kì thu có để trống hay không?
            if (entity.Period == null || entity.Period == decimal.Zero)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_EmptyFeePeriod);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng tên khoản thu
            var isExitByCode = await _feeDataLayer.CheckNameExitUpdate(entity.FeeName, entity.FeeID);

            if (isExitByCode == false)
            {
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.ErroService_DuplicateFeeName);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            return isValid;
        }
    }
}
