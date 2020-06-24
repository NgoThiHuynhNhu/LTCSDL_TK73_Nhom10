using System;
using System.Collections.Generic;
using System.Text;
using DTDD.Common.DAL;
using System.Linq;

namespace DTDD.DAL
{
    using DTDD.DAL.Models;
    using DTDD.Common.Rsp;

    public class CategoryRep : GenericRep<DemoDTDDContext, Category>
    {
        #region --Overrides--
        public override Category Read(int id)
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
        public SingleRsp CreateCategory(Category cate)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Category.Add(cate);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = cate;
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

        public SingleRsp UpdateCategory(Category cate)
        {
            var res = new SingleRsp();
            using (var context = new DemoDTDDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Category.Update(cate);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = cate;
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

        public int DeleteCategory(int id)
        {
            var m = base.All.First(i => i.Id == id);
            Context.Category.Remove(m);
            Context.SaveChanges();
            return m.Id;
        }
    }
}
