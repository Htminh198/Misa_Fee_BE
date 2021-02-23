using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa_MF736_HqMinh_Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        IBaseService<T> _service;
        public BaseController(IBaseService<T> baseService)
        {
            _service = baseService;
        }
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <returns>Danh sách truy vấn</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rs = await _service.GetData();
            var res = rs.Data as List<T>;
            if (rs.Success == true)
            {
                if (res.Count == 0)
                {
                    return StatusCode(204, rs.Data);
                }
                return StatusCode(200, rs.Data);
            }
            return StatusCode(200, rs.Data);
        }

        [HttpGet("GetOderBy")]
        public async Task<IActionResult> GetOderBy()
        {
            var rs = await _service.GetDataOrderBy();
            var res = rs.Data as List<T>;
            if (rs.Success == true)
            {
                if (res.Count == 0)
                {
                    return StatusCode(204, rs.Data);
                }
                return StatusCode(200, rs.Data);
            }
            return StatusCode(200, rs.Data);
        }
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dữ liệu theo ID truyền vào</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var rs = await _service.GetDataByID(id);
            if (rs.Success == true)
            {
                
                return StatusCode(200, rs.Data);
            }
            return StatusCode(204, rs.Data);
        }
        /// <summary>
        /// Xóa dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _service.DeleteDataByID(id);
            if ((int)rs.Data > 0)
            {
                rs.Data = Misa_MF736_HqMinh_Common.Properties.Resources.DeleteSuccess;
                return StatusCode(200, rs.Data);
            }
            return StatusCode(400, rs.Data);
        }
        /// <summary>
        /// Thêm mới dữ liệu
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]T entity)
        {
            var rs = await _service.Insert(entity);
            if (rs.Success == false)
            {
                return StatusCode(400, rs.Data);
            }
            return StatusCode(201, rs.Data);
        }
        /// <summary>
        /// Sửa dữ liệu theo ID
        /// CreateBy: MinhHq - 18/02/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]T entity)
        {
            var rs = await _service.Update(entity);
            if (rs.Success == false)
            {
                return StatusCode(400, rs.Data);
            }
            return StatusCode(201, rs.Data);
        }
    }
}
