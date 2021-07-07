<%@ Page Title="" Language="C#" MasterPageFile="~/Rank/MasterPageRanking.Master" AutoEventWireup="true" CodeBehind="rankDetail.aspx.cs" Inherits="EADPPROJ.rankDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header header-1" style="background-image: url(&apos;assets/img/bg2.jpg&apos;);">
        <div class="container">
            <div class="col-md-10 ml-auto mr-auto">
                <asp:Panel ID="blogRank" runat="server">
                    <ul class="nav nav-pills nav-pills-rose">
                        <li class="nav-item">
                            <a class="nav-link active" style="color: white" href="#pill1" data-toggle="tab">Most Favorite</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#pill2" style="color: white" data-toggle="tab">Most Valuable</a>
                        </li>
                    </ul>
                    <div class="tab-content tab-space">
                        <div class="tab-pane active" id="pill1">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: white" class="text-center">#</th>
                                                    <th style="width: 50%;color: white">Title</th>
                                                    <th style="color: white" class="text-center">Author ID</th>
                                                    <th style="color: white">Post On</th>
                                                    <th style="color: white" class="text-center" style="width: 10%">Favorite Number</th>
                                                    <th style="color: white" class="text-right">Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                            <td><%#Eval("Title").ToString() %></td>
                                            <td class="text-center"><%#Eval("Poster").ToString() %></td>
                                            <td><%#Eval("PostTime").ToString() %></td>
                                            <td class="text-center"><%#Eval("Favorite").ToString() %></td>
                                            <td class="td-actions text-right">
                                                <asp:LinkButton ID="viewProfile" rel="tooltip" title="Visit profile" CssClass="btn btn-info btn-just-icon btn-sm" runat="server"><i class="material-icons">person</i></asp:LinkButton>
                                                <asp:LinkButton ID="viewBlog" rel="tooltip" title="Visit Blog" CssClass="btn btn-success btn-just-icon btn-sm" runat="server"><i class="material-icons">launch</i></asp:LinkButton>

                                                <asp:HiddenField ID="posterId" runat="server" Value='<%#Eval("Poster").ToString() %>' />
                                                <asp:HiddenField ID="blogId" runat="server" Value='<%#Eval("Id").ToString() %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate></tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 * FROM [tb_Blog] ORDER BY [Favorite] DESC"></asp:SqlDataSource>

                            </div>
                        </div>
                        <div class="tab-pane" id="pill2">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: white" class="text-center">#</th>
                                                    <th style="width: 50%;color: white">Title</th>
                                                    <th style="color: white" class="text-center">Author ID</th>
                                                    <th style="color: white">Post On</th>
                                                    <th style="color: white" class="text-center" style="width: 10%">Total Tipping</th>
                                                    <th style="color: white" class="text-right">Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                            <td><%#Eval("Title").ToString() %></td>
                                            <td class="text-center"><%#Eval("Poster").ToString() %></td>
                                            <td><%#Eval("PostTime").ToString() %></td>
                                            <td class="text-center"><%#Eval("Tip").ToString() %></td>
                                            <td class="td-actions text-right">
                                                <asp:LinkButton ID="viewProfile" rel="tooltip" title="Visit profile" CssClass="btn btn-info btn-just-icon btn-sm" runat="server"><i class="material-icons">person</i></asp:LinkButton>
                                                <asp:LinkButton ID="viewBlog" rel="tooltip" title="Visit Blog" CssClass="btn btn-success btn-just-icon btn-sm" runat="server"><i class="material-icons">launch</i></asp:LinkButton>
                                                <asp:HiddenField ID="posterId" runat="server" Value='<%#Eval("Poster").ToString() %>' />
                                                <asp:HiddenField ID="blogId" runat="server" Value='<%#Eval("Id").ToString() %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate></tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 * FROM [tb_Blog] ORDER BY [Tip] DESC"></asp:SqlDataSource>

                            </div>
                        </div>
                    </div>

                </asp:Panel>
                <asp:Panel ID="userRank" runat="server">
                    <ul class="nav nav-pills nav-pills-rose">
                        <li class="nav-item">
                            <a class="nav-link active" href="#pill1" style="color: white" data-toggle="tab">Most Question Asked</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#pill2" style="color: white" data-toggle="tab">Most Answer Posted</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#pill3" style="color: white" data-toggle="tab">Most Question Solved</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#pill4" style="color: white" data-toggle="tab">Most Blog Posted</a>
                        </li>
                    </ul>
                    <div class="tab-content tab-space">
                        <div class="tab-pane active" id="pill1">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource3">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: white" class="text-center">#</th>
                                                    <th style="width: 50%; color: white">Name</th>
                                                    <th style="color: white" class="text-center">ID</th>
                                                    <th style="color: white" class="text-center" style="width: 10%">Total Question</th>
                                                    <th style="color: white" class="text-right">Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                            <td><%# GetName(Eval("Username").ToString()) %></td>
                                            <td class="text-center"><%#Eval("Username").ToString() %></td>
                                            <td class="text-center"><%#Eval("TotalQuestion").ToString() %></td>
                                            <td class="td-actions text-right">
                                                <asp:LinkButton ID="viewProfile" rel="tooltip" title="Visit profile" CssClass="btn btn-info btn-just-icon btn-sm" runat="server"><i class="material-icons">person</i></asp:LinkButton>
                                                <asp:HiddenField ID="username" runat="server" Value='<%#Eval("Username").ToString() %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate></tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 Username, COUNT(Id) AS TotalQuestion FROM tb_Question WHERE Review = 1 GROUP BY Username ORDER BY TotalQuestion DESC"></asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="tab-pane" id="pill2">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater4" runat="server" DataSourceID="SqlDataSource4">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: white" class="text-center">#</th>
                                                    <th style="color: white;width: 50%">Name</th>
                                                    <th style="color: white" class="text-center">ID</th>
                                                    <th style="color: white" class="text-center" style="width: 10%">Total Answer</th>
                                                    <th style="color: white" class="text-right">Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                            <td><%# GetName(Eval("Username").ToString()) %></td>
                                            <td class="text-center"><%#Eval("Username").ToString() %></td>
                                            <td class="text-center"><%#Eval("TotalAnswer").ToString() %></td>
                                            <td class="td-actions text-right">
                                                <asp:LinkButton ID="viewProfile" rel="tooltip" title="Visit profile" CssClass="btn btn-info btn-just-icon btn-sm" runat="server"><i class="material-icons">person</i></asp:LinkButton>
                                                <asp:HiddenField ID="username" runat="server" Value='<%#Eval("Username").ToString() %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate></tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 Username, COUNT(Id) AS TotalAnswer FROM tb_Answer GROUP BY Username ORDER BY TotalAnswer DESC"></asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="tab-pane" id="pill3">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater5" runat="server" DataSourceID="SqlDataSource5">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: white" class="text-center">#</th>
                                                    <th style="width: 50%;color: white">Name</th>
                                                    <th style="color: white" class="text-center">ID</th>
                                                    <th style="color: white" class="text-center" style="width: 10%">Total Best Answer</th>
                                                    <th style="color: white" class="text-right">Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                            <td><%# GetName(Eval("Username").ToString()) %></td>
                                            <td class="text-center"><%#Eval("Username").ToString() %></td>
                                            <td class="text-center"><%#Eval("TotalBestAnswer").ToString() %></td>
                                            <td class="td-actions text-right">
                                                <asp:LinkButton ID="viewProfile" rel="tooltip" title="Visit profile" CssClass="btn btn-info btn-just-icon btn-sm" runat="server"><i class="material-icons">person</i></asp:LinkButton>
                                                <asp:HiddenField ID="username" runat="server" Value='<%#Eval("Username").ToString() %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate></tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 Username, COUNT(Id) AS TotalBestAnswer FROM tb_Answer WHERE BestSelected = 1 GROUP BY Username ORDER BY TotalBestAnswer DESC"></asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="tab-pane" id="pill4">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater6" runat="server" DataSourceID="SqlDataSource6">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: white" class="text-center">#</th>
                                                    <th style="width: 50%;color: white">Name</th>
                                                    <th style="color: white" class="text-center">ID</th>
                                                    <th style="color: white" class="text-center" style="width: 10%">Total Blog</th>
                                                    <th style="color: white" class="text-right">Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                            <td><%# GetName(Eval("Poster").ToString()) %></td>
                                            <td class="text-center"><%#Eval("Poster").ToString() %></td>
                                            <td class="text-center"><%#Eval("TotalBlog").ToString() %></td>
                                            <td class="td-actions text-right">
                                                <asp:LinkButton ID="viewProfile" rel="tooltip" title="Visit profile" CssClass="btn btn-info btn-just-icon btn-sm" runat="server"><i class="material-icons">person</i></asp:LinkButton>
                                                <asp:HiddenField ID="username" runat="server" Value='<%#Eval("Poster").ToString() %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate></tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 Poster, COUNT(Id) AS TotalBlog FROM tb_Blog GROUP BY Poster ORDER BY TotalBlog DESC"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="questionRank" runat="server">
                    <ul class="nav nav-pills nav-pills-rose">
                        <li class="nav-item">
                            <a class="nav-link active" href="#pill1" style="color: white" data-toggle="tab">Question with most answers</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#pill2" style="color: white" data-toggle="tab">Answers with most upvotes</a>
                        </li>
                    </ul>
                    <div class="tab-content tab-space">
                        <div class="tab-pane active" id="pill1">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater7" runat="server" DataSourceID="SqlDataSource7">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: white" class="text-center">#</th>
                                                    <th style="width: 50%;color: white">Question Title</th>
                                                    <th style="color: white" class="text-center">Poster</th>
                                                    <th style="color: white" class="text-center" style="width: 10%">Total Answer</th>
                                                    <th style="color: white" class="text-right">Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                            <td>
                                                <asp:Label ID="title" runat="server"></asp:Label></td>
                                            <td class="text-center">
                                                <asp:Label ID="poster" runat="server"></asp:Label></td>
                                            <td class="text-center"><%#Eval("TotalAnswer").ToString() %></td>
                                            <td class="td-actions text-right">
                                                <asp:LinkButton ID="viewProfile" rel="tooltip" title="Visit profile" CssClass="btn btn-info btn-just-icon btn-sm" runat="server"><i class="material-icons">person</i></asp:LinkButton>
                                                <asp:LinkButton ID="viewQuestion" rel="tooltip" title="Visit Question" CssClass="btn btn-success btn-just-icon btn-sm" runat="server"><i class="material-icons">launch</i></asp:LinkButton>
                                                <asp:HiddenField ID="questionCode" runat="server" Value='<%#Eval("QuestionCode").ToString() %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate></tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 QuestionCode, COUNT(Id) AS TotalAnswer FROM tb_Answer GROUP BY QuestionCode ORDER BY TotalAnswer DESC"></asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="tab-pane" id="pill2">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater8" runat="server" DataSourceID="SqlDataSource8">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: white" class="text-center">#</th>
                                                    <th style="width: 50%;color:white">Question Title</th>
                                                    <th style="color: white" class="text-center">Poster</th>
                                                    <th style="color: white">Post On</th>
                                                    <th style="color: white" class="text-center" style="width: 10%">Total Upvote</th>
                                                    <th style="color: white" class="text-right">Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                            <td>
                                                <asp:Label ID="title" runat="server"></asp:Label></td>
                                            <td class="text-center">
                                                <asp:Label ID="poster" runat="server"></asp:Label></td>
                                            <td><%#Eval("PostTime").ToString() %></td>
                                            <td class="text-center"><%#Eval("UpVote").ToString() %></td>
                                            <td class="td-actions text-right">
                                                <asp:LinkButton ID="viewProfile" rel="tooltip" title="Visit profile" CssClass="btn btn-info btn-just-icon btn-sm" runat="server"><i class="material-icons">person</i></asp:LinkButton>
                                                <asp:LinkButton ID="viewQuestion" rel="tooltip" title="Visit Question" CssClass="btn btn-success btn-just-icon btn-sm" runat="server"><i class="material-icons">launch</i></asp:LinkButton>
                                                <asp:HiddenField ID="questionCode" runat="server" Value='<%#Eval("QuestionCode").ToString() %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate></tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TOP 5 QuestionCode, Username, PostTime, UpVote FROM tb_Answer ORDER BY UpVote DESC"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
