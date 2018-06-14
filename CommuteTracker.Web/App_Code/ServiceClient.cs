using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for ServiceClient
/// </summary>
public static class ServiceClient
{

    #region Declarations

    private static ICommuteTrackerService client;
    private static CommuteItemResponse response;
    private static CommuteEntryRequest request;
    private static CommuteRouteEntryRequest requestRoute;
    private static CommuteItemEntryRequest requestItemEntry;
    private static CommuteItemEntryResponse responseItemEntry;

    #endregion

    #region Public Static Methods

    #region Statistic Methods

    public static string GetAverageCommutesByDay(int routeId, out int depth)
    {
        string result = String.Empty;

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.Id = routeId;

            response = client.GetAverageCommutesByDayForRoute(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            result = response.XMLData;
            depth = response.Id;

            return result;
        }
        finally
        {
        }
    }

    public static string GetAverageCommutesByDayByDestination()
    {
        string result = String.Empty;

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();

            response = client.GetAverageCommutesByDayByDestination(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            result = response.XMLData;

            return result;
        }
        finally
        {
        }
    }

    public static string GetAverageCommutesByDayByDestination(int routeId, out int depth)
    {
        string result = String.Empty;

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.Id = routeId;

            response = client.GetAverageCommutesByDayByDestinationForRoute(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            result = response.XMLData;
            depth = response.Id;

            return result;
        }
        finally
        {
        }
    }

    public static string GetAverageCommutesByMonth(int routeId, out int depth)
    {
        string result = String.Empty;

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.Id = routeId;

            response = client.GetAverageCommutesByMonthForRoute(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            result = response.XMLData;
            depth = response.Id;

            return result;
        }
        finally
        {
        }
    }

