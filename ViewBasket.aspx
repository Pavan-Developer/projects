<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBasket.aspx.cs" Inherits="ShoppingCartAPI.ViewBasket" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Basket</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    
    <script>
        function reload() {
            window.location.reload();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">SHOPPING BASKET</a>
                </div>
                <ul class="nav navbar-nav">
                    <li>
                        <a href="ShoppingCart.aspx">Go home</a>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="container">
            <div style="text-align: center; font-size: 18px">
                <asp:Label ID="lblErr" runat="server" />
            </div>
            <div style="text-align: right; font-size: 18px">
                <asp:Button ID="btnPlaceOrder" runat="server" Text="Place order" CssClass="btn btn-success" OnClick="btnPlaceOrder_Click"/>
            </div>
            <br />
            <asp:GridView ID="gvCart"
                runat="server"
                CssClass="table table-bordered"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Product ID" HeaderText="Product ID" />
                    <asp:BoundField DataField="Product Desc" HeaderText="Product Name" />
                    <asp:BoundField DataField="Product Price" HeaderText="Product cost" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Total" HeaderText="Total Cost" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn btn-warning" OnClick="btnRemove_Click" ClientIDMode="Static" />
                            <asp:HiddenField ID="HdnID" Value='<%# Eval("Product ID") %>' ClientIDMode="Static" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div style="font-size: 18px; text-align: right">
                <asp:Label ID="lblCartTotal" runat="server" Font-Bold="true" />
            </div>
            <div style="font-size: 18px; text-align: right">
                <asp:Label ID="lblShippingcost" runat="server" Font-Bold="true" />
            </div>
            <div style="font-size: 18px; text-align: right">
                <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />
            </div>
        </div>
    </form>
</body>
</html>
