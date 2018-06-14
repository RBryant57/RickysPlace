using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommuteResults : System.Web.UI.Page
{

    #region Declarations

    private class subCommute
    {
        private string startTime;
        private string endTime;
        private string route;
        private string delayReason;
        private string fareClass;

        public string StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                this.startTime = value;
            }
        }

        public string EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }

        }

        public string Route
        {
            get
            {
                return this.route;
            }
            set
            {
                this.route = value;
            }
        }

        public string FareClass
        {
            get
            {
                return this.fareClass;
            }
            set
            {
                this.fareClass = value;
            }
        }

        public string DelayReason
        {
            get
            {
                return this.delayReason;
            }
            set
            {
                this.delayReason = value;
            }
        }

    }

    #endregion

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        int commuteId = Convert.ToInt32(Request.QueryString["CommuteId"]);
        DateTime commuteDate = Convert.ToDateTime(Request.QueryString["CommuteDate"]);
        List<Structs.Commute> commutes = (List<Structs.Commute>)Session["Commutes"];
        List<subCommute> subCommutes = new List<subCommute>();
        DateTime startDate = new DateTime(), endDate;
        string destination = String.Empty;
        TimeSpan commuteTime = new TimeSpan();
        int delaySeconds = 0;
        Dictionary<int, List<string>> response = new Dictionary<int, List<string>>();

        if (commutes != null)
        {
            commutes.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));
            startDate = commutes[0].StartTime;
            commutes.Reverse();
            endDate = commutes[0].EndTime;
            commuteTime = endDate - startDate;
            this.lblTotalTime.Text = "Total Time: " + commuteTime.ToString();
            delaySeconds = commutes.Select((i) => i.DelaySeconds).Sum();
            commuteTime = new TimeSpan(0, 0, delaySeconds);

            response = ServiceClient.GetCommutes(commuteId);
        }
        else
        {
            startDate = commuteDate;
            this.Title = "Ricky's Place: Commute for: " + commuteDate.ToShortDateString();

            response = ServiceClient.GetCommutes(startDate);
        }

        if (response.Count > 0)
        {
            TimeSpan totalTime = new TimeSpan();
            bool isPassCondition = !(response.ToList()[0].Value[0].ToLower().Contains("a") || response.ToList()[0].Value[0].ToLower().Contains("p"));
            foreach (KeyValuePair<int, List<string>> commute in response)
            {
                subCommute subcommute = new subCommute();

                if (!isPassCondition)
                {
                    subcommute.StartTime = commute.Value[0];
                    var startTime = Convert.ToDateTime(subcommute.StartTime);
                    subcommute.EndTime = commute.Value[1];
                    var endTime = Convert.ToDateTime(subcommute.EndTime);
                    var subTime = endTime - startTime;
                    totalTime += subTime;
                    destination = commute.Value[2];
                    subcommute.Route = commute.Value[3];
                    delaySeconds += Convert.ToInt32(commute.Value[4]);
                    subcommute.DelayReason = commute.Value[5];
                    subcommute.FareClass = commute.Value[6];
                }
                else
                {
                    subcommute.StartTime = commute.Value[1];
                    var startTime = Convert.ToDateTime(subcommute.StartTime);
                    subcommute.EndTime = commute.Value[2];
                    subcommute.Route = commute.Value[3];
                    delaySeconds += ((Convert.ToInt32(subcommute.EndTime) - Convert.ToInt32(subcommute.Route)) * 60);
                    subcommute.DelayReason = commute.Value[4];
                    subcommute.FareClass = commute.Value[5];
                }

                subCommutes.Add(subcommute);

            }

            if (isPassCondition)
            {
                this.gvwCommutes.Columns[0].HeaderText = "Time";
                this.gvwCommutes.Columns[1].HeaderText = "Minutes";
                this.gvwCommutes.Columns[2].HeaderText = "Usual Minutes";
                this.gvwCommutes.Columns[3].HeaderText = "Route";
                this.gvwCommutes.Columns[4].HeaderText = "Delay Reason";

            }

            this.gvwCommutes.DataSource = subCommutes;
            this.gvwCommutes.DataBind();

            if (isPassCondition)
            {
                this.lblTotalTime.Visible = false;
            }
            else
            {
                this.lblTotalTime.Text = "Total Time: " + totalTime.ToString();
            }

            if (commuteTime.Ticks == 0)
                commuteTime = new TimeSpan(0, 0, delaySeconds);

            this.lblDelay.Text = "Total Delay: " + commuteTime.ToString();
            this.lblDate.Text = "Date: " + startDate.ToShortDateString();

        }
        else
        {

        }
    }

    #endregion

}