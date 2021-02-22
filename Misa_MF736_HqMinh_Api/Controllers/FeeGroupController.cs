using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa_MF736_HqMinh_Common.Models;
using Misa_MF736_HqMinh_Service.FeeGroupService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Api.Controllers
{
    public class FeeGroupController : BaseController<FeeGroup>
    {
        IFeeGroupService _service;
        public FeeGroupController(IFeeGroupService feeGroupService) : base(feeGroupService)
        {
            _service = feeGroupService;
        }
    }
}
