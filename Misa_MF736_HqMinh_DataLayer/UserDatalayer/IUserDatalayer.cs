using Misa_MF736_HqMinh_Common.Models;
using Misa_MF736_HqMinh_DataLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa_MF736_HqMinh_DataLayer.UserDatalayer
{
    public interface IUserDatalayer : IDbContext<User>
    {
    }
}
