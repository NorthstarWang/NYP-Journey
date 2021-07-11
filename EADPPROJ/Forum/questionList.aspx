<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageQuestion.Master" AutoEventWireup="true" CodeBehind="questionList.aspx.cs" Inherits="EADPPROJ.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <!-- begin:: Content Head -->
    <div class="kt-subheader   kt-grid__item" id="kt_subheader">
        <div class="kt-container  kt-container--fluid ">
            <div class="kt-subheader__main">
                <h3 class="kt-subheader__title">Questions
                </h3>
                <span class="kt-subheader__separator kt-subheader__separator--v"></span>
                <div class="kt-subheader__toolbar" id="kt_subheader_search">
                    <span class="kt-subheader__desc" id="kt_subheader_total">
                        <asp:Label ID="RowCount" class="kt-subheader__desc" runat="server"></asp:Label></span>
                    <form class="kt-subheader__search" id="kt_subheader_search_form">
                        <div class="input-group">
                            <asp:TextBox ID="search" CssClass="form-control" runat="server" AutoPostBack="True"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="Btn_Search" CssClass="btn btn-primary btn-pill" runat="server" Text="Search" OnClick="Btn_Search_Click" />
                            </div>
                        </div>
                    </form>
                    <asp:DropDownList ID="Schooltype" class="btn btn-secondary dropdown-toggle" runat="server" AutoPostBack="True">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>SIT</asp:ListItem>
                        <asp:ListItem>SHSS</asp:ListItem>
                        <asp:ListItem>SEG</asp:ListItem>
                        <asp:ListItem>SIDM</asp:ListItem>
                        <asp:ListItem>SDN</asp:ListItem>
                        <asp:ListItem>SBM</asp:ListItem>
                        <asp:ListItem>SCL</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="kt-subheader__toolbar">
                <a href="./postQuestion.aspx" class="btn btn-brand btn-bold">Ask Now! </a>
            </div>
        </div>
    </div>
    <!-- end:: Content Head -->
    <!-- begin:: Content -->
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <!--Begin::App-->
        <div class="kt-grid kt-grid--desktop kt-grid--ver kt-grid--ver-desktop kt-app">
            <!--Begin:: App Content-->
            <div class="kt-portlet kt-portlet--mobile">
                <div class="kt-portlet__body kt-portlet__body--fit">
                    <div class="kt-grid__item kt-grid__item--fluid kt-app__content">
                        <div class="kt-portlet__body">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="Questions" Font-Size="Large" GridLines="None" Width="100%" BorderStyle="None" CssClass="table-sm" AllowPaging="True" AllowSorting="True" ShowFooter="True" DataKeyNames="Id">
                                <Columns>
                                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Forum/questionDetail.aspx?id={0}" DataTextField="Title" DataTextFormatString="{0}" HeaderText="Title">
                                        <ControlStyle CssClass="table-sm" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Width="40%" HorizontalAlign="Left" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="CreditReward" HeaderText="Reward" SortExpression="CreditReward">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" ControlStyle-CssClass="table-sm">
                                        <ControlStyle CssClass="table-sm" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SchoolType" HeaderText="Schools" SortExpression="SchoolType" ControlStyle-CssClass="table-sm">
                                        <ControlStyle CssClass="table-sm" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Username" HeaderText="Post By" SortExpression="Username" ControlStyle-CssClass="table-sm">
                                        <ControlStyle CssClass="table-sm" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastUpdate" HeaderText="LastUpdate" SortExpression="LastUpdate">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle CssClass="table-sm" />
                                <HeaderStyle CssClass="table-sm" />
                                <PagerSettings FirstPageText="&lt;i class=&quot;flaticon2-fast-back&quot;&gt;&lt;/i&gt;" Mode="NumericFirstLast" LastPageText="&lt;i class=&quot;flaticon2-fast-next&quot;&gt;&lt;/i&gt;" PageButtonCount="5" />
                                <PagerStyle Height="20px" HorizontalAlign="Center" Width="10px" />
                                <RowStyle CssClass="table-sm" BorderStyle="None" Height="60px" Font-Size="Large" />
                                <SelectedRowStyle CssClass="table-sm" />
                                <SortedAscendingCellStyle CssClass="table-sm" />
                                <SortedAscendingHeaderStyle CssClass="table-sm" />
                                <SortedDescendingCellStyle CssClass="table-sm" />
                                <SortedDescendingHeaderStyle CssClass="table-sm" />
                            </asp:GridView>

                            <asp:SqlDataSource ID="Questions" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Question] Where [Review] = 1 ORDER BY [State], [CreditReward] DESC, [LastUpdate] DESC"></asp:SqlDataSource>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--End:: App Content-->

    <!--End::App-->

    <!-- end:: Content -->
</asp:Content>
