<%@ Page Language="C#" MasterPageFile="~/MasterPages/2ColumnMaster.master" AutoEventWireup="true" CodeFile="Route.aspx.cs" Inherits="Route" Title="Ricky's Place: Enter new route" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Height="75px" Text="Enter information about the route. Select the link below if you need to add a new route type." Width="250px" CssClass="SmallLabelStyle"></asp:Label>
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LabelStyle" NavigateUrl="~/RouteType.aspx">Add a New Route Type</asp:HyperLink>
    </p>
    <br />
    <br />
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteEntry.aspx">Back to Entering Commutes</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LabelStyle" NavigateUrl="~/PassConditions.aspx">Back to Entering Pass Conditions</asp:HyperLink>
    </p>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblError" runat="server" CssClass="ErrorLabelStyle" Text="Label" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" CssClass="EntryLabelStyle" Text="Name:" Width="90px"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" CssClass="EntryLabelStyle" Text="Type:" Width="90px"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="cboTypes" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" CssClass="EntryLabelStyle" Text="Number:" Width="90px"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" CssClass="EntryLabelStyle" Text="Miles:" Width="90px"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtMiles" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" CssClass="EntryLabelStyle" Text="Notes:" Width="90px"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtNotes" runat="server" Height="95px"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnAddRoute" runat="server" CssClass="ButtonStyle" onclick="btnAddRoute_Click" Text="Add Route" />
</asp:Content>