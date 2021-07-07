<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRegistration.Master" AutoEventWireup="true" CodeBehind="registerType.aspx.cs" Inherits="EADPPROJ.Register" %>
<asp:Content ID="registration" ContentPlaceHolderID="register" runat="server">
                            <div class="form-group" style="text-align:center">
                                <div class="form-check">
                                <label class="form-check-label">
                                    <input class="form-check-input" type="radio" name="identity" runat="server" id="identityStudent"> Student
                                    <span class="circle">
                                        <span class="check"></span>
                                    </span>
                                </label>
                            </div>
                                <div class="form-check">
                                <label class="form-check-label">
                                    <input class="form-check-input" type="radio" name="identity" runat="server" id="identityTeacher"> Teacher
                                    <span class="circle">
                                        <span class="check"></span>
                                    </span>
                                </label>
                            </div>
                                        </div>
                                        <div class="text-center">
                                            <asp:Button ID="next" class="btn btn-primary btn-round" style="margin:40px 0" runat="server" Text="Next Page" OnClick="next_Click" />
                                        </div>
</asp:Content>
