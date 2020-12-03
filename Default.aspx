<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-2"></div>
        <div class="col-lg-8" id="News-Box">
            <h1>Nyheder fra diverse steder</h1>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <div>
                        <a href="SpecificNews.aspx?news_id=<%#Eval ("news_id") %>"<h1><%#Eval ("news_title") %></h1></a>
                        <p><%#Eval ("news_text") %></p>
                        <hr />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [News]"></asp:SqlDataSource>
        </div>
    <div class="col-lg-2"></div>
</asp:Content>

