$(function () {GetCardInfoView();});

PostOrder = form => {
    $.ajax({
        url: form.action,
        type: "Post",
        contentType: false,
        processData: false,
        data: new FormData(form),
        success: function (res) {
            $("#StatusOrder").html(res.html);
            $("#ModalStatus").modal("show");
        }
    });
    return false;
};

GetCardInfoView = () => {
    currVoucherId = $("#voucherSelect").val();
    currTourId = $("#tourSelect").val();

    $.ajax({
        url: "CardInfo",
        type: "Get",
        data: {
            selectVoucherId: currVoucherId,
            selectTourId: currTourId
        },
        success: function (res) {
            $("#CardInfo").html(res);
        }
    });
};