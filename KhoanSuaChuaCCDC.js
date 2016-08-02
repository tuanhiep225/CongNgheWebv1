/// <reference path="../../../ext-all.js" />
Ext.onReady(function () {
    //var tinhtongtien = 0;

    var itemsPerPage = 25;

    Ext.define('KhoanSuaChuaCCDC', {
        extend: 'Ext.data.Model',
        fields: ['TongThanhTien', 'KhoanCCDCID', 'TenCongCu', 'SoLuongCCDC', 'TuNgay', 'DenNgay', 'KhoanHangMucThiCongID', 'TienSuaChua', 'DonViTinh', 'ThanhTien', 'TongSoNgay', 'TenHangMuc', 'CongTrinhID']
    });

    var Mystore = Ext.create('Ext.data.Store', {
        groupField: 'TenHangMuc',
        autoLoad: { start: 0, limit: itemsPerPage },
        model: 'KhoanSuaChuaCCDC',
        pageSize: itemsPerPage,


        proxy: {
            extraParams: {
                txt: "",
                MaCongTrinh: "",

            },
            type: 'ajax',
            url: '/KhoanCCDC/GetData',
            reader: {
                type: 'json',
                root: 'data',
                totalProperty: 'total'
            }


        },

    });
    Mystore.load({
        scope: Mystore,
        callback: function () {
            Ext.getCmp('cbbhienthi').setValue(itemsPerPage);
        }

    });
    //function hienthiCBB()
    //{
    //    Ext.getCmp('cbbhienthi').setValue(itemsPerPage);
    //}
    function loadTinhTongTienSC() {
        Ext.Ajax.request({
            url: '/KhoanCCDC/TongThanhTien',
            params: { MaCongtrinh: Ext.getCmp('cbCongTrinhSC').getValue() },
            success: function (response) {
                TongThanhTien = Ext.JSON.decode(response.responseText).tinhtongtien;

                Ext.getCmp('tinhtongtienSC').setValue(Ext.util.Format.number(TongThanhTien, "0,000") + ' VNĐ');
            }
        });
    };

    var dsCongTrinhStoreSC = Ext.create('Ext.data.Store', {
        id: 'dsCongTrinhStore',
        autoLoad: false,
        pageSize: itemsPerPage,
        fields: [{ name: 'CongTrinhID', type: 'string' },
          { name: 'TenCongTrinh', type: 'string' }],
        proxy: {
            type: 'ajax',
            url: '/KhoanCCDC/GetDataCongTrinh',
            reader: {
                type: 'json',
                root: 'data',

            },
        },
    });
    //dsCongTrinhStore.on('load', function (store, records, successful, eOpts) {
    //    dsCongTrinhStore.add({ CongTrinhID: null }, { TenCongTrinh: 'Hiển Thị Tất Cả' });
    //});

 



    var hienthi = Ext.create('Ext.data.Store', {
        id: 'dshienthiStore',
        autoLoad: false,
        pageSize: itemsPerPage,
        fields: [{ name: 'Ma', type: 'string' },
          { name: 'Ten', type: 'int' }],
        data: [
              { Ma: '1', Ten: '10' },
              { Ma: '2', Ten: '20' },
              { Ma: '6', Ten: '25' },
              { Ma: '3', Ten: '30' },
              { Ma: '4', Ten: '40' },
              { Ma: '5', Ten: '50' },
        ]


    });

    var rowEditingSC = Ext.create('Ext.grid.plugin.RowEditing',
    {
        errorSummary: false,
        saveBtnText: "Đồng Ý",
        cancelBtnText: "Hủy Bỏ",
        listeners: {

            cancelEdit: function (rowEditing, context) {
                if (context.record.phantom) {
                    Mystore.remove(context.record);
                }
                loadTinhTongTienSC();
                Mystore.load();
                gridSC.load();
            },

            Edit: function (rowEditing, context) {



                var record = context.record.data;

                Ext.Ajax.request({
                    url: '/KhoanCCDC/Update',
                    params: {
                        KhoanCCDCID: record.KhoanCCDCID,
                        TienSuaChua: record.TienSuaChua,
                    }, success: function (response) {
                        var ok = Ext.JSON.decode(response.responseText).status;
                        if (ok == 1)
                            Ext.Msg.alert('Thông báo', 'Cập Nhật Thành Công  !');
                        else
                            Ext.Msg.alert('Thông báo', 'Không Thể Thêm !');
                    }

                }); Mystore.load();
                loadTinhTongTienSC();
                gridSC.load();


            },
        }
    });
    var cfgroupingsummary = {
        id: 'cfgroupingsummary',
        hideGroupedHeader: true,
        enableGroupingMenu: true,
        ftype: 'groupingsummary',
    }
    var myWindow = Ext.create('Ext.window.Window', {
        width: '80%',
        height: 600,
        items: [{
            xtype: 'grid',
            title: 'Bảng Khoán Sửa Chữa Công Cụ Dụng Cụ',
            features: [cfgroupingsummary],
            plugins: [rowEditingSC],
            store: Mystore,
            autoWidth: true,
            autoScroll: true,
            collapsible: true,
            frame: true,
            columnLines: true, 
            columns: [

                {
                    text: "STT", xtype: 'rownumberer', style: "text-align:center;", align: 'center', width: 45,
                    listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    }
                },
                {
                    header: 'Tên CCDC', style: "text-align:center;", dataIndex: 'TenCongCu', autoWidth: true, sortable: true, flex: 3,
                    listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    }
                },

                {
                    header: 'Đơn vị', style: "text-align:center;", align: 'left', dataIndex: 'DonViTinh', autoWidth: true, sortable: true, flex: .8,
                    listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    }

                },

                {
                    header: 'Số Lượng', style: "text-align:center;", align: 'right', dataIndex: 'SoLuongCCDC', autoWidth: true, sortable: true, flex: 1,
                    listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    },
                    renderer: function (value) {
                        return Ext.util.Format.number(value, "0,000")
                    },
                },

                {
                    header: 'Từ Ngày',
                    dataIndex: 'TuNgay',
                    align: 'right',
                    sortable: true,
                    flex: 1,
                    style: "text-align:center",
                    autoSizeColumn: true,
                    listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    }
                },

                {
                    header: 'Đến Ngày',
                    align: 'right',
                    dataIndex: 'DenNgay',
                    sortable: true,
                    autoWidth: true,
                    flex: 1,
                    autoSizeColumn: true,
                    style: "text-align:center",
                    listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    }
                },

                {
                    header: 'Tổng Số Ngày', style: "text-align:center;", align: 'right', dataIndex: 'TongSoNgay', autoWidth: true, sortable: true, flex: 1,
                    listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    }
                },



                {
                    header: 'Tiền Sửa Chữa', style: "text-align:center;", align: 'right', flex: 1.5, autoWidth: true,
                    listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    },
                    renderer: function (value) {
                        return Ext.util.Format.number(value, "0,000")
                    },
                    field: {
                        xtype: 'numberfield',
                        allowDecimals: true,

                        value: 0,
                        minValue: 0,

                        allowBlank: false,
                        blankText: 'Mời Nhập Tiền Sửa Chữa !',

                    }, dataIndex: 'TienSuaChua', sortable: true, flex: 1, summaryRenderer: function () {
                        return Ext.String.format("Tổng Thành Tiền :");
                    }, listeners: {
                        afterrender: function (cot) {
                            setTimeout(function () {
                                if (cot.getWidth() < 90) {
                                    cot.autoSizeColumn = true;
                                    cot.autoSize();
                                }
                            }, 300);
                        }
                    },
                },

                 {
                     header: 'Thành Tiền', style: "text-align:center;", align: 'right', dataIndex: 'ThanhTien', sortable: true, flex: 2, autoWidth: true,
                     summaryType: 'sum', summaryRenderer: function (value) {
                         return Ext.String.format(Ext.util.Format.number(value, "0,000") + " VNĐ ");
                     }, renderer: function (value) {
                         return Ext.util.Format.number(value, "0,000")
                     }, listeners: {
                         afterrender: function (cot) {
                             setTimeout(function () {
                                 if (cot.getWidth() < 90) {
                                     cot.autoSizeColumn = true;
                                     cot.autoSize();
                                 }
                             }, 300);
                         }
                     }
                 },

            ],
            dockedItems: [{
                xtype: 'pagingtoolbar',
                store: Mystore,
                dock: 'bottom',
                displayInfo: true,
                emptyMsg: 'Không có dữ liệu để hiển thị !',
                displayMsg: 'Hiển Thị {0} - {1} trong {2}',
                beforePageText: 'Trang',
                afterPageText: 'trên {0}',
                inputItemWidth: 50,
                items: [{
                    xtype: 'label',
                    forId: 'myFieldId',
                    text: 'TỔNG SỐ TIỀN',
                    style: "color:red;",
                    margin: '0 10 0 100'
                }, {
                    xtype: 'textfield',
                    id: 'tinhtongtienSC',
                    editable: false,
                    width: 180

                }
                ]

            },
            {
                xtype: 'toolbar',
                items: [

                    {
                        width: 350,
                        id: 'cbCongTrinhSC',
                        // fieldLabel: 'Tên Công Trình :',
                        xtype: 'combobox',

                        store: dsCongTrinhStoreSC,
                        selectOnFocus: true,
                        displayField: 'TenCongTrinh',
                        editable: false,
                        valueField: 'CongTrinhID',
                        emptyText: 'Chọn công trình...',

                        listeners: {
                            select: function (combo, record, index) {
                                Mystore.proxy.extraParams.MaCongTrinh = record.data.CongTrinhID;

                                Mystore.load({ params: { start: 0, limit: itemsPerPage } });
                                loadTinhTongTienSC();
                                // Mystore.autoLoad();
                            },
                        }



                    }, '-',

                      {
                          width: 70,
                          id: 'cbbhienthi',
                          // fieldLabel: 'Hiển Thị',
                          //labelWidth: 60,
                          xtype: 'combobox',
                          store: hienthi,
                          forceSelection: true,
                          displayField: 'Ten',
                          editable: false,
                          valueField: 'Ten',
                          queryMode: 'local',

                          listeners: {
                              select: function (combo, record, index) {
                                  itemsPerPage = record.data.Ten;
                                  Mystore.pageSize = itemsPerPage;
                                  Mystore.load({ params: { start: 0, limit: itemsPerPage } });
                                  loadTinhTongTienSC();

                              },
                          }


                      }, '->', {
                          xtype: 'textfield',
                          width: '30%',
                          emptyText: 'Nhập từ khóa tìm kiếm...',
                          //fieldLabel: 'Tìm Kiếm',
                          labelWidth: 70,
                          enableKeyEvents: true,
                          listeners: {
                              keyup: function (string) {
                                  var str = string.getValue();
                                  Mystore.proxy.extraParams.txt = str;
                                  Mystore.load({ params: { start: 0, limit: itemsPerPage } });


                              }
                          }
                      },

                ]
            },
            ],
        }],
        closeAction: 'hide',
        listeners: {
            'hide': {
                fn: function (panel, eOpts) {
                    panel.items.getAt(0).fireEvent('hide');
                },
                scope: this
            }
        }
    });   
    $('#xempopup').on('click', function () {
        if (myWindow.isVisible()) {
            myWindow.items.getAt(0).fireEvent('hide');
            myWindow.hide();

        } else {
            myWindow.show();
        }
        dsCongTrinhStoreSC.load({
            scope: this,
            callback: function (records, operation, success) {
                if (success) {
                    var sessionCongTrinh = Ext.getElementById('idCongTrinhTextbox').value;
                    var congTrinhId = dsCongTrinhStoreSC.getData().items[0].data.CongTrinhID;
                    if (sessionCongTrinh.length > 0) {
                        Ext.getCmp('cbCongTrinhSC').setValue(sessionCongTrinh);
                        Mystore.proxy.extraParams.MaCongTrinh = sessionCongTrinh;
                    }
                    else {
                        Ext.getCmp('cbCongTrinhSC').setValue(congTrinhId);
                        Mystore.proxy.extraParams.MaCongTrinh = congTrinhId;
                    }
                    Mystore.load();
                    loadTinhTongTienSC();



                } else {
                    console.log('error');
                }
            }
        });
    })


});