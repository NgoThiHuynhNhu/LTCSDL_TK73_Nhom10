using System;
using System.Collections.Generic;
using System.Text;
using DTDD.Common.DAL;
using System.Linq;

namespace DTDD.DAL
{
    using DTDD.DAL.Models;
    using DTDD.Common.Rsp;
    using System.Net.Http.Headers;

    public class OrderRep : GenericRep<DemoDTDDContext, Order>
    {
        #region --Overrides--
        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            m = base.Delete(m);
            return m.OrderId;
        }
        #endregion
        public SingleRsp CreateOrder(Order ord)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Order.Add(ord);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = ord;
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

        public SingleRsp UpdateOrder(Order ord)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Order.Update(ord);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = ord;
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

        public int DeleteOrder(int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            Context.Order.Remove(m);
            Context.SaveChanges();
            return m.OrderId;
        }
    }
}
