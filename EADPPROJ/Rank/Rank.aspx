<%@ Page Title="" Language="C#" MasterPageFile="~/Rank/MasterPageRanking.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="rank.aspx.cs" Inherits="EADPPROJ.Rank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="requireSelection" runat="server" Visible="false">
        <div class="alert alert-warning" style="margin-bottom: 0">
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
    <asp:Panel ID="illegalAccess" runat="server" Visible="false">
        <div class="alert alert-danger" style="margin-bottom: 0">
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
                    <h2 class="title">Check Ranking</h2>
                    <h4>Proceed to view the rank by selecting the option and clicking check button</h4>
                </div>
                <div class="col-md-8 ml-auto mr-auto">
                    <div class="card card-raised card-form-horizontal">
                        <div class="card-body ">
                                <div class="row">
                                    <div class="col-md-8">
                                        <select class="selectpicker" data-style="select-with-transition" id="rank" title="Select Rank Type" data-size="3">
                                            <option disabled>Choose rank to view</option>
                                            <option value="User">User</option>
                                            <option value="Question">Let&#39;s Ask</option>
                                            <option value="Blog">Blog</option>
                                        </select>
                                    </div>
                                    <div class="col-md-4">
                                        <script>
                                            function view_rank()
                                            {
                                                var url = "./Rank/rankDetail.aspx?type=";
                                                var select_val = document.getElementById("rank").value;
                                                if (select_val.length!==0) {
                                                    window.location.href = url + select_val;
                                                } else {
                                                    alert("Please select a rank to view");
                                                }
                                            }
                                        </script>
                                        <input type="button" class="btn btn-primary btn-block" runat="server" value="Check" onclick="view_rank()"/>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
