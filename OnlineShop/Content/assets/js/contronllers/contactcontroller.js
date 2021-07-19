var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var Name = $('#txtName').val();
            var Email = $('#txtEmail').val();
            var Phone = $('#txtPhone').val();
            var Content = $('#txtContent').val();
            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    Name: Name,
                    Email: Email,
                    Phone: Phone,
                    Content: Content,
                },
                success: function (res) {
                    if (res.status == 1) {
                        window.alert("Gửi thành công");
                        contact.resetForm()
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtPhone').val('');
        $('#txtContent').val('');
    }
}

contact.init();
