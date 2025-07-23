<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Maps2.aspx.vb" Inherits="CPAQA.Maps2" %> 
<%@ Import Namespace="System.Data" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
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
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">  
       <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-map-marker icon-gradient bg-success"></i>
                </div>
                <div>
                   แผนที่ตั้งร้านยา
                </div>
            </div>
        </div>
    </div>
     
    <section class="content">

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
                            <label>จังหวัด</label>
                            <br />
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

        </section>
    <script> 
      function initMap() {
			var mapOptions = {
                center: { lat: <% =String.Concat(dtPv.Rows(0)("Lat")) %>, lng: <% =String.Concat(dtPv.Rows(0)("Lng")) %>},
			  zoom: 11,
			}				
			var maps = new google.maps.Map(document.getElementById("map"),mapOptions);			
			var marker, i, info;
			<% For Each row As DataRow In dtMap.Rows %>  
				marker = new google.maps.Marker({
                position: new google.maps.LatLng(<% =String.Concat(row("Lat")) %>,<% =String.Concat(row("Lng")) %>),
				map: maps,
                    title: '<% =String.Concat(row("LocationName")) %>',
                    icon: '<% =String.Concat(row("icon")) %>'
                });

				info = new google.maps.InfoWindow();
				google.maps.event.addListener(marker, 'click', (function(marker, i) {
					return function() {
                    info.setContent('<% =String.Concat(row("LocationName")) %>');
					info.open(maps, marker);
					}
				 })(marker, i));				 
			<% Next %>
		}
    </script>  
</asp:Content>
