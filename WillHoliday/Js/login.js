//Engloba todos los javascripts de la pagina Login.aspx

//INICIO Facebook Login
// This function is called when someone finishes with the Login
// Button.  See the onlogin handler attached to it in the sample
// code below.
function checkLoginState() {
    FB.getLoginStatus(function(response) {
        statusChangeCallback(response);
    });
}


// This is called with the results from from FB.getLoginStatus().
function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        loginSuccessful();
    } else if (response.status === 'not_authorized') {
        // The person is logged into Facebook, but not your app.
        document.getElementById('status').innerHTML = 'Please log ' +
        'into this app.';
    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
        document.getElementById('status').innerHTML = 'Please log ' +
        'into Facebook.';
    }
}

window.fbAsyncInit = function() {
    FB.init({
    appId: '1066772186673164',
        cookie: true,  // enable cookies to allow the server to access
        // the session
        xfbml: true,  // parse social plugins on this page
        version: 'v2.1' // use version 2.1
    });

    // Now that we've initialized the JavaScript SDK, we call 
    // FB.getLoginStatus().  This function gets the state of the
    // person visiting this page and can return one of three states to
    // the callback you provide.  They can be:
    //
    // 1. Logged into Facebook and into your app ('connected')
    // 2. Logged into Facebook, but not your app ('not_authorized')
    // 3. Not logged into Facebook and can't tell if they are logged into
    //    your app or not.
    //
    // These three cases are handled in the callback function.

    FB.getLoginStatus(function(response) {
        statusChangeCallback(response);
    });

};

// Load the SDK asynchronously
(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/es_LA/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
} (document, 'script', 'facebook-jssdk'));

// Here we run a very simple test of the Graph API after login is
// successful.  See statusChangeCallback() for when this call is made.
function loginSuccessful() {
    console.log('Bienvenido!  Buscando su informacion.... ');
    FB.api('/me', function FacebookLogin(response) {
        //hago la llamada ajax al code behing para redireccionar a la home
        var dataValue = "{facebookUserId: '" + response.id.toString() + "' , first_name: '" + response.first_name + "' , last_name: '" + response.last_name + "' , gender: '" + response.gender + "' , email: '" + response.email + "' }";
        $.ajax({
            type: "POST",
            url: "login.aspx/LoginWithFacebook",
            data: dataValue,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function(result) {
            window.location = "Home.aspx";
            }
        });
    });
}
//FIN Facebook Login

//INICIO Google Login

function signinCallback(authResult) {
    if (authResult['access_token']) {
        document.getElementById('signinButton').setAttribute('style', 'display: none');
        console.log('Oculta el inicio de sesión si se ha accedido correctamente.');
        // Activa la solicitud para obtener la dirección de correo electrónico.
         gapi.client.load('oauth2', 'v2', function() {
          var request = gapi.client.oauth2.userinfo.get();
            request.execute(getEmailCallback);
        });
/*
        
  */      
    } else if (authResult['error']) {
        // Se ha producido un error.
        // Posibles códigos de error:
        //   "access_denied": el usuario ha denegado el acceso a la aplicación.
        //   "immediate_failed": no se ha podido dar acceso al usuario de forma automática.
        // console.log('There was an error: ' + authResult['error']);
    }
}


function getEmailCallback(obj)
{
if (obj['email']) {
    //Envio los datos al servidor.
     var dataValue = "{email: '" + obj['email']+ "' }";
        $.ajax({
            type: "POST",
            url: "login.aspx/LoginWithGoogle",
            data: dataValue,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function(result) {
            window.location = "Home.aspx";
            }
        });
    }
}


function disconnectUser(access_token) {
  var revokeUrl = 'https://accounts.google.com/o/oauth2/revoke?token=' +
      access_token;

  // Realiza una solicitud GET asíncrona.
  $.ajax({
    type: 'GET',
    url: revokeUrl,
    async: false,
    contentType: "application/json",
    dataType: 'jsonp',
    success: function(nullResponse) {
      // Lleva a cabo una acción ahora que el usuario está desconectado
      // La respuesta siempre está indefinida.
    },
    error: function(e) {
      // Gestiona el error
      // console.log(e);
      // Puedes indicar a los usuarios que se desconecten de forma manual si se produce un error
      // https://plus.google.com/apps
    }
  });
}

(function() {
    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
    po.src = 'https://apis.google.com/js/client:plusone.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
    $('#revokeButton').click(disconnectUser);
})();
//FIN Google Login


