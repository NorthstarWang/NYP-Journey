<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRanking.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="rank.aspx.cs" Inherits="EADPPROJ.Rank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="requireSelection" runat="server" Visible="false" >
    <div class="alert alert-warning" style="margin-bottom:0">
                <div class="container">
                    <div class="alert-icon">
                        <i class="material-icons">warning</i>
                    </div>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="material-icons">clear</i></span>
                    </button>
                    <b>Warning :</b> Please select the options in order to check the ranking!
                </div>
            </div>
    </asp:Panel>
    <asp:Panel ID="illegalAccess" runat="server" Visible="false" >
    <div class="alert alert-danger" style="margin-bottom:0">
                <div class="container">
                    <div class="alert-icon">
                        <i class="material-icons">error_outline</i>
                    </div>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="material-icons">clear</i></span>
                    </button>
                    <b>Error :</b> Illegal access! Please select the options on this page in order to check the ranking!
                </div>
            </div>
    </asp:Panel>
    <div class="page-header header-filter" style="background-image: url(&apos;assets/img/examples/office2.jpg&apos;);">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-8 ml-auto mr-auto text-center">
                                <h1 class="title">May the force be with you.</h1>
                                <h4>You can check the ranking using this system!</h4>
                            </div>
                            <div class="col-md-8 ml-auto mr-auto">
                                <div class="card card-raised card-form-horizontal">
                                    <div class="card-body ">
                                        <form method="" action="">
                                            <div class="row">
                                                <div class="col-md-8">
                                                    <asp:DropDownList CssClass="selectpicker" data-style="select-with-transition" ID="type" runat="server" title="Select Rank Type" AutoPostBack="False" ViewStateMode="Enabled">
                                                        <asp:ListItem Selected="False" Value="0" Enabled="False">--Select Rank Type--</asp:ListItem>
                                                        <asp:ListItem>User</asp:ListItem>
                                                        <asp:ListItem Value="Question">Let&#39;s Ask</asp:ListItem>
                                                        <asp:ListItem>Blog</asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Button ID="check" CssClass="btn btn-primary btn-block" runat="server" Text="Check" OnClick="check_Click"/>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>
                        
</asp:Content>
