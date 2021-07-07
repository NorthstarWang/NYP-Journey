<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EADPPROJ.Index" %>

<asp:Content ID="index" ContentPlaceHolderID="content" runat="server">
    <div class="main main-raised">
        <div class="section">
            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource" GroupItemCount="3">
                <LayoutTemplate>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-7">
                                <div class="title">
                                    <h4><strong>Useful Blogs</strong></h4>
                                </div>
                            </div>
                        </div>
                        <div id="groupPlaceholder" runat="server" />
                    </div>
                </LayoutTemplate>
                <GroupTemplate>
                    <div class="row">
                        <div id="itemPlaceholder" runat="server" />
                    </div>
                </GroupTemplate>
                <ItemTemplate>
                    <div class="col-md-4 col-sm-12">
                        <div class="card card-blog">
                            <div class="card-header card-header-image">
                                <a href="<%# Eval("Id","./blogDetail.aspx?id={0}") %>">
                                    <img src="<%# Convert.ToInt32(Eval("BGDefault"))==0?Eval("BGImage","./assets/img/BlogBG/{0}"):"./assets/img/bg.jpg" %>" style="height: 200px" alt="">
                                </a>
                            </div>
                            <div class="card-body">
                                <h4 class="card-title" style="height: 100px; overflow: hidden">
                                    <a href="<%# Eval("Id","./blogDetail.aspx?id={0}") %>"><%# Eval("Title") %></a>
                                </h4>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 6 [BGImage], [BGDefault], [Title], [Id] FROM [tb_Blog] WHERE ([HighLight] = @HighLight) ORDER BY [PostTime] DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="HighLight" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>

        <div class="section">
            <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSourceBook" GroupItemCount="3">
                <LayoutTemplate>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-7">
                                <div class="title">
                                    <h4><strong>Top selling books</strong></h4>
                                </div>
                            </div>
                        </div>
                        <div id="groupPlaceholder" runat="server" />
                    </div>
                </LayoutTemplate>
                <GroupTemplate>
                    <div class="row">
                        <div id="itemPlaceholder" runat="server" />
                    </div>
                </GroupTemplate>
                <ItemTemplate>
                    <div class="col-md-4 col-sm-12">
                        <div class="card card-blog">
                            <div class="card-header card-header-image">
                                <a href="<%# Eval("Id","./bookDetail.aspx?id={0}") %>">
                                    <img src="<%# Eval("Image","./assets/img/books/{0}") %>" style="height: 400px" alt="">
                                </a>
                                &nbsp;&nbsp;&nbsp;
                            </div>
                            <div class="card-body">
                                <h4 class="card-title" style="height: 100px; overflow: hidden">
                                    <a href="<%# Eval("Id","./bookDetail.aspx?id={0}") %>"><%# Eval("Name").ToString() %></a>
                                </h4>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSourceBook" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 6 SUM(i.Quantity) AS Sells, s.Name, s.Image, s.Id FROM tb_Invoice AS i RIGHT OUTER JOIN tb_Shop AS s ON s.Id = i.BookId GROUP BY s.Id, s.Name, s.Image ORDER BY Sells DESC"></asp:SqlDataSource>
        </div>
    </div>
    <footer class="footer footer-white footer-big">
        <div class="container">
            <div class="content">
                <div class="row">
                    <div class="col-md-3">
                        <h5>Blog</h5>
                        <ul class="links-vertical">
                            <li>
                                <a href="/Blog/blog.aspx">Blog
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="col-md-3">
                        <h5>Online Shop</h5>
                        <ul class="links-vertical">
                            <li>
                                <a href="/Shop/bookShop.aspx">Buy Now
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="col-md-3">
                        <h5>Ranking</h5>
                        <ul class="links-vertical">
                            <li>
                                <a href="/Rank/rankDetail.aspx?type=Question">Let's Ask ranking
                                </a>
                            </li>
                            <li>
                                <a href="/Rank/rankDetail.aspx?type=User">User ranking
                                </a>
                            </li>
                            <li>
                                <a href="/Rank/rankDetail.aspx?type=Blog">Blog ranking
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
</asp:Content>
