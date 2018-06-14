<%@ Page Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="FareClass.aspx.cs" Inherits="FareClass" Title="Ricky's Place: Add new fare class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Height="75px" Text="Enter a name of the fare class." Width="250px" CssClass="SmallLabelStyle"></asp:Label>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteEntry.aspx">Back to Entering Commutes</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LabelStyle" NavigateUrl="~/PassConditions.aspx">Back to Entering Pass Conditions</asp:HyperLink>
    </p>
    <br />
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblError" runat="server" CssClass="ErrorLabelStyle" Text="Label" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" CssClass="EntryLabelStyle" Text="Name:"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtName" runat="server" Height="20px"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" CssClass="EntryLabelStyle" Text="Notes:"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtNotes" runat="server" Height="88px"></asp:TextBox>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="btnAddFareClass" runat="server" CssClass="ButtonStyle" Text="Add Fare Class" onclick="btnAddFareClass_Click" />
</asp:Content>