<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WillHoliday.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Inicio</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
      html { height: 100% }
      body { height: 100%; margin: 0; padding: 0 }
      #map_canvas { height: 100% }
    </style>
    <script type="text/javascript"
      src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCzFkQwEgUxeyBezLNLeOfmXioaFLNO8Mc&sensor=TRUE">
    </script>
    <script type="text/javascript">
      function initialize() {
        var mapOptions = {
        center: new google.maps.LatLng(-34.612029, -58.389959),
          zoom: 2,
          mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("map_canvas"),
            mapOptions);

        // Agrego un marcador en Buenos Aires
        var marker = new google.maps.Marker({
        position: new google.maps.LatLng(-34.6158533, -58.4332985), //https://developers.google.com/maps/documentation/javascript/markers
        map: map,
        animation: google.maps.Animation.DROP,

            title: "¡Buenos Aires, Argentina!"
        });
        
        var infowindow = new google.maps.InfoWindow({
        content: 'Información del destino:</br>  Pais: "Argentina"</br>  Ciudad: Buenos Aires'
        });
        google.maps.event.addListener(marker, 'click', function () {
        // Calling the open method of the infoWindow 
        infowindow.open(map, marker);
});
    }
      
    </script>
  </head>
<body onload="initialize()">
<form id="form1" runat="server" style="width:100%; height:100%">
    <div>
        <asp:Button ID="btnLogout" runat="server" Text="Log out" OnClick="btnLogout_onclick" />
    </div>
    <div id="map_canvas" style="width:100%; height:100%"></div>
    </form>
    
  </body>

</html>
