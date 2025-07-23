<%@ Page Title="" Language="vb" AutoEventWireup="false"  CodeBehind="Maps.aspx.vb" Inherits="CPAQA.Maps" %> 
<%@ Import Namespace="System.Data" %>  

    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <title>แผนที่ตั้งร้านยา สภาเภสัชกรรรม</title>
        <link href="https://fonts.googleapis.com/css?family=Sarabun:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <!-- Bootstrap 3.3.7 
  < link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min.css">-->
        <!-- Font Awesome -->
        <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css" />
        <!-- Ionicons -->
        <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css" />
        <!-- Theme style -->
        <link rel="stylesheet" href="assets/css/AdminLTE.min.css" />
        <link rel="stylesheet" href="css/rajchasistyles.css" />
        
	<link href="css/main.css" rel="stylesheet">
	<link href="css/rajchasistyles.css" rel="stylesheet">

        <!-- Google Font -->
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />         
        <link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min-login.css" />
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script> 
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>   

        	<!-- Select2 -->
	<link rel="stylesheet" href="bower_components/select2/assets/css/select2.min.css">

      <!-- Maps -->
         <script async defer  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBfMj6L9aj4d2o6a_vxYVLYC2nrwnCjXFg&callback=initMap"></script>
	<style>
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 100%;
      }
      /* Optional: Makes the sample page fill the window. */
      html {
        height: 100%;
        margin: 0;
        padding: 0;
		text-align: center;
      }
      #map {		 
        height: 600px;
        width: 100%;
      }
    </style>
     <!-- End Maps -->
    </head>
    <body>
        <form id="form1" class="user" runat="server">
            <div class="container-login">
                <div class="row">
                    <section class="col-lg-12 connectedSortable">
                        <div class="row">
                            <div class="col-md-9">
                                <table>
                                    <tr>
                                        <td class="logo">
                                            <img src="images/logo2p.png" alt="" width="150" />
                                        </td>
                                        <td>
                                            <div class="header-logo">ร้านยาสภาเภสัชกรรม</div>
                                            <div class="header-appname">
                                                
                                            </div>
                                            <div class="header-text">The Pharmacy Council (Thailand)
                                            </div>
                                        </td> 
                                    </tr>
                                </table>
                            </div> 
                              <div class="col-md-3 text-right pull-right bottom">
                                 <br />  <br />  <br />
                                  
                                  </div>
                        </div>
                    </section>
                </div>
                <div class="row">               
    <section class="col-lg-12 connectedSortable">   
          <div class="justify-content-center">
                            <div class="col-lg-12 my-3">                               
          
           
     <div class="box box-solid">          
            <div class="box-body">
                <div class="row">
                  <div class="col-lg-6 col-md-3 col-xl-3">
                        <div class="form-group">
                            <i class="fa fa-map"></i>  <label>แผนที่ตั้งร้านยา</label>                        
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>                    
                  <div class="col-lg-6 col-md-2 col-xl-2">
                      <br />
                        <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-success" Width="100px">Reload</asp:LinkButton>
                    </div>
                       <div class="col-lg-12 col-md-12 col-xl-6">
                        <div class="form-group">
                            <label>คำอธิบาย</label>   <br />
                            <img src="images/acc_icon.png" /> คือ ร้านยาคุณภาพ
                             <img src="images/pa_icon.png" /> คือ ร้านยาทั่วไป (ไม่ใช่ร้านยาคุณภาพ)
                        </div>
                    </div>  
                </div>
            </div>
        </div>
  <div id="map"></div>
               
                            </div>
                        </div> 
 </section>
                </div>
                           
                <div class="footer text-center">
                    <footer class="main-footer-login">
                        <div class="text-center hidden-xs">
                            <strong>Copyright &copy; 2022-2024 <a href="https://papc.pharmacycouncil.org">สภาเภสัชกรรม</a>.</strong> All rights reserved.
                        </div>
                    </footer>
                </div>
            </div>

        </form>

        <!-- jQuery 3 
        <script src="bower_components/jquery/assets/jquery.min.js"></script>-->
        <!-- Bootstrap 3.3.7 -->
        <script src="bower_components/bootstrap/assets/js/bootstrap.min.js"></script>
    
      	<!-- Select2 -->
	<script src="bower_components/select2/assets/js/select2.full.min.js"></script>

	<script>
        $(function () {
            $('.select2').select2()
        })
    </script>        
    <script> 
        function initMap() {
            var mapOptions = {
                center: { lat: <% =String.Concat(dtPv.Rows(0)("Lat")) %>, lng: <% =String.Concat(dtPv.Rows(0)("Lng")) %>},
              zoom: 11,
          }
          var maps = new google.maps.Map(document.getElementById("map"), mapOptions);
          var marker, i, info;
			<% For Each row As DataRow In dtMap.Rows %>  
          marker = new google.maps.Marker({
              position: new google.maps.LatLng(<% =String.Concat(row("Lat")) %>,<% =String.Concat(row("Lng")) %>),
                    map: maps,
                    title: '<% =String.Concat(row("LocationName")) %>',
                    icon: '<% =String.Concat(row("icon")) %>'
                });

          info = new google.maps.InfoWindow();
          google.maps.event.addListener(marker, 'click', (function (marker, i) {
              return function () {
                  info.setContent('<% =String.Concat(row("LocationName")) %>');
                        info.open(maps, marker);
                    }
                })(marker, i));
			<% Next %>
        }
    </script>  
    </body>

    </html>
