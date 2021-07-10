<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageQuestion.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="postQuestion.aspx.cs" Inherits="EADPPROJ.postQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="container" style="margin: 20px">
        <br />
        <h3>Title</h3>
        <br />
        <asp:TextBox ID="TitlePost" class="form-control" runat="server" Rows="1" Width="40%" Font-Size="Large"></asp:TextBox>
        <br />
    </div>
    <div class="container" style="margin: 20px">
        <br />
        <h3>School Type</h3>
        <br />
        <asp:DropDownList ID="Type" class="form-control" runat="server" DataTextField="SchoolType" DataValueField="SchoolType" Width="20%" Font-Size="Large">
            <asp:ListItem>SIT</asp:ListItem>
            <asp:ListItem>SEG</asp:ListItem>
            <asp:ListItem>SIDM</asp:ListItem>
            <asp:ListItem>SHSS</asp:ListItem>
            <asp:ListItem>SDN</asp:ListItem>
            <asp:ListItem>SBM</asp:ListItem>
            <asp:ListItem>SCL</asp:ListItem>
        </asp:DropDownList>
        <br />
    </div>
    <div class="container" style="margin: 20px">
        <asp:DropDownList ID="CreditReward" runat="server" class="form-control" Width="20%" Font-Size="Large">
            <asp:ListItem Selected="True">10</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>100</asp:ListItem>
        </asp:DropDownList>
        <br />
    </div>
    <div class="container" style="margin: 20px">
        <br />
        <h3>Content</h3>
        <br />
        <asp:TextBox ID="QuestionPost" TextMode="MultiLine" runat="server"></asp:TextBox>
        <br />
    </div>
    <br />
    <div class="container" style="margin: 20px">
        <asp:Button ID="Post" runat="server" Text="Submit" class="btn btn-success rounded-pill" OnClick="Post_Click" />
        <br />
    </div>
</asp:Content>
