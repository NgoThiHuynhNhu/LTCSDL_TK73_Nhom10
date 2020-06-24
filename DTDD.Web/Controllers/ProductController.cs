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
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
            _svc = new ProductSvc();
        }

        [HttpPost("get-by-product-id")]
        public IActionResult getProductById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);

        }

        [HttpPost("get-all-product")]
        public IActionResult getAllProduct()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);

        }
        //viet function create/update product
        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody]ProductReq req)
        {
            var res = new SingleRsp();
            res = _svc.CreateProduct(req);
            return Ok(res);
        }

        [HttpPost("update-product")]
        public IActionResult UpdateProduct([FromBody] ProductReq req)
        {
            var res = _svc.UpdateProduct(req);
            return Ok(res);
        }

        [HttpPost("delete-product")]
        public IActionResult DeleteProduct([FromBody] DeleteProductReq req)
        {
            var res = _svc.DeleteProduct(req.Id);
            return Ok(res);
        }

        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchProduct(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }



        private readonly ProductSvc _svc;

    }
}
