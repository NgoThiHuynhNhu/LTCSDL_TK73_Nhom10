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
    using System.Security.Cryptography.X509Certificates;

    public class CustomerSvc : GenericSvc<CustomerRep, Customer>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        //Viet ham SELECT SEARCH CUSTOMER
        public object SearchCustomer(string keyword, int page, int size)
        {
            var cus = All.Where(x => x.CustomerName.Contains(keyword));

            var offset = (page - 1) * size;
            var total = cus.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = cus.OrderBy(x => x.CustomerName).Skip(offset).Take(size).ToList();
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

        //viet function create/update customer
        public SingleRsp CreateCustomer(CustomerReq cus)
        {
            var res = new SingleRsp();
            Customer customers = new Customer();
            customers.CustomerId = cus.CustomerId;
            customers.CustomerName = cus.CustomerName;
            customers.CustomerPhone = cus.CustomerPhone;
            customers.CustomerMail = cus.CustomerMail;
            res = _rep.CreateCustomer(customers);
            return res;

        }

        public SingleRsp UpdateCustomer(CustomerReq cus)
        {
            var res = new SingleRsp();
            Customer customers = new Customer();
            customers.CustomerId = cus.CustomerId;
            customers.CustomerName = cus.CustomerName;
            customers.CustomerPhone = cus.CustomerPhone;
            customers.CustomerMail = cus.CustomerMail;
            res = _rep.UpdateCustomer(customers);
            return res;

        }


        public SingleRsp DeleteCustomer(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteCustomer(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

    }



}

