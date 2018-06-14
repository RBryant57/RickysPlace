<%@ page language="C#" masterpagefile="~/MasterPages/2ColumnMaster.master" autoeventwireup="true" Inherits="CommuteEntry" CodeFile="~/CommuteEntry.aspx.cs" title="Ricky's Place: Enter commuting information" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scmCommuteEntry" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <p class="p">
        <asp:Label ID="Label8" runat="server" Height="150px" Text="Enter commute time information. To enter other commute data, select from the links below." Width="200px"></asp:Label>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LabelStyle" NavigateUrl="~/Delay.aspx?Source=Commute">Add a New Delay Reason</asp:HyperLink>
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
        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LabelStyle" NavigateUrl="~/PassConditions.aspx">Pass Conditions</asp:HyperLink>
    </p>
    <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteStatistics.aspx">View Commuting Statistics</asp:HyperLink>
    </p>
        <p class="LabelStyle">
        <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LabelStyle" NavigateUrl="~/CommuteQuery.aspx">View Past Commutes</asp:HyperLink>
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
                    onselectionchanged="cldMain_SelectionChanged">
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
            <asp:Label ID="Label1" runat="server" Text="Start Time:" CssClass="EntryLabelStyle" Width="90px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtStartTime" runat="server" CssClass="TextBoxStyle"></asp:TextBox>
            <%--<cc1:MaskedEditExtender   
                ID="MaskedEditExtender1"  
                runat="server"  
                TargetControlID="txtStartTime"  
                Mask="99/99/9999 99:99:99"  
                MaskType="DateTime"  
                MessageValidatorTip="true"
                AcceptAMPM="true">  
            </cc1:MaskedEditExtender>  
            <cc1:MaskedEditValidator   
                ID="MaskedEditValidator2"  
                runat="server"  
                ControlToValidate="txtEndTime"  
                ControlExtender="MaskedEditExtender1"  
                IsValidEmpty="false"  
                EmptyValueMessage="Input time"  
                InvalidValueMessage="Date time is not valid">  
            </cc1:MaskedEditValidator>--%>
            <%--<cc1:CalendarExtender runat="server" TargetControlID="txtStartTime"></cc1:CalendarExtender>--%>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="End Time:" CssClass="EntryLabelStyle" Width="90px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtEndTime" runat="server" CssClass="TextBoxStyle"></asp:TextBox>&nbsp;&nbsp;
           <%-- <cc1:MaskedEditExtender   
                ID="MaskedEditExtender2"  
                runat="server"  
                TargetControlID="txtEndTime"  
                Mask="99/99/9999 99:99:99"  
                MaskType="DateTime"  
                MessageValidatorTip="true"
                AcceptAMPM="true">  
            </cc1:MaskedEditExtender>  
            <cc1:MaskedEditValidator   
                ID="MaskedEditValidator1"  
                runat="server"  
                ControlToValidate="txtEndTime"  
                ControlExtender="MaskedEditExtender2"  
                IsValidEmpty="false"  
                EmptyValueMessage="Input time"  
                InvalidValueMessage="Date time is not valid.">  
            </cc1:MaskedEditValidator>--%>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" CssClass="EntryLabelStyle" Text="Destination:" Width="90px"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="cboDestinations" runat="server" CssClass="TextBoxStyle"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" CssClass="EntryLabelStyle" Text="Fare Class:" Width="90px"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="cboFareClass" runat="server" CssClass="TextBoxStyle"></asp:DropDownList>
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
                    onselectedindexchanged="cboDelays_SelectedIndexChanged" 
                    AutoPostBack="True"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblDelayTime" runat="server" Text="Delay Time:" CssClass="EntryLabelStyle" Width="90px" Visible=false></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtDelay" runat="server" CssClass="TextBoxStyle" Visible="false">00:00:00</asp:TextBox>
            <%--<cc1:MaskedEditExtender   
                ID="MaskedEditExtender3"  
                runat="server"  
                TargetControlID="txtDelay"  
                Mask="99:99:99"  
                MaskType="Time"  
                MessageValidatorTip="true"
                AcceptAMPM="false">  
            </cc1:MaskedEditExtender>  
            <cc1:MaskedEditValidator   
                ID="MaskedEditValidator3"  
                runat="server"  
                ControlToValidate="txtDelay"  
                ControlExtender="MaskedEditExtender3"  
                IsValidEmpty="false"  
                EmptyValueMessage="Input time"  
                InvalidValueMessage="Time is not valid">  
            </cc1:MaskedEditValidator>--%>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" CssClass="EntryLabelStyle" Text="Notes:" Width="90px"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtNotes" runat="server" Height="92px" CssClass="TextBoxStyle"></asp:TextBox>
            <br />
            <br />
                <asp:CheckBox ID="chkAddMore" CssClass="EntryLabelStyle" Text="Add another leg" runat="server" />
            <br />
            <br />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddCommute" runat="server" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button ID="btnAddCommute" runat="server" CssClass="ButtonStyle" Text="Add Commute" onclick="btnAddCommute_Click" />
</asp:Content>