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

    public class   OrderSvc : GenericSvc<OrderRep, Order>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        //Viet ham SELECT SEARCH CATEGORY
        public object SearchOrder(string keyword, int page, int size)
        {
            var ord = All.Where(x => x.DeliveryAddress.Contains(keyword));

            var offset = (page - 1) * size;
            var total = ord.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = ord.OrderBy(x => x.DeliveryAddress).Skip(offset).Take(size).ToList();
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
        public SingleRsp CreateOrder(OrderReq ord)
        {
            var res = new SingleRsp();
            Order ords = new Order();
            ords.OrderId = ord.OrderId;
            ords.CustomerId = ord.CustomerId;
            ords.StatusId = ord.StatusId;
            ords.DelivererId = ord.DelivererId;
            ords.CreateDate = ord.CreateDate;
            ords.TotalPrice = ord.TotalPrice;
            ords.DeliveryAddress = ord.DeliveryAddress;
            ords.Note = ord.Note;

            res = _rep.CreateOrder(ords);

            return res;

        }
        public SingleRsp UpdateOrder(OrderReq ord)
        {
            var res = new SingleRsp();
            Order ords = new Order();
            ords.OrderId = ord.OrderId;
            ords.CustomerId = ord.CustomerId;
            ords.StatusId = ord.StatusId;
            ords.DelivererId = ord.DelivererId;
            ords.CreateDate = ord.CreateDate;
            ords.TotalPrice = ord.TotalPrice;
            ords.DeliveryAddress = ord.DeliveryAddress;
            ords.Note = ord.Note;

            res = _rep.UpdateOrder(ords);

            return res;

        }

        public SingleRsp DeleteOrder(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteOrder(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

    }
}
