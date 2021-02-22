using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa_MF736_HqMinh_Common.Models;
using Misa_MF736_HqMinh_Service.FeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Api.Controllers
{
    public class FeeController : BaseController<Fee>
    {
        IFeeService _service;
        public FeeController(IFeeService feeService) : base(feeService)
        {
            _service = feeService;
        }
    }
}
