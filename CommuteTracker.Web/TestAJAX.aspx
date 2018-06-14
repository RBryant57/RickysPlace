<%@ Page Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="TestAJAX.aspx.cs" Inherits="TestAJAX" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="cboRoutes" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:ListBox ID="lstRoutes" runat="server"></asp:ListBox>
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

