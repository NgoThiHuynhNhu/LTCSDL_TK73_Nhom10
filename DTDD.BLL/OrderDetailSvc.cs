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

    public class OrderDetailSvc : GenericSvc<OrderDetailRep, OrderDetail>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        //Viet ham SELECT SEARCH CATEGORY
        public object SearchOrderDetail(string keyword, int page, int size)
        {
            var ordt = All.Where(x => x.Price.Contains(keyword));

            var offset = (page - 1) * size;
            var total = ordt.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = ordt.OrderBy(x => x.Price).Skip(offset).Take(size).ToList();
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
        public SingleRsp CreateOrderDetail(OrderDetailReq ordt)
        {
            var res = new SingleRsp();
            OrderDetail orderdetails = new OrderDetail();
            orderdetails.OrderDetailId = ordt.OrderDetailId;
            orderdetails.OrderId = ordt.OrderId;
            orderdetails.ProductId = ordt.ProductId;
            orderdetails.Price = ordt.Price;
            orderdetails.SaleQuantity = ordt.SaleQuantity;

            res = _rep.CreateOrderDetail(orderdetails);

            return res;
        }
        public SingleRsp UpdateOrderDetail(OrderDetailReq ordt)
        {
            var res = new SingleRsp();
            OrderDetail orderdetails = new OrderDetail();
            orderdetails.OrderDetailId = ordt.OrderDetailId;
            orderdetails.OrderId = ordt.OrderId;
            orderdetails.ProductId = ordt.ProductId;
            orderdetails.Price = ordt.Price;
            orderdetails.SaleQuantity = ordt.SaleQuantity;

            res = _rep.UpdateOrderDetail(orderdetails);

            return res;
        }

        public SingleRsp DeleteOrderDetail(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteOrderDetail(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

    }
}
