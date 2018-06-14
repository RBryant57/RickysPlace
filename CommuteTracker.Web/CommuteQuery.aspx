<%@ Page Title="Ricky's Place: Query past commutes" Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="CommuteQuery.aspx.cs" Inherits="CommuteQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:ScriptManager ID="scmCommuteEntry" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <p class="p">
        <asp:Label ID="Label8" runat="server" Height="150px" Text="Select a commute time to see information about that commute." Width="200px"></asp:Label>
    </p>
    <br />
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteEntry.aspx">Back to Entering Commutes</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LabelStyle" NavigateUrl="~/PassConditions.aspx">Back to Entering Pass Conditions</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteStatistics.aspx">View Commuting Statistics</asp:HyperLink>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblError" runat="server" CssClass="ErrorLabelStyle" Text="Label" Visible="False" Width="450"></asp:Label>
            <br />
            <br />
            <asp:Calendar ID="cldMain" runat="server" BackColor="White" BorderColor="White"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                Height="190px" NextPrevFormat="FullMonth" Width="350px"
                OnSelectionChanged="cldMain_SelectionChanged">
                <SelectedDayStyle BackColor="#999966" ForeColor="White" />
                <TodayDayStyle BackColor="#CCCCCC" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#999966" />
            </asp:Calendar>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Commute Date:" CssClass="EntryLabelStyle" Width="120px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtSearchDate" runat="server" CssClass="TextBoxStyle"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnSearchCommute" runat="server" CssClass="ButtonStyle" Text="Search Commute" onclick="btnSearchCommute_Click" />
</asp:Content>