var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('lick').on('lick', function () {
            window.location.href = "/";
        });

        $('#btnUpdate').off('lick').on('lick', function () {
            var listProduct = $('.quantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    product: {
                        IdProduct: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == 1) {
                        window.location.href = "/gio-hang";
                    } 
                }
            })
        });
    }
}
cart.init();