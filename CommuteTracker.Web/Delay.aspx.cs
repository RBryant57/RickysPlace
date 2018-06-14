using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Delay : System.Web.UI.Page
{

    #region Page Event Handlers

    protected void btnAddDelayReason_Click(object sender, EventArgs e)
    {
        this.lblError.Visible = false;

        if (!String.IsNullOrEmpty(this.txtDescription.Text))
        {
            ServiceClient.InsertDelayReason(this.txtDescription.Text);

            this.lblError.CssClass = "ResultLabelStyle";
            this.lblError.Text = String.Format("Delay Reason: {0} added.", this.txtDescription.Text);
            this.lblError.Visible = true;

            this.txtDescription.Text = String.Empty;
        }
        else
        {
            this.lblError.Text = "A valid description is required.";
            this.lblError.Visible = true;
            this.txtDescription.Focus();
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblError.CssClass = "ErrorLabelStyle";
        var source = Request.QueryString["Source"].ToLower();

        switch (source)
        {
            case "passcondition":
                this.hypCommute.NavigateUrl = "~/PassConditions.aspx";
                this.hypCommute.Text = "Back to Entering Pass Conditions";
                break;
            case "commute":
                this.hypCommute.NavigateUrl = "~/CommuteEntry.aspx";
                this.hypCommute.Text = "Back to Entering Commutes";
                break;
        }
    }

    #endregion
    
}