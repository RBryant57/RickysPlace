using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class PassConditions : System.Web.UI.Page
{

    #region Declarations

    private Dictionary<int, string> selectedRoutes = new Dictionary<int, string>();

    private Structs.PassCondition passConition = new Structs.PassCondition();

    #endregion

    #region Private Methods

    private void clearPage()
    {
        this.txtMinutes.Text = String.Empty;
        this.txtUsualMinutes.Text = String.Empty;
        this.selectedRoutes.Clear();
        this.txtNotes.Text = String.Empty;
    }

    private int convertToSeconds(string delayTime)
    {
        DateTime delay = Convert.ToDateTime(delayTime);
        int hours, minutes;

        hours = delay.Hour;
        minutes = delay.Minute;

        return hours * 3600 + minutes * 60 + delay.Second;
    }

    private int insertPassCondition()
    {
        DateTime date;
        int minutes, usualMinutes;
        int route;
        int delay;
        string notes = String.Empty;
        int passConditionId = 0;

        date = new DateTime(this.passConition.Date.Year, this.passConition.Date.Month,this.passConition.Date.Day);
        switch (this.passConition.Time)
        {
            case 1:
                date = date.AddHours(12);
                break;
            case 2:
                date = date.AddHours(15);
                break;
            case 3:
                date = date.AddHours(18);
                break;
            case 4:
                date = date.AddHours(21);
                break;
        }
        minutes = this.passConition.Minutes;
        usualMinutes = this.passConition.UsualMinutes;
        route = this.passConition.Route;
        delay = this.passConition.Delay;

        passConditionId = ServiceClient.InsertPassCondition(date, minutes, usualMinutes, route, delay, notes);

        return passConditionId;
    }

    private void loadDelayReasons()
    {
        this.cboDelays.DataSource = ServiceClient.GetDelayReasons().OrderBy(d => d.Value);
        this.cboDelays.DataTextField = "Value";
        this.cboDelays.DataValueField = "Key";
        this.cboDelays.DataBind();
        this.cboDelays.SelectedValue = "1";
    }

    private void loadTimes()
    {
        this.cboTime.Items.Add(new ListItem("12:00", "1"));
        this.cboTime.Items.Add(new ListItem("3:00", "2"));
        this.cboTime.Items.Add(new ListItem("6:00", "3"));
        this.cboTime.Items.Add(new ListItem("9:00", "4"));
    }

    private void loadRoutes()
    {
        this.cboRoutes.DataSource = ServiceClient.GetRoutes().OrderBy(r => r.Value);
        this.cboRoutes.DataTextField = "Value";
        this.cboRoutes.DataValueField = "Key";
        this.cboRoutes.DataBind();
    }

    private void updateSession()
    {
        Session["PassCondition"] = this.passConition;
    }

    private bool validatePage()
    {
        try
        {
            if (String.IsNullOrEmpty(this.txtMinutes.Text))
            {
                this.lblError.Text = "Minutes are required.";
                this.lblError.Visible = true;
                this.txtMinutes.Focus();

                return false;
            }
            if (String.IsNullOrEmpty(this.txtUsualMinutes.Text))
            {
                this.lblError.Text = "Usual minutes are required.";
                this.lblError.Visible = true;
                this.txtUsualMinutes.Focus();

                return false;
            }
            var minutes = 0;
            if (!Int32.TryParse(this.txtMinutes.Text, out minutes))
            {
                this.lblError.Text = "Minutes must be an integer.";
                this.lblError.Visible = true;
                this.txtMinutes.Focus();

                return false;
            }
            else if (minutes < 0)
            {
                this.lblError.Text = "Minutes must be a positive integer.";
                this.lblError.Visible = true;
                this.txtUsualMinutes.Focus();

                return false;
            }
            if (!Int32.TryParse(this.txtUsualMinutes.Text, out minutes))
            {
                this.lblError.Text = "Usual minutes must be an integer.";
                this.lblError.Visible = true;
                this.txtUsualMinutes.Focus();

                return false;
            }
            else if (minutes < 0)
            {
                this.lblError.Text = "Usual minutes must be a positive integer.";
                this.lblError.Visible = true;
                this.txtUsualMinutes.Focus();

                return false;
            }
            if (this.cldMain.SelectedDate.Year == 1)
            {
                this.lblError.Text = "A valid date must be selected.";
                this.lblError.Visible = true;
                this.cldMain.Focus();

                return false;
            }
        }
        catch (Exception ex)
        {
            this.lblError.Text = ex.Message;
            this.lblError.Visible = true;

            return false;
        }

        return true;
    }

    #endregion

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.loadDelayReasons();
            this.loadTimes();
            this.loadRoutes();

            this.cldMain.SelectedDate = DateTime.Now.Date;

            this.updateSession();
        }

        this.lblError.Visible = false;
        this.lblError.CssClass = "ErrorLabelStyle";

    }

    protected void btnAddPassCondition_Click(object sender, EventArgs e)
    {
        this.lblError.Visible = false;
        this.passConition = (Structs.PassCondition)Session["PassCondition"];

        if (this.validatePage())
        {
            this.passConition.Date = this.cldMain.SelectedDate;
            this.passConition.Time = Convert.ToInt32(this.cboTime.SelectedValue);
            this.passConition.Minutes = Convert.ToInt32(this.txtMinutes.Text);
            this.passConition.UsualMinutes = Convert.ToInt32(this.txtUsualMinutes.Text);
            this.passConition.Delay = Convert.ToInt32(this.cboDelays.SelectedValue);
            this.passConition.Route = Convert.ToInt32(this.cboRoutes.SelectedValue);
            this.passConition.Notes = this.txtNotes.Text;

            var id = this.insertPassCondition();
            this.clearPage();
            Response.Redirect("PassConditionResults.aspx?PassConditionId=" + id);
        }
    }

    #endregion
   
}