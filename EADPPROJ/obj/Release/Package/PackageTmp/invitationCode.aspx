<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invitationCode.aspx.cs" Inherits="EADPPROJ.invitationCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- Favicons -->
    <link rel="apple-touch-icon" href="../assets/img/apple-icon.png">
    <link rel="icon" href="../assets/img/favicon.png">
    <title>
        Forget
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
                                    <p style="display:inline">My Code: </p>
                                    <asp:Label ID="codeno" style="display:inline" CssClass="form-text" runat="server"></asp:Label></div></div>
                                    </div>
                            </div>
                            <div class="footer text-center"  style="margin:50px 0">
                                <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                    </div>
                </div>
            </div>
           </form>
        </div>
        <footer class="footer footer-white footer-big">
                        <div class="container">
                            <div class="content">
                                <div class="row">
                                    <div class="col-md-3">
                                        <h5>Schools</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="./about.aspx">
                                                    About Us
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <h5>Blog</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="./blog.aspx">
                                                    Blog
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <h5>Online Shop</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="./bookShop.aspx">
                                                    Buy Now
                                                </a>
                                            </li>
                                            
                                        </ul>
                                    </div>
                                    <div class="col-md-3">
                                        <h5>Ranking</h5>
                                        <ul class="links-vertical">
                                            <li>
                                                <a href="./rankDetail.aspx?type=Question">
                                                    Let's Ask ranking
                                                </a>
                                            </li>
                                            <li>
                                                <a href="./rankDetail.aspx?type=User">
                                                    User ranking
                                                </a>
                                            </li>
                                            <li>
                                                <a href="./rankDetail.aspx?type=Blog">
                                                    Blog ranking
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
        </div>
</body>
</html>
