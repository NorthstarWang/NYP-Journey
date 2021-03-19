<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAcee.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="EADPPROJ.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <table>
        <tr><th>Contact Us</th></tr>
        <tr><td>Name:</td><td><asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
        <tr><td>Email-Id:</td><td><asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
        <tr><td>Subject Of Complaint:</td><td><asp:TextBox ID="tbSubject" runat="server"></asp:TextBox></td></tr>
        <tr><td>Complaint:</td><td><asp:TextBox ID="tbComplaint" runat="server" TextMode="MultiLine"></asp:TextBox></td></tr>
        <tr><td></td><td><asp:Button ID="btnSubmit" runat="server" Text="Send" OnClick="btnSubmit_Click" />
                         <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                     </td></tr>
        <tr><td colspan="2">
            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Green"></asp:Label>
            </td></tr>
    </table>
</asp:Content>
