<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageShop.Master" AutoEventWireup="true" CodeBehind="bookShop.aspx.cs" Inherits="EADPPROJ.bookShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="section-title">Redeem Your Credits!</h2>
                    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" ItemPlaceholderID="itemPlaceholder" GroupPlaceholderID="groupPlaceholder" GroupItemCount="3">
                        <LayoutTemplate>
                            <div class="container" id="groupPlaceholderContainers" runat="server">
                                <div class="section">
                                    <div id="groupPlaceholder" runat="server">
                                    </div>
                                </div>
                            </div>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <div id="itemPlaceholderContainer" runat="server">
                                <div class="row">
                                    <div id="itemPlaceholder" runat="server"></div>
                                </div>
                            </div>
                        </GroupTemplate>
                        <ItemTemplate>
                            <div class="col-md-4">
                                <div class="card card-product card-plain no-shadow" data-colored-shadow="false">
                                    <div class="card-header card-header-image">
                                        <a href='./bookDetail.aspx?id=<%# Eval("Id") %>'>
                                            <img src='../assets/img/books/<%# Eval("Image").ToString() %>' alt="..." height="450px">
                                        </a>
                                    </div>
                                    <div class="card-body">
                                        <div style="height: 110px;">
                                            <a href='./bookDetail.aspx?id=<%# Eval("Id") %>'>
                                                <h4 class="card-title"><%# Eval("Name") %></h4>
                                            </a>
                                        </div>
                                        <p class="description">
                                            <%# Eval("School") %>
                                        </p>
                                    </div>
                                    <div class="card-footer justify-content-between">
                                        <div class="price-container">
                                            <span class="price"><%# Eval("Price").ToString() %> Credits</span>
                                        </div>
                                        <asp:Label ID="Id" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="btn btn-primary btn-fab btn-round pull-right" runat="server">
                                            <i class="material-icons">add</i>
                                        </asp:LinkButton>
                                        <a href='./bookDetail.aspx?id=<%# Eval("Id") %>'>
                                            <div class="btn btn-primary btn-round pull-right"><i class="material-icons">search</i>View Detail</div>
                                        </a>
                                    </div>
                                </div>
                                <!-- end card -->
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [tb_Shop] ORDER BY [Id]"></asp:SqlDataSource>

                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>
