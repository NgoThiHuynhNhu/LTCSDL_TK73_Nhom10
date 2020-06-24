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

    public class OrderDetailRep : GenericRep<DemoDTDDContext, OrderDetail>
    {
        #region --Overrides--
        public override OrderDetail Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderDetailId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.OrderDetailId == id);
            m = base.Delete(m);
            return m.OrderDetailId;
        }
        #endregion
        public SingleRsp CreateOrderDetail(OrderDetail ordt)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.OrderDetail.Add(ordt);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = ordt;
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

        public SingleRsp UpdateOrderDetail(OrderDetail ordt)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.OrderDetail.Update(ordt);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = ordt;
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

        public int DeleteOrderDetail(int id)
        {
            var m = base.All.First(i => i.OrderDetailId == id);
            Context.OrderDetail.Remove(m);
            Context.SaveChanges();
            return m.OrderDetailId;
        }


    }
}