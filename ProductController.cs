using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        ProductList productList = new ProductList();
        public IEnumerable<ProductModel> Get()
        {
            productList.AddProduct("C111", "USB-C Adapter", 10);
            productList.AddProduct("D222", "iPhone 12 case", 20);
            productList.AddProduct("E333", "iPhone 12 Pro case", 25);
            productList.AddProduct("P444", "iPhone 11 Pro case", 15);
            productList.AddProduct("P555", "iPhone XR case", 12);

            return productList.getProducts().ToList();
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public List<ProductModel> Post([FromBody] ProductModel product)
        {
            productList.AddProductOrder(product.productId, product.productDesc, product.productPrice, product.productQuantity, product.total);
            return productList.getProducts().ToList();
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
