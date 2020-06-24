using System;
using System.Collections.Generic;
using System.Text;
using DTDD.Common.DAL;
using System.Linq;

namespace DTDD.DAL
{
    using DTDD.DAL.Models;
    using DTDD.Common.Rsp;

    public class CustomerRep : GenericRep<DemoDTDDContext, Customer>
    {
        #region --Overrides--
        public override Customer Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CustomerId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CustomerId == id);
            m = base.Delete(m);
            return m.CustomerId;
        }
        #endregion
        public SingleRsp CreateCustomer(Customer cus)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Customer.Add(cus);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = cus;
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

        public SingleRsp UpdateCustomer(Customer cus)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Customer.Update(cus);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = cus;
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

        public int DeleteCustomer(int id)
        {
            var m = base.All.First(i => i.CustomerId == id);
            Context.Customer.Remove(m);
            Context.SaveChanges();
            return m.CustomerId;
        }
    }
}
