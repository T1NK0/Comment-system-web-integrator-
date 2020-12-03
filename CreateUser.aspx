<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-3"></div>
    <div id="CreateUser-Box" class="col-lg-6">
        <asp:TextBox ID="TextBox_Email" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox><br />
        <asp:TextBox ID="TextBox_Name" runat="server" CssClass="form-control" placeholder="Navn"></asp:TextBox><br />
        <asp:TextBox ID="TextBox_Password" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox><br />
        <asp:FileUpload ID="FileUpload_ProfilePicture" runat="server" CssClass="btn btn-success"/><br />
        <asp:Button ID="Button_Opret" runat="server" Text="Opret din bruger" CssClass="btn btn-success" OnClick="Button_Opret_Click"/>
    </div>
    <div class="col-lg-3"></div>
</asp:Content>

