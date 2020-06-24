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

    public class ProductRep : GenericRep<DemoDTDDContext, Product>
    {
        #region --Overrides--
        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Id == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.Id == id);
            m = base.Delete(m);
            return m.Id;
        }
        #endregion
        public SingleRsp CreateProduct(Product pro)
        {
            var res = new SingleRsp();
            using(var context = new DemoDTDDContext())
            {
                using(var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Product.Add(pro);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = pro;
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateProduct(Product pro)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Product.Update(pro);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = pro;
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

        public int DeleteProduct(int id)
        {
            var m = base.All.First(i => i.Id == id);
            Context.Product.Remove(m);
            Context.SaveChanges();
            return m.Id;
        }

        
    }
}