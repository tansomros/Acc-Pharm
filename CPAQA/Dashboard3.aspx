<%@ Page Title="Dashboard" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dashboard3.aspx.vb" Inherits="CPAQA.Dashboard3" %>

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
                                    <div class="page-title-subheading">Process Performance</div>
                </div>
            </div>
        </div>
    </div>

    <!-- Main content -->
    <section class="content">

        <div class="row">
            <div class="col-lg-12 connectedSortable">
   <div class="row">
                    <div class="col-md-12 col-lg-12 col-xl-12">
                       
        <div class="box box-solid">
             <div class="box-header">
              <i class="fa fa-filter"></i>
              <h3 class="box-title">ค้นหา</h3>   
                  <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-6 col-md-3 col-xl-3">
                        <div class="form-group">
                            <label>Start Date</label>
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control text-center"
                                    autocomplete="off" data-date-format="dd/mm/yyyy"
                                    data-date-language="th-th" data-provide="datepicker"
                                    onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-6 col-md-3 col-xl-3">
                        <div class="form-group">
                            <label>End Date</label>
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control text-center"
                                    autocomplete="off" data-date-format="dd/mm/yyyy"
                                    data-date-language="th-th" data-provide="datepicker"
                                    onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="col-lg-6 col-md-3 col-xl-3">
                         <br />
                        <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-success" Width="120px"><i class="fa fa-search"></i>View</asp:LinkButton>
                </div> 
            </div>
      </div>
                </div>
 </div>

                </div>
                <div class="row">
                    <div class="col-md-12 col-lg-12 col-xl-12">
                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ระยะเวลาการดำเนินการเฉลี่ย            
                            </div>
                            <div class="card-body">
                                <div id="chartA"></div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12 col-lg-12 col-xl-12">
                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                คำอธิบาย            
                            </div>
                            <div class="card-body">
                                <div class="col-md-12">
                                    <div class="mb-2 mr-2 badge badge-dot badge-dot-lg" style="background: #008FFB !important; color: #fff; border-color: #008FFB;">R2A</div>
                                    ระยะเวลาจากส่งคำขอพิจารณา ถึง นัดสัมภาษณ์ 
                   
                                    <div class="mb-2 mr-2 badge badge-dot badge-dot-lg" style="background: #FEB019 !important; color: #fff; border-color: #FEB019;">A2S</div>
                                    ระยะเวลาจากนัดสัมภาษณ์ ถึง ผ่านการประเมินโดยผู้ตรวจ 
                   
                                    <div class="mb-2 mr-2 badge badge-dot badge-dot-lg" style="background: #00E396 !important; color: #fff; border-color: #00E396;">S2P</div>
                                    ระยะเวลาจากผ่านการประเมินโดยผู้ตรวจ ถึง ผ่านคณะกรรมการรับรอง
             
                                    <br />
                                    <div class="mb-2 mr-2 badge badge-dot badge-dot-lg" style="background: #FF4560 !important; color: #fff; border-color: #FF4560;">R2S</div>
                                    ระยะเวลาจากส่งคำขอพิจารณา ถึง ผ่านการประเมินโดยผู้ตรวจ
                   
                                    <div class="mb-2 mr-2 badge badge-dot badge-dot-lg" style="background: #775DD0 !important; color: #fff; border-color: #775DD0;">R2P</div>
                                    ระยะเวลาจากส่งคำขอพิจารณา ถึง ผ่านคณะกรรมการรับรอง            
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12 col-lg-12 col-xl-12">
                        <div class="main-card mb-3 card">
                            <div class="card-header h3">
                                ระยะเวลาการดำเนินการเฉลี่ย        
                                <div class="btn-actions-pane-right">
                                  <asp:LinkButton ID="cmdExport" runat="server" CssClass="btn btn-success" Width="120px"><i class="fa fa-file-excel"></i>Export</asp:LinkButton>
                                </div>
                            </div>
                            <div class="card-body">
                                <table id="tbdata" class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th class="text-center" rowspan="2">No.</th>
                                            <th class="text-center" rowspan="2">เดือน</th>
                                            <th class="text-center" colspan="5">จำนวนวันดำเนินการเฉลี่ย</th> 
                                        </tr>
                                         <tr> 
                                            <th class="text-left">R2A</th>
                                            <th class="text-center">A2S</th>
                                            <th class="text-center">S2P</th>
                                            <th class="text-center">R2S</th> 
                                            <th class="text-center">R2P</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <% For Each row As DataRow In dtRpt.Rows %>
                                        <tr>
                                            <td class="text-center"><% =String.Concat(row("nRow")) %></td>
                                            <td class="text-center"><% =String.Concat(row("txtMonth")) %></td>
                                            <td class="text-center"><% =String.Concat(row("R2A")) %></td>
                                            <td class="text-center"><% =String.Concat(row("A2S")) %> </td>
                                            <td class="text-center"><% =String.Concat(row("S2P")) %></td>
                                            <td class="text-center"><% =String.Concat(row("R2S")) %></td>
                                            <td class="text-center"><% =String.Concat(row("R2P")) %></td>
                                        </tr>
                                        <%  Next %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>

    <script>
        var options = {
            series: [<%=dataValue %>],
         chart: {
             height: 350,
             type: 'line',
             dropShadow: {
                 enabled: true,
                 color: '#000',
                 top: 18,
                 left: 7,
                 blur: 10,
                 opacity: 0.2
             },
             toolbar: {
                 show: true
             }
         },

         dataLabels: {
             enabled: true,
         },
         stroke: {
             curve: 'smooth'
         },
         title: {
             text: 'Average Time to Process Performance',
             align: 'left'
         },
         grid: {
             borderColor: '#e7e7e7',
             row: {
                 colors: ['#f3f3f3', 'transparent'], // takes an array which will be repeated on columns
                 opacity: 0.5
             },
         },
         markers: {
             size: 1
         },
         xaxis: {
             categories: [<%=cateName %>],
                title: {
                    text: 'เดือน'
                }
            },
            yaxis: {
                title: {
                    text: 'Average Day'
                },
                min: 1
            },
            legend: {
                fontSize: '12px',
                fontFamily: 'Sarabun, Arial, sans-serif',
                fontWeight: 600,
                position: 'top',
                horizontalAlign: 'center',
                floating: true,
                offsetY: -25,
                offsetX: -5
            }
        };

        var chart = new ApexCharts(document.querySelector("#chartA"), options);
        chart.render();
    </script>
</asp:Content>
