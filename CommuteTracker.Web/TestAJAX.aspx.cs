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

public partial class TestAJAX : System.Web.UI.Page
{
    private void loadRoutes()
    {
        this.cboRoutes.DataSource = ServiceClient.GetRoutes();
        this.cboRoutes.DataTextField = "Value";
        this.cboRoutes.DataValueField = "Key";
        this.cboRoutes.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.loadRoutes();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.lstRoutes.Items.Add(this.cboRoutes.SelectedItem.Text);
    }
}