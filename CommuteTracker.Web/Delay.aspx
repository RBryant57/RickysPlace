<%@ Page Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="Delay.aspx.cs" Inherits="Delay" Title="Ricky's Place: Add new delay reason" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Height="75px" Text="Enter a description of the delay reason." Width="250px" CssClass="SmallLabelStyle"></asp:Label>
    <p>
        <asp:HyperLink ID="hypCommute" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteEntry.aspx">Back to Entering Commutes</asp:HyperLink>
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
    <asp:Label ID="Label1" runat="server" CssClass="EntryLabelStyle" Text="Description:"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtDescription" runat="server" Height="88px"></asp:TextBox>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="btnAddDelayReason" runat="server" CssClass="ButtonStyle" Text="Add Delay Reason" onclick="btnAddDelayReason_Click" />
</asp:Content>