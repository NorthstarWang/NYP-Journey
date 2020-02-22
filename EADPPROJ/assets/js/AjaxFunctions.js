//Global variables
var timeID;
var refreshRate = 2000; // two seconds
var rnd = Math.random();

var isFirefox;
var isIE;

//var XmlHttp;
var AjaxServerPageName;
AjaxServerPageName = "Server.aspx";

//Creating and setting the instance of appropriate XMLHTTP Request object to a “XmlHttp?variable  
function getAjax()
{
	var XmlHttp;
	
	//Creating object of XMLHTTP in IE
	try
	{
		XmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
	}
	catch(e)
	{
		try
		{
			XmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
		} 
		catch(oc)
		{
			XmlHttp = null;
		}
	}
	//Creating object of XMLHTTP in Mozilla and Safari 
	if(!XmlHttp && typeof XMLHttpRequest != "undefined") 
	{
		XmlHttp = new XMLHttpRequest();
	}
	return XmlHttp;
}

// Get browser type
function sniffBrowserType() {
	isFirefox = ( navigator.appName == "Netscape" );
	isIE = (navigator.appName == "Microsoft Internet Explorer" ); 
}


// Capture the enter key on the input box and post message
function captureReturn( event )
{
	if(event.which || event.keyCode)
	{
		if ((event.which == 13) || (event.keyCode == 13)) 
		{
			postText();
			return false;
		}
		else {
			return true;
		}
	}	
}

// Start the update timer
function setTimers()
{
	timeID = window.setTimeout( "updateAll()", refreshRate );
}

// Start to update and reset the update timer
function updateAll()
{
	window.clearTimeout( timeID );
	getUserList();
	setTimers();
}

function getUserList()
{
	rnd++;
	url = 'Server.aspx?action=UserList&session=' + rnd;
	req = getAjax();

	req.onreadystatechange = function(){
	
		if( req.readyState == 4 && req.status == 200 ) {
		
			obj = getElement( "userlist" );
			obj.innerHTML = req.responseText;
			getBufferText();
		}
	
	}
	
	req.open( 'GET', url, true );
	req.send( null );
}

function getBufferText()
{
    rnd++;
	url = 'Server.aspx?action=GetMsg&session=' + rnd;
	req = getAjax();
	
	req.onreadystatechange = function(){
	
		if( req.readyState == 4 && req.status == 200 ) {
		
			obj = getElement( "chatbuffer" );
			obj.innerHTML = req.responseText;
			scrollChatPane();
			//FocusWindow();
		}
	}
	
	req.open( 'GET', url , true );
	req.send( null );
}

function postText()
{
	rnd++;
	chatbox = getElement( "mytext" );
	chat = chatbox.value;
	chatbox.value = "";
	
	userid = location.search.substring( 1, location.search.length );
	url = 'Server.aspx?action=PostMsg&u=' + userid + '&t=' + encodeURIComponent(chat) + '&session=' + rnd;
	
	req = getAjax();
	
	req.onreadystatechange = function(){
	
		if( req.readyState == 4 && req.status == 200 ) {
			updateAll();
		}
	
	}
	
	req.open( 'GET', url, true );
	req.send( null );
}

function getElement( id ) 
{
	if( isIE ) {
		return document.all[ id ];
	}
	else {
		return document.getElementById( id );
	}
}

function showLoadScreen()
{
	var loading = "<div style=\"text-align:center;color:red;\"><h5>Loading...</h5></div>";

	chat = getElement( "chatbuffer" );
	chat.innerHTML = loading;
	
	user = getElement( "userlist" );
	user.innerHTML = loading;
}

function scrollChatPane()
{
	var obj = document.getElementById("chatpane");
	obj.scrollTop = obj.scrollHeight;
}

function setFocus(ControlName)
{
	var control = document.getElementById(ControlName);
	if( control != null )
	{
		control.focus();
	}
}
function FocusWindow()
{

	//TODO: FireFox doesn't work?
	window.focus();

}