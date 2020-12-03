<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-lg-4"></div>
    <div class="col-lg-4" id="login-box">
        <asp:TextBox ID="TextBox_name" runat="server" placeholder="Navn" CssClass="form-control"></asp:TextBox><br />
        <asp:TextBox ID="TextBox_password" runat="server" Placeholder="Kodeord" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
        <asp:Button ID="Button_login" runat="server" Text="Button" OnClick="Button_login_Click" CssClass="btn btn-success"/>
    </div>
    <div class="col-lg-4"></div>
</asp:Content>

