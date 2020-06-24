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

    public class CategorySvc: GenericSvc<CategoryRep, Category>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        //Viet ham SELECT SEARCH CATEGORY
        public object SearchCategory(string keyword, int page, int size)
        {
            var cate = All.Where(x => x.CategoryName.Contains(keyword));

            var offset = (page - 1) * size;
            var total = cate.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = cate.OrderBy(x => x.CategoryName).Skip(offset).Take(size).ToList();
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
        public SingleRsp CreateCategory(CategoryReq cate)
        {
            var res = new SingleRsp();
            Category categories = new Category();
            categories.Id = cate.Id;
            categories.CategoryName = cate.CategoryName;
            categories.ParentId = cate.ParentId;
            res = _rep.CreateCategory(categories);

            return res;

        }
        public SingleRsp UpdateCategory(CategoryReq cate)
        {
            var res = new SingleRsp();
            Category categories = new Category();
            categories.Id = cate.Id;
            categories.CategoryName = cate.CategoryName;
            categories.ParentId = cate.ParentId;
            res = _rep.UpdateCategory(categories);

            return res;

        }


        public SingleRsp DeleteCategory(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteCategory(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

    }
}
