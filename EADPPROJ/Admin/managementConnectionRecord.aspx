<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminManagement.Master" AutoEventWireup="true" CodeBehind="managementConnectionRecord.aspx.cs" Inherits="EADPPROJ.managementStatistic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="kt-content  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">
        <div class="kt-subheader   kt-grid__item" id="kt_subheader">
							<div class="kt-container  kt-container--fluid ">
								<div class="kt-subheader__main">
									<button class="kt-subheader__mobile-toggle" id="kt_subheader_mobile_toggle"><span></span></button>
									<h3 class="kt-subheader__title">
										Records
									</h3>
									<span class="kt-subheader__separator kt-subheader__separator--v"></span>
									<div class="kt-subheader__toolbar" id="kt_subheader_search">
										<span class="kt-subheader__desc" id="kt_subheader_total">
                                            <asp:Label ID="RowCount" class="kt-subheader__desc" runat="server"></asp:Label></span>
										<form class="kt-subheader__search" id="kt_subheader_search_form">
											<div class="input-group">
                                                <asp:TextBox ID="search" CssClass="form-control form-control-pill" runat="server" AutoPostBack="True"></asp:TextBox>
												<asp:TextBox ID="daterange" name="dates" class="form-control form-control-pill" runat="server"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <asp:LinkButton ID="Btn_Apply" CssClass="btn btn-outline-hover-brand btn-icon" runat="server" Text="<i class='fa fa-search'></i>" />
												
												</div>
											</div>
										</form>
									</div>
								</div>
							
							</div>
						</div>
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid" >
							<div class="kt-portlet" style="height:86%;width:83%;position:fixed">
                                <div class="kt-section">
								<div class="kt-portlet__body">
                                    <asp:Label ID="NoData" runat="server" Text="No Record Found" Visible="false"></asp:Label>
                                    <asp:GridView ID="connectionRecord" class="table table-striped- table-bordered table-hover table-checkable" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="conRecord" Width="100%" Font-Size="Medium" PageSize="15">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                            <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP" />
                                            <asp:BoundField DataField="LoginTime" HeaderText="LoginTime" SortExpression="LoginTime" />
                                            <asp:BoundField DataField="LeaveTime" HeaderText="LeaveTime" SortExpression="LeaveTime" />
                                            <asp:BoundField DataField="Browser" HeaderText="Browser" SortExpression="Browser" />
                                            <asp:BoundField DataField="OS" HeaderText="OS" SortExpression="OS" />
                                            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                                        </Columns>
                                        <PagerSettings FirstPageText="&lt;i class=&quot;flaticon2-fast-back&quot;&gt;&lt;/i&gt;" Mode="NumericFirstLast" LastPageText="&lt;i class=&quot;flaticon2-fast-next&quot;&gt;&lt;/i&gt;" PageButtonCount="5" />
                                        <PagerStyle Height="20px" HorizontalAlign="Center" Width="10px" />
                                    </asp:GridView>
                                    </div>
                                    </div>
                                </div>
        </div>
        </div>
    <asp:SqlDataSource ID="conRecord" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_ConnectionRecord] ORDER BY [LeaveTime] DESC, [Id] DESC"></asp:SqlDataSource>
    <script src="assets/js/plugins/moment.min.js"></script>
    <script src="assets/js/core/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
    <script>
        $(function () {
            $('[id$=daterange]').daterangepicker({
                autoUpdateInput: false,
                locale: {
                    cancelLabel: 'Clear'
                }
            });
            $('[id$=daterange]').on('apply.daterangepicker', function (ev, picker) {
                $(this).val(picker.startDate.format('YYYY/MM/DD') + '-' + picker.endDate.format('YYYY/MM/DD'));
            });

            $('[id$=daterange]').on('cancel.daterangepicker', function (ev, picker) {
                $(this).val('');
            });
        });
</script>
</asp:Content>
