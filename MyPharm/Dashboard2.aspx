<%@ Page Title="Dashboard" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dashboard2.aspx.vb" Inherits="CPA.Dashboard2" %>

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
                                    <div class="page-title-subheading">ระบบฐานข้อมูลร้านยา</div>
                </div>
            </div>
        </div>
    </div>

    <!-- Main content -->
    <section class="content">

        <h5>จำนวนร้านแยกตามประเภท</h5>
        <div class="row">
            <div class="col-lg-6 col-xl-6 connectedSortable">
                <div class="row">
                    <div class="col-md-12 col-lg-12 col-xl-12">
                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ภาพรวมร้านยาแยกตามประเภท        
                            </div>
                            <div class="card-body">
                                <div id="chartA"></div>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
            <div class="col-lg-6 col-xl-6 connectedSortable">
                <div class="row">
                    <div class="col-md-6 col-lg-3 col-xl-6">
                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ร้านยาหน่วยร่วมบริการ สปสช.              
                            </div>
                            <div class="card-body">
                                <div id="piechart1"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-3 col-xl-6">

                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ร้านยาเครือข่ายสำนักอนามัย กทม.              
                            </div>
                            <div class="card-body">
                                <div id="piechart2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-3 col-xl-6">

                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ร้านยาสร้างเสริมสุขภาพ  สสส.          
                            </div>
                            <div class="card-body">
                                <div id="piechart3"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-3 col-xl-6">

                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ร้านยาเลิกบุหรี่           
                            </div>
                            <div class="card-body">
                                <div id="piechart4"></div>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
        <div class="row">

            <div class="col-lg-6 col-xl-6 connectedSortable">
                <div class="row">
                 
 <div class="col-md-6 col-lg-3 col-xl-6">

                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ร้านยาแจก ATK          
                            </div>
                            <div class="card-body">
                                <div id="piechart6"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-3 col-xl-6">

                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ร้านยา เจอ แจก จบ (SI )            
                            </div>
                            <div class="card-body">
                                <div id="piechart7"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-xl-6 connectedSortable">
                <div class="row">
                      <div class="col-md-6 col-lg-3 col-xl-6">
                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ร้านยาแจกยาคุม ถุงยาง            
                            </div>
                            <div class="card-body">
                                <div id="piechart5"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <script>
        var options = {
            series: [<%=databarType2 %>],
         chart: {
             width: 500,
             height: 565,
             type: 'pie',
             toolbar: {
                 show: true
             }
         },
         labels: [<%=catebarType2 %>],
            colors: colors,
            legend: {
                fontSize: '12px',
                fontFamily: 'Sarabun, Arial, sans-serif',
                position: 'bottom',
                horizontalAlign: 'center'
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

        var chart = new ApexCharts(document.querySelector("#chartA"), options);
        chart.render();
    </script>

    <script>      
        var options = {
            series: [<%=hDatachart1 %>],
            chart: {
                width: 300,
                height: 240,
                type: 'pie',
                toolbar: {
                    show: true
                }
            },
            labels: ['ร้านยาหน่วยร่วมบริการ สปสช.', 'ร้านยาทั้งหมด'],
            colors: ['#00E396', '#008FFB'],
            legend: {
                position: 'bottom',
                horizontalAlign: 'center'
            },
            responsive: [{
                breakpoint: 300,
                options: {
                    chart: {
                        width: 300
                    },
                    legend: {
                        position: 'bottom',
                        horizontalAlign: 'center'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#piechart1"), options);
        chart.render();

    </script>

    <script>      
        var options = {
            series: [<%=hDatachart2 %>],
            chart: {
                width: 300,
                height: 240,
                type: 'pie',
                toolbar: {
                    show: true
                }
            },
            labels: ['ร้านยาเครือข่ายสำนักอนามัย กทม.', 'ร้านยาทั้งหมด'],
            colors: ['#FEB019', '#008FFB'],
            legend: {
                position: 'bottom',
                horizontalAlign: 'center'
            },
            responsive: [{
                breakpoint: 300,
                options: {
                    chart: {
                        width: 300
                    },
                    legend: {
                        position: 'bottom',
                        horizontalAlign: 'center'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#piechart2"), options);
        chart.render();

    </script>


    <script>      
        var options = {
            series: [<%=hDatachart3 %>],
            chart: {
                width: 300,
                height: 240,
                type: 'pie',
                toolbar: {
                    show: true
                }
            },
            labels: ['ร้านยาสร้างเสริมสุขภาพ  สสส.', 'ร้านยาทั้งหมด'],
            colors: ['#FF4560', '#008FFB'],
            legend: {
                position: 'bottom',
                horizontalAlign: 'center'
            },
            responsive: [{
                breakpoint: 300,
                options: {
                    chart: {
                        width: 300
                    },
                    legend: {
                        position: 'bottom',
                        horizontalAlign: 'center'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#piechart3"), options);
        chart.render();

    </script>


    <script>      
        var options = {
            series: [<%=hDatachart4 %>],
            chart: {
                width: 300,
                height: 240,
                type: 'pie',
                toolbar: {
                    show: true
                }
            },
            labels: ['ร้านยาเลิกบุหรี่', 'ร้านยาทั้งหมด'],
            colors: ['#775DD0', '#008FFB'],
            legend: {
                position: 'bottom',
                horizontalAlign: 'center'
            },
            responsive: [{
                breakpoint: 300,
                options: {
                    chart: {
                        width: 300
                    },
                    legend: {
                        position: 'bottom',
                        horizontalAlign: 'center'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#piechart4"), options);
        chart.render();

    </script>

    <script>      
        var options = {
            series: [<%=hDatachart5 %>],
            chart: {
                width: 300,
                height: 240,
                type: 'pie',
                toolbar: {
                    show: true
                }
            },
            labels: ['ร้านยาแจกยาคุม ถุงยาง', 'ร้านยาทั้งหมด'],
            colors: ['#546E7A', '#008FFB'],
            legend: {
                position: 'bottom',
                horizontalAlign: 'center'
            },
            responsive: [{
                breakpoint: 300,
                options: {
                    chart: {
                        width: 300
                    },
                    legend: {
                        position: 'bottom',
                        horizontalAlign: 'center'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#piechart5"), options);
        chart.render();

    </script>

    <script>      
        var options = {
            series: [<%=hDatachart6 %>],
            chart: {
                width: 300,
                height: 240,
                type: 'pie',
                toolbar: {
                    show: true
                }
            },
            labels: ['ร้านยาแจก ATK', 'ร้านยาทั้งหมด'],
            colors: ['#26a69a', '#008FFB'],
            legend: {
                position: 'bottom',
                horizontalAlign: 'center'
            },
            responsive: [{
                breakpoint: 300,
                options: {
                    chart: {
                        width: 300
                    },
                    legend: {
                        position: 'bottom',
                        horizontalAlign: 'center'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#piechart6"), options);
        chart.render();

    </script>

    <script>      
        var options = {
            series: [<%=hDatachart7 %>],
            chart: {
                width: 300,
                height: 240,
                type: 'pie',
                toolbar: {
                    show: true
                }
            },
            labels: ['ร้านยา เจอ แจก จบ (SI )', 'ร้านยาทั้งหมด'],
            colors: ['#D10CE8', '#008FFB'],
            legend: {
                position: 'bottom',
                horizontalAlign: 'center'
            },
            responsive: [{
                breakpoint: 300,
                options: {
                    chart: {
                        width: 300
                    },
                    legend: {
                        position: 'bottom',
                        horizontalAlign: 'center'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#piechart7"), options);
        chart.render();

    </script>

</asp:Content>
