// sử dụng cú pháp jQuery (thay vì $) khi và chỉ khi
// nhúng mã javascript vào codesnippet.
//
// còn nếu như đặt riêng mã JavaScript ra file như này thì ko cần.
// Kịch bản này cần được gọi ngay sau jquery trong layout

$(document).ready(function () {
    $("#itemsPerPage").change(function () {
        $("#btnSearch").trigger("click");
    });

    $(".alert-success").delay(2000).fadeOut(5000);
});
