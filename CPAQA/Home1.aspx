<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home1.aspx.vb" Inherits="CPAQA.Home1" %>
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
      '#00E396',
      '#FEB019',
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
                                <div>Dashboard
                                    <div class="page-title-subheading">ระบบประเมินร้านยาคุณภาพ</div>
                                </div>
                            </div>
                        </div>
                    </div>

  <!-- Main content -->
  <section class="content">  
      <h5>จำนวนกฎหมายที่เกี่ยวข้อง</h5>
    <div class="row">     
   
        <section class="col-lg-6 connectedSortable">
  <div class="main-card mb-3 card">
                                            <div class="card-body">                                             
                                                <h5 class="card-title">แยกตามประเภท</h5>
                                                <div id="chart"></div>
                                            </div>
                                        </div>
            </section>
         <section class="col-lg-6 connectedSortable">
        <div class="main-card mb-3 card">
          <div class="card-body">
            <!-- THE CALENDAR -->
            <div id="calendar2"></div>
          </div>
        </div>
      </section>
        </div> 
</section> 
     
    <script>
      
        var options = {
            series: [{
              name:'',
          data: [<%=databar1 %>]
        }],
          chart: {
          height: 410,
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
            offsetX: -6,          
          style: {
            fontSize: '12px',
            colors: ['#fff']
          }
        },
        legend: {
          show: false
        },
        xaxis: {
          categories: [<%=catebar1 %>],
          labels: {
            style: {
              colors: colors,
              fontSize: '14px'
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

        var chart = new ApexCharts(document.querySelector("#chart"), options);
        chart.render();                  
      
      
    </script>
    
</asp:Content>