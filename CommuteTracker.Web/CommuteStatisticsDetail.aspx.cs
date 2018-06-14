using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommuteStatisticsDetail : System.Web.UI.Page
{

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        int routeId = Convert.ToInt32(Request.QueryString[0]);
        int depth;
        string routeName = Request.QueryString[1];

        if (!Page.IsPostBack)
        {
            this.xmlDisplay.DocumentContent = ServiceClient.GetAverageCommutesByDay(routeId, out depth);
            this.xmlDisplay.TransformSource = Constants.DAY_FOR_ROUTE;

            this.rblTime.Items[0].Selected = true;
            this.lblRoute.Text = routeName;
            this.Title = String.Format("Ricky's Place: View Commuting Statistics for: {0}", routeName);

            depth = depth - Constants.DEFAULT_DEPTH > 0 ? depth -= Constants.DEFAULT_DEPTH : Constants.INVERSE_DAY_STAT_DEPTH;
            depth *= Constants.DAY_STAT_DEPTH;
            this.lblSpacer.Height = new Unit(depth);
        }

    }

    protected void control_SelectedChanged(object sender, EventArgs e)
    {
        int routeId = Convert.ToInt32(Request.QueryString[0]);
        int depth;

        if (this.rblTime.Items[0].Selected)
        {
            if (this.chkDestination.Checked)
            {
                this.xmlDisplay.DocumentContent = ServiceClient.GetAverageCommutesByDayByDestination(routeId, out depth);
                this.xmlDisplay.TransformSource = Constants.DESTINATION_DAY_FOR_ROUTE;

                depth = depth - Constants.DEFAULT_DEPTH > 0 ? depth -= Constants.DEFAULT_DEPTH : Constants.INVERSE_DAY_STAT_DEPTH;
                depth *= Constants.DAY_STAT_DEPTH;
                depth += Constants.DAY_SPACE;
                this.lblSpacer.Height = new Unit(depth);
            }
            else
            {
                this.xmlDisplay.DocumentContent = ServiceClient.GetAverageCommutesByDay(routeId, out depth);
                this.xmlDisplay.TransformSource = Constants.DAY_FOR_ROUTE;

                depth = depth - Constants.DEFAULT_DEPTH > 0 ? depth -= Constants.DEFAULT_DEPTH : Constants.INVERSE_DAY_STAT_DEPTH;
                depth *= Constants.DAY_STAT_DEPTH;
                this.lblSpacer.Height = new Unit(depth);
            }
        }
        else if(this.rblTime.Items[1].Selected)
        {
            if (this.chkDestination.Checked)
            {
                this.xmlDisplay.DocumentContent = ServiceClient.GetAverageCommutesByMonthByDestination(routeId, out depth);
                this.xmlDisplay.TransformSource = Constants.DESTINATION_MONTH_FOR_ROUTE;

                depth = depth - Constants.DEFAULT_DEPTH > 0 ? depth -= Constants.DEFAULT_DEPTH : Constants.INVERSE_MONTH_STAT_DEPTH;
                depth *= Constants.MONTH_STAT_DEPTH;
                depth += Constants.MONTH_SPACE;
                this.lblSpacer.Height = new Unit(depth);
            }
            else
            {
                this.xmlDisplay.DocumentContent = ServiceClient.GetAverageCommutesByMonth(routeId, out depth);
                this.xmlDisplay.TransformSource = Constants.MONTH_FOR_ROUTE;

                depth = depth - Constants.DEFAULT_DEPTH > 0 ? depth -= Constants.DEFAULT_DEPTH : Constants.INVERSE_MONTH_STAT_DEPTH;
                depth *= Constants.MONTH_STAT_DEPTH;
                this.lblSpacer.Height = new Unit(depth);
            }
        }

    }

    #endregion

}