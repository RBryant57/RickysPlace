using System;
using System.Collections;
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

public partial class Route : System.Web.UI.Page
{

    #region Private Methods

    private void clearPage()
    {
        this.txtName.Text = String.Empty;
        this.txtNumber.Text = String.Empty;
        this.txtMiles.Text = String.Empty;
        this.txtNotes.Text = String.Empty;
    }

    private void loadTypes()
    {
        this.cboTypes.DataSource = ServiceClient.GetRouteTypes();
        this.cboTypes.DataTextField = "Value";
        this.cboTypes.DataValueField = "Key";
        this.cboTypes.DataBind();
    }

    private bool validatePage()
    {
        bool result = true;
        Regex objNotPositivePattern = new Regex("[^0-9.]");
        Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
        Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");

        if (String.IsNullOrEmpty(this.txtName.Text))
        {
            this.lblError.Text = "A valid name is required.";
            this.lblError.Visible = true;
            this.txtName.Focus();

            return false;
        }

        if (String.IsNullOrEmpty(this.txtNumber.Text))
        {
            this.lblError.Text = "A valid number is required.";
            this.lblError.Visible = true;
            this.txtNumber.Focus();

            return false;
        }

        if (!(!objNotPositivePattern.IsMatch(this.txtMiles.Text) &&
                objPositivePattern.IsMatch(this.txtMiles.Text) &&
                !objTwoDotPattern.IsMatch(this.txtMiles.Text)))
        {
            this.lblError.Text = "A valid mileage is required.";
            this.lblError.Visible = true;
            this.txtMiles.Focus();

            return false;
        }
        else if (Convert.ToDouble(this.txtMiles.Text) == 0)
        {
            this.lblError.Text = "A valid mileage is required.";
            this.lblError.Visible = true;
            this.txtMiles.Focus();

            return false;
        }

        return result;
    }

    #endregion

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.loadTypes();
        }

        this.lblError.CssClass = "ErrorLabelStyle";

    }
            
    protected void btnAddRoute_Click(object sender, EventArgs e)
    {
        this.lblError.Visible = false;

        if (this.validatePage())
        {
            string notes = String.Empty;

            if (!String.IsNullOrEmpty(this.txtNotes.Text))
            {
                notes = this.txtNotes.Text;
            }

            ServiceClient.InsertRoute(this.txtName.Text,
                Convert.ToInt32(this.cboTypes.SelectedValue),
                this.txtNumber.Text,
                Convert.ToInt32(this.txtMiles.Text),
                notes);
    
            this.lblError.CssClass = "ResultLabelStyle";
            this.lblError.Text = String.Format("Route: {0} added.", this.txtName.Text);
            this.lblError.Visible = true;
            this.clearPage();
        }
    }

    #endregion
   
}