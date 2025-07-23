<%@ Page Title="Home" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dashboard.aspx.vb" Inherits="CPAQA.Dashboard" %>
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
        Math.random = function () {
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
        

        <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <> 1 Then %>
        <h5>จำนวนร้านยา</h5>
        <div class="row">
            <section class="col-lg-6 connectedSortable">

                <div class="main-card mb-3 card">
                    <div class="card-header h3">
                        แยกตามสถานะร้านยา              
                    </div>
                    <div class="card-body">
                        <div id="dnchart"></div>
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
                                            <td class="text-center"><% =String.Concat(row("ProvinceName")) %></td>
                                            <td class="text-center"><% =String.Concat(row("ProvinceGroupName")) %></td>
                                            <td class="text-center"><% =String.Concat(row("Lcount")) %></td>
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
                                    <td class="text-left"><a target="_blank" href='<% Response.Write(dtNew.Rows(i)("NewsLink")) %>' title='<% Response.Write(dtNew.Rows(i)("NewsHead")) %>'><% Response.Write(dtNew.Rows(i)("NewsHead")) %></a></td>
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
               
            </section>
            <section class="col-lg-6 connectedSortable">
                 <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 Then %>
              <div class="main-card mb-3 card">
                    <div class="card-header h3">
                        คู่มือการใช้งาน          
                    </div>
                    <div class="card-body">
                      <table class="table table-hover">
                            <tbody>
                                <tr>
                                    <td class="text-center" width="30">
                                        <img src="images/pdf_download.png?v=01" width="20" /></td>
                                    <td class="text-left"><a href="documents/ManualDataCollector.pdf" target="_blank">คู่มือการใช้งาน</a></td>
                                </tr>
                                <tr>
                                    <td class="text-center" width="30">
                                        <img src="images/www.png?v=01" width="20" /></td>
                                    <td class="text-left"><a href="https://www.acc-pharm.com/NewsDetail?NewsID=11" target="_blank">วิธี Clear Cache บาวเซอร์ (สำหรับ google chrome)</a></td>
                                </tr>    
                                <tr>
                                    <td class="text-center" width="30">
                                        <img src="images/youtube.png?v=01" width="20" /></td>
                                    <td class="text-left"><a href="https://www.acc-pharm.com/Documents/UploadPicByiPhone.mp4" target="_blank">วิธีลดขนาดไฟล์ภาพ ก่อนอัพโหลดด้วย iPhone / iPad</a></td>
                                </tr>
                                <tr>
                                    <td class="text-center" width="30">
                                        <img src="images/www.png?v=01" width="20" /></td>
                                    <td class="text-left"><a href="https://www.acc-pharm.com/NewsDetail?NewsID=10" target="_blank">โปรแกรมและวิธีลดขนาดไฟล์ภาพ เพื่อเตรียมภาพก่อนอัพโหลด</a></td>
                                </tr>
                                <tr>
                                    <td class="text-center" width="30">
                                        <img src="images/pdf_download.png?v=01" width="20" /></td>
                                    <td class="text-left"><a href="https://www.acc-pharm.com/ImageNews/9/news_9_25651009015954.pdf" target="_blank">วิธีลดขนาดไฟล์ PDF ให้เล็กลงก่อนอัพโหลด</a></td>
                                </tr>
                            </tbody>
                        </table> 
                    </div>
                </div> 
                <% End If %>
            </section>
        </div>
    </section>

    
 <script>
     var options = {
         series: [<%=Datachart1 %>],
         chart: {
             width: 380,
             height: 400,
             type: 'donut',
             toolbar: {
                 show: true
             }
         },
         labels: ['ร้านยาคุณภาพ', 'ไม่ใช่ร้านยาคุณภาพ'],
         colors: colors,
         legend: {
             position: 'bottom',
             horizontalAlign: 'center',
             fontSize: '14px',
             fontFamily: 'Sarabun, Arial, sans-serif'
         },
         plotOptions: {
             pie: {
                 startAngle: 0,
                 endAngle: 360,
                 expandOnClick: true,
                 offsetX: 0,
                 offsetY: 0,
                 customScale: 1,
                 dataLabels: {
                     offset: 0,
                     minAngleToShowLabel: 10
                 },
                 donut: {
                     size: '45%',
                     background: 'transparent',
                     labels: {
                         show: true,
                         name: {
                             show: true,
                             fontSize: '22px',
                             fontFamily: 'Sarabun, Arial, sans-serif',
                             fontWeight: 600,
                             color: undefined,
                             offsetY: -10,
                             formatter: function (val) {
                                 return val
                             }
                         },
                         value: {
                             show: true,
                             fontSize: '16px',
                             fontFamily: 'Helvetica, Arial, sans-serif',
                             fontWeight: 400,
                             color: undefined,
                             offsetY: 16,
                             formatter: function (val) {
                                 return val
                             }
                         },
                         total: {
                             show: true,
                             showAlways: true,
                             label: 'ร้านยาทั้งหมด',
                             fontSize: '16px',
                             fontFamily: 'Sarabun, Arial, sans-serif',
                             fontWeight: 600,
                             color: '#373d3f',
                             formatter: function (w) {
                                 return w.globals.seriesTotals.reduce((a, b) => {
                                     return a + b
                                 }, 0)
                             }
                         }
                     }
                 },
             }
         },


         responsive: [{
             breakpoint: 480,
             options: {
                 chart: {
                     width: 200
                 },
                 legend: {
                     position: 'bottom'
                 }
             }
         }]
     };

     var chart = new ApexCharts(document.querySelector("#dnchart"), options);
     chart.render();
 </script>

<!--    <script>      
        var options = {
            series: [< %=hDatachart1 % >],
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

    </script>-->

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
                    click: function (chart, w, e) {
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
                    formatter: function (val) {
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
                    click: function (chart, w, e) {
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
                    formatter: function (val) {
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
                    click: function (chart, w, e) {
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
                    formatter: function (val) {
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
                    click: function (chart, w, e) {
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
                    formatter: function (val) {
                        return val;
                    }
                }

            }
        };

        var chartChain = new ApexCharts(document.querySelector("#chartChain"), options);
        chartChain.render();
    </script>

</asp:Content>
