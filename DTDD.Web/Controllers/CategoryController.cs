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

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController()
        {
            _svc = new CategorySvc();
        }

        [HttpPost("get-by-category-id")]
        public IActionResult getCategoryById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);

        }

        [HttpPost("get-all-category")]
        public IActionResult getAllCategory()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);

        }

        //viet function create/update category
        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromBody] CategoryReq req)
        {
            var res = new SingleRsp();
            res = _svc.CreateCategory(req);
            return Ok(res);
        }

        [HttpPost("update-category")]
        public IActionResult UpdateCategory([FromBody] CategoryReq req)
        {
            var res = _svc.UpdateCategory(req);
            return Ok(res);
        }

        [HttpPost("delete-category")]
        public IActionResult DeleteCategory([FromBody] DeleteCategoryReq req)
        {
            var res = _svc.DeleteCategory(req.Id);
            return Ok(res);
        }

        [HttpPost("search-category")]
        public IActionResult SearchCategory([FromBody] SearchCategoryReq req)
        {
            var res = new SingleRsp();
            var cates = _svc.SearchCategory(req.Keyword, req.Page, req.Size);
            res.Data = cates;
            return Ok(res);
        }

        private readonly CategorySvc _svc;

    }
}
