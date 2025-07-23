<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Maps.aspx.vb" Inherits="CPA.Maps" %> 
<%@ Import Namespace="System.Data" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
	
     <script async defer  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDx38-CFgM3RndsCRoow9BG5TZgBVSa-wY&callback=initMap"></script> 

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
		  /*
        height: 500px;
        width: 600px;*/
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">  
  <div id="map"></div>
    <script> 
      function initMap() {
			var mapOptions = {
                center: { lat: 13.77744, lng: 100.53934},
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
