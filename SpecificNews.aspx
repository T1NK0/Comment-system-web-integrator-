<%@ Page ValidateRequest="false"  Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="SpecificNews.aspx.cs" Inherits="SpecificNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-3"></div>
    <div class="col-lg-6" id="Specific-News">
        <div id="Single-News">
            <asp:Repeater ID="Repeater_ViewNews" runat="server">
                <ItemTemplate>
                    <h1><%#Eval ("news_title") %></h1>
                    <p><%#Eval ("news_text") %></p>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <br />

        <div>
            <asp:TextBox ID="TextBox_Content" runat="server" placeholder="Nyheds Tekst" CssClass="form-control" TextMode="MultiLine" ClientIDMode="Static" Rows="10"></asp:TextBox>
            <asp:Button ID="Button_MakeCommentary" runat="server" Text="Post" OnClick="Button_MakeCommentary_Click" class="btn btn-success" />
            <script>
                // Replace the <textarea id="editor1"> with a CKEditor
                // instance, using default configuration.
                CKEDITOR.replace('ctl00$ContentPlaceHolder1$TextBox_Content');
            </script>
        </div>

        <div>
            <h1>Kommentare</h1>
            <asp:Repeater ID="Repeater_Comments" runat="server">
                <ItemTemplate>
                    <div id="kommentar">
                        <div style="display: inline-block;">
                            <img style="height: 50px; width: 50px;" src='images/Resized/<%#Eval ("user_picture") %>' />
                        </div>
                        <div style="display: inline-block;">
                            <div>
                                <p style="margin: 0px;" class="comment-author-text"><%#Eval ("user_name") %></p>
                            </div>
                            <div>
                                <p style="margin: 0px;"><%#Eval ("coment_text") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="bottom">
            <ul class="breadcrumb">
                <li><a href="Default.aspx">Forside</a></li>
                <li>
                    <asp:HyperLink ID="HyperLink_BreadCrumb_Category" runat="server"></asp:HyperLink></li>
                <li class="active">
                    <asp:Literal ID="Literal_BreadCrumb_NewsTitle" runat="server"></asp:Literal></li>
            </ul>
        </div>
    </div>
    <div class="col-lg-3"></div>
</asp:Content>

