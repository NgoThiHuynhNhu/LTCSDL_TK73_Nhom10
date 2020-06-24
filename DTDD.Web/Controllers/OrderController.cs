using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTDD.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    using DTDD.Common;

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
            _svc = new OrderSvc();
        }

        [HttpPost("get-by-order-id")]
        public IActionResult getOrderById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);

        }

        [HttpPost("get-all-order")]
        public IActionResult getAllOrder()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);

        }

        //viet function create/update category
        [HttpPost("create-order")]
        public IActionResult CreateOrder([FromBody] OrderReq req)
        {
            var res = new SingleRsp();
            res = _svc.CreateOrder(req);
            return Ok(res);
        }

        [HttpPost("update-order")]
        public IActionResult UpdateOrder([FromBody] OrderReq req)
        {
            var res = _svc.UpdateOrder(req);
            return Ok(res);
        }

        [HttpPost("delete-order")]
        public IActionResult DeleteOrder([FromBody] DeleteOrderReq req)
        {
            var res = _svc.DeleteOrder(req.OrderId);
            return Ok(res);
        }

        [HttpPost("search-order")]
        public IActionResult SearchOrder([FromBody] SearchOrderReq req)
        {
            var res = new SingleRsp();
            var ords = _svc.SearchOrder(req.Keyword, req.Page, req.Size);
            res.Data = ords;
            return Ok(res);
        }

        private readonly OrderSvc _svc;

    }
}
