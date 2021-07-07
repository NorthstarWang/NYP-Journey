<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCredit.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="EADPPROJ.invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <link href="assets/css/pages/invoice/invoice-v2.css" rel="stylesheet" type="text/css" />
    <div class="kt-content  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="kt-subheader kt-grid__item" id="kt_subheader"></div>
        <div class="kt-portlet">
            <div runat="server" id="pdfHTML">
								<div class="kt-invoice-2">
									<div class="kt-invoice__head">
										<div class="kt-invoice__container">
											<div class="kt-invoice__brand">
												<h1 class="kt-invoice__title">INVOICE</h1>
												<div href="#" class="kt-invoice__logo">
													<a href="#"><img src="assets/media/misc/NYP-logo.png"></a>
													<span class="kt-invoice__desc">
														<span>180 Ang Mo Kio Ave 8,</span>
														<span>Singapore 569830</span>
													</span>
												</div>
											</div>
											<div class="kt-invoice__items">
												<div class="kt-invoice__item">
													<span class="kt-invoice__subtitle">INVOICE TO:</span>
													<span class="kt-invoice__text">180 Ang Mo Kio Ave 8,<br>Singapore 569830</span>
												</div>
												<div class="kt-invoice__item">
													<span class="kt-invoice__subtitle">DATE:</span>
													<span class="kt-invoice__text" runat="server" id="PostTime"></span>
													<span class="kt-invoice__subtitle">INVOICE NO</span>
													<span class="kt-invoice__text" runat="server" id="invoiceId"></span>
												</div>
											</div>
										</div>
									</div>
									<div class="kt-invoice__body">
										<div class="kt-invoice__container">
                                            <asp:Repeater ID="RepeaterInvoice" runat="server" DataSourceID="SqlDataSource1" EnableViewState="false">
                                                <HeaderTemplate>
                                                <div class="table-responsive">
												    <table class="table">
													    <thead>
														    <tr>
															    <td>Book Name</td>
															    <td>Quantity</td>
															    <td>Credits Price/Book</td>
															    <td>AMOUNT</td>
														    </tr>
													    </thead>
													    <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                        <tr>
															<td><%# loadName(Convert.ToInt32(Eval("BookId").ToString())) %></td>
															<td><%#Eval("Quantity") %></td>
															<td><%# loadPrice(Convert.ToInt32(Eval("BookId").ToString())) %></td>
															<td><%# loadTotal(Convert.ToInt32(Eval("Quantity")),Convert.ToInt32(loadPrice(Convert.ToInt32(Eval("BookId").ToString())))) %></td>
														</tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
													</tbody>
												</table>
											</div>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [tb_Invoice] WHERE ([OrderId] = @OrderId)">
                                                <SelectParameters>
                                                    <asp:QueryStringParameter QueryStringField="id" Name="OrderId" Type="Int32"></asp:QueryStringParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
										</div>
									</div>
									<div class="kt-invoice__footer">
										<div class="kt-invoice__container">
											<div class="table-responsive">
												<table class="table">
													<thead>
														<tr>
															<th>School</th>
															<th>ACC.NO.</th>
															<th>TOTAL AMOUNT</th>
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>Nanyang Polytechnic</td>
															<td>
                                                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
															<td class="kt-font-danger kt-font-xl kt-font-boldest" runat="server" id="totalPrice"></td>
														</tr>
													</tbody>
												</table>
											</div>
										</div>
									</div>
									<div class="kt-invoice__actions">
										<div class="kt-invoice__container">
                                            <asp:Button ID="download" OnClick="download_Click" CssClass="btn btn-label-brand btn-bold" runat="server" Text="Download Invoice" />
										</div>
									</div>
								</div>
            </div>
							</div>

        </div>
        </div>
</asp:Content>
