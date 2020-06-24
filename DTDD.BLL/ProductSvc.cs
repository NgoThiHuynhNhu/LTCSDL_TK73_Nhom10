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

    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        //Viet ham SELECT SEARCH PRODUCT
        public object SearchProduct(string keyword, int page, int size)
        {
            var pro = All.Where(x => x.ProductName.Contains(keyword));

            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.ProductName).Skip(offset).Take(size).ToList();
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
        public SingleRsp CreateProduct(ProductReq pro)
        {
            var res = new SingleRsp();
            Product products = new Product();
            products.Id = pro.Id;
            products.IdCat = pro.IdCat;
            products.ProductName = pro.ProductName;
            products.Title = pro.Title;
            products.Description = pro.Description;
            products.Price = pro.Price;
            products.Quantity = pro.Quantity;
            //products.Size = pro.Size;
            //products.Weight = pro.Weight;
            //products.Color = pro.Color;
            //products.Image = pro.Image;
            //products.Memory = pro.Memory;
            //products.Os = pro.Os;
            //products.CpuSpeed = pro.CpuSpeed;
            //products.CameraPrimary = pro.CameraPrimary;
            //products.Battery = pro.Battery;
            //products.Bluetooth = pro.Bluetooth;
            //products.Wlan = pro.Wlan;
            //products.PromotionPrice = pro.PromotionPrice;
        
            res = _rep.CreateProduct(products);

            return res;

        }

        public SingleRsp UpdateProduct(ProductReq pro)
        {
            var res = new SingleRsp();
            Product products = new Product();
            products.Id = pro.Id;
            products.IdCat = pro.IdCat;
            products.ProductName = pro.ProductName;
            products.Title = pro.Title;
            products.Description = pro.Description;
            products.Price = pro.Price;
            products.Quantity = pro.Quantity;
            products.Size = pro.Size;
            products.Weight = pro.Weight;
            products.Color = pro.Color;
            products.Image = pro.Image;
            products.Memory = pro.Memory;
            products.Os = pro.Os;
            products.CpuSpeed = pro.CpuSpeed;
            products.CameraPrimary = pro.CameraPrimary;
            products.Battery = pro.Battery;
            products.Bluetooth = pro.Bluetooth;
            products.Wlan = pro.Wlan;
            products.PromotionPrice = pro.PromotionPrice;
            
            res = _rep.UpdateProduct(products);

            return res;
        }

        public SingleRsp DeleteProduct(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteProduct(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
        
    }

    

}
