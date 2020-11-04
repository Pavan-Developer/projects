using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCartAPI
{
    public partial class Thankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["cart"];

                gvFinish.DataSource = dt;
                gvFinish.DataBind();

                Session["cart"] = null;
            }
        }
    }
}