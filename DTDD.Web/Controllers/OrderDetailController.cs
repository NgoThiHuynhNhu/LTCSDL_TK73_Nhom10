using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTDD.Web.Controllers
{
    using BLL;
    using System.Collections;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    using DTDD.Common;


    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        public OrderDetailController()
        {
            _svc = new OrderDetailSvc();
        }

        [HttpPost("get-by-order-detail-id")]
        public IActionResult getOrderDetailById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);

        }

        [HttpPost("get-all-order-detail")]
        public IActionResult getAllOrderDetail()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);

        }
        //viet function create/update product
        [HttpPost("create-order-detail")]
        public IActionResult CreateOrderDetail([FromBody] OrderDetailReq req)
        {
            var res = new SingleRsp();
            res = _svc.CreateOrderDetail(req);
            return Ok(res);
        }

        [HttpPost("update-order-detail")]
        public IActionResult UpdateOrderDetail([FromBody] OrderDetailReq req)
        {
            var res = _svc.UpdateOrderDetail(req);
            return Ok(res);
        }

        [HttpPost("delete-order-detail")]
        public IActionResult DeleteOrderDetail([FromBody] DeleteOrderDetailReq req)
        {
            var res = _svc.DeleteOrderDetail(req.OrderDetailId);
            return Ok(res);
        }

        [HttpPost("search-order-detail")]
        public IActionResult SearchOrderDetail([FromBody] SearchOrderDetailReq req)
        {
            var res = new SingleRsp();
            var ordts = _svc.SearchOrderDetail(req.Keyword, req.Page, req.Size);
            res.Data = ordts;
            return Ok(res);
        }



        private readonly OrderDetailSvc _svc;

    }
}
