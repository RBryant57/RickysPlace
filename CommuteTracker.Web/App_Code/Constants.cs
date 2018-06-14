using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Constants
/// </summary>
public static class Constants
{

    private const string PATH = "~/App_Themes/RPTheme/";

    public const string DEFAULT = PATH + "Default.xsl";
    public const string DAY_FOR_ROUTE = PATH + "DayForRoute.xsl";
    public const string DESTINATION_DAY_FOR_ROUTE = PATH + "DayDestinationForRoute.xsl";
    public const string DESTINATION_MONTH_FOR_ROUTE = PATH + "MonthDestinationForRoute.xsl";
    public const string MONTH_FOR_ROUTE = PATH + "MonthForRoute.xsl";

    public const int STAT_DEPTH = 195;
    public const int DAY_STAT_DEPTH = 75;
    public const int MONTH_STAT_DEPTH = 80;
    public const int INVERSE_STAT_DEPTH = 1 / STAT_DEPTH;
    public const int INVERSE_DAY_STAT_DEPTH = 1 / DAY_STAT_DEPTH;
    public const int INVERSE_MONTH_STAT_DEPTH = 1 / MONTH_STAT_DEPTH;
    public const int DAY_SPACE = 25;
    public const int MONTH_SPACE = 125;
    public const int DEFAULT_DEPTH = 3;

}