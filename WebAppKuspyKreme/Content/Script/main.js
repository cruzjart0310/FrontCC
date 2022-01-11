$(".BtnExchange").click(function (eve) {
    $("#modal-content").load("/Coupon/ExchangeGet/" + $(this).data("id"));
});

$(".BtnEdit").click(function (eve) {
    $("#modal-content").load("/User/Edit/" + $(this).data("id"));
});