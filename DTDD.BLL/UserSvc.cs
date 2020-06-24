using System;
using System.Collections.Generic;
using System.Text;

using DTDD.Common.Rsp;
using DTDD.Common.BLL;

namespace DTDD.BLL
{
    using DAL;
    using DAL.Models;
    using DTDD.Common.Req;
    using System.Linq;

    public class UserSvc : GenericSvc<UserRep, User>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        //Viet ham SELECT SEARCH CATEGORY
        public object SearchUser(string keyword, int page, int size)
        {
            var us = All.Where(x => x.Username.Contains(keyword));

            var offset = (page - 1) * size;
            var total = us.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = us.OrderBy(x => x.Username).Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                Page = page,
                Size = size
            };
            return res;
        }


        //viet function create/update product
        public SingleRsp CreateUser(UserReq us)
        {
            var res = new SingleRsp();
            User users = new User();
            users.UserId = us.UserId;
            users.Username = us.Username;
            users.Password = us.Password;
            users.Name = us.Name;
           
            res = _rep.CreateUser(users);

            return res;

        }
        public SingleRsp UpdateUser(UserReq us)
        {
            var res = new SingleRsp();
            User users = new User();
            users.UserId = us.UserId;
            users.Username = us.Username;
            users.Password = us.Password;
            users.Name = us.Name;

            res = _rep.UpdateUser(users);

            return res;

        }


        public SingleRsp DeleteUser(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteUser(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

    }
}
