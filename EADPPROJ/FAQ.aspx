<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAcee.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="EADPPROJ.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script type="text/javascript" src="jquery.min.js"></script>
    <link href="https://unpkg.com/ionicon@4.5.10-0/dist/css/ionicons.min.css" rel="stylesheet" />
    <link href="assets/css/style.bundle.css" rel="stylesheet" />
    <link rel="stylesheet" href="styles.css" />
    <div class="kt-subheader kt-grid__item" id="kt_subheader"></div>
   <section id="faq">
       <div class="col-xl-12">

									<!--begin::Portlet-->
									<div class="kt-portlet">
										<div class="kt-portlet__head">
											<div class="kt-portlet__head-label">
												<h3 class="kt-portlet__head-title">FAQ</h3>
											</div>
										</div>
										<div class="kt-portlet__body">
											<div class="accordion" id="accordionExample">
												<div class="card">
													<div class="card-header" id="headingOne">
														<div class="card-title" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
															Which course is suitable for me
														</div>
													</div>
													<div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
														<div class="card-body">
															You can select from a wide range of courses based on the school you are in
														</div>
													</div>
												</div>
												<div class="card">
													<div class="card-header" id="headingTwo">
														<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
															Is there activities or clubs I can join?
														</div>
													</div>
													<div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
														<div class="card-body">
															Here's a wide range of CCAs</div>
													</div>
												</div>
												<div class="card">
													<div class="card-header" id="headingThree">
														<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
															What is the solution to my work
														</div>
													</div>
													<div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
														<div class="card-body">
															Here are some suggestions to your solutions</div>
													</div>
												</div>
											</div>
										</div>
									</div>

									<!--end::Portlet-->
								</div>
   </section>
    <div class="col-12">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Question" DataSourceID="SqlDataSource1" >
            <Columns>
                <asp:BoundField DataField="Question" HeaderText="Question" SortExpression="Question" />
                <asp:BoundField DataField="Answer" HeaderText="Answer" SortExpression="Answer" />
            </Columns>

        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Question], [Answer] FROM [Faq]"></asp:SqlDataSource>
</div>
</asp:Content>
