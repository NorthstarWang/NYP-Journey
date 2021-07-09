<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageBlog.Master" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="EADPPROJ.blog" %>

<%@ Import Namespace="EADPPROJ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="blogPost" runat="server">
    <asp:Panel ID="addFav" runat="server" Visible="false">
        <div class="alert alert-success" style="margin-bottom: 0">
            <div class="container">
                <div class="alert-icon">
                    <i class="material-icons">check</i>
                </div>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true"><i class="material-icons">clear</i></span>
                </button>
                <b>Success :</b> This blog has been added to your favorite list! You can view it in your profile > Favorite anytime you want!
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="cannotFavAgain" runat="server" Visible="false">
        <div class="alert alert-warning" style="margin-bottom: 0">
            <div class="container">
                <div class="alert-icon">
                    <i class="material-icons">warning</i>
                </div>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true"><i class="material-icons">clear</i></span>
                </button>
                <b>Warning :</b> You have already added this article in your favorite list! You can view it in your profile > Favorite anytime you want!
            </div>
        </div>
    </asp:Panel>
    <div class="page-header header-filter header-small" data-parallax="true" style="background-image: url(&apos;../assets/img/bg10.jpg&apos;);">
        <div class="container">
            <div class="row">
                <div class="col-md-8 ml-auto mr-auto text-center">
                    <h2 class="title">A Place for Student to Share and Discover Useful Experience</h2>
                </div>
            </div>
        </div>
    </div>
    <div class="main main-raised">
        <div class="container">
            <div class="section">
                <div class="row">
                    <div class="col-md-8 ml-auto mr-auto text-center">
                        <ul class="nav nav-pills nav-pills-primary">
                            <li class="nav-item">
                                <a class="nav-link active" href="#pill1" role="tab" data-toggle="tab">All</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#pill2" role="tab" data-toggle="tab">HighLight</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#pill3" role="tab" data-toggle="tab">Most Favorite</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#pill4" role="tab" data-toggle="tab">Most Valuable</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="tab-content tab-space">
                    <div class="tab-pane active" id="pill1">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" BorderStyle="None" GridLines="None" ShowHeader="False" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Blog">
                                            <ItemTemplate>
                                                <div class="card card-raised card-background" runat="server" id="BlogImg" style="background-image: url('../assets/img/examples/card-project6.jpg')">
                                                    <div class="card-body">
                                                        <h6 class="card-category text-info">Highlight Blog Post</h6>
                                                        <h3 class="card-title"><%# Eval("Title", "{0}") %></h3>
                                                        <div class="card-description" style="overflow: hidden; max-height: 200px">
                                                            <%# RichTextConverter.ConvertToPlainText(Eval("Content", "{0}")) %>
                                                        </div>
                                                        <asp:LinkButton ID="Url" CssClass="btn btn-warning btn-round" runat="server"><i class="material-icons">subject</i> Read</asp:LinkButton>
                                                        <asp:LinkButton ID="addFav" OnClick="addFav_Click" runat="server" CssClass="btn btn-white btn-just-icon btn-link" rel="tooltip" data-original-title="Add to favorite"><i class="fa fa-get-pocket"></i></asp:LinkButton>
                                                        <asp:Label ID="BlogId" Visible="false" runat="server" Text='<%# Eval("Id", "{0}") %>'></asp:Label>
                                                        <asp:Label ID="Default" Visible="false" runat="server" Text='<%# Eval("BGDefault", "{0}") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 3 * FROM [tb_Blog] WHERE ([HighLight] = @HighLight) ORDER BY [Id] DESC">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="HighLight" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 ml-auto mr-auto">
                                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2" GroupItemCount="2">
                                    <LayoutTemplate>
                                        <div id="groupPlaceholder" runat="server" />
                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <div class="row">
                                            <div id="itemPlaceholder" runat="server" />
                                        </div>
                                    </GroupTemplate>
                                    <ItemTemplate>
                                        <div class="col-md-12 col-lg-6">
                                            <div class="card card-raised card-background" id="BlogImg" runat="server" style="background-image: url('../assets/img/examples/office2.jpg');">
                                                <div class="card-body">
                                                    <div style="overflow: hidden; height: 300px">
                                                        <h3 class="card-title"><%# Eval("Title", "{0}") %></h3>
                                                        <div class="card-description">
                                                            <%# RichTextConverter.ConvertToPlainText(Eval("Content", "{0}")) %>
                                                        </div>
                                                    </div>
                                                    <a href='./blogDetail.aspx?id=<%# Eval("Id", "{0}") %>' class="btn btn-danger btn-round"><i class="material-icons">format_align_left</i>Read Blog</a>
                                                    <asp:Label ID="BlogId" Visible="false" runat="server" Text='<%# Eval("Id", "{0}") %>'></asp:Label>
                                                    <asp:Label ID="Default" Visible="false" runat="server" Text='<%# Eval("BGDefault", "{0}") %>'></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Blog] ORDER BY [Id] DESC"></asp:SqlDataSource>

                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="pill2">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource3" ShowHeader="False" BorderStyle="None" GridLines="None" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Blog">
                                            <ItemTemplate>
                                                <div class="card card-raised card-background" runat="server" id="BlogImg" style="background-image: url('../assets/img/examples/card-project6.jpg')">
                                                    <div class="card-body">
                                                        <h6 class="card-category text-info">Highlight Blogpost</h6>
                                                        <h3 class="card-title"><%# Eval("Title", "{0}") %></h3>
                                                        <div class="card-description" style="overflow: hidden; max-height: 200px">
                                                            <%# RichTextConverter.ConvertToPlainText(Eval("Content", "{0}")) %>
                                                        </div>
                                                        <asp:LinkButton ID="Url" CssClass="btn btn-warning btn-round" runat="server"><i class="material-icons">subject</i> Read</asp:LinkButton>
                                                        <asp:LinkButton ID="addFav" OnClick="addFav_Click" runat="server" CssClass="btn btn-white btn-just-icon btn-link" rel="tooltip" data-original-title="Add to favorite"><i class="fa fa-get-pocket"></i></asp:LinkButton>
                                                        <asp:Label ID="BlogId" Visible="false" runat="server" Text='<%# Eval("Id", "{0}") %>'></asp:Label>
                                                        <asp:Label ID="Default" Visible="false" runat="server" Text='<%# Eval("BGDefault", "{0}") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Blog] WHERE ([HighLight] = @HighLight) ORDER BY [Id] DESC">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="HighLight" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane " id="pill3">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource4" ShowHeader="False" BorderStyle="None" GridLines="None" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Blog">
                                            <ItemTemplate>
                                                <div class="card card-raised card-background" runat="server" id="BlogImg" style="background-image: url('../assets/img/examples/card-project6.jpg')">
                                                    <div class="card-body">
                                                        <h6 class="card-category text-info">Highlight Blogpost</h6>
                                                        <h3 class="card-title"><%# Eval("Title", "{0}") %></h3>
                                                        <div class="card-description" style="overflow: hidden; max-height: 200px">
                                                            <%# RichTextConverter.ConvertToPlainText(Eval("Content", "{0}")) %>
                                                        </div>
                                                        <asp:LinkButton ID="Url" CssClass="btn btn-warning btn-round" runat="server"><i class="material-icons">subject</i> Read</asp:LinkButton>
                                                        <asp:LinkButton ID="addFav" OnClick="addFav_Click" runat="server" CssClass="btn btn-white btn-just-icon btn-link" rel="tooltip" data-original-title="Add to favorite"><i class="fa fa-get-pocket"></i></asp:LinkButton>
                                                        <asp:Label ID="BlogId" Visible="false" runat="server" Text='<%# Eval("Id", "{0}") %>'></asp:Label>
                                                        <asp:Label ID="Default" Visible="false" runat="server" Text='<%# Eval("BGDefault", "{0}") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Blog] ORDER BY [Favorite] DESC, [Id] DESC"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="pill4">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource5" ShowHeader="False" BorderStyle="None" GridLines="None" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Blog">
                                            <ItemTemplate>
                                                <div class="card card-raised card-background" runat="server" id="BlogImg" style="background-image: url('../assets/img/examples/card-project6.jpg')">
                                                    <div class="card-body">
                                                        <h6 class="card-category text-info">Highlight Blogpost</h6>
                                                        <h3 class="card-title"><%# Eval("Title", "{0}") %></h3>
                                                        <div class="card-description" style="overflow: hidden; max-height: 200px">
                                                            <%# RichTextConverter.ConvertToPlainText(Eval("Content", "{0}")) %>
                                                        </div>
                                                        <asp:LinkButton ID="Url" CssClass="btn btn-warning btn-round" runat="server"><i class="material-icons">subject</i> Read</asp:LinkButton>
                                                        <asp:LinkButton ID="addFav" OnClick="addFav_Click" runat="server" CssClass="btn btn-white btn-just-icon btn-link" rel="tooltip" data-original-title="Add to favorite"><i class="fa fa-get-pocket"></i></asp:LinkButton>
                                                        <asp:Label ID="BlogId" Visible="false" runat="server" Text='<%# Eval("Id", "{0}") %>'></asp:Label>
                                                        <asp:Label ID="Default" Visible="false" runat="server" Text='<%# Eval("BGDefault", "{0}") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Blog] ORDER BY [Tip] DESC, [Id] DESC"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
