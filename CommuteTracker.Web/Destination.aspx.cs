using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Destination
/// </summary>
public partial class Destination : System.Web.UI.Page
{

    #region Page Event Handlers

    protected void btnAddDestination_Click(object sender, EventArgs e)
    {
        this.lblError.Visible = false;

        if (!String.IsNullOrEmpty(this.txtName.Text))
        {
            string notes = String.Empty;

            if (!String.IsNullOrEmpty(this.txtNotes.Text))
            {
                notes = this.txtNotes.Text;
            }

            ServiceClient.InsertDestination(this.txtName.Text, notes);

            this.lblError.CssClass = "ResultLabelStyle";
            this.lblError.Text = String.Format("Destination: {0} added.", this.txtName.Text);
            this.lblError.Visible = true;

            this.txtName.Text = String.Empty;
            this.txtNotes.Text = String.Empty;

        }
        else
        {
            this.lblError.Text = "A valid name is required.";
            this.lblError.Visible = true;
            this.txtName.Focus();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblError.CssClass = "ErrorLabelStyle";
    }

    #endregion
   
}