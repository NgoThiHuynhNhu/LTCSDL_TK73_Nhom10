using System;
using System.Collections.Generic;
using System.Text;
using DTDD.Common.DAL;
using System.Linq;

namespace DTDD.DAL
{
    using DTDD.Common.Rsp;
    using DTDD.DAL.Models;
    using System.Net.Http.Headers;

    public class UserRep : GenericRep<DemoDTDDContext, User>
    {
        #region --Overrides--
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(p => p.UserId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.UserId == id);
            m = base.Delete(m);
            return m.UserId;
        }
        #endregion
        public SingleRsp CreateUser(User us)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.User.Add(us);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = us;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateUser(User us)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.User.Update(us);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = us;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public int DeleteUser(int id)
        {
            var m = base.All.First(i => i.UserId == id);
            Context.User.Remove(m);
            Context.SaveChanges();
            return m.UserId;
        }


    }
}