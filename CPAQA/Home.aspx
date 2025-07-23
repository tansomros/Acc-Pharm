<%@ Page Title="Home" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="CPAQA.Home" %>

    <%@ Import Namespace="System.Data" %>

        <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
            <link href="assets/styles.css" rel="stylesheet" />

            <script>
                window.Promise ||
                    document.write(
                        '<script src="assets/polyfill.min.js"><\/script>'
                    )
                window.Promise ||
                    document.write(
                        '<script src="assets/classList.min.js"><\/script>'
                    )
                window.Promise ||
                    document.write(
                        '<script src="assets/findindex_polyfill_mdn.js"><\/script>'
                    )
            </script>


            <script src="assets/apexcharts.js"></script>


            <script>
                // Replace Math.random() with a pseudo-random number generator to get reproducible results in e2e tests
                // Based on https://gist.github.com/blixt/f17b47c62508be59987b
                var _seed = 42;
                Math.random = function() {
                    _seed = _seed * 16807 % 2147483647;
                    return (_seed - 1) / 2147483646;
                };
            </script>
            <script>
                var colors = [
                    '#008FFB',
                    '#FEB019',
                    '#00E396',
                    '#FF4560',
                    '#775DD0',
                    '#546E7A',
                    '#26a69a',
                    '#D10CE8'
                ]
            </script>
        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

            <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-light icon-gradient bg-mean-fruit"></i>
                        </div>
                        <div>
                            Dashboard
                            <div class="page-title-subheading">ระบบประเมินร้านยาคุณภาพ</div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Main content -->
            <section class="content">
                <div class="alert alert-primary text-center">
                    <b>เลขที่บัญชีสำหรับโอนค่าธรรมเนียม</b>
                    <br /> ธนาคารไทยพาณิชย์ เลขที่บัญชี <b>3402014548</b> ชื่อบัญชี สภาเภสัชกรรม


                </div>

                <div class="row">
                     <section class="col-lg-6 connectedSortable">

     <div class="main-card mb-3 card">
         <img src="slide/slide13.jpg?v=01" width="100%" />
     </div>
 </section>
                    <section class="col-lg-6 connectedSortable">
                        <div class="main-card mb-3 card text-center">
                          <a href="https://www.acc-pharm.com/Documents/ร้านยาคุณภาพ.pdf" target="_blank">
    <img src="slide/cpareg.jpg?v=01" width="100%" alt="" />
