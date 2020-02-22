<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageShop.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="bookCart.aspx.cs" Inherits="EADPPROJ.shoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="container">
        <div class="col-lg-12 col-md-12 ml-auto mr-auto">
            <div style="height:100px;text-align:center;">
            <asp:Label ID="NoCart" Visible="false" runat="server" Text="There is nothing in your shopping cart right now!"></asp:Label></div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate><div class="table-responsive">
                                    <table class="table table-shopping">
                                        <thead>
                                            <tr>
                                                <th class="text-center"></th>
                                                <th>Product</th>
                                                <th class="text-center">Price</th>
                                                <th class="text-right">Qty</th>
                                                <th class="text-right">Total Credits</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="bookId" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Key") %>'></asp:Label>
                    <tr>
                                                <td>
                                                    <div class="img-container">
                                                        <img runat="server" id="Image" src="assets/img/product1.jpg" alt="...">
                                                    </div>
                                                </td>
                                                <td class="td-name">
                                                    <asp:Label ID="bookName" runat="server"></asp:Label>        
                                                    <br>
                                                    <small>
                                                        <asp:Label ID="school" runat="server"></asp:Label></small>
                                                </td>
                                                <td class="td-number text-center">
                                                    <asp:Label ID="price" runat="server"></asp:Label><small>Credits</small>
                                                </td>
                                                <td class="td-number">
                                                    <asp:Label ID="Number" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Value") %>'></asp:Label>
                                                    <div class="btn-group">
                                                        <asp:LinkButton ID="remove" OnClick="remove_Click" CssClass="btn btn-round btn-info btn-sm" runat="server"><i class="material-icons">remove</i></asp:LinkButton>
                                                        <asp:LinkButton ID="add" OnClick="add_Click" CssClass="btn btn-round btn-info btn-sm" runat="server"><i class="material-icons">add</i></asp:LinkButton>
                                                        
                                                    </div>
                                                </td>
                                                <td class="td-number text-center">
                                                    <asp:Label ID="total" runat="server"></asp:Label><small>Credits</small>
                                                </td>
                                                <td class="td-actions">
                                                    <asp:LinkButton ID="delete" OnClick="delete_Click" rel="tooltip" data-placement="left" title="Remove item" CssClass="btn btn-link" runat="server"><i class="material-icons">close</i></asp:LinkButton>
                                                    
                                                </td>
                                            </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                                                <td colspan="3">
                                                </td>
                                                <td class="td-total">
                                                    Total
                                                </td>
                                                <td class="td-price text-center">
                                                    <asp:Label ID="OverallPrice" runat="server" Text="Label"></asp:Label><small>Credits</small>
                                                </td>
                                                <td colspan="3" class="text-right">
                                                    <button type="button" data-toggle="modal" data-target="#paymentModal" onclick="return false;" class="btn btn-info btn-round">Complete Purchase <i class="material-icons">keyboard_arrow_right</i></button>
                                                    <div class="modal fade" id="paymentModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="false">
                                                      <div class="modal-dialog" role="document">
                                                        <div class="modal-content">
                                                          <div class="modal-header">
                                                            <h5 class="modal-title" id="exampleModalLabel">Payment</h5>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                              <span aria-hidden="true">&times;</span>
                                                            </button>
                                                          </div>
                                                          <div class="modal-body">
                                                              <p runat="server" id="paymentBody"></p>
                                                          </div>
                                                          <div class="modal-footer">
                                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                              <div runat="server" id="paymentSection" visible="false">
                                                                  <asp:Button ID="Pay" OnClick="Pay_Click" CssClass="btn btn-primary" runat="server" Text="Pay Now!" />

                                                              </div>
                                                          </div>
                                                        </div>
                                                      </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                </FooterTemplate>
            </asp:Repeater>
                                
                            </div>
            </div>
    </div>
</asp:Content>
