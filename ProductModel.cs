using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartAPI.Models
{
    public class ProductModel
    {
        public string productId { get; set; }
        public string productDesc { get; set; }
        public int productPrice { get; set; }
    }

    class ProductList
    {
        List<ProductModel> productList = new List<ProductModel>();
        public void AddProduct(string productID, string productDesc, int productPrice)
        {
            productList.Add(new ProductModel { productId = productID, productDesc = productDesc, productPrice = productPrice });
        }

        public List<ProductModel> getProducts()
        {
            return productList;
        }
    }
}