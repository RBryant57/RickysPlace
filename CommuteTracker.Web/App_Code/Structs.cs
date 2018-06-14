using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Structs
/// </summary>
public static class Structs
{

    [Serializable]
    public struct Commute
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public int Destination;
        public int Delay;
        public int DelaySeconds;
        public int FareClass;
        public int Route;
        public int CommuteId;
        public string Notes;
    }

    [Serializable]
    public struct PassCondition
    {
        public DateTime Date;
        public int Time;
        public int Minutes;
        public int UsualMinutes;
        public int Delay;
        public int Route;
        public string Notes;
    }

}