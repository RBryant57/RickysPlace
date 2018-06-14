using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PassConditionResults : System.Web.UI.Page
{

    #region Declarations

    #endregion

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        int passConditionId = Convert.ToInt32(Request.QueryString["PassConditionId"]);
        Dictionary<int, List<string>> response = new Dictionary<int, List<string>>();

        response = ServiceClient.GetPassCondition(passConditionId);
        var passCondition = response.Values.First();

        var startDate = passCondition[0];
        this.Title = "Ricky's Place: Pass Condition for: " + startDate;

        this.lblDate.Text = "Date: " + startDate;
        this.lblTime.Text = "Time: " + passCondition[1];
        this.lblMinutes.Text = "Minutes: " + passCondition[2];
        this.lblDelayMinutes.Text = "Delay Minutes: " + (Convert.ToInt32(passCondition[2]) - Convert.ToInt32(passCondition[3])).ToString();
        this.lblDestination.Text = "Destination: " + passCondition[4];
        this.lblDelay.Text = "Delay Reason: " + passCondition[5];

    }

    #endregion

}