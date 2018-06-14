<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="CommuteStatisticsDetail.aspx.cs" Inherits="CommuteStatisticsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scmCommuteEntry" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <p class="p">
        <asp:Label ID="Label8" runat="server" Height="150px" Text="View detailed commuting statistics. To enter commute data or view more general statistics, select from the links below." Width="200px"></asp:Label>
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
        <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LabelStyle" NavigateUrl="~/FareClass.aspx">Add a New Fare Class</asp:HyperLink>
    </p>
    <br />
    <br />
    <br />
    <br />
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteEntry.aspx">Enter Commute Times</asp:HyperLink>
    </p>
    <br />
    <br />
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteStatistics.aspx">View Commuting Statistics</asp:HyperLink>
    </p>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Label runat="server" ID="lblSpacer" ForeColor="White" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <br />
    <asp:Label ID="lblRoute" runat="server" CssClass="LargeLabelStyle" />
    <br />
    <br />
    <asp:Label ID="lblInformation" runat="server" CssClass="SmallLabelStyle" Width="300" Text="Below represents basic commuting statisics broken out by time." ></asp:Label>
    <br />
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:RadioButtonList runat="server" ID="rblTime" Width="200px" CssClass="SmallLabelStyle" OnSelectedIndexChanged="control_SelectedChanged" AutoPostBack="true" RepeatDirection="Horizontal" >
                <asp:ListItem>By Day</asp:ListItem>
                <asp:ListItem>By Month</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:CheckBox runat="server" ID="chkDestination" CssClass="SmallLabelStyle" Text="By Destination" OnCheckedChanged="control_SelectedChanged" AutoPostBack="true" />
            <br />
            <br />
            <asp:Xml runat="server" ID="xmlDisplay" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

