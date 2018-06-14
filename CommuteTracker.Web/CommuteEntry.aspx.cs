using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class CommuteEntry : System.Web.UI.Page
{

    #region Declarations

    private Dictionary<int, string> selectedRoutes = new Dictionary<int, string>();

    private List<Structs.Commute> commutes = new List<Structs.Commute>();

    #endregion

    #region Private Methods

    private void clearPage()
    {
        this.txtStartTime.Text = String.Empty;
        this.txtEndTime.Text = String.Empty;
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

    private int insertCommute()
    {

        DateTime startTime, endTime;
        int destination;
        int delaySeconds;
        string notes = String.Empty;
        int commuteId;

        this.commutes.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));
        startTime = this.commutes[0].StartTime;
        this.commutes.Sort((x, y) => x.EndTime.CompareTo(y.EndTime));
        this.commutes.Reverse();
        endTime = this.commutes[0].EndTime;
        destination = this.commutes[0].Destination;
        delaySeconds = this.commutes.Select((i) => i.DelaySeconds).Sum();

        commuteId = ServiceClient.InsertCommute(startTime, endTime, destination, delaySeconds, notes);
        foreach (Structs.Commute currentCommute in this.commutes)
        {
            ServiceClient.InsertCommuteLeg(currentCommute.StartTime, currentCommute.EndTime, 
                currentCommute.Destination, currentCommute.Delay, currentCommute.DelaySeconds, 
                currentCommute.FareClass, currentCommute.Route, commuteId, currentCommute.Notes);
        }

        return commuteId;
    }

    private void loadDelayReasons()
    {
        this.cboDelays.DataSource = ServiceClient.GetDelayReasons().OrderBy(d => d.Value);
        this.cboDelays.DataTextField = "Value";
        this.cboDelays.DataValueField = "Key";
        this.cboDelays.DataBind();
        this.cboDelays.SelectedValue = "1";
    }

    private void loadDestinations()
    {
        this.cboDestinations.DataSource = ServiceClient.GetDestinations().OrderBy(d => d.Value);
        this.cboDestinations.DataTextField = "Value";
        this.cboDestinations.DataValueField = "Key";
        this.cboDestinations.DataBind();
    }

    private void loadFareClasses()
    {
        this.cboFareClass.DataSource = ServiceClient.GetFareClasses();
        this.cboFareClass.DataTextField = "Value";
        this.cboFareClass.DataValueField = "Key";
        this.cboFareClass.DataBind();
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
        Session["Commutes"] = this.commutes;
    }

    private bool validatePage()
    {
        try
        {
            if (String.IsNullOrEmpty(this.txtStartTime.Text))
            {
                this.lblError.Text = "A valid start time is required.";
                this.lblError.Visible = true;
                this.txtStartTime.Focus();

                return false;
            }
            if (String.IsNullOrEmpty(this.txtEndTime.Text))
            {
                this.lblError.Text = "A valid end time is required.";
                this.lblError.Visible = true;
                this.txtEndTime.Focus();

                return false;
            }
            if (Convert.ToDateTime(this.txtStartTime.Text) > Convert.ToDateTime(this.txtEndTime.Text))
            {
                this.lblError.Text = "The starting time must be before the ending time.";
                this.lblError.Visible = true;
                this.txtStartTime.Focus();

                return false;
            }
            if (String.IsNullOrEmpty(this.txtDelay.Text))
            {
                this.lblError.Text = "A valid delay time is required.";
                this.lblError.Visible = true;
                this.txtDelay.Focus();

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
        catch(Exception ex)
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
            this.loadDestinations();
            this.loadRoutes();
            this.loadFareClasses();

            this.txtStartTime.Text = DateTime.Now.ToString();
            this.txtEndTime.Text = DateTime.Now.ToString();

            this.cldMain.SelectedDate = DateTime.Now.Date;

            this.updateSession();
        }

        this.lblError.Visible = false;
        this.lblError.CssClass = "ErrorLabelStyle";

    }

    protected void btnAddCommute_Click(object sender, EventArgs e)
    {
        string notes = String.Empty;
        DateTime startTime, endTime, startDate, endDate;

        this.lblError.Visible = false;
        this.commutes = (List<Structs.Commute>)Session["Commutes"];

        if(!String.IsNullOrEmpty(this.txtNotes.Text))
        {
            notes = this.txtNotes.Text;
        }

        if (this.validatePage())
        {

            startDate = this.cldMain.SelectedDate;
            startTime = Convert.ToDateTime(this.txtStartTime.Text);
            startDate = startDate.AddHours(startTime.Hour);
            startDate = startDate.AddMinutes(startTime.Minute);
            startDate = startDate.AddSeconds(startTime.Second);

            endDate = this.cldMain.SelectedDate;
            endTime = Convert.ToDateTime(this.txtEndTime.Text);
            endDate = endDate.AddHours(endTime.Hour);
            endDate = endDate.AddMinutes(endTime.Minute);
            endDate = endDate.AddSeconds(endTime.Second);

            Structs.Commute currentCommute = new Structs.Commute();

            currentCommute.StartTime = Convert.ToDateTime(this.txtStartTime.Text);
            currentCommute.EndTime = Convert.ToDateTime(this.txtEndTime.Text);
            currentCommute.Destination = Convert.ToInt32(this.cboDestinations.SelectedValue);
            currentCommute.Delay = Convert.ToInt32(this.cboDelays.SelectedValue);
            currentCommute.DelaySeconds = this.convertToSeconds(this.txtDelay.Text);
            currentCommute.FareClass = Convert.ToInt32(this.cboFareClass.SelectedValue);
            currentCommute.Route = Convert.ToInt32(this.cboRoutes.SelectedValue);
            currentCommute.Notes = notes;

            this.commutes.Add(currentCommute);
            this.clearPage();
            this.lblError.CssClass = "ResultLabelStyle";
            this.lblError.Text = "Commute Leg added.";

            if (!this.chkAddMore.Checked)
            {
                int id = this.insertCommute();

                this.lblError.CssClass = "ResultLabelStyle";
                this.lblError.Text = "Commute added.";
                this.lblError.Visible = true;
                this.clearPage();
                Response.Redirect("CommuteResults.aspx?CommuteId=" + id);
            }
            else
            {
                this.cboDestinations.Enabled = false;
                this.txtStartTime.Text = this.cldMain.SelectedDate.ToString();
                this.txtEndTime.Text = this.cldMain.SelectedDate.ToString();
            }
        }
    }

    protected void cboDelays_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.cboDelays.SelectedValue != "1")
        {
            this.txtDelay.Visible = true;
            this.lblDelayTime.Visible = true;
        }
        else
        {
            this.txtDelay.Visible = false;
            this.lblDelayTime.Visible = false;
            this.txtDelay.Text = "00:00:00";
        }

    }

    protected void cldMain_SelectionChanged(object sender, EventArgs e)
    {
        this.txtStartTime.Text = this.cldMain.SelectedDate.ToString();
        this.txtEndTime.Text = this.cldMain.SelectedDate.ToString();
    }

#endregion

}