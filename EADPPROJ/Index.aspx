<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EADPPROJ.Index" %>
<asp:Content ID="index" ContentPlaceHolderID="content" runat="server">
    <div class="main main-raised">
        <div class="section">
        <div class="container">
                    <div class="row">
                        <div class="col-md-12 ml-auto mr-auto">
                        <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="LatestQuestion" it GroupItemCount="6">
                            
                            <GroupTemplate>
                                <div class="title">
                                        <h2 class="title">Latest Questions</h2>
                                    </div>
                                <div id="itemPlaceholderContainer" runat="server" >
                                    <div class="row">
                                    <div id="itemPlaceholder" runat="server"></div>
                                        </div>
                                </div>
                            </GroupTemplate>
                            <ItemTemplate>
                                <div class="col-4">
                                <div class="rotating-card-container">
                                    <div class="card card-rotate">
                                        <div class="front">
                                            <div class="card-body">
                                                <h5 class="card-category card-category-social text-success">
                                                    <i class="fa fa-newspaper-o"></i> Question
                                                </h5>
                                                <h4 class="card-title">
                                                    <a href="#pablo"><%# Eval("Title") %></a>
                                                </h4>
                                            </div>
                                        </div>
                                        <div class="back">
                                            <div class="card-body">
                                                <asp:Label CssClass="card-description" style="overflow:hidden;height:70px" ID="ContentForQuestions" runat="server" Text='<%# Eval("Content").ToString() %>'></asp:Label>
                                                <div class="footer text-center">
                                                    <asp:HyperLink ID="HyperLink1" CssClass="btn btn-rose btn-round" NavigateUrl='<%# Eval("Id","~/questionDetail.aspx?id={0}") %>' runat="server">
                                                        <i class="material-icons">subject</i>Read
                                                    </asp:HyperLink>
                                                        
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </div>
                            </ItemTemplate>
                            <LayoutTemplate>
                                                <div class="container" id="groupPlaceholderContainers" runat="server">
                                                    <div class="section">
                                                <div id="groupPlaceholder" runat="server">
                                                    </div>
                                                </div>
                                                </div>
                            </LayoutTemplate>
                        </asp:ListView>
                        <asp:SqlDataSource ID="LatestQuestion" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 6 [Id], [Title], [Content], [Review] FROM [tb_Question] WHERE ([Review] = @Review) ORDER BY [Id] DESC">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="Review" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                            </div>
                        </div>
            </div>
        <div class="container" >
                    <div class="row">
                        <div class="col-md-12 ml-auto mr-auto">
                            <h2 class="title">Latest Blogposts</h2>
                            <br>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Width="100%" BorderStyle="None" GridLines="None" ShowHeader="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Blog">
                                        <ItemTemplate>
                                            <div class="card card-plain card-blog" style="height:130px;">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="card-header card-header-image">
                                            <img class="img img-raised" runat="server" id="BlogImg" src="assets/img/examples/card-blog4.jpg">
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <h6 class="card-category text-info">Highlight</h6>
                                        <h3 class="card-title">
                                            <a href='./blogDetail.aspx?id=<%# Eval("Id") %>'><%# Eval("Title") %></a>
                                        </h3>
                                        <div class="card-description" style="overflow:hidden;max-height:90px">
                                            <%# Eval("Content") %>
                                            
                                        </div><a href='./blogDetail.aspx?id=<%# Eval("Id") %>'> Read More </a>
                                    </div>
                                </div>
                            </div>
                                            <asp:Label ID="Default" Visible="false" runat="server" Text='<%# Eval("BGDefault") %>'></asp:Label>
                                            <asp:Label ID="BlogId" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Blog] WHERE ([HighLight] = @HighLight) ORDER BY [Id] DESC">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="HighLight" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                           
                        </div>
                    </div>
                </div>
        </div>
                </div>
                </div>
        </div>
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
                                            <li>
                                                <a href="./Questionnaire.aspx">
                                                    Questionnaire
                                                </a>
                                            </li>
                                            <li>
                                                <a href="./FAQ.aspx">
                                                    FAQ
                                                </a>
                                            </li>
                                            <li>
                                                <a href="./Contact.aspx">
                                                    Contact Us
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
</asp:Content>
