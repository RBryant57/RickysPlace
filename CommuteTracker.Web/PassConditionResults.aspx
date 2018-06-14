<%@ Page Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="PassConditionResults.aspx.cs" Inherits="PassConditionResults" Title="Ricky's Place: The currently entered pass condition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scmCommuteEntry" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <p class="p">
        <asp:Label ID="Label8" runat="server" Height="150px" Text="The following pass condition has been added to the data store." Width="200px"></asp:Label>
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
        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteEntry.aspx">Back To Entering Commutes</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteStatistics.aspx">View Commuting Statistics</asp:HyperLink>
    </p>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <br />
    <br />
    <div style="text-align:center">
        <asp:Label ID="Label1"  CssClass="MediumLabelStyle" runat="server" Text="Pass Condition Information"></asp:Label>
    </div>
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="lblDate" CssClass="LabelStyle" runat="server" Text="Date:"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblTime" CssClass="LabelStyle" runat="server" Text="Time:"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblMinutes" CssClass="LabelStyle" runat="server" Text="Minutes:"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblDelayMinutes" CssClass="LabelStyle" runat="server" Text="Delay Minutes:"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblDestination" CssClass="LabelStyle" runat="server" Text="Destination:"></asp:Label>
        <br />
    <br />
    <asp:Label ID="lblDelay" CssClass="LabelStyle" runat="server" Text="Delay:"></asp:Label>
    <br />
    <br />
    <br />
        <br />
    <br />
    <div style="text-align:center">
        <p class="LabelStyle">
            <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LabelStyle" NavigateUrl="~/PassConditions.aspx">Back to Entering Pass Conditions</asp:HyperLink>
        </p>
    </div>
</asp:Content>

