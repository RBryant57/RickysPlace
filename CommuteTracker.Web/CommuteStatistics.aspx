<%@ Page Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="CommuteStatistics.aspx.cs" Inherits="CommuteStatistics" Title="Ricky's Place: View Commuting Statistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scmCommuteEntry" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <p class="p">
        <asp:Label ID="Label8" runat="server" Height="150px" Text="View commuting statistics. To enter commute data, select from the links below." Width="200px"></asp:Label>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LabelStyle" NavigateUrl="~/Delay.aspx">Add a New Delay Reason</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LabelStyle" NavigateUrl="~/Destination.aspx">Add a New Destination</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LabelStyle" NavigateUrl="~/Route.aspx">Add a New Route</asp:HyperLink>
    </p>
        <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="LabelStyle" NavigateUrl="~/FareClass.aspx">Add a New Fare Class</asp:HyperLink>
    </p>
    <br />
    <br />
    <br />
    <br />
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteEntry.aspx">Back To Entering Commutes</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LabelStyle" NavigateUrl="~/PassConditions.aspx">Back To Entering Pass Conditions</asp:HyperLink>
    </p>
    <asp:Label runat="server" ID="lblSpacer" ForeColor="White" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <br />
    <asp:Label runat="server" CssClass="SmallLabelStyle" Width="300" Text="Below represents basic commuting statisics by route. Click on a route to get more detailed information."></asp:Label>
    <br />
    <br />
    <asp:Xml runat="server" ID="xmlDisplay" />
</asp:Content>