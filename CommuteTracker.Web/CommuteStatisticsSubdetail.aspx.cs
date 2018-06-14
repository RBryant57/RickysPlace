using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class CommuteStatisticsSubdetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int depth;
        this.xmlDisplay.TransformSource = "~/App_Themes/RPTheme/Test.xsl";
        this.xmlDisplay.DocumentContent = ServiceClient.GetAverageCommutes(out depth);

        //XmlDocument doc = new XmlDocument();
        //doc.LoadXml(this.xmlDisplay.DocumentContent);

        depth = depth - 3 > 0 ? depth -= 3 : (3 / 20);
        depth *= 50;
        this.lblSpacer.Height = new Unit(depth);

    }
}