<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookDetail.aspx.cs" Inherits="EADPPROJ.bookDetail" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- Favicons -->
    <title>
        Shop
    </title>
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../assets/css/material-kit.css?v=2.0.3">
    <!-- Documentation extras -->
</head>

<body class="product-page ">
    <form id="form1" runat="server">
    <nav class="navbar navbar-expand-lg " style="margin-bottom:0" id="sectionsNav">
        <div class="container">
            <div class="navbar-translate">
                <a class="navbar-brand" href="./index.aspx">Education System</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                    <span class="navbar-toggler-icon"></span>
                    <span class="navbar-toggler-icon"></span>
                </button>
            </div>
                <ul class="navbar-nav ml-auto"> 
                    <li class="nav-item">
                                        <a href="./rank.aspx" class="nav-link">
                                            <i class="fa fa-graduation-cap"></i> Ranking
                                        </a>
                                    </li>
                    <li class="nav-item">
                                        <a href="./blog.aspx" class="nav-link">
                                            <i class="fa fa-rss"></i> Blog
                                        </a>
                                    </li>
                    <li class="nav-item">
                                        <a href="./bookShop.aspx" class="nav-link">
                                            <i class="fa fa-shopping-basket"></i> Shop
                                        </a>
                                    </li>
                    <li class="nav-item">
                                        <a href="./bookCart.aspx" class="nav-link">
                                            <i class="fa fa-shopping-cart"></i> Cart
                                        </a>
                                    </li>
                    <li class="dropdown nav-item" runat="server" id="appGroup">
                        <a href="#" class="dropdown-toggle nav-link" data-toggle="dropdown">
                            <i class="material-icons">apps</i> Apps
                        </a>
                        <div class="dropdown-menu dropdown-with-icons">
                            <a href="./questionList.aspx" class="dropdown-item">
                                <i class="material-icons">forum</i>Let's Ask
                            </a>
                            <a href="./courseList.aspx" class="dropdown-item">
                                <i class="material-icons">class</i>Online Course
                            </a>
                            <a href="./creditBalance.aspx" class="dropdown-item">
                                <i class="material-icons">account_balance_wallet</i>Account Wallet
                            </a>
                            <a href="#" class="dropdown-item">
                                <i class="material-icons">shopping_cart</i>Shop Related
                            </a>
                        </div>
                    </li>
                                    <li class="nav-item" id="user">
                                        <a href="./profile.aspx" class="profile-photo nav-link" id="profileUrl" runat="server">
                                            <div class="profile-photo-small">
                                                <img src="assets/img/user-head-icon.jpg" id="profileimg" alt="Circle Image" class="rounded-circle img-fluid" style="display:none" runat="server">
                                            </div>
                                        </a>
                                    </li>
                    <li class="nav-item"  >
                        <a href="./index.aspx" id="logout" class="nav-link" runat="server" style="display:none;" onserverclick="btn_logout_Click">
                                           Log Out
                                        </a>
                                    </li>
                    <li class="nav-item" id="login_func" runat="server">
                                        <a href="./login.aspx" class="nav-link">
                                            Login
                                        </a>
                                    </li>
                    <li class="nav-item" id="register_func" runat="server">
                                        <a href="./registerType.aspx" class="nav-link">
                                            Register
                                        </a>
                                    </li>
                </ul>
            </div>
    </nav>
        <asp:Panel ID="successCart" runat="server" Visible="false" >
    <div class="alert alert-success" style="margin-bottom:0">
                <div class="container">
                    <div class="alert-icon">
                        <i class="material-icons">check</i>
                    </div>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="material-icons">clear</i></span>
                    </button>
                    <b>Success :</b> Added to Cart!
                </div>
            </div>
    </asp:Panel>
    <div class="page-header header-filter" data-parallax="true" filter-color="rose" style="background-image: url(&apos;../assets/img/bg6.jpg&apos;);">
        
    </div>
    <div class="section section-gray">
        <div class="container">
            <div class="main main-raised main-product">
                <div class="row">
                    <div class="col-md-6 col-sm-6">
                        <div class="tab-content">
                            <div class="tab-pane active" id="product-page1">
                                <img src="../assets/img/examples/product2.jpg" runat="server" id="img">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6">
                        <h2 class="title" runat="server" id="name"></h2>
                        <h3 class="main-price" runat="server" id="price"></h3>
                                    <h5>
                                            Description
                                    </h5>
                                        <p runat="server" id="description"></p>
                                    
                            
                        <div class="row pull-right">
                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="btn btn-rose btn-round" runat="server">
                                            Add to Cart &#xA0;<i class="material-icons">shopping_cart</i>
                                        </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
    </div>
        </form>
    <footer class="footer footer-white footer-big">
                        <div class="container">
                            <div class="content">
                                <div class="row">
                                    <div class="col-md-2">
                                        <h5>Schools</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="#">
                                                    School Events
                                                </a>
                                            </li>
                                            <li>
                                                <a href="./about.aspx">
                                                    About Us
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-2">
                                        <h5>Let's Ask</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="./postQuestion.aspx">
                                                    Ask Now
                                                </a>
                                            </li>
                                            <li>
                                                <a href="./questionList.aspx">
                                                    Questions
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-2">
                                        <h5>Online Course</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="#pablo">
                                                    Learn Now
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <h5>Online Shop</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="./eCommerce.aspx">
                                                    Buy Now
                                                </a>
                                            </li>
                                            
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <h5>Ranking</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="#pablo">
                                                    Question
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#pablo">
                                                    Answer
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#pablo">
                                                    Best Answer
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <hr>
                            <div class="copyright pull-center">
                                <script>
                                    document.write(new Date().getFullYear())
                                </script> NYP Journey
                            </div>
                        </div>
                    </footer>
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
    <script>
        $(document).ready(function() {
            $("#flexiselDemo1").flexisel({
                visibleItems: 4,
                itemsToScroll: 1,
                animationSpeed: 400,
                enableResponsiveBreakpoints: true,
                responsiveBreakpoints: {
                    portrait: {
                        changePoint: 480,
                        visibleItems: 3
                    },
                    landscape: {
                        changePoint: 640,
                        visibleItems: 3
                    },
                    tablet: {
                        changePoint: 768,
                        visibleItems: 3
                    }
                }
            });
        });
    </script>
</body>

</html>
