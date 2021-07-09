<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookDetail.aspx.cs" Inherits="EADPPROJ.bookDetail" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- Favicons -->
    <link rel="apple-touch-icon" href="./assets/img/apple-icon.png">
    <link rel="icon" href="./assets/img/favicon.png">
    <title>NYP Journey | Book</title>
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../assets/css/material-kit.css?v=2.0.3">
    <!-- Documentation extras -->
</head>

<body class="product-page ">
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg " style="margin-bottom:0" id="sectionsNav">
            <style>
                .nyp-title {
                    margin-left: 6em;
                    font-size: large;
                    color: inherit;
                    font-weight: bolder;
                    transition: transform .3s;
                }

                    .nyp-title:hover {
                        color: inherit;
                        transform: scale(1.2)
                    }

                .logo-image {
                    width: 50px;
                    height: 50px;
                    position: relative;
                    overflow: hidden;
                    border-radius: 50%;
                }

                @media only screen and (max-width:992px) {
                    .nyp-title {
                        margin-left: 3em;
                        font-size: large;
                        color: inherit;
                        font-weight: bolder;
                        transition: transform .3s;
                    }

                        .nyp-title:hover {
                            color: inherit;
                            transform: scale(1.2)
                        }
                }
            </style>
            <a class="nyp-title" href="../Index.aspx"><strong>NYP Journey</strong></a>
            <div class="container">
                <div class="navbar-translate">
                    <p class="navbar-brand"></p>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                        <span class="navbar-toggler-icon"></span>
                        <span class="navbar-toggler-icon"></span>
                    </button>
                </div>
                <div class="collapse navbar-collapse">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <a href="../Rank/rank.aspx" class="nav-link">
                                <i class="fa fa-graduation-cap"></i>Ranking
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="../Blog/blog.aspx" class="nav-link">
                                <i class="fa fa-rss"></i>Blog
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="../Shop/bookShop.aspx" class="nav-link">
                                <i class="fa fa-shopping-basket"></i>Shop
                            </a>
                        </li>
                        <li class="dropdown nav-item" runat="server" id="appGroup">
                            <a href="#" class="dropdown-toggle nav-link" data-toggle="dropdown">
                                <i class="material-icons">apps</i> Apps
                            </a>
                            <div class="dropdown-menu dropdown-with-icons">
                                <a href="../Forum/questionList.aspx" class="dropdown-item">
                                    <i class="material-icons">forum</i>Let's Ask
                                </a>
                                <a href="../Credit/creditBalance.aspx" class="dropdown-item">
                                    <i class="material-icons">account_balance_wallet</i>Account Wallet
                                </a>
                            </div>
                        </li>
                        <li class="dropdown nav-item">
                            <a class="profile-photo dropdown-toggle nav-link" data-toggle="dropdown">
                                <div style="text-align: center; margin: 10px">
                                    <img src="../assets/img/faces/user-head-icon.jpg" class="logo-image" alt="Circle Image" id="profileimg" runat="server" />
                                </div>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right" style="overflow-y: hidden;">
                                <a class="dropdown-item" style="display: none" href="../Profile/profile.aspx" id="profileUrl" runat="server">Profile</a>
                                <a class="dropdown-item" href="../index.aspx" id="logout" runat="server" style="display: none;" onserverclick="btn_logout_Click">Sign out</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <asp:Panel ID="successCart" runat="server" Visible="false">
            <div class="alert alert-success" style="margin-bottom: 0">
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
                                    <img src="../assets/img/examples/product2.jpg" runat="server" id="img"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6">
                            <h2 class="title" runat="server" id="name"></h2>
                            <h3 class="main-price" runat="server" id="price"></h3>
                            <h5>Description
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
                <div class="col-md-3">
                    <h5>Blog</h5>
                    <ul class="links-vertical">
                        <li>
                            <a href="../Blog/blog.aspx">Blog
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="col-md-3">
                    <h5>Online Shop</h5>
                    <ul class="links-vertical">
                        <li>
                            <a href="../Shop/bookShop.aspx">Buy Now
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="col-md-3">
                    <h5>Ranking</h5>
                    <ul class="links-vertical">
                        <li>
                            <a href="../Rank/rankDetail.aspx?type=Question">Let's Ask ranking
                            </a>
                        </li>
                        <li>
                            <a href="../Rank/rankDetail.aspx?type=User">User ranking
                            </a>
                        </li>
                        <li>
                            <a href="../Rank/rankDetail.aspx?type=Blog">Blog ranking
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
            </script>
            NYP Journey
        </div>
    </div>
</footer>
    <!--   Core JS Files   -->
    <script src="../assets/js/core/jquery.min.js"></script>
    <script src="../assets/js/core/popper.min.js"></script>
    <script src="../assets/js/bootstrap-material-design.js"></script>
    <!--	Plugin for Select, full documentation here: http://silviomoreto.github.io/bootstrap-select -->
    <script src="../assets/js/plugins/bootstrap-selectpicker.js"></script>
    <!--	Plugin for Tags, full documentation here: http://xoxco.com/projects/code/tagsinput/  -->
    <script src="../assets/js/plugins/bootstrap-tagsinput.js"></script>
    <!--	Plugin for Small Gallery in Product Page -->
    <script src="../assets/js/plugins/jquery.flexisel.js"></script>
    <script src="../assets/js/material-kit.js?v=2.0.3"></script>
    <script>
        $(document).ready(function () {
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
