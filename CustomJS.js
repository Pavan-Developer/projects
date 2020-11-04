
$(document).ready(function () {
    var count = 0;
    var rowCount = $("table#gvCart tr").length - 1;
    $("#btnPlaceOrder").click(function () {
        var table = $("table#gvCart > tbody  > tr").not(":first");
        table.each(function (i) {
            count = parseInt(count) + 1
            var product = new Object();
            var $tds = $(this).find('td');
            product.productId = $tds.eq(0).text();
            product.Productdesc = $tds.eq(1).text();
            product.productPrice = $tds.eq(3).text();
            product.productQuantity = $tds.eq(4).text();
            product.total = $tds.eq(5).text();
            posttoProduct(product, rowCount, count);
        });
    });
});

function posttoProduct(product, rowCount, count) {
    var query = "";
    $.ajax({
        //url: 'http://localhost:3411/api/Product',
        url: 'http://shoppingcartapp.azurewebsites.net/api/Product',
        type: 'POST',
        dataType: 'json',
        data: product,
        success: function (data, textStatus, xhr) {
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation');
        }
    });
    if (count == rowCount) {
        window.location.href = "Thankyou.aspx";
    }
}
function reload() {
    window.location.reload();
}