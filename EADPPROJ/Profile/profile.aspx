<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/MasterPageProfile.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="EADPPROJ.profile1" %>

<asp:Content ID="profileContent" ContentPlaceHolderID="detail" runat="server">
    <div class="page-header header-filter" data-parallax="true" style="background-image: url('../assets/img/NYPheader1.jpg');"></div>
    <div class="main main-raised">
        <div class="profile-content">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 ml-auto mr-auto">
                        <div class="profile">
                            <div class="avatar">
                                <img src="../assets/img/faces/user-head-icon.jpg" id="headicon" alt="Circle Image" class="img-raised rounded-circle img-fluid" runat="server" />
                            </div>
                            <div class="name" style="margin: 30px">
                                <asp:Label ID="Name" CssClass="title" runat="server" Font-Size="XX-Large"></asp:Label><br />
                            </div>
                            <div class="identity" style="margin: 30px">
                                <asp:Label ID="Identity" runat="server" Font-Size="Large" Font-Bold="True" Font-Italic="True"></asp:Label>
                            </div>
                        </div>
                        <div class="follow">

                            <button class="btn btn-fab btn-primary btn-round" rel="tooltip" title="Edit HeadIcon" data-toggle="modal" data-target="#iconModal" onclick="return false;">
                                <i class="material-icons">create</i>
                            </button>
                            <div class="modal fade" id="iconModal" tabindex="-1" role="dialog" data-backdrop="false">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title">Edit Icon</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <i class="material-icons">clear</i>
                                            </button>
                                        </div>
                                        <div class="modal-body" style="margin: 0 auto; display: inline-block">
                                            <div class="fileinput fileinput-new text-center" data-provides="fileinput">
                                                <div class="fileinput-new thumbnail img-raised">
                                                    <img src="../assets/img/image_placeholder.jpg" alt="...">
                                                </div>
                                                <div class="fileinput-preview fileinput-exists thumbnail img-raised"></div>
                                                <div>
                                                    <span class="btn btn-raised btn-round btn-default btn-file">
                                                        <span class="fileinput-new">Select
                                                        </span>
                                                        <span class="fileinput-exists">Change</span>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="Button4" data-dismiss="fileinput" runat="server" class="btn btn-primary btn-round" Text="Confirm" OnClick="Button4_Click" />
                                            <button type="button" class="btn btn-default btn-link" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <button class="btn btn-fab btn-primary btn-round" rel="tooltip" title="Write Blog" data-toggle="modal" data-target="#myModal" onclick="return false;">
                                <i class="material-icons">add</i>
                            </button>
                            <div class="modal fade bd-example-modal-lg" id="myModal" tabindex="-1" role="dialog" data-backdrop="false">
                                <div class="modal-dialog modal-lg" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title">Post Blog</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <i class="material-icons">clear</i>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-group">
                                                <label for="exampleInput1" class="bmd-label-floating">Title</label>
                                                <asp:TextBox ID="blogTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-file-upload form-file-multiple">
                                                <asp:FileUpload ID="FileUpload2" CssClass="inputFileHidden" runat="server" />
                                                <div class="input-group">
                                                    <input type="text" class="form-control inputFileVisible" placeholder="Background Image(Optional)">
                                                    <span class="input-group-btn">
                                                        <button type="button" class="btn btn-fab btn-round btn-primary">
                                                            <i class="material-icons">attach_file</i>
                                                        </button>
                                                    </span>
                                                </div>
                                            </div>
                                            <asp:TextBox ID="blogContent" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="post" CssClass="btn btn-link" runat="server" Text="Post" OnClick="post_Click" />
                                            <button type="button" class="btn btn-danger btn-link" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="profile-tabs">
                            <ul class="nav nav-pills nav-pills-icons justify-content-center" role="tablist">

                                <li class="nav-item">
                                    <a class="nav-link active" href="#work" role="tab" data-toggle="tab">
                                        <i class="material-icons">thumbs_up_down</i> Comment
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#connections" role="tab" data-toggle="tab">
                                        <i class="material-icons">speaker_notes</i> Blog Post
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#favourite" role="tab" data-toggle="tab">
                                        <i class="material-icons">favorite</i> Favorite
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="tab-content tab-space">
                    <div class="tab-pane active work" id="work">
                        <div class="row">
                            <div class="col-md-3 mr-auto ml-auto stats">
                                <h4 class="title">Stats</h4>
                                <ul class="list-unstyled">
                                    <li>
                                        <b>
                                            <asp:Label ID="QuestionNo" runat="server"></asp:Label>
                                        </b>&nbsp;Questions Posted</li>
                                    <li>
                                        <b>
                                            <asp:Label ID="AnswersNo" runat="server"></asp:Label>
                                        </b>&nbsp;Answers Posted</li>
                                    <li>
                                        <b>
                                            <asp:Label ID="BestAnswerNo" runat="server"></asp:Label>
                                        </b>&nbsp;Best Solution</li>
                                    <li>
                                        <b>
                                            <asp:Label ID="BlogNo" runat="server"></asp:Label>
                                        </b>&nbsp;Blog Posted</li>
                                </ul>

                            </div>
                            <div class="col-md-9">
                                <div class="media-area">
                                    <h3 class="title text-center" runat="server" id="commentNo"></h3>
                                    <asp:GridView ID="GridView1" CssClass="pagination-area" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" BorderStyle="None" GridLines="None" ShowHeader="False" PageSize="5">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Comment">
                                                <ItemTemplate>
                                                    <div class="media">
                                                        <a class="float-left" href="#pablo">
                                                            <div class="avatar">
                                                                <asp:Image CssClass="media-object" ID="Icon" runat="server" />
                                                            </div>
                                                        </a>
                                                        <div class="media-body">
                                                            <h4 class="media-heading"><%# Eval("Poster", "{0}") %>
                                                                <small>&#xB7; </small><small runat="server" id="countdown"><%# Eval("PostTime", "{0}") %></small>
                                                            </h4>
                                                            <p><%# Eval("Content", "{0}") %></p>
                                                            <asp:Label ID="Username" runat="server" Text='<%# Eval("Poster", "{0}") %>' Visible="false" />
                                                            <asp:Label ID="postTime" runat="server" Text='<%# Eval("PostTime", "{0}") %>' Visible="false" />
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Center" CssClass="pagination-area" ForeColor="Black" Font-Size="Large" BorderStyle="None" VerticalAlign="Bottom" />
                                        <PagerSettings FirstPageText="&amp;#xAB;" LastPageText="&amp;#xBB;" Mode="NumericFirstLast" PageButtonCount="5" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Comment] WHERE ([Username] = @Username) ORDER BY [Id] DESC">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="Username" QueryStringField="id" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <div class="media media-post" runat="server" id="postSection">
                                        <a class="author float-left">
                                            <div class="avatar">
                                                <img src="../assets/img/user-head-icon.jpg" id="profileimg" alt="64x64" runat="server" />
                                            </div>
                                        </a>
                                        <div class="media-body">
                                            <asp:TextBox ID="CommentPostText" CssClass="form-control" runat="server"></asp:TextBox>
                                            <div class="media-footer">
                                                <asp:Button ID="CommentPostButton" CssClass="btn btn-primary float-right" runat="server" Text="Comment" OnClick="CommentPostButton_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane connections" id="connections">
                        <div class="row">
                            <div class="col-md-12 ml-auto mr-auto">
                                <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource2" BorderStyle="None" GridLines="None" ShowHeader="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Blog">
                                            <ItemTemplate>

                                                <div class="card">
                                                    <div class="card-body">
                                                        <h4 class="card-title">
                                                            <%# Eval("Title", "{0}") %>
                                                        </h4>
                                                        <div style="overflow: hidden; max-height: 200px"><%# Eval("Content", "{0}") %></div>
                                                        <div class="card-stats justify-content-center">
                                                            <a href='../Blog/blogDetail.aspx?id=<%# Eval("Id", "{0}") %>' class="btn btn-white btn-round"><i class="material-icons">subject</i>Read Blog</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Blog] WHERE ([Poster] = @Poster) ORDER BY [Id] DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="Poster" QueryStringField="id" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane favourite" id="favourite">
                        <div class="row">
                            <div class="col-md-12 ml-auto mr-auto">
                                <asp:Label ID="noFav" runat="server" Visible="false" Text="You do not have any favorite blog post right now!"></asp:Label>
                                <asp:GridView ID="favList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource3" BorderStyle="None" GridLines="None" Width="100%" ShowHeader="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Favorite">
                                            <ItemTemplate>
                                                <asp:Label ID="BlogId" runat="server" Text='<%# Eval("BlogId", "{0}") %>' Visible="false"></asp:Label>
                                                <div class="card">
                                                    <div class="card-body" runat="server">
                                                        <h4 class="card-title" runat="server" id="title"></h4>
                                                        <div class="card-stats justify-content-center">
                                                            <a href='../Blog/blogDetail.aspx?id=<%# Eval("BlogId", "{0}") %>' class="btn btn-white btn-round"><i class="material-icons">subject</i>Read Blog</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Favourite] WHERE ([Username] = @Username) ORDER BY [Id] DESC">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Username" SessionField="Account" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
