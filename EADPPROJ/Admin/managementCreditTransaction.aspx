<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminManagement.Master" AutoEventWireup="true" CodeBehind="managementCreditTransaction.aspx.cs" Inherits="EADPPROJ.managementCreditTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
       <div class="kt-subheader   kt-grid__item" id="kt_subheader">
							<div class="kt-container  kt-container--fluid ">
								<div class="kt-subheader__main">
									<button class="kt-subheader__mobile-toggle" id="kt_subheader_mobile_toggle"><span></span></button>
									<h3 class="kt-subheader__title">
										Transactions
									</h3>
									<span class="kt-subheader__separator kt-subheader__separator--v"></span>
									<div class="kt-subheader__toolbar" id="kt_subheader_search">
										<span class="kt-subheader__desc" id="kt_subheader_total">
                                            <asp:Label ID="RowCount" class="kt-subheader__desc" runat="server"></asp:Label></span>
										<form class="kt-subheader__search" id="kt_subheader_search_form">
											<div class="input-group">
                                                <asp:TextBox ID="search" CssClass="form-control form-control-pill" runat="server" AutoPostBack="True"></asp:TextBox>
												
                                                <div class="input-group-append">
                                                    <asp:LinkButton ID="Btn_Search" CssClass="btn btn-outline-hover-brand btn-icon" runat="server" Text="<i class='fa fa-search'></i>" />
												</div>
											</div>
										</form>
									</div>
								</div>
							
							</div>
						</div>
							<div class="kt-portlet" style="height:86%;width:83%;position:fixed">
                                <div class="kt-section">
								<div class="kt-portlet__body">
                                    <asp:Label ID="NoData" runat="server" Text="No Record Found" Visible="false"></asp:Label>
                                    <asp:GridView ID="GridView1" CssClass="table table-striped- table-bordered table-hover table-checkable" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="creditTransaction" Width="100%" Font-Size="Large" PageSize="15">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                                            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                                            <asp:BoundField DataField="Act" HeaderText="Act" SortExpression="Act" />
                                            <asp:BoundField DataField="CreditValue" HeaderText="CreditValue" SortExpression="CreditValue" />
                                            <asp:BoundField DataField="OccurTime" HeaderText="OccurTime" SortExpression="OccurTime" />
                                        </Columns>
                                        <PagerSettings FirstPageText="&lt;i class=&quot;flaticon2-fast-back&quot;&gt;&lt;/i&gt;" Mode="NumericFirstLast" LastPageText="&lt;i class=&quot;flaticon2-fast-next&quot;&gt;&lt;/i&gt;" PageButtonCount="5" />
                                        <PagerStyle Height="20px" HorizontalAlign="Center" Width="10px" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="creditTransaction" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [tb_CreditRecord] WHERE [Id] = @original_Id AND [Username] = @original_Username AND [Act] = @original_Act AND [CreditValue] = @original_CreditValue AND [OccurTime] = @original_OccurTime" InsertCommand="INSERT INTO [tb_CreditRecord] ([Id], [Username], [Act], [CreditValue], [OccurTime]) VALUES (@Id, @Username, @Act, @CreditValue, @OccurTime)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [tb_CreditRecord] ORDER BY [OccurTime] DESC, [Id] DESC" UpdateCommand="UPDATE [tb_Record] SET [Username] = @Username, [Act] = @Act, [CreditValue] = @CreditValue, [OccurTime] = @OccurTime WHERE [Id] = @original_Id AND [Username] = @original_Username AND [Act] = @original_Act AND [CreditValue] = @original_CreditValue AND [OccurTime] = @original_OccurTime">
                                        <DeleteParameters>
                                            <asp:Parameter Name="original_Id" Type="Int32" />
                                            <asp:Parameter Name="original_Username" Type="String" />
                                            <asp:Parameter Name="original_Act" Type="String" />
                                            <asp:Parameter Name="original_CreditValue" Type="Int32" />
                                            <asp:Parameter Name="original_OccurTime" Type="DateTime" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="Id" Type="Int32" />
                                            <asp:Parameter Name="Username" Type="String" />
                                            <asp:Parameter Name="Act" Type="String" />
                                            <asp:Parameter Name="CreditValue" Type="Int32" />
                                            <asp:Parameter Name="OccurTime" Type="DateTime" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="Username" Type="String" />
                                            <asp:Parameter Name="Act" Type="String" />
                                            <asp:Parameter Name="CreditValue" Type="Int32" />
                                            <asp:Parameter Name="OccurTime" Type="DateTime" />
                                            <asp:Parameter Name="original_Id" Type="Int32" />
                                            <asp:Parameter Name="original_Username" Type="String" />
                                            <asp:Parameter Name="original_Act" Type="String" />
                                            <asp:Parameter Name="original_CreditValue" Type="Int32" />
                                            <asp:Parameter Name="original_OccurTime" Type="DateTime" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                    </div>
                                    </div>
                                </div>
        </div>
</asp:Content>
