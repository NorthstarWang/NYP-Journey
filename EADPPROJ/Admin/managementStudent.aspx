<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminManagement.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="managementStudent.aspx.cs" Inherits="EADPPROJ.managementEditPersonalInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="kt-subheader   kt-grid__item" id="kt_subheader">
							<div class="kt-container  kt-container--fluid ">
								<div class="kt-subheader__main">
									<button class="kt-subheader__mobile-toggle" id="kt_subheader_mobile_toggle"><span></span></button>
									<h3 class="kt-subheader__title">
										Students
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
							<div class="kt-portlet kt-portlet--mobile" style="height:86%;width:83%;position:fixed">
								<div class="kt-portlet__head">
									<div class="kt-portlet__head-label">
										<h3 class="kt-portlet__head-title">
											Student Management
										</h3>
									</div>
                                    </div>
								<div class="kt-portlet__body">
                                    <asp:Label ID="NoData" runat="server" Visible="false" Text="No Data Found"></asp:Label>
    <asp:GridView ID="GridView1" CssClass="table table-striped- table-bordered table-hover table-checkable" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="AdminNo" DataSourceID="PersonalInfo" PageSize="15" Width="100%" Font-Size="Large">
        <Columns>
            <asp:BoundField DataField="AdminNo" HeaderText="AdminNo" ReadOnly="True" SortExpression="AdminNo" ItemStyle-Width="20%">
<ItemStyle Width="20%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" ItemStyle-Width="30%">
<ItemStyle Width="30%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-Width="20%">
<ItemStyle Width="20%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Graduation" HeaderText="Graduation" SortExpression="Graduation" ItemStyle-Width="10%">
<ItemStyle Width="10%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" ItemStyle-Width="10%">
<ItemStyle Width="10%"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Actions" ItemStyle-Width="10%">
                <ItemTemplate>
                    <div class="dropdown dropdown-inline">
												<button type="button" class="btn btn-clean btn-sm btn-icon btn-icon-md" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
													<i class="la la-ellipsis-h"></i>
												</button>
												<div class="dropdown-menu dropdown-menu-right">
													<ul class="kt-nav">
														<li class="kt-nav__item">
															<a href="#" class="kt-nav__link" data-toggle="modal" data-target="#modalEdit">
																<i class="kt-nav__link-icon flaticon2-edit"></i>
																<span class="kt-nav__link-text">Edit Graduation</span>
															</a>
														</li>
														<li class="kt-nav__item">
															<a href="#" class="kt-nav__link" data-toggle="modal" data-target="#modalDeletion">
																<i class="kt-nav__link-icon flaticon2-trash"></i>
																<span class="kt-nav__link-text">Delete</span>
															</a>
                                                                
															
														</li>
													</ul>

												</div>
                        
											</div>
                   <div class="modal fade" id="modalDeletion" tabindex="-1" role="dialog" aria-labelledby="modalDeletionLabel" aria-hidden="true" data-backdrop="false">
														            <div class="modal-dialog" role="document">
															            <div class="modal-content">
																            <div class="modal-header">
																	            <h5 class="modal-title" id="modalDeletionLabel">Deletion</h5>
																	            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
																		            <span aria-hidden="true">&times;</span>
																	            </button>
																            </div>
																<div class="modal-body">
																	<p>Are you sure you want to delete <%# Eval("AdminNo", "{0}") %>?</p>
																</div>
																<div class="modal-footer">
																	<button type="button" class="btn btn-outline-brand" data-dismiss="modal">Close</button>
																     <asp:Button ID="btn_Delete" CssClass="btn btn-brand" runat="server" Text="Delete" OnClick="btn_Delete_Click"/>
                                                                </div>
															</div>
														</div>
													</div>
                    <div class="modal fade" id="modalEdit" tabindex="-1" role="dialog" aria-labelledby="modalEditLabel" aria-hidden="true" data-backdrop="false">
														            <div class="modal-dialog" role="document">
															            <div class="modal-content">
																            <div class="modal-header">
																	            <h5 class="modal-title" id="modalEditLabel">Edit Graduation</h5>
																	            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
																		            <span aria-hidden="true">&times;</span>
																	            </button>
																            </div>
																<div class="modal-body">
                                                                    <asp:TextBox ID="newGraduation" runat="server" CssClass="form-control" Text='<%# Eval("Graduation", "{0}") %>'></asp:TextBox>
																</div>
																<div class="modal-footer">
																	<button type="button" class="btn btn-outline-brand" data-dismiss="modal">Close</button>
																     <asp:Button ID="btn_Change" CssClass="btn btn-brand" runat="server" Text="Save Change" OnClick="btn_Change_Click"/>
                                                                </div>
															</div>
														</div>
													</div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
            </asp:TemplateField>
        </Columns>
        <PagerSettings FirstPageText="&lt;i class=&quot;flaticon2-fast-back&quot;&gt;&lt;/i&gt;" Mode="NumericFirstLast" LastPageText="&lt;i class=&quot;flaticon2-fast-next&quot;&gt;&lt;/i&gt;" PageButtonCount="5" />
                                        <PagerStyle Height="20px" HorizontalAlign="Center" Width="10px" />
    </asp:GridView>
    <asp:SqlDataSource ID="PersonalInfo" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Student] ORDER BY [AdminNo]"></asp:SqlDataSource>
    </div>
                                    </div>
                                </div>
</asp:Content>
