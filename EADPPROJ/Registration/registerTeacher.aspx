<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageRegistration.Master" AutoEventWireup="true" CodeBehind="registerTeacher.aspx.cs" Inherits="EADPPROJ.registerTeacher" %>

<asp:Content ID="registerTeacher" ContentPlaceHolderID="register" runat="server">
    <div class="form-group">
        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text">
                    <i class="material-icons">perm_identity</i>
                </span>
            </div>
            <asp:TextBox ID="NRIC" class="form-control" placeholder="NRIC/FIN..." runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="NRIC" ErrorMessage="Required Field" Display="Dynamic" ForeColor="Red" />
        </div>
    </div>
    <div class="form-group">
        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text">
                    <i class="material-icons">mail_outline</i>
                </span>
            </div>
            <asp:TextBox ID="mail" placeholder="Email..." class="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="mail" ErrorMessage="Required Field" Display="Dynamic" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="MailValidate" runat="server" ControlToValidate="mail" Display="Dynamic" ErrorMessage="Invalid Format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text">
                    <i class="material-icons">lock_outline</i>
                </span>
            </div>
            <asp:TextBox ID="pwd" type="password" class="form-control" placeholder="Password..." runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="pwd" ErrorMessage="Required Field" Display="Dynamic" ForeColor="Red" />
        </div>
    </div>
    <div class="form-group">
        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text">
                    <i class="material-icons">lock_outline</i>
                </span>
            </div>
            <asp:TextBox ID="repwd" type="password" class="form-control" placeholder="Retype Password..." runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="repwd" ErrorMessage="Required Field" Display="Dynamic" ForeColor="Red" />
        </div>
    </div>
    <div class="form-group">
        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text">
                    <i class="material-icons">face</i>
                </span>
            </div>
            <asp:TextBox ID="name" placeholder="Full name..." class="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="name" ErrorMessage="Required Field" Display="Dynamic" ForeColor="Red" />
        </div>
    </div>
    <div class="form-group">

        <div class="form-group">
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="material-icons">date_range</i>
                    </span>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="DOB" CssClass="form-control datetimepicker" placeholder="Date of birth..." ClientIDMode="Static" runat="server"/>
                </div>
            </div>
        </div>
        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text">
                    <i class="material-icons">group</i>
                </span>
            </div>
            <div class="dropdown">
                <select class="selectpicker " runat="server" id="gender" data-style="select-with-transition" title="Gender" data-size="7">
                    <option disabled>Choose Gender</option>
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                </select>
            </div>
        </div>
    </div>

    <div class="text-center">
        <asp:Button ID="register" class="btn btn-primary btn-round" Style="margin: 50px" runat="server" Text="Sign Up" OnClick="register_Click" />
    </div>

</asp:Content>
