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
    public class UserController : ControllerBase
    {
        public UserController()
        {
            _svc = new UserSvc();
        }

        [HttpPost("get-by-user-id")]
        public IActionResult getUserById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);

        }

        [HttpPost("get-all-user")]
        public IActionResult getAllUser()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);

        }
        //viet function create/update product
        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] UserReq req)
        {
            var res = new SingleRsp();
            res = _svc.CreateUser(req);
            return Ok(res);
        }

        [HttpPost("update-user")]
        public IActionResult UpdateUser([FromBody] UserReq req)
        {
            var res = _svc.UpdateUser(req);
            return Ok(res);
        }

        [HttpPost("delete-user")]
        public IActionResult DeleteUser([FromBody] DeleteUserReq req)
        {
            var res = _svc.DeleteUser(req.UserId);
            return Ok(res);
        }

        [HttpPost("search-user")]
        public IActionResult SearchUser([FromBody] SearchUserReq req)
        {
            var res = new SingleRsp();
            var userss = _svc.SearchUser(req.Keyword, req.Page, req.Size);
            res.Data = userss;
            return Ok(res);
        }



        private readonly UserSvc _svc;

    }
}
