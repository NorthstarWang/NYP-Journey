<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetPwd.aspx.cs" Inherits="EADPPROJ.forgetPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- Favicons -->
    <link rel="apple-touch-icon" href="./assets/img/apple-icon.png" />
    <link rel="icon" href="./assets/img/favicon.png" />
    <title>NYP Journey | Forget Password</title>
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
    <link rel="stylesheet" href="./assets/css/material-kit.css?v=2.0.3">
</head>
<body class="login-page ">
    <nav class="navbar navbar-color-on-scroll navbar-transparent fixed-top navbar-expand-lg " color-on-scroll="50" id="sectionsNav">
        <div class="container">
            <div class="navbar-translate">
                <a class="navbar-brand" href="./index.aspx">NYP Journey</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                    <span class="navbar-toggler-icon"></span>
                    <span class="navbar-toggler-icon"></span>
                </button>
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
                                <h4 class="card-title">Forget Password</h4>
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
                            </div>
                            <div class="footer text-center" style="margin: 50px 0">
                                <asp:Button ID="btnGet" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnGet_Click" />
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
    !--   Core JS Files   -->
    <script src="./assets/js/core/jquery.min.js"></script>
    <script src="./assets/js/core/popper.min.js"></script>
    <script src="./assets/js/bootstrap-material-design.js"></script>
    <script src="./assets/js/material-kit.js?v=2.0.3"></script>
</body>
</html>
