<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ShoppingCartAPI.ShoppingCart" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">SHOPPING CART</a>
                </div>
                <ul class="nav navbar-nav">
                    <li>
                        <a href="ViewBasket.aspx">Go to cart</a>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="container">
<%--            <div id="divAlertSuccess" class="alert alert-success" style="text-align:center">
                Product Added to the cart
            </div>--%>
            <h1>PRODUCT LIST</h1>
            <asp:GridView ID="gvProductList" runat="server"
                AutoGenerateColumns="false" CssClass="table table-responsive">
                <Columns>
                    <asp:BoundField DataField="productID" HeaderText="Product ID" />
                    <asp:BoundField DataField="productdesc" HeaderText="Product Description" />
                    <asp:BoundField DataField="productprice" HeaderText="Price" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnAddtoCart" runat="server" Text="Add to cart" CssClass="btn btn-success" ClientIDMode="Static" OnClick="btnAddtoCart_Click"/>
                            <asp:HiddenField ID="HdnID" Value='<%# Eval("productID") %>' ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="HiddenField1" Value='<%# Eval("productdesc") %>' ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="HiddenField2" Value='<%# Eval("productprice") %>' ClientIDMode="Static" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <span id="table" />
        </div>

    </form>
</body>
</html>
