using Misa_MF736_HqMinh_Common.Models;
using Misa_MF736_HqMinh_DataLayer.FeeGroupDatalayer;
using Misa_MF736_HqMinh_Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa_MF736_HqMinh_Service.FeeGroupService
{
    public class FeeGroupService : BaseService<FeeGroup>, IFeeGroupService
    {
        IFeeGroupDatalayer _feeGroupDatalayer;
        public FeeGroupService(IFeeGroupDatalayer feeGroupDatalayer) : base(feeGroupDatalayer)
        {
            _feeGroupDatalayer = feeGroupDatalayer;
        }
    }
}