</a>
                        </div>

                    </section>
                    <section class="col-lg-6 connectedSortable">

                        <div class="main-card mb-3 card">
                            <img src="slide/slide2.jpg?v=02" width="100%" />
                        </div>
                    </section>
                </div>

          <!--      <div class="row">
                    <section class="col-lg-6 connectedSortable">

                        <div class="main-card mb-3 card">
                            <a href="https://www.acc-pharm.com/slide/slide11A.jpg" target="_blank">
                                <img src="slide/slide11B.jpg?v=01" width="100%" alt="" />
                            </a>
                        </div>

                    </section>
                    <section class="col-lg-6 connectedSortable">
                        <div class="main-card mb-3 card">
                            <a href="https://www.acc-pharm.com/slide/slide12A.jpg" target="_blank"> <img src="slide/slide12B.jpg?v=01" width="100%" alt="" /></a>
                        </div>
                    </section>
                </div> -->
                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <> 1 Then %>
                    <h5 class="mt-0">จำนวนร้านยาคุณภาพ</h5>
                    <div class="row">
                        <section class="col-lg-6 connectedSortable">

                            <div class="main-card mb-3 card">
                                <div class="card-header h3">
                                    แยกตามสถานะการรับรอง
                                </div>
                                <div class="card-body">
                                    <div id="piechart"></div>
                                </div>
                            </div>
                            <div class="main-card mb-3 card">
                                <div class="card-header h3">
                                    แยกตามประเภทร้านยา
                                </div>
                                <div class="card-body">
                                    <div id="chartT"></div>
                                </div>
                            </div>
                            <div class="main-card mb-3 card">
                                <div class="card-header h3">
                                    แยกตามกลุ่มยา Chain
                                </div>
                                <div class="card-body">
                                    <div id="chartChain"></div>
                                </div>
                            </div>

                        </section>

                        <section class="col-lg-6 connectedSortable">
                            <div class="main-card mb-3 card">
                                <div class="card-header h3">
                                    แยกตามภาค
                                </div>
                                <div class="card-body">
                                    <div id="chartGroup"></div>
                                </div>
                            </div>

                            <div class="main-card mb-3 card">
                                <div class="card-header h3">
                                    แยกตามเขต สปสช.
                                </div>
                                <div class="card-body">
                                    <div id="chartNHSO"></div>
                                </div>
                            </div>

                            <div class="main-card mb-3 card">
                                <div class="card-header h3">
                                    แยกตามจังหวัด
                                </div>
                                <div class="card-body">

                                    <div class="scroll-area-lg">
                                        <div class="scrollbar-container ps--active-y ps">
                                            <table id="tbdata" class="table table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center">จังหวัด</th>
                                                        <th class="text-center">ภาค</th>
                                                        <th class="text-left">จำนวน</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <% For Each row As DataRow In dtProv.Rows %>
                                                        <tr>
                                                            <td class="text-center">
                                                                <% =String.Concat(row("ProvinceName")) %>
                                                            </td>
                                                            <td class="text-center">
                                                                <% =String.Concat(row("ProvinceGroupName")) %>
                                                            </td>
                                                            <td class="text-center">
                                                                <% =String.Concat(row("Lcount")) %>
                                                            </td>
                                                        </tr>
                                                        <%  Next %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>


                            </div>



                        </section>


                    </div>
                    <% End If %>

                        <div class="row">
                            <section class="col-lg-6 connectedSortable">

                                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then %>
                                    <div class="row">

                                        <div class="col-md-12">
                                            <div class="card-shadow-primary card-border mb-3 profile-responsive card">
                                                <div class="dropdown-menu-header">
                                                    <div class="dropdown-menu-header-inner bg-primary">
                                                        <div class="menu-header-image opacity-4" style="background-image: url('assets/images/dropdown-header/abstract2.jpg');"></div>
                                                        <div class="menu-header-content btn-pane-right">
                                                            <div class="avatar-icon-wrapper mr-3 avatar-icon-xl btn-hover-shine">
                                                                <div class="avatar-icon rounded">
                                                                    <asp:Image ID="imgLocation" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <h5 class="menu-header-title">
                                                                    <asp:Label ID="lblLocationName" runat="server" Text=""></asp:Label>
                                                                </h5>
                                                                <h6 class="menu-header-subtitle">
                                                                    <asp:Label ID="lblProvinceName" runat="server" Text=""></asp:Label>
                                                                </h6>
                                                            </div>
                                                            <div class="menu-header-btn-pane">

                                                                <!--
