<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EADPPROJ.login" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- Favicons -->
    <link rel="apple-touch-icon" href="../assets/img/apple-icon.png">
    <link rel="icon" href="../assets/img/favicon.png">
    <title>
        Login
    </title>
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../assets/css/material-kit.css?v=2.0.3">
</head>

<body class="login-page ">
    <nav class="navbar navbar-color-on-scroll navbar-transparent fixed-top navbar-expand-lg " color-on-scroll="50" id="sectionsNav">
        <div class="container">
            <div class="navbar-translate">
                <a class="navbar-brand" href="./index.aspx">Education System</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                    <span class="navbar-toggler-icon"></span>
                    <span class="navbar-toggler-icon"></span>
                </button>
            </div>
        </div>
    </nav>
     <div class="modal fade" id="loginErrorModal" tabindex="-1" role="dialog" aria-labelledby="loginErrorModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="loginModalLabel">Identify Error</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        Please check your username and password.
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
    <div class="page-header header-filter" style="background-image: url(&apos;assets/img/NYPheader2.jpg&apos;); background-size: cover; background-position: top center;">
        <div class="container">
            <form runat="server">
            <div class="row">
                <div class="col-md-4 col-sm-6 ml-auto mr-auto">
                    <div class="card card-signup">
                            <div class="card-header card-header-primary text-center">
                                <h4 class="card-title">Log in</h4>
                            </div>
                            <div class="card-body">
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="material-icons">face</i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="username" class="form-control" placeholder="NRIC/FIN/Admin Number..." runat="server"></asp:TextBox>
                                    
                                </div>
                                    <div class="input-group-prepend" >
                                        <asp:RequiredFieldValidator ID="usernameValidate" ValidationGroup='login' style="margin:auto" runat="server" ErrorMessage="Username Required" ControlToValidate="username" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                <div class="input-group" style="margin:20px 0px">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="material-icons">lock_outline</i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="password"  type="password" class="form-control" placeholder="Password..." runat="server"></asp:TextBox>
                                   
                                </div> 
                                    <div class="input-group-prepend" >
                                        <asp:RequiredFieldValidator ID="passwordValidate" ValidationGroup='login' style="margin:auto" runat="server" ControlToValidate="password" Display="Dynamic" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                            </div>
                            <div class="footer text-center">
                                <asp:Button ID="btnLogin" ValidationGroup='login' class="btn btn-primary" runat="server" Text="Login" OnClick="btnLogin_Click" />
                            </div>
                         <div class="footer text-center">
                             <asp:Button ID="btnForget" class="btn btn-primary btn-link btn-wd btn-lg" runat="server" Text="Forgot Password" OnClick="btnForget_Click" />
                         </div>
                    </div>
                </div>
            </div>
           </form>
        </div>
        <footer class="footer">
              <div class="container">
                <nav class="float-centre">
                   <div class="row">
                                    <div class="col-md-3">
                                        <h5 class="title">Main</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="#pablo">
                                                    Blog
                                                </a>
                                            </li>
                                            <li>
                                                <a href="./about.aspx">
                                                    About Us
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <h5 class="title">OTS</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="#pablo">
                                                    Enter
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <h5 class="title">LMS</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="#pablo">
                                                    Borrow
                                                </a>
                                            </li>
                                            <li>
                                                <a href="./about.aspx">
                                                    Return
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <h5 class="title">Popular Shop</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="#pablo">
                                                    Sales FAQ
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#pablo">
                                                    Buy NOW!
                                                </a>
                                            </li>
                                            
                                        </ul>
                                    </div>
                                </div>
                </nav>
            </div>
                                    
                                </footer>
    </div>
    <!--   Core JS Files   -->
    <script src="../assets/js/core/jquery.min.js"></script>
    <script src="../assets/js/core/popper.min.js"></script>
    <script src="../assets/js/bootstrap-material-design.js"></script>
    <!--  Google Maps Plugin  -->
    <!-- <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script> -->
    <!--  Plugin for Date Time Picker and Full Calendar Plugin  -->
    <script src="../assets/js/plugins/moment.min.js"></script>
    <!--	Plugin for the Datepicker, full documentation here: https://github.com/Eonasdan/bootstrap-datetimepicker -->
    <script src="../assets/js/plugins/bootstrap-datetimepicker.min.js"></script>
    <!--	Plugin for the Sliders, full documentation here: http://refreshless.com/nouislider/ -->
    <script src="../assets/js/plugins/nouislider.min.js"></script>
    <!--	Plugin for Select, full documentation here: http://silviomoreto.github.io/bootstrap-select -->
    <script src="../assets/js/plugins/bootstrap-selectpicker.js"></script>
    <!--	Plugin for Tags, full documentation here: http://xoxco.com/projects/code/tagsinput/  -->
    <script src="../assets/js/plugins/bootstrap-tagsinput.js"></script>
    <!--	Plugin for Fileupload, full documentation here: http://www.jasny.net/bootstrap/javascript/#fileinput -->
    <script src="../assets/js/plugins/jasny-bootstrap.min.js"></script>
    <!--	Plugin for Small Gallery in Product Page -->
    <script src="../assets/js/plugins/jquery.flexisel.js"></script>
    <!-- Plugins for presentation and navigation  -->
    <script src="../assets/assets-for-demo/js/modernizr.js"></script>
    <script src="../assets/assets-for-demo/js/vertical-nav.js"></script>
    <!-- Material Kit Core initialisations of plugins and Bootstrap Material Design Library -->
    <script src="../assets/js/material-kit.js?v=2.0.3"></script>
    <!-- Fixed Sidebar Nav - js With initialisations For Demo Purpose, Don't Include it in your project -->
    <script src="../assets/assets-for-demo/js/material-kit-demo.js"></script>
</body>
</html>