    public static string GetAverageCommutesByMonthByDestination()
    {
        string result = String.Empty;

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();

            response = client.GetAverageCommutesByMonthByDestination(request);
            
            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            result = response.XMLData;

            return result;
        }
        finally
        {
        }
    }

    public static string GetAverageCommutes(out int depth)
    {
        string result = String.Empty;

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();

            response = client.GetAverageCommutes(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            result = response.XMLData;
            depth = response.Id;

            return result;
        }
        finally
        {
        }
    }

    public static string GetAverageCommutesByMonthByDestination(int routeId, out int depth)
    {
        string result = String.Empty;

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.Id = routeId;

            response = client.GetAverageCommutesByMonthByDestinationForRoute(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            result = response.XMLData;
            depth = response.Id;

            return result;
        }
        finally
        {
        }
    }

    #endregion

    #region Insert Methods

    public static int InsertCommute(DateTime startTime,
        DateTime endTime,
        int destination,
        int delaySeconds,
        string notes)
    {
        try
        {
            request = new CommuteEntryRequest();
            responseItemEntry = new CommuteItemEntryResponse();
            client = new CommuteTrackerServiceClient();
            int id = 0;

            request.StartTime = startTime;
            request.EndTime = endTime;
            request.Destination = destination;
            request.DelaySeconds = delaySeconds;
            request.Notes = notes;

            responseItemEntry = client.InsertCommute(request);
            id = responseItemEntry.Id;
            try
            {
                ((CommuteTrackerServiceClient)client).Close();
                return id;
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
                else if (((CommuteTrackerServiceClient)client).State == CommunicationState.Opened)
                    ((CommuteTrackerServiceClient)client).Close();
                return id;
            }
        }
        finally { }

    }

    public static void InsertCommuteLeg(DateTime startTime,
        DateTime endTime,
        int destination,
        int delay,
        int delaySeconds,
        int fareClass,
        int route,
        int commute,
        string notes)
    {
        try
        {
            request = new CommuteEntryRequest();
            client = new CommuteTrackerServiceClient();

            request.StartTime = startTime;
            request.EndTime = endTime;
            request.Destination = destination;
            request.Delay = delay;
            request.DelaySeconds = delaySeconds;
            request.FareClass = fareClass;
            request.Route = route;
            request.Commute = commute;
            request.Notes = notes;

            client.InsertCommuteLeg(request);
            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
                else if (((CommuteTrackerServiceClient)client).State == CommunicationState.Opened)
                    ((CommuteTrackerServiceClient)client).Close();
            }
        }
        finally { }

    }

    public static int InsertPassCondition(DateTime date,
    int minutes,
    int usualMinutes,
    int route,
    int delay,
    string notes)
    {
        try
        {
            request = new CommuteEntryRequest();
            client = new CommuteTrackerServiceClient();
            responseItemEntry = new CommuteItemEntryResponse();
            int id = 0;

            request.StartTime = date;
            request.DelaySeconds = minutes;
            request.UsualMinutes = usualMinutes;
            request.Route = route;
            request.Delay = delay;
            request.Notes = notes;

            responseItemEntry = client.InsertPassCondition(request);
            id = responseItemEntry.Id;
            try
            {
                ((CommuteTrackerServiceClient)client).Close();
                return id;
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
                else if (((CommuteTrackerServiceClient)client).State == CommunicationState.Opened)
                    ((CommuteTrackerServiceClient)client).Close();
                return id;
            }
        }
        finally { }

    }

    public static int InsertDelayReason(string description)
    {
        try
        {
            requestItemEntry = new CommuteItemEntryRequest();
            client = new CommuteTrackerServiceClient();

            requestItemEntry.Name = description;

            responseItemEntry = client.InsertDelayReason(requestItemEntry);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
                else if (((CommuteTrackerServiceClient)client).State == CommunicationState.Opened)
                    ((CommuteTrackerServiceClient)client).Close();
            }
        }
        finally { }

        return responseItemEntry.Id;
    }

    public static int InsertDestination(string name)
    {
        return InsertDestination(name, String.Empty);
    }

    public static int InsertDestination(string name, string notes)
    {
        try
        {
            requestItemEntry = new CommuteItemEntryRequest();
            client = new CommuteTrackerServiceClient();

            requestItemEntry.Name = name;
            requestItemEntry.Notes = notes;

            responseItemEntry = client.InsertDestination(requestItemEntry);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
                else if (((CommuteTrackerServiceClient)client).State == CommunicationState.Opened)
                    ((CommuteTrackerServiceClient)client).Close();
            }
        }
        finally { }

        return responseItemEntry.Id;
    }

    public static int InsertFareClass(string name)
    {
        return InsertFareClass(name, String.Empty);
    }

    public static int InsertFareClass(string name, string notes)
    {
        try
        {
            requestItemEntry = new CommuteItemEntryRequest();
            client = new CommuteTrackerServiceClient();

            requestItemEntry.Name = name;
            requestItemEntry.Notes = notes;

            responseItemEntry = client.InsertFareClass(requestItemEntry);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
                else if (((CommuteTrackerServiceClient)client).State == CommunicationState.Opened)
                    ((CommuteTrackerServiceClient)client).Close();
            }
        }
        finally { }

        return responseItemEntry.Id;
    }

    public static int InsertRoute(string name, int type, string number, int miles)
    {
        return InsertRoute(name, type, number, miles, String.Empty);
    }

    public static int InsertRoute(string name, int type, string number, int miles, string notes)
    {
        try
        {
            requestRoute = new CommuteRouteEntryRequest();
            client = new CommuteTrackerServiceClient();

            requestRoute.Name = name;
            requestRoute.Type = type;
            requestRoute.Number = number;
            requestRoute.Miles = miles;
            requestRoute.Notes = notes;

            responseItemEntry = client.InsertRoute(requestRoute);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
                else if (((CommuteTrackerServiceClient)client).State == CommunicationState.Opened)
                    ((CommuteTrackerServiceClient)client).Close();
            }
        }
        finally { }

        return responseItemEntry.Id;
    }

    public static int InsertRouteType(string name)
    {
        return InsertRouteType(name, String.Empty);
    }

    public static int InsertRouteType(string name, string notes)
    {
        try
        {
            requestItemEntry = new CommuteItemEntryRequest();
            client = new CommuteTrackerServiceClient();

            requestItemEntry.Name = name;
            requestItemEntry.Notes = notes;

            responseItemEntry = client.InsertRouteType(requestItemEntry);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
                else if (((CommuteTrackerServiceClient)client).State == CommunicationState.Opened)
                    ((CommuteTrackerServiceClient)client).Close();
            }
        }
        finally { }

        return responseItemEntry.Id;
    }

    #endregion

    #region Retrieval Methods

    public static Dictionary<int, string> GetDelayReasons()
    {
        Dictionary<int, string> delays = new Dictionary<int, string>();

        try
        {
            client = new CommuteTrackerServiceClient();
            response = client.GetDelayReasons(new CommuteItemRequest());

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            delays = response.Delays;
        }
        finally
        {
        }

        return delays;
    }

    public static Dictionary<int, string> GetDestinations()
    {
        Dictionary<int, string> destinations = new Dictionary<int, string>();

        try
        {
            client = new CommuteTrackerServiceClient();
            response = client.GetDestinations(new CommuteItemRequest());

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            destinations = response.Destinations;
        }
        finally
        {
        }

        return destinations;
    }

    public static Dictionary<int, string> GetFareClasses()
    {
        Dictionary<int, string> destinations = new Dictionary<int, string>();

        try
        {
            client = new CommuteTrackerServiceClient();
            response = client.GetFareClasses(new CommuteItemRequest());

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            destinations = response.Destinations;
        }
        finally
        {
        }

        return destinations;
    }

    public static Dictionary<int, string> GetRoutes()
    {
        Dictionary<int, string> routes = new Dictionary<int, string>();

        try
        {
            client = new CommuteTrackerServiceClient();
            response = client.GetRoutes(new CommuteItemRequest());

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            routes = response.Routes;
        }
        finally
        {
        }

        return routes;
    }

    public static Dictionary<int, string> GetRouteTypes()
    {
        Dictionary<int, string> routeTypes = new Dictionary<int, string>();

        try
        {
            client = new CommuteTrackerServiceClient();
            response = client.GetRouteTypes(new CommuteItemRequest());

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            routeTypes = response.RouteTypes;
        }
        finally { }

        return routeTypes;
    }

    public static Dictionary<int, List<string>> GetCommutes(int commuteId)
    {
        Dictionary<int, List<string>> commutes = new Dictionary<int, List<string>>();
        Dictionary<int, string[]> rawCommutes = new Dictionary<int, string[]>();

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.Id = commuteId;
            response = client.GetCommutes(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            rawCommutes = response.AverageCommutes;

            foreach (KeyValuePair<int, string[]> commute in rawCommutes)
            {
                List<string> stats = new List<string>();

                stats.Add(commute.Value[0]);
                stats.Add(commute.Value[1]);
                stats.Add(commute.Value[2]);
                stats.Add(commute.Value[3]);
                stats.Add(commute.Value[4]);
                stats.Add(commute.Value[5]);
                stats.Add(commute.Value[6]);

                commutes.Add(commute.Key, stats);
            }
        }
        finally { }

        return commutes;
    }

    public static Dictionary<int, List<string>> GetCommutes(DateTime commuteDate)
    {
        Dictionary<int, List<string>> commutes = new Dictionary<int, List<string>>();
        Dictionary<int, string[]> rawCommutes = new Dictionary<int, string[]>();

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.CommuteDate = commuteDate;
            response = client.GetCommutes(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            rawCommutes = response.AverageCommutes;

            foreach (KeyValuePair<int, string[]> commute in rawCommutes)
            {
                List<string> stats = new List<string>();

                stats.Add(commute.Value[0]);
                stats.Add(commute.Value[1]);
                stats.Add(commute.Value[2]);
                stats.Add(commute.Value[3]);
                stats.Add(commute.Value[4]);
                stats.Add(commute.Value[5]);
                stats.Add(commute.Value[6]);

                commutes.Add(commute.Key, stats);
            }
        }
        finally { }

        return commutes;
    }

    public static Dictionary<int, List<string>> GetPassCondition(int passConditionId)
    {
        Dictionary<int, List<string>> passCondition = new Dictionary<int, List<string>>();
        Dictionary<int, string[]> rawPassCondition = new Dictionary<int, string[]>();

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.Id = passConditionId;
            response = client.GetPassCondition(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            rawPassCondition = response.AverageCommutes;

            foreach (KeyValuePair<int, string[]> pCondition in rawPassCondition)
            {
                List<string> stats = new List<string>();

                stats.Add(pCondition.Value[0]);
                stats.Add(pCondition.Value[1]);
                stats.Add(pCondition.Value[2]);
                stats.Add(pCondition.Value[3]);
                stats.Add(pCondition.Value[4]);
                stats.Add(pCondition.Value[5]);
                stats.Add(pCondition.Value[6]);

                passCondition.Add(pCondition.Key, stats);
            }
        }
        finally { }

        return passCondition;
    }

    #endregion

    #region Obsolete Dictionary Methods

    public static Dictionary<int, List<List<string>>> GetAverageCommutesByDay()
    {
        Dictionary<int, List<List<string>>> averages = new Dictionary<int, List<List<string>>>();
        Dictionary<int, string[][]> rawAverages = new Dictionary<int, string[][]>();
        List<string> dayList;
        List<List<string>> interimList;

        try
        {
            client = new CommuteTrackerServiceClient();
            response = client.GetAverageCommutesByDay(new CommuteItemRequest());

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            rawAverages = response.AverageCommutesBy;
            foreach (KeyValuePair<int, string[][]> average in rawAverages)
            {
                interimList = new List<List<string>>();
                foreach (string[] dayAverage in average.Value)
                {
                    dayList = new List<string>(dayAverage);
                    interimList.Add(dayList);
                }

                averages.Add(average.Key, interimList);
            }
        }
        finally
        {
        }

        return averages;
    }

    public static Dictionary<string, List<string>> GetAverageCommutesByDayByRoute(int routeId)
    {
        Dictionary<string, List<string>> averages = new Dictionary<string, List<string>>();
        Dictionary<string, string[]> rawAverages = new Dictionary<string, string[]>();
        List<string> stats = new List<string>();
        StringBuilder displayString = new StringBuilder();

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.Id = routeId;
            response = client.GetAverageCommutesByDayByRoute(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            rawAverages = response.AverageCommutesByTime;
            foreach (KeyValuePair<string, string[]> average in rawAverages)
            {
                decimal speed = Convert.ToDecimal(Convert.ToDecimal(average.Value[2]) / (Convert.ToDecimal(average.Value[0]) / 3600));
                decimal time = Convert.ToDecimal(Convert.ToDecimal(average.Value[0]) / 60);
                decimal timeDeviation = Convert.ToDecimal(Convert.ToDecimal(average.Value[1]) / 60);

                displayString.Append("Average Speed: ");
                displayString.Append(Math.Round(speed, 0));
                displayString.Append(" miles per hour.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append("Average Time: ");
                displayString.Append(Math.Round(time, 0));
                displayString.Append(" minutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append("Standard Deviation: ");
                displayString.Append(Math.Round(timeDeviation, 0));
                displayString.Append(" minutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append(average.Value[3]);
                displayString.Append(" commutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;

                averages.Add(average.Key, stats);
                stats = new List<string>();
            }
        }
        finally
        {
        }

        return averages;
    }

    public static Dictionary<string, List<string>> GetAverageCommutesByMonthByRoute(int routeId)
    {
        Dictionary<string, List<string>> averages = new Dictionary<string, List<string>>();
        Dictionary<string, string[]> rawAverages = new Dictionary<string, string[]>();
        List<string> stats = new List<string>();
        StringBuilder displayString = new StringBuilder();

        try
        {
            client = new CommuteTrackerServiceClient();
            CommuteItemRequest request = new CommuteItemRequest();
            request.Id = routeId;
            response = client.GetAverageCommutesByMonthByRoute(request);

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            rawAverages = response.AverageCommutesByTime;
            foreach (KeyValuePair<string, string[]> average in rawAverages)
            {
                decimal speed = Convert.ToDecimal(Convert.ToDecimal(average.Value[2]) / (Convert.ToDecimal(average.Value[0]) / 3600));
                decimal time = Convert.ToDecimal(Convert.ToDecimal(average.Value[0]) / 60);
                decimal timeDeviation = Convert.ToDecimal(Convert.ToDecimal(average.Value[1]) / 60);

                displayString.Append("Average Speed: ");
                displayString.Append(Math.Round(speed, 0));
                displayString.Append(" miles per hour.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append("Average Time: ");
                displayString.Append(Math.Round(time, 0));
                displayString.Append(" minutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append("Standard Deviation: ");
                displayString.Append(Math.Round(timeDeviation, 0));
                displayString.Append(" minutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append(average.Value[3]);
                displayString.Append(" commutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;

                averages.Add(average.Key, stats);
                stats = new List<string>();
            }
        }
        finally
        {
        }

        return averages;
    }

    public static Dictionary<string, List<string>> GetAverageCommutesDictionary()
    {
        Dictionary<string, List<string>> averages = new Dictionary<string, List<string>>();
        Dictionary<int, string[]> rawAverages = new Dictionary<int, string[]>();
        List<string> stats = new List<string>();
        StringBuilder displayString = new StringBuilder();

        try
        {
            client = new CommuteTrackerServiceClient();
            response = client.GetAverageCommutes(new CommuteItemRequest());

            try
            {
                ((CommuteTrackerServiceClient)client).Close();
            }
            catch
            {
                if (((CommuteTrackerServiceClient)client).State == CommunicationState.Faulted)
                    ((CommuteTrackerServiceClient)client).Abort();
            }

            rawAverages = response.AverageCommutes;
            foreach (KeyValuePair<int, string[]> average in rawAverages)
            {
                decimal speed = Convert.ToDecimal(Convert.ToDecimal(average.Value[1]) / (Convert.ToDecimal(average.Value[3]) / 3600));
                decimal time = Convert.ToDecimal(Convert.ToDecimal(average.Value[3]) / 60);
                decimal timeDeviation = Convert.ToDecimal(Convert.ToDecimal(average.Value[4]) / 60);

                displayString.Append("Average Speed: ");
                displayString.Append(Math.Round(speed, 0));
                displayString.Append(" miles per hour.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append("Average Time: ");
                displayString.Append(Math.Round(time, 0));
                displayString.Append(" minutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append("Standard Deviation: ");
                displayString.Append(Math.Round(timeDeviation, 0));
                displayString.Append(" minutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append(average.Value[1]);
                displayString.Append(" miles by ");
                displayString.Append(average.Value[2]);
                stats.Add(displayString.ToString());
                displayString.Length = 0;
                displayString.Append(average.Value[5]);
                displayString.Append(" commutes.");
                stats.Add(displayString.ToString());
                displayString.Length = 0;

                while (averages.ContainsKey(average.Value[0]))
                {
                    average.Value[0] += "1";
                }
                average.Value[0] += "r" + average.Key.ToString();
                averages.Add(average.Value[0], stats);
                stats = new List<string>();
            }
        }
        finally
        {
        }

        return averages;
    }

    #endregion

    #endregion

}