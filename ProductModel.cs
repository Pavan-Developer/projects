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
        public int productQuantity { get; set; }
        public int total { get; set; }
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

        public void AddProductOrder(string productID, string productDesc, int productPrice, int productQuantity, int total)
        {
            productList.Add(new ProductModel { productId = productID, productDesc = productDesc, productPrice = productPrice,productQuantity=productQuantity,total=total });
        }
    }
}