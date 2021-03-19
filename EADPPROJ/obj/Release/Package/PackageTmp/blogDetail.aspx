<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBlog.Master" AutoEventWireup="true" CodeBehind="blogDetail.aspx.cs" Inherits="EADPPROJ.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="blogPost" runat="server">
    <asp:Panel ID="successTip" runat="server" Visible="false" >
    <div class="alert alert-success" style="margin-bottom:0">
                <div class="container">
                    <div class="alert-icon">
                        <i class="material-icons">check</i>
                    </div>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="material-icons">clear</i></span>
                    </button>
                    <b>Success :</b> Thanks for your tipping!
                </div>
            </div>
    </asp:Panel>
    <asp:Panel ID="addFav" runat="server" Visible="false" >
    <div class="alert alert-success" style="margin-bottom:0">
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
    <asp:Panel ID="successSet" runat="server" Visible="false" >
    <div class="alert alert-success" style="margin-bottom:0">
                <div class="container">
                    <div class="alert-icon">
                        <i class="material-icons">check</i>
                    </div>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="material-icons">clear</i></span>
                    </button>
                    <b>Success :</b> This blog has been set as highlight blogpost!
                </div>
            </div>
    </asp:Panel>
    <asp:Panel ID="cannotFavAgain" runat="server" Visible="false" >
    <div class="alert alert-warning" style="margin-bottom:0">
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
    <asp:Panel ID="insufficientCredit" runat="server" Visible="false">
    <div class="alert alert-warning" style="margin-bottom:0">
                <div class="container">
                    <div class="alert-icon">
                        <i class="material-icons">warning</i>
                    </div>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="material-icons">clear</i></span>
                    </button>
                    <b>Warning :</b> You do not have enough credit for tipping! Please proceed to Top-Up page!
                </div>
            </div>

    </asp:Panel>
    <asp:Panel ID="wrongData" runat="server" Visible="false">
            <div class="alert alert-danger" style="margin-bottom:0">
                <div class="container">
                    <div class="alert-icon">
                        <i class="material-icons">error_outline</i>
                    </div>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="material-icons">clear</i></span>
                    </button>
                    <b>Error :</b> Please type in correct credit amount!
                </div>
            </div>

    </asp:Panel>
    <asp:Panel ID="cancelSet" runat="server" Visible="false">
            <div class="alert alert-danger" style="margin-bottom:0">
                <div class="container">
                    <div class="alert-icon">
                        <i class="material-icons">error_outline</i>
                    </div>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="material-icons">clear</i></span>
                    </button>
                    <b>Notice :</b> This post has been removed from highlight post!
                </div>
            </div>

    </asp:Panel>
                     <div class="page-header header-filter" data-parallax="true" style="background-image: url(&apos;../assets/img/bg5.jpg&apos;);" runat="server" id="BG">
        <div class="container">
            <div class="row">
                <div class="col-md-8 ml-auto mr-auto text-center">
                    <h1 class="title" runat="server" id="title"></h1>
                    <br>
                </div>
            </div>
        </div>
    </div>
    <div class="main main-raised">
        <div class="container">
            <div class="section section-text">
                <div class="row">
                    <div class="col-md-8 ml-auto mr-auto" runat="server" id="content">
                        
                </div>
            </div>
        </div>
            <div class="section section-blog-info">
                <div class="container">
                <div class="row">
                    <div class="col-md-8 ml-auto mr-auto">
                        <div class="row">
                            <button class="btn btn-google btn-round float-right" rel="tooltip" title="Tip this author" data-toggle="modal" data-target="#tipModal" onclick="return false;">
                                    <i class="material-icons">attach_money</i>TIP
                                </button>
                            <asp:LinkButton ID="favorite" OnClick="favorite_Click" CssClass="btn btn-facebook btn-round float-right" rel="tooltip" title="Add to favourite" runat="server"><i class="material-icons">favorite</i>Favourite</asp:LinkButton>
                            <asp:LinkButton ID="highlight" OnClick="highlight_Click" Visible="false" CssClass="btn btn-dribbble btn-round float-right" rel="tooltip" title="Highlight" runat="server"><i class="material-icons">star</i>Highlight</asp:LinkButton>
                        </div>
                        <div class="row">
                             <div class="modal fade" id="tipModal" tabindex="-1" role="dialog" data-backdrop="false">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Tip</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <i class="material-icons">clear</i>
                    </button>
                </div>
                <div class="modal-body" style="margin: 0 auto;display:inline-block">
                    
                    <div class="form-group">
                                <label for="exampleInput1" class="bmd-label-floating">How Much?</label>
                                <asp:TextBox ID="tip" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="bmd-help">We appreciate your support</span>
                            </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="confirmTip" runat="server" class="btn btn-primary btn-round" Text="Confirm" OnClick="confirmTip_Click"/>
                    <button type="button" class="btn btn-default btn-link" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
                            </div>
            <hr>
                        <div class="card card-profile card-plain">
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="card-avatar">
                                        <asp:Image ID="icon" CssClass="img" runat="server" />
                                        <div class="ripple-container"></div>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <h4 class="card-title" runat="server" id="author"></h4>
                                    <p class="description" runat="server" id="username"></p>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="visit" runat="server" OnClick="visit_Click" CssClass="btn btn-default pull-right btn-round" Text="Visit" />
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
                </div>
    </div>

                </div>

                </div>
    </div>
    </div>
</asp:Content>