<button type="button" class="btn-wide btn-hover-shine btn-pill btn btn-success">Active</button> -->
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="scrollbar-container ps">
                                                    <ul class="nav flex-column">
                                                        <li class="nav-item-header nav-item">เลขที่ใบรับรองร้านยาคุณภาพ
                                                            <div class="ml-auto pull-right">
                                                                <asp:Label ID="lblAccLicense" runat="server" Text="">
                                                                </asp:Label>
                                                            </div>
                                                        </li>
                                                        <li class="nav-item-header nav-item">ปีที่เริ่มเป็นร้านยาคุณภาพ
                                                            <div class="ml-auto pull-right">
                                                                <asp:Label ID="lblStartYear" runat="server" Text="">
                                                                </asp:Label>
                                                            </div>
                                                        </li>
                                                        <li class="nav-item-header nav-item">วันที่เริ่มรับรอง
                                                            <div class="ml-auto pull-right">
                                                                <asp:Label ID="lblStartDate" runat="server" Text="">
                                                                </asp:Label>
                                                            </div>

                                                        </li>
                                                        <li class="nav-item-header nav-item">วันหมดอายุ
                                                            <div class="ml-auto pull-right">
                                                                <asp:Label ID="lblEndDate" runat="server" Text="">
                                                                </asp:Label>
                                                            </div>

                                                        </li>
                                                    </ul>

                                                </div>

                                                <ul class="list-group list-group-flush">
                                                    <li class="p-0 list-group-item">
                                                        <div class="widget-content">
                                                            <div class="text-center">

                                                                <h5 class="widget-heading mb-0 opacity-4">
                                                                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                                                </h5>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="p-0 list-group-item">
                                                        <div class="grid-menu grid-menu-2col">
                                                            <div class="no-gutters row">
                                                                <div class="col-sm-6">
                                                                    <div class="p-1">
                                                                        <a href="LocationModify.aspx?m=l&lid=<% =String.Concat(Request.Cookies("LoginLocationUID").Value) %>" class="btn-icon-vertical btn-transition-text btn-transition btn-transition-alt pt-2 pb-2 btn btn-outline-focus"><i class="lnr-home text-primary opacity-7 btn-icon-wrapper mb-2"></i>ข้อมูลร้านยา
                                                    </a>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <div class="p-1">
                                                                        <a href="RequestList.aspx?m=req&s=asm&lid=<% =Request.Cookies("LoginLocationUID").Value %>" class="btn-icon-vertical btn-transition-text btn-transition btn-transition-alt pt-2 pb-2 btn btn-outline-focus"><i class="lnr-magic-wand text-primary opacity-7 btn-icon-wrapper mb-2"></i>คำขอประเมิน
                                                    </a>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div id="pnCert" runat="server" class="main-card mb-3 card">
                                                <div class="grid-menu">
                                                    <div class="no-gutters row">
                                                        <div class="col-sm-12">
                                                            <div class="widget-chart widget-chart-hover">
                                                                <asp:ImageButton ID="imgCert1" runat="server" ImageUrl="images/certificate1.jpg" Width="100%" />

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="no-gutters row">
                                                        <div class="col-sm-12">
                                                            <div class="widget-chart widget-chart-hover">
                                                                <asp:ImageButton ID="imgCert2" runat="server" ImageUrl="images/certificate2.jpg" Width="100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <% End If %>

                                        <div class="main-card mb-3 card">
                                            <div class="card-header h3">
                                                ข่าวประชาสัมพันธ์
                                            </div>
                                            <div class="card-body">
                                                <div class="row">

                                                    <% For i = 0 To dtNew.Rows.Count - 1 %>

                                                        <table class="table table-hover">
                                                            <tr>
                                                                <td width="150"><a target="_blank" href='<% Response.Write(dtNew.Rows(i)("NewsLink")) %>' title='<% Response.Write(dtNew.Rows(i)("NewsHead")) %>' rel="bookmark">
                                        <img src="<% Response.Write(CPAQA.ImageCoverNews + dtNew.Rows(i)("CoverimagePath")) %>" height="80" width="150" alt="" />
                                    </a></td>
                                                                <td class="text-left">
                                                                    <a target="_blank" href='<% Response.Write(dtNew.Rows(i)("NewsLink")) %>' title='<% Response.Write(dtNew.Rows(i)("NewsHead")) %>'>
                                                                        <% Response.Write(dtNew.Rows(i)("NewsHead")) %>
                                                                    </a>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                        </table>

                                                        <% Next %>
                                                </div>
                                            </div>
                                            <div class="card-footer pull-right">
                                                <a href="NewsList.aspx" class="pull-right">อ่านข่าวทั้งหมด</a>
                                            </div>
                                        </div>
                                        <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <> 1 Then %>
                                            <div class="main-card mb-3 card">
                                                <div class="card-header h3">
                                                    คู่มือการใช้งานสำหรับ admin/ผู้ตรวจประเมิน
                                                </div>
                                                <div class="card-body">
                                                    <table class="table table-hover">
                                                        <tbody>
                                                            <tr>
                                                                <td class="text-center" width="30">
                                                                    <img src="images/pdf_download.png" /></td>
                                                                <td class="text-left"><a href="documents/AdminManual.pdf" target="_blank">คู่มือการใช้งานสำหรับ Admin/ผู้ตรวจประเมิน</a></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center" width="30">
                                                                    <img src="images/pdf_download.png" /></td>
                                                                <td class="text-left"><a href="https://www.acc-pharm.com/ImageNews/22/news_22_25670203155951.pdf" target="_blank">คู่มือการใช้งานระบบข้อร้องเรียน</a></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <% End If %>
                            </section>
                            <section class="col-lg-6 connectedSortable">
                                <div class="main-card mb-3 card">
                                    <div class="card-header">
                                        <i class="header-icon lnr-calendar-full icon-gradient bg-plum-plate"></i>ปฏิทินกิจกรรม/นัดสัมภาษณ์
                                        <div class="btn-actions-pane-right">
                                            <div role="group" class="btn-group-sm nav btn-group">
                                                <a data-toggle="tab" href="#tab-eg1-0" class="btn-shadow btn btn-primary active">แสดงแบบปฏิทิน</a>
                                                <a data-toggle="tab" href="#tab-eg1-1" class="btn-shadow btn btn-primary">แสดงแบบลิสต์รายการ</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body no-padding">
                                        <div class="tab-content">
                                            <div class="tab-pane active" id="tab-eg1-0" role="tabpanel">
                                                <div id="calendar2"></div>
                                            </div>
                                            <div class="tab-pane" id="tab-eg1-1" role="tabpanel">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdEvent" runat="server" CellPadding="0" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%" CssClass="table table-hover" AllowPaging="True">
                                                            <RowStyle HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:BoundField DataField="EventDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่">
                                                                    <ItemStyle Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Descriptions" HeaderText="ชื่อรายการ">
                                                                    <HeaderStyle CssClass="text-left" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle CssClass="dc_pagination dc_paginationC dc_paginationC01" HorizontalAlign="Center" />
                                                            <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="grdEvent" EventName="PageIndexChanging" />
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </div>
            </section>
            <script>
                var options = {
                    series: [<%=hDatachart1 %>],
                    chart: {
                        width: 380,
                        height: 400,
                        type: 'pie',
                        toolbar: {
                            show: true
                        }
                    },
                    labels: ['รับรองแล้ว', 'หมดอายุการรับรอง', 'กำลังยื่นคำขอ'],
                    colors: ['#00E396', '#008FFB', '#FEB019'],
                    legend: {
                        position: 'bottom',
                        horizontalAlign: 'center'
                    },
                    responsive: [{
                        breakpoint: 480,
                        options: {
                            chart: {
                                width: 200
                            },
                            legend: {
                                position: 'bottom',
                                horizontalAlign: 'center'
                            }
                        }
                    }]
                };

                var chart = new ApexCharts(document.querySelector("#piechart"), options);
                chart.render();
            </script>

            <script>
                var options = {
                    series: [{
                        name: '',
                        data: [<%=databarType %>]
                    }],
                    chart: {
                        height: 350,
                        type: 'bar',
                        events: {
                            click: function(chart, w, e) {
                                // console.log(chart, w, e)
                            }
                        }
                    },
                    colors: colors,
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '45%',
                            distributed: true,
                            dataLabels: {
                                position: 'top', // top, center, bottom
                            }
                        }
                    },
                    dataLabels: {
                        enabled: true,
                        offsetX: -1,
                        offsetY: -15,
                        style: {
                            fontSize: '12px',
                            colors: ['#000']
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: [<%=catebarType %>],
                        labels: {
                            style: {
                                colors: colors,
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        axisBorder: {
                            show: true
                        },
                        axisTicks: {
                            show: true,
                        },
                        labels: {
                            show: true,
                            formatter: function(val) {
                                return val;
                            }
                        }

                    }
                };

                var chartT = new ApexCharts(document.querySelector("#chartT"), options);
                chartT.render();
            </script>

            <script>
                var optionsG = {
                    series: [{
                        data: [<%=databarGroup %>]
                    }],
                    chart: {
                        height: 350,
                        type: 'bar',
                        events: {
                            click: function(chart, w, e) {
                                // console.log(chart, w, e)
                            }
                        }
                    },
                    colors: colors,
                    plotOptions: {
                        bar: {
                            horizontal: true,
                            borderRadius: 10,
                            columnWidth: '45%',
                            distributed: true,
                            dataLabels: {
                                position: 'top', // top, center, bottom
                            }
                        }
                    },
                    dataLabels: {
                        enabled: true,
                        offsetX: -1,
                        offsetY: 0,
                        style: {
                            fontSize: '12px',
                            colors: ['#000']
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: [<%=catebarGroup %>],
                        labels: {
                            style: {
                                colors: colors,
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        axisBorder: {
                            show: true
                        },
                        axisTicks: {
                            show: true,
                        },
                        labels: {
                            show: true,
                            formatter: function(val) {
                                return val;
                            }
                        }

                    }
                };

                var chartGroup = new ApexCharts(document.querySelector("#chartGroup"), optionsG);
                chartGroup.render();
            </script>



            <script>
                var options = {
                    series: [{
                        data: [<%=databarNHSO %>]
                    }],
                    chart: {
                        height: 350,
                        type: 'bar',
                        events: {
                            click: function(chart, w, e) {
                                // console.log(chart, w, e)
                            }
                        }
                    },
                    colors: colors,
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '45%',
                            distributed: true,
                            dataLabels: {
                                position: 'top', // top, center, bottom
                            }
                        }
                    },
                    dataLabels: {
                        enabled: true,
                        offsetX: -1,
                        offsetY: -15,
                        style: {
                            fontSize: '12px',
                            colors: ['#000']
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: [<%=catebarNHSO %>],
                        labels: {
                            style: {
                                colors: colors,
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        axisBorder: {
                            show: true
                        },
                        axisTicks: {
                            show: true,
                        },
                        labels: {
                            show: true,
                            formatter: function(val) {
                                return val;
                            }
                        }

                    }
                };

                var chartNHSO = new ApexCharts(document.querySelector("#chartNHSO"), options);
                chartNHSO.render();
            </script>


            <script>
                var options = {
                    series: [{
                        data: [<%=databarChain %>]
                    }],
                    chart: {
                        height: 350,
                        type: 'bar',
                        events: {
                            click: function(chart, w, e) {
                                // console.log(chart, w, e)
                            }
                        }
                    },
                    colors: colors,
                    plotOptions: {
                        bar: {
                            horizontal: true,
                            borderRadius: 10,
                            columnWidth: '45%',
                            distributed: true,
                            dataLabels: {
                                position: 'top', // top, center, bottom
                            }
                        }
                    },
                    dataLabels: {
                        enabled: true,
                        offsetX: -1,
                        offsetY: 0,
                        style: {
                            fontSize: '12px',
                            colors: ['#000']
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: [<%=catebarChain %>],
                        labels: {
                            style: {
                                colors: colors,
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        axisBorder: {
                            show: true
                        },
                        axisTicks: {
                            show: true,
                        },
                        labels: {
                            show: true,
                            formatter: function(val) {
                                return val;
                            }
                        }

                    }
                };

                var chartChain = new ApexCharts(document.querySelector("#chartChain"), options);
                chartChain.render();
            </script>


        </asp:Content>