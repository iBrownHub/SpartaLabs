<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="helloworld.aspx.cs" Inherits="Lab_28_ASP_First_Website.helloworld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Hello World</h1>
    <ul>
        <li>one</li>
        <li>two</li>
    </ul>
    <button onclick="alert(hello);">JavaScript Button</button>
    <asp:Label ID="Label1" runat="server" Text="Label">This is a label</asp:Label>
    <asp:TextBox ID="TextBox1" runat="server">This is a textbox</asp:TextBox>
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <form>
        First Name <input type="text" placeholder="Type here" name="firstname" />
        <button type="submit" onclick="eventPreventDefault();">Submit</button>
    </form>
</asp:Content>
