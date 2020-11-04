using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using ShoppingCartAPI.Models;
using System.Collections;
using System.Data;

namespace ShoppingCartAPI
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        IEnumerable<ProductModel> productList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //This code get the list of products from the productAPI
            if (!IsPostBack)
            {
                HttpClient httpClient = new HttpClient();
                //httpClient.BaseAddress = new Uri("http://localhost:3411/api/");

                httpClient.BaseAddress = new Uri("http://shoppingcartapp.azurewebsites.net/api/");

                var productApiConsume = httpClient.GetAsync("product");
                productApiConsume.Wait();

                var data = productApiConsume.Result;
                if (data.IsSuccessStatusCode)
                {
                    var products = data.Content.ReadAsAsync<IList<ProductModel>>();
                    products.Wait();
                    productList = products.Result;
                    if (gvProductList != null)
                    {
                        gvProductList.DataSource = productList;
                        gvProductList.DataBind();
                    }
                }
            }
        }

        //This function Adds the selected product to the session
        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string productId = (btn.NamingContainer.FindControl("HdnID") as HiddenField).Value.Trim();
            string productDesc = (btn.NamingContainer.FindControl("HiddenField1") as HiddenField).Value.Trim();
            string productPrice = (btn.NamingContainer.FindControl("HiddenField2") as HiddenField).Value.Trim();
            int quantity = 1;
            bool updated = false;

            if (Session["cart"] != null)
            {
                DataTable dt = (DataTable)Session["cart"];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Product ID"].ToString().Equals(productId))
                    {
                        int currentQuantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                        int currentPrice = Convert.ToInt32(dt.Rows[i]["Total"]);

                        dt.Rows[i]["Quantity"] = currentQuantity + 1;
                        dt.Rows[i]["Total"] = Convert.ToInt32(productPrice) * Convert.ToInt32(dt.Rows[i]["Quantity"]);
                        updated = true;
                    }
                }

                if (!updated)
                {
                    DataRow dr = dt.NewRow();
                    dr["Product ID"] = productId;
                    dr["Product Desc"] = productDesc;
                    dr["Product Price"] = productPrice;
                    dr["Quantity"] = quantity;
                    dr["Total"] = quantity * Convert.ToInt32(productPrice);

                    dt.Rows.Add(dr);
                }
                Session["cart"] = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Product ID", typeof(string));
                dt.Columns.Add("Product Desc", typeof(string));
                dt.Columns.Add("Product Price", typeof(int));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("Total", typeof(int));
                DataRow dr = dt.NewRow();
                dr["Product ID"] = productId;
                dr["Product Desc"] = productDesc;
                dr["Product Price"] = productPrice;
                dr["Quantity"] = quantity;
                dr["Total"] = quantity * Convert.ToInt32(productPrice);

                dt.Rows.Add(dr);

                Session["cart"] = dt;
            }
        }
    }
}