var khachhang = {
    init: function()
    {
        khachhang.registerEvents();
    },
    registerEvents: function()
    {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax
            ({
                url: "/Admin/KhachHang/Changes",
                dataType: "json",
                type: "POST",
                data: { id: id },
                success:function(response)
                {
                    if(response.PhanLoai==true)
                    {
                        var lb = '<span class="label label-success">Active</span>'
                        btn.html(lb);
                    }
                    else
                    {
                        var lb = '<span class="label label-important">Banned</span>'
                        btn.html(lb);
                    }
                }
            });
        });
    }
}
khachhang.init();