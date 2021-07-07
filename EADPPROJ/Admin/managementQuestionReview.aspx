<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminManagement.Master" AutoEventWireup="true" CodeBehind="managementQuestionReview.aspx.cs" Inherits="EADPPROJ.managementQuestionReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server" >
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid" style="height:100%">
        <div class="kt-subheader   kt-grid__item" id="kt_subheader"></div>
        <div class="kt-portlet kt-portlet--mobile" style="height:86%;width:83%;position:fixed">
            <div class="kt-portlet__head">
                <div class="kt-portlet__head-label">
                    <h3 class="kt-portlet__head-title">Question Review
                    </h3>
                </div>
            </div>
            <div class="kt-portlet__body" style="height: 100%">
                <asp:Label ID="NoRecord" runat="server" Text="Currently there is no more question need to be reviewed" Visible="false"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="QuestionReviewGV" AllowPaging="True" BorderStyle="None" ShowHeaderWhenEmpty="True" Font-Size="Large" GridLines="None">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="questionDetail.aspx?id={0}" DataTextField="Title" DataTextFormatString="{0}" HeaderText="Title">
                            <ControlStyle BorderStyle="None" />
                            <ItemStyle Width="85%" />
                        </asp:HyperLinkField>
                        <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="Approve" CssClass="btn btn-outline-hover-success" runat="server" Text="Approve" OnClick="Approve_Click" />
                                <asp:Button ID="Delete" CssClass="btn btn-outline-hover-danger" runat="server" Text="Reject" OnClick="Delete_Click" />
                                <asp:HiddenField ID="IdV" Visible="false" Value='<%# Eval("Id") %>' runat="server" />
                                <asp:HiddenField ID="User" Visible="false" Value='<%# Eval("Username") %>' runat="server" />
                                <asp:HiddenField ID="URL" Visible="false" Value='<%# Eval("id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle Width="100%" />
                </asp:GridView>
                <asp:SqlDataSource ID="QuestionReviewGV" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Question] WHERE ([Review] = @Review) ORDER BY [Id]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="Review" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
                                </div>
</asp:Content>
