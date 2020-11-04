using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCartAPI
{
    public partial class ViewBasket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["cart"];

                gvCart.DataSource = dt;
                gvCart.DataBind();
                CalculateCosts(dt);

                if (dt.Rows.Count == 0)
                {
                    lblErr.Text = "Shopping basket is empty. Please <a href='ShoppingCart.aspx'>click here</a> to add products to the basket";
                }
            }
            else
            {
                lblErr.Text = "Shopping basket is empty. Please <a href='ShoppingCart.aspx'>click here</a> to add products to the basket";
            }
        }

        //This function calculates the shipping costs, basket total and total costs
        private void CalculateCosts(DataTable dt)
        {
            int carttotal = 0;
            int shippingcost = 0;
            int total = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                carttotal = Convert.ToInt32(dt.Rows[i]["Total"]) + carttotal;
            }

            if (carttotal != 0)
            {
                if (carttotal <= 50)
                {
                    shippingcost = 10;
                }
                else
                {
                    shippingcost = 20;
                }
            }
            else
            {
                shippingcost = 0;
                total = 0;
                lblErr.Text = "Shopping basket is empty. Please <a href='ShoppingCart.aspx'>click here</a> to add products to the basket";
                btnPlaceOrder.Visible = false;
            }

            lblCartTotal.Text = "Basket total: $" + carttotal;
            lblShippingcost.Text = "Total shipping cost: $" + shippingcost;
            total = carttotal + shippingcost;
            lblTotal.Text = "TOTAL: $" + total;

        }

        //This function removed the item from the Shopping basket.
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string productId = (btn.NamingContainer.FindControl("HdnID") as HiddenField).Value.Trim();
            if (Session["cart"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["cart"];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Product ID"].ToString().Equals(productId))
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Quantity"]) <= 1)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                            break;
                        }
                        else
                        {
                            dt.Rows[i]["Quantity"] = Convert.ToInt32(dt.Rows[i]["Quantity"]) - 1;
                            dt.Rows[i]["Total"] = Convert.ToInt32(dt.Rows[i]["Total"]) - Convert.ToInt32(dt.Rows[i]["Product Price"]);
                            break;
                        }
                    }
                }

                Session["cart"] = dt;
                CalculateCosts(dt);
                gvCart.DataSource = dt;
                gvCart.DataBind();
            }
        }

        //This function places the order
        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["cart"];

            if (Session["cart"] != null)
            {
                Response.Redirect("Thankyou.aspx");
            }
        }
    }
}