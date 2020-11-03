<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thankyou.aspx.cs" Inherits="ShoppingCartAPI.Thankyou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank you!!</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Thank you</a>
                </div>
            </div>
        </nav>
        <div class="container">
            <div style="font-size: 18px; text-align: center">
                <asp:Label ID="lblFinal" runat="server" Text="Thank you for placing your order. Your order is successfully posted." />
                <br />
<%--                <asp:Label ID="lbl" runat="server" Text="Please see your order details below" />--%>
            </div>
            <br />
            <asp:GridView ID="gvFinish" runat="server" CssClass="table table-bordered" />
        </div>
    </form>
</body>
</html>
