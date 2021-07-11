<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageCredit.Master" AutoEventWireup="true" CodeBehind="creditBalance.aspx.cs" Inherits="EADPPROJ.creditBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <link href="../assets/css/pages/pricing/pricing-v1.css" rel="stylesheet" type="text/css" />
    <div class="kt-content  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">
        <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
            <div class="kt-subheader kt-grid__item" id="kt_subheader"></div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="kt-portlet kt-portlet--tabs">
                        <div class="kt-portlet__head">
                            <div class="kt-portlet__head-label">
                                <h3 class="kt-portlet__head-title">Credit
                                </h3>
                            </div>
                            <div class="kt-portlet__head-toolbar">
                                <ul class="nav nav-tabs nav-tabs-bold nav-tabs-line nav-tabs-line-brand" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-toggle="tab" href="#kt_portlet_tabs_1_1_content" role="tab">Balance
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="tab" href="#kt_portlet_tabs_1_2_content" role="tab">Transation history
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="tab" href="#kt_portlet_tabs_1_3_content" role="tab">Invoice
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="kt-portlet__body">
                            <div class="tab-content">
                                <div class="tab-pane active" id="kt_portlet_tabs_1_1_content" role="tabpanel">
                                    <div class="row row-no-padding">
                                        <div class="col-lg-12 col-xl-3">
                                            <div class="kt-pricing-v1 kt-pricing-v1--danger">
                                                <div class="kt-pricing-v1__header">
                                                    <div class="kt-iconbox kt-iconbox--no-hover">
                                                        <div class="kt-iconbox__icon">
                                                            <div class="kt-iconbox__icon-bg"></div>
                                                            <i class="flaticon-avatar"></i>
                                                        </div>
                                                        <div class="kt-iconbox__title">
                                                            Total Balance
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="kt-pricing-v1__body">
                                                    <div class="kt-pricing-v1__content">
                                                        Total available credits you can use in this system.
                                                    </div>
                                                    <div class="kt-pricing-v1__price">
                                                        <asp:Label ID="creditAmt" runat="server" Text="Label"></asp:Label><span class="kt-pricing-v1__price-currency">Credits</span>
                                                    </div>
                                                    <div class="kt-pricing-v1__button">
                                                        <a class="btn btn-primary btn-pill btn-widest btn-taller btn-bold" href="./creditTopUp.aspx">Top Up More</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-xl-3">
                                            <div class="kt-pricing-v1 kt-pricing-v1--success">
                                                <div class="kt-pricing-v1__header">
                                                    <div class="kt-iconbox kt-iconbox--no-hover">
                                                        <div class="kt-iconbox__icon">
                                                            <div class="kt-iconbox__icon-bg"></div>
                                                            <i class="flaticon-statistics"></i>
                                                        </div>
                                                        <div class="kt-iconbox__title">
                                                            Total Transaction
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="kt-pricing-v1__body">
                                                    <div class="kt-pricing-v1__content">
                                                        Number of transactions you have dealed.
                                                    </div>
                                                    <div class="kt-pricing-v1__price">
                                                        <asp:Label ID="transactionNo" runat="server"></asp:Label><span class="kt-pricing-v1__price-currency">Transactions</span>
                                                    </div>
                                                    <div class="kt-pricing-v1__button">
                                                        <a data-toggle="tab" href="#kt_portlet_tabs_1_2_content">
                                                            <button type="button" class="btn btn-primary btn-pill btn-widest btn-taller btn-bold">Check</button></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-xl-3">
                                            <div class="kt-pricing-v1 kt-pricing-v1--warning">
                                                <div class="kt-pricing-v1__header">
                                                    <div class="kt-iconbox">
                                                        <div class="kt-iconbox__icon">
                                                            <div class="kt-iconbox__icon-bg"></div>
                                                            <i class="flaticon-price-tag"></i>
                                                        </div>
                                                        <div class="kt-iconbox__title">
                                                            Total Spent
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="kt-pricing-v1__body">
                                                    <div class="kt-pricing-v1__content">
                                                        Total credits spent in the system.
                                                    </div>
                                                    <div class="kt-pricing-v1__price">
                                                        <asp:Label ID="spentNo" runat="server"></asp:Label><span class="kt-pricing-v1__price-currency">Credits</span>
                                                    </div>
                                                    <div class="kt-pricing-v1__button">
                                                        <a data-toggle="tab" href="#kt_portlet_tabs_1_2_content" class="btn btn-primary btn-pill btn-widest btn-taller btn-bold">Check</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-xl-3">
                                            <div class="kt-pricing-v1 kt-pricing-v1--last kt-pricing-v1--focus">
                                                <div class="kt-pricing-v1__header">
                                                    <div class="kt-iconbox">
                                                        <div class="kt-iconbox__icon">
                                                            <div class="kt-iconbox__icon-bg"></div>
                                                            <i class="flaticon-coins"></i>
                                                        </div>
                                                        <div class="kt-iconbox__title">
                                                            Total Earn
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="kt-pricing-v1__body">
                                                    <div class="kt-pricing-v1__content">
                                                        Total credits earned or topped op from the system.
                                                    </div>
                                                    <div class="kt-pricing-v1__price">
                                                        <asp:Label ID="earnNo" runat="server"></asp:Label><span class="kt-pricing-v1__price-currency">Credits</span>
                                                    </div>
                                                    <div class="kt-pricing-v1__button">
                                                        <a data-toggle="tab" href="#kt_portlet_tabs_1_2_content" class="btn btn-primary btn-pill btn-widest btn-taller btn-bold">Check</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="kt_portlet_tabs_1_2_content" role="tabpanel">
                                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                        <HeaderTemplate>
                                            <div class="kt-section__content">
                                                <table class="table">
                                                    <thead class="thead-dark">
                                                        <tr>
                                                            <th>#</th>
                                                            <th>Amount</th>
                                                            <th>Time</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <th scope="row"><%#Container.ItemIndex+1 %></th>
                                                <td><%# ((string)Eval("Act") == "Add") ? "+" : "-" %><%#Eval("CreditValue") %></td>
                                                <td><%#Eval("OccurTime") %></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                                            </table>
                                                            </div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [tb_CreditRecord] WHERE ([Username] = @Username)">
                                        <SelectParameters>
                                            <asp:SessionParameter SessionField="Account" Name="Username" Type="String"></asp:SessionParameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <div class="tab-pane" id="kt_portlet_tabs_1_3_content" role="tabpanel">
                                    <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                        <HeaderTemplate>
                                            <div class="kt-section__content">
                                                <table class="table table-head-noborder">
                                                    <thead>
                                                        <tr>
                                                            <th>#</th>
                                                            <th>Invoice Id</th>
                                                            <th>Generate On</th>
                                                            <th>Link</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <th scope="row"><%# Container.ItemIndex+1 %></th>
                                                <td><%# Eval("Id") %></td>
                                                <td><%# Eval("PostTime") %></td>
                                                <td><a href="./invoice.aspx?id=<%#Eval("Id").ToString() %>">
                                                    <button type="button" class="btn btn-focus btn-elevate btn-elevate-air btn-pill btn-success">View Invoice Detail</button></a></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                                            </table>
                                                            </div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [tb_Order] WHERE ([Username] = @Username) ORDER BY [Id] DESC">
                                        <SelectParameters>
                                            <asp:SessionParameter SessionField="Account" Name="Username" Type="String"></asp:SessionParameter>
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
</asp:Content>
