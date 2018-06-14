<%@ Page Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="PassConditions.aspx.cs" Inherits="PassConditions" Title="Ricky's Place: Enter new pass condition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scmPassConditions" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Height="75px" Text="Enter information about the pass conditions. Select the link below if you need to add a new mountain pass." Width="250px" CssClass="SmallLabelStyle"></asp:Label>
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LabelStyle" NavigateUrl="~/RouteType.aspx">Add a New Mountain Pass</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="LabelStyle" NavigateUrl="~/Delay.aspx?Source=PassCondition">Add a New Delay Reason</asp:HyperLink>
    </p>
    <br />
    <br />
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteEntry.aspx">Back to Entering Commutes</asp:HyperLink>
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
                    Height="190px" NextPrevFormat="FullMonth" Width="350px" >
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
            <asp:Label ID="Label1" runat="server" Text="Time:" CssClass="EntryLabelStyle" Width="90px"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="cboTime" runat="server" CssClass="TextBoxStyle"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Minutes:" CssClass="EntryLabelStyle" Width="90px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtMinutes" runat="server" CssClass="TextBoxStyle"></asp:TextBox>&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" CssClass="EntryLabelStyle" Text="Usual Minutes:" Width="90px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtUsualMinutes" runat="server" CssClass="TextBoxStyle"></asp:TextBox>&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" CssClass="EntryLabelStyle" Text="Route:" Width="90px"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="cboRoutes" runat="server" CssClass="TextBoxStyle"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblDelay" runat="server" CssClass="EntryLabelStyle" Text="Delay:" Width="90px"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="cboDelays" runat="server" CssClass="TextBoxStyle" 
                    AutoPostBack="True"></asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" CssClass="EntryLabelStyle" Text="Notes:" Width="90px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtNotes" runat="server" Height="92px" CssClass="TextBoxStyle"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddPassCondition" runat="server" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button ID="btnAddPassCondition" runat="server" CssClass="ButtonStyle" Text="Add Pass Condition" onclick="btnAddPassCondition_Click" />
</asp:Content>