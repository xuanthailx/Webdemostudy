var teamdetail = {
    init: function () {
        teamdetail.registerEvents();
    },
    registerEvents: function () {
        $('.btn_active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/TeamDetail/ChangeCheckin",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.Checkin == 1) {
                        btn.text('Tham gia');
                    }
                    else {
                        btn.text('Chưa tham gia');
                    }
                }
            });
        });
    }
}
teamdetail.init();