$(function () {
    PostEditOrder = (form) => {

    };

    GetEditOrder = id => {
        $.ajax({
            url: "Admin/Edit",
            type: "Get",
            data: {
                id: id
            },
            success: function (res) {
                $("#EditModal").html(res);
                $("#OrderModal").modal("show");
            }
        });
        return false;
    };
});