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
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
            _svc = new CustomerSvc();
        }

        [HttpPost("get-by-customer-id")]
        public IActionResult getCustomeryId([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.CustomerId);
            return Ok(res);

        }

        [HttpPost("get-all-customer")]
        public IActionResult getAllCustomer()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);

        }

        //viet function create/update customer
        [HttpPost("create-customer")]
        public IActionResult CreateCustomer([FromBody] CustomerReq req)
        {
            var res = new SingleRsp();
            res = _svc.CreateCustomer(req);
            return Ok(res);
        }

        [HttpPost("update-customer")]
        public IActionResult UpdateCustomer([FromBody] CustomerReq req)
        {
            var res = _svc.UpdateCustomer(req);
            return Ok(res);
        }

        [HttpPost("delete-customer")]
        public IActionResult DeleteCustomer([FromBody] DeleteCustomerReq req)
        {
            var res = _svc.DeleteCustomer(req.CustomerId);
            return Ok(res);
        }

        [HttpPost("search-customer")]
        public IActionResult SearchCustomer([FromBody] SearchCustomerReq req)
        {
            var res = new SingleRsp();
            var cuss = _svc.SearchCustomer(req.Keyword, req.Page, req.Size);
            res.Data = cuss;
            return Ok(res);
        }

        private readonly CustomerSvc _svc;

    }
}
