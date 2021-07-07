<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invitationCode.aspx.cs" Inherits="EADPPROJ.invitationCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- Favicons -->
    <link rel="apple-touch-icon" href="./assets/img/apple-icon.png" />
    <link rel="icon" href="./assets/img/favicon.png" />
    <title>NYP Journey | Invitation Code</title>
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
    <link rel="stylesheet" href="./assets/css/material-kit.css?v=2.0.3" />
</head>
<body class="login-page ">
    <nav class="navbar navbar-color-on-scroll navbar-transparent fixed-top navbar-expand-lg " color-on-scroll="100" id="sectionsNav">
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
        <a class="nyp-title" href="./Index.aspx"><strong>NYP Journey</strong></a>
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
                        <a href="./Rank/rank.aspx" class="nav-link">
                            <i class="fa fa-graduation-cap"></i>&nbsp;Ranking
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="./Blog/blog.aspx" class="nav-link">
                            <i class="fa fa-rss"></i>Blog
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="./Shop/bookShop.aspx" class="nav-link">
                            <i class="fa fa-shopping-basket"></i>&nbsp;Shop
                        </a>
                    </li>
                    <li class="dropdown nav-item" runat="server" id="appGroup">
                        <a href="#" class="dropdown-toggle nav-link" data-toggle="dropdown">
                            <i class="material-icons">apps</i> Apps
                        </a>
                        <div class="dropdown-menu dropdown-with-icons">
                            <a href="./Forum/questionList.aspx" class="dropdown-item">
                                <i class="material-icons">forum</i>Let's Ask
                            </a>
                            <a href="./Credit/creditBalance.aspx" class="dropdown-item">
                                <i class="material-icons">account_balance_wallet</i>Account Wallet
                            </a>
                        </div>
                    </li>
                    <li class="dropdown nav-item">
                        <a class="profile-photo dropdown-toggle nav-link" data-toggle="dropdown">
                            <div style="text-align: center; margin: 10px">
                                <img src="./assets/img/faces/user-head-icon.jpg" class="logo-image" alt="Circle Image" id="profileimg" runat="server" style="width: 50px" />
                            </div>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right" style="overflow-y: hidden;">
                            <a class="dropdown-item" style="display: none" href="./Profile/profile.aspx" id="profileUrl" runat="server">Profile</a>
                            <a class="dropdown-item" href="./index.aspx" id="logout" runat="server" style="display: none;" onserverclick="btn_logout_Click">Sign out</a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="page-header header-filter" style="background-image: url(&apos;assets/img/NYPheader2.jpg&apos;); background-size: cover; background-position: top center;">
        <div class="container">
            <form runat="server">
                <div class="row">
                    <div class="col-md-4 col-sm-6 ml-auto mr-auto">
                        <div class="card card-signup">
                            <div class="card-header card-header-primary text-center">
                                <h4 class="card-title">Invitation Code</h4>
                            </div>
                            <div class="card-body">
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="material-icons">face</i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="code" required="required" class="form-control" placeholder="Fill in the code" runat="server"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-12" style="text-align: center;">
                                            <p class="title" style="display: inline;color: black">My Code: </p>
                                            <asp:Label ID="codeno" Style="display: inline;color: black" CssClass="title" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="footer text-center" style="margin: 50px 0">
                                <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <footer class="footer">
            <div class="container">
                <nav class="float-left">
                    <ul>
                        <li>
                            <a href="./Blog/blog.aspx">Blog
                            </a>
                        </li>
                        <li>
                            <a href="./Shop/bookShop.aspx">Buy Now
                            </a>
                        </li>
                        <li>
                            <a href="./Rank/rankDetail.aspx">Ranking
                            </a>
                        </li>
                    </ul>
                </nav>

                <div class="copyright float-right">
                    <script>
                        document.write(new Date().getFullYear())
                    </script>
                    NYP Journey
                </div>
            </div>
        </footer>
    </div>
<!--   Core JS Files   -->
    <script src="./assets/js/core/jquery.min.js"></script>
    <script src="./assets/js/core/popper.min.js"></script>
    <script src="./assets/js/bootstrap-material-design.js"></script>
    <script src="./assets/js/material-kit.js?v=2.0.3"></script>
</body>
</html>
