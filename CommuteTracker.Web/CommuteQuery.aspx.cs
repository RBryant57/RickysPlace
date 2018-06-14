using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommuteQuery : System.Web.UI.Page
{

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearchCommute_Click(object sender, EventArgs e)
    {
        Session.Clear();
        DateTime commuteDate = Convert.ToDateTime(this.txtSearchDate.Text);
        Response.Redirect("CommuteResults.aspx?CommuteDate=" + commuteDate);
    }

    protected void cldMain_SelectionChanged(object sender, EventArgs e)
    {
        this.txtSearchDate.Text = this.cldMain.SelectedDate.ToShortDateString();
    }

    #endregion

}