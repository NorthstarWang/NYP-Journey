<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="questionnaire.aspx.cs" Inherits="EADPPROJ.Questionnaire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
     <div class="main main-raised">
            <div class="section section-basic">
            <div class="container">
    <div class="title">
                    <h2>User Feedback</h2>
                </div>
    <div class="cards" id="morphingCards">
                    <div class="container">
                        <div class="row">
                            <div class="col-10">
                        <div class="form-group">
                            <label>Admin Number: </label>
                            <asp:TextBox ID="adminno" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="adminnoValid" runat="server"
                                ControlToValidate="adminno" ErrorMessage="Please enter your admin number" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        
                        <div class="form-group">
                            <label>Which school are you from?</label>
                            <asp:RadioButtonList ID="school" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem text="SBM" value="SBM"/>
                                <asp:ListItem text="SHSS" value="SHSS"/>
                                <asp:ListItem text="SEG" value="SEG"/>
                                <asp:ListItem text="SDN" value="SDN"/>
                                <asp:ListItem text="SHLS" value="SHLS"/>
                                <asp:ListItem text="SIT" value="SIT"/>
                                <asp:ListItem text="SIDM" value="SIDM"/>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="schoolValid" runat="server"
                                ControlToValidate="school" ErrorMessage="Please select a school" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>What is your current year at NYP?</label>
                            <asp:RadioButtonList ID="year" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem text="Year 1" value="y1"/>
                                <asp:ListItem text="Year 2" value="y2"/>
                                <asp:ListItem text="Year 3" value="y3"/>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="yearValid" runat="server"
                                ControlToValidate="year" ErrorMessage="Please select a year" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>How would you rate the overall quality of this website?</label>
                            <asp:RadioButtonList ID="qlty" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem text="Terrible" value="terrible"/>
                                <asp:ListItem text="OK" value="okay"/>
                                <asp:ListItem text="Great" value="great"/>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="qltyValid" runat="server"
                                ControlToValidate="qlty" ErrorMessage="Please select a quality" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>Would you recommend this website to your friends?</label>
                            <asp:RadioButtonList ID="rcmd" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem text="No" value="no"/>
                                <asp:ListItem text="Yes" value="yes"/>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="rcmdValid" runat="server"
                                ControlToValidate="rcmd" ErrorMessage="Please select an answer" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>How difficuly do you find it to navigate our website?</label>
                            <asp:RadioButtonList ID="nav" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem text="Very Hard" value="vhard"/>
                                <asp:ListItem text="Hard" value="hard"/>
                                <asp:ListItem text="OK" value="ok"/>
                                <asp:ListItem text="Easy" value="easy"/>
                                <asp:ListItem text="Very Easy" value="veasy"/>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="navValid" runat="server"
                                ControlToValidate="nav" ErrorMessage="Please select an answer" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <h6>What was the reason you visited this website?</h6>
                            <asp:TextBox ID="reas" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reasValid" runat="server"
                                ControlToValidate="reas" ErrorMessage="Please enter your reason" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>Your school email</label>
                            <asp:TextBox ID="email" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="emailValid" runat="server"
                                ControlToValidate="email" ErrorMessage="Please enter your email" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="form-control" />
                        </div>
                                </div>
                            </div>
                    </div>
        </div>
                </div>
                </div>
        </div>
    
</asp:Content>
