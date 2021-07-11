<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageAdminManagement.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="managementTeacher.aspx.cs" Inherits="EADPPROJ.managementEditTeacherInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="kt-subheader kt-grid__item" id="kt_subheader">
            <div class="kt-container  kt-container--fluid ">
                <div class="kt-subheader__main">
                    <button class="kt-subheader__mobile-toggle" id="kt_subheader_mobile_toggle"><span></span></button>
                    <h3 class="kt-subheader__title">Teachers
                    </h3>
                    <span class="kt-subheader__separator kt-subheader__separator--v"></span>
                    <div class="kt-subheader__toolbar" id="kt_subheader_search">
                        <span class="kt-subheader__desc" id="kt_subheader_total">
                            <asp:Label ID="RowCount" class="kt-subheader__desc" runat="server"></asp:Label></span>
                        <div class="input-group">
                            <asp:TextBox ID="search" CssClass="form-control form-control-pill" runat="server" AutoPostBack="True"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:LinkButton ID="Btn_Search" CssClass="btn btn-outline-hover-danger btn-icon" runat="server" Text="<i class='fa fa-search'></i>" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="kt-portlet kt-portlet--mobile" style="height: 86%; width: 83%; position: fixed">
            <div class="kt-portlet__head">
                <div class="kt-portlet__head-label">
                    <h3 class="kt-portlet__head-title">Teacher Management
                    </h3>
                </div>
            </div>
            <div class="kt-portlet__body">
                <asp:Label ID="NoData" runat="server" Visible="false" Text="No Data Found"></asp:Label>
                <asp:GridView ID="GridView1" CssClass="table table-striped- table-bordered table-hover table-checkable" runat="server" AutoGenerateColumns="False" DataKeyNames="NRIC" DataSourceID="TeacherInfo" AllowPaging="True" Font-Size="Large" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="NRIC" HeaderText="NRIC" ReadOnly="True" SortExpression="NRIC" ItemStyle-Width="20%">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" ItemStyle-Width="30%">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-Width="25%">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" ItemStyle-Width="20%">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                            <ItemTemplate>

                                <div class="dropdown dropdown-inline">
                                    <div class="dropdown dropdown-inline">
                                        <asp:LinkButton ID="Delete" CssClass="btn btn-clean btn-sm btn-icon btn-icon-md" OnClick="Delete_Click" runat="server"><i class="la la-trash-o"></i></asp:LinkButton>

                                    </div>
                                </div>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings FirstPageText="&lt;i class=&quot;flaticon2-fast-back&quot;&gt;&lt;/i&gt;" Mode="NumericFirstLast" LastPageText="&lt;i class=&quot;flaticon2-fast-next&quot;&gt;&lt;/i&gt;" PageButtonCount="5" />
                    <PagerStyle Height="20px" HorizontalAlign="Center" Width="10px" />

                </asp:GridView>
                <asp:SqlDataSource ID="TeacherInfo" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Teacher] ORDER BY [NRIC] DESC"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
