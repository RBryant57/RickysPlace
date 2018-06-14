using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FareClass : System.Web.UI.Page
{

    #region Page Event Handlers

    protected void btnAddFareClass_Click(object sender, EventArgs e)
    {
        this.lblError.Visible = false;

        if (!String.IsNullOrEmpty(this.txtName.Text))
        {
            string notes = String.Empty;

            if (!String.IsNullOrEmpty(this.txtNotes.Text))
            {
                notes = this.txtNotes.Text;
            }

            ServiceClient.InsertFareClass(this.txtName.Text, notes);

            this.lblError.CssClass = "ResultLabelStyle";
            this.lblError.Text = String.Format("Fare class: {0} added.", this.txtName.Text);
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