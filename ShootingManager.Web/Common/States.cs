using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;

namespace ShootingManager.Web.Common
{
        public class State
        {
            public string StateName { get; set; }
            public string Abbreviation { get; set; }

            public static IEnumerable<State> GetStates()
            {
                var result = new List<State>();
                string stateFile = "ShootingManager.Web.Resources.States.xml";
                Assembly assem = Assembly.GetExecutingAssembly();
                Stream strm = assem.GetManifestResourceStream(stateFile);

                XDocument states = XDocument.Load(strm);
                foreach (var st in states.Element("GeographicalUnits").Element("States").Elements())
                {
                    var s = new State();
                    s.StateName = st.Attribute("Name").Value;
                    s.Abbreviation = st.Attribute("PostalCode").Value;
                    result.Add(s);
                }
                foreach (var st in states.Element("GeographicalUnits").Element("Provinces").Elements())
                {
                    var s = new State();
                    s.StateName = st.Attribute("Name").Value;
                    s.Abbreviation = st.Attribute("PostalCode").Value;
                    result.Add(s);
                }

                return result;
            }
        }

}