using Misa_MF736_HqMinh_Common.Common;
using Misa_MF736_HqMinh_Common.Models;
using Misa_MF736_HqMinh_DataLayer.UserDatalayer;
using Misa_MF736_HqMinh_Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Service.UserService
{
    public class UserService : BaseService<User>, IUserService
    {
        IUserDatalayer _userDatalayer ;
        public UserService(IUserDatalayer userDatalayer) : base(userDatalayer)
        {
            _userDatalayer = userDatalayer;
        }

        protected override async Task<bool> ValidateDataLogin(string username, string password, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            var isValid = true;
            if (username == null || username == string.Empty)
            {
                errorMsg.UserMsg += "Tên đăng nhập không được để trống.";
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            if (password == null || password == string.Empty)
            {
                errorMsg.UserMsg += "Mật khẩu không được để trống.";
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            var login = await _userDatalayer.Login(username, password);
            if (login == false)
            {
                errorMsg.UserMsg += "Tên tài khoản hoặc mật khẩu không đúng.";
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            return isValid;
        }
    }
}
