<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageQuestion.Master" Debug="true" ValidateRequest="false" AutoEventWireup="true" CodeBehind="questionDetail.aspx.cs" Inherits="EADPPROJ.questionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="kt-subheader   kt-grid__item" id="kt_subheader"></div>
        <div class="kt-portlet">
            <div class="kt-section">
                <div class="kt-portlet__body">
                    <div class="kt-blog-post">
                        <h1 class="kt-blog-post__title kt-heading kt-heading--lg kt-heading--medium" runat="server" id="title"></h1>
                        <div class="kt-blog-post__meta">
                            <div class="kt-blog-post__date">
                                <asp:Label ID="PostTime" runat="server"></asp:Label>
                            </div>
                            <div class="kt-blog-post__author">
                                By
                                <asp:HyperLink ID="Username" runat="server"></asp:HyperLink>
                            </div>
                            <div class="kt-blog-post__comments">
                                <asp:Label ID="answerCount" runat="server"></asp:Label>
                                Answers
                            </div>
                        </div>
                        <div class="kt-blog-post__content">
                            <asp:Label ID="Content" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="kt-blog-post__foot">
                            <div class="kt-blog-post__author">
                                <div class="kt-blog-post__profile">
                                    <img src="../assets/media/users/300_21.jpg" class="kt-blog-post__image" runat="server" id="icon" />
                                </div>
                                <div class="kt-blog-post__label">
                                    <span>
                                        <asp:Label ID="Name" runat="server"></asp:Label></span>
                                </div>
                            </div>
                            <div class="col-lg-6 kt-align-right" runat="server" id="collapseAnswerButton">
                                <button type="button" data-toggle="collapse" href="#answer" role="button" aria-expanded="false" aria-controls="collapseExample" class="btn btn-success btn-focus btn-pill">Answer</button>
                            </div>

                        </div>
                        <div class="collapse" id="answer" style="margin: 30px">
                            <div class="card card-body">
                                <asp:TextBox ID="answerContent" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="kt-blog-post__foot" style="margin: 20px">
                                <asp:Button ID="postAnswer" runat="server" CssClass="btn btn-success btn-focus btn-pill" Text="Post Answer" OnClick="postAnswer_Click" />
                            </div>
                        </div>


                    </div>
                </div>

            </div>
            <div class="kt-separator kt-separator--space-lg kt-separator--border-dashed"></div>
            <div style="display: none" runat="server" id="BestAnswerBlock">
                <div class="kt-portlet__body">
                    <div class="kt-blog-post">
                        <h2 class="kt-font-success">Best Solution</h2>
                        <div class="kt-blog-post__meta">
                            <div class="kt-blog-post__date">
                                <asp:Label ID="bestAnswerPostTime" runat="server"></asp:Label>
                            </div>
                            <div class="kt-blog-post__author">
                                By
                                <asp:HyperLink ID="bestAnswerUsername" runat="server"></asp:HyperLink>
                            </div>
                        </div>
                        <br />
                        <div class="kt-blog-post__content">
                            <asp:Label ID="bestAnswerDetailContent" runat="server"></asp:Label>
                            <asp:Label ID="Id" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="kt-blog-post__foot">
                            <div class="kt-blog-post__author">
                                <div class="kt-blog-post__profile">
                                    <asp:Image ID="bestAnswerIcon" runat="server" CssClass="kt-blog-post__image" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="kt-separator kt-separator--space-lg kt-separator--border-dashed"></div>
            </div>
            <div class="kt-section">
                <asp:GridView ID="AnswerList" runat="server" AutoGenerateColumns="False" DataSourceID="AnswerListData" GridLines="None" HorizontalAlign="Center" ShowHeader="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="AnswerDetail">
                            <ItemTemplate>
                                <div class="kt-portlet__body">
                                    <div class="kt-blog-post">
                                        <div class="kt-blog-post__meta">
                                            <div class="kt-blog-post__date">
                                                <asp:Label ID="answerPostTime" runat="server" Text='<%# Eval("PostTime", "{0}") %>'></asp:Label>
                                            </div>
                                            <div class="kt-blog-post__author">
                                                By
                                                <asp:HyperLink ID="answerUsername" runat="server" Text='<%# Eval("Username", "{0}") %>'></asp:HyperLink>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="kt-blog-post__content">
                                            <asp:Label ID="answerDetailContent" runat="server" Text='<%# Eval("Content", "{0}") %>'></asp:Label>
                                            <asp:Label ID="Id" runat="server" Text='<%# Eval("Id", "{0}") %>' Visible="False"></asp:Label>
                                        </div>
                                        <div class="kt-blog-post__foot">
                                            <div class="kt-blog-post__author">
                                                <div class="kt-blog-post__profile">
                                                    <asp:Image ID="answerIcon" runat="server" CssClass="kt-blog-post__image" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6 kt-align-right">
                                                <div class="kt-blog-list__meta">
                                                    <div class="kt-blog-post__label" style="display: inline-block; margin-right: 20px">
                                                        <p style="font-size: medium"><%# Eval("UpVote", "{0}") %> Upvotes</p>
                                                    </div>
                                                    <div class="kt-blog-post__label" style="display: inline-block; margin: 0 20px 0 20px">
                                                        <asp:Button ID="btn_upVote" runat="server" Text="Up Vote" CssClass="btn btn-success btn-focus btn-pill" OnClick="upVote_Click" />
                                                    </div>
                                                    <div class="kt-blog-post__label" style="display: inline-block; margin-left: 20px">
                                                        <button type="button" data-toggle="collapse" href="#reply<%# Eval("Id", "{0}") %>" role="button" aria-expanded="false" class="btn btn-success btn-focus btn-pill">Comment</button>
                                                    </div>
                                                    <asp:Button ID="Solution" runat="server" CssClass="btn btn-success btn-focus btn-pill" Text="Select As Solution" OnClick="SolutionSelect" Visible="False" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="collapse" id="reply<%# Eval("Id", "{0}") %>" style="margin: 30px">
                                            <div class="card card-body">
                                                <asp:TextBox ID="replyContent" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                            <div class="kt-blog-post__foot" style="margin: 20px">
                                                <asp:Button ID="postReply" runat="server" CssClass="btn btn-success btn-focus btn-pill" Text="Post Reply" OnClick="postReply_Click" />
                                                <asp:HiddenField ID="answerPostUsername" Value='<%# Eval("Username", "{0}") %>' runat="server" />
                                            </div>
                                        </div>
                                        <div class="kt-portlet">
                                            <div class="kt-portlet__body">
                                                <div class="kt-section">
                                                    <div class="kt-section__content kt-section__content--border">
                                                        <div class="card">
                                                            <div class="card-header kt-font-bolder">
                                                                Reply
                                                            </div>
                                                            <div class="card-body">
                                                                <asp:Label ID="NoYet" runat="server" Text="There is no reply under this section currently." Visible="false"></asp:Label>
                                                                <asp:LinkButton ID="Show" runat="server" OnClick="Show_Click" CommandName="show" CssClass="btn btn-outline-hover-info btn-elevate btn-pill" CommandArgument='<%# Eval("Id") %>'><i class="la la-angle-double-down"></i>Load Reply</asp:LinkButton>
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="AnswerSection" Visible="False" BorderStyle="None" GridLines="None" ShowHeader="False">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Reply">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                                                <asp:Image ID="ReplyUserIcon" runat="server" CssClass="kt-media kt-media--circle" BorderStyle="None" Width="30px" />
                                                                                <asp:HyperLink ID="ReplyUsername" runat="server" Text='<%# Eval("Username") %>' Visible="false"></asp:HyperLink>
                                                                                <asp:HyperLink ID="ReplyName" runat="server" CssClass="kt-inbox__author"></asp:HyperLink>
                                                                                <asp:Label ID="AnswerId" runat="server" Text='<%# Eval("AnswerId") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="ReferenceId" runat="server" Text='<%# Eval("ReferenceId") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="ReplyTo" runat="server" Text=" Says:"></asp:Label>
                                                                                <asp:Label ID="ReplyContent" runat="server" Text='<%# Eval("Content") %>' CssClass="kt-inbox__subject"></asp:Label>
                                                                                <button type="button" data-toggle="collapse" href="#replyIn<%# Eval("Id", "{0}") %>" role="button" aria-expanded="false" class="btn btn-success btn-focus btn-pill">Reply</button>
                                                                                <div class="collapse" id="replyIn<%# Eval("Id", "{0}") %>" style="margin: 30px">
                                                                                    <div class="card card-body">
                                                                                        <asp:TextBox ID="Editor1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="kt-blog-post__foot" style="margin: 20px">
                                                                                        <asp:Button ID="Reply" runat="server" CssClass="btn btn-success btn-focus btn-pill btn-sm" Text="Reply" OnClick="Reply_Click" />
                                                                                    </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <asp:SqlDataSource ID="AnswerSection" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_AnswerSection] WHERE ([AnswerId] = @AnswerId) ORDER BY [Id]">

                                                                    <SelectParameters>
                                                                        <asp:ControlParameter ControlID="Id" Name="AnswerId" PropertyName="Text" Type="Int32" />
                                                                    </SelectParameters>

                                                                </asp:SqlDataSource>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="kt-separator kt-separator--space-lg kt-separator--border-dashed"></div>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="AnswerListData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Content], [Username], [PostTime],[UpVote] FROM [tb_Answer] WHERE ([QuestionCode] = @QuestionCode) ORDER BY [UpVote] DESC,[PostTime] DESC">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="QuestionCode" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>

</asp:Content>
