using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommuteStatistics : System.Web.UI.Page
{

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        int depth;

        this.xmlDisplay.TransformSource = Constants.DEFAULT;
        this.xmlDisplay.DocumentContent = ServiceClient.GetAverageCommutes(out depth);

        depth = depth - Constants.DEFAULT_DEPTH > 0 ? depth -= Constants.DEFAULT_DEPTH : Constants.INVERSE_STAT_DEPTH;
        depth *= Constants.STAT_DEPTH;
        this.lblSpacer.Height = new Unit(depth);

    }

    #endregion

}