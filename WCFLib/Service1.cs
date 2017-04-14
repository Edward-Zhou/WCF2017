using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public Station[] LoadStationsArray()
        {
            Station[] list =new Station[3];
            Station s1 = new Station() { StationId = 1, City = "C1", Type = "T1" };
            Station s2 = new Station() { StationId = 2, City = "C2", Type = "T2" };
            Station s3 = new Station() { StationId = 3, City = "C3", Type = "T3" };
            List<Station> Stations = new List<Station>();
            Stations.Add(s1);
            Stations.Add(s2);
            Stations.Add(s3);
            list[0] = s1;
            list[1] = s1;
            list[2] = s1;
            return list;
        }
        public List<Station> LoadStations()
        {
            List<Station> list = new List<Station>();
            Station s1 = new Station() { StationId=1, City="C1", Type="T1" };
            Station s2 = new Station() { StationId = 2, City = "C2", Type = "T2" };
            Station s3 = new Station() { StationId = 3, City = "C3", Type = "T3" };
            List<Station> Stations = new List<Station>();
            Stations.Add(s1);
            Stations.Add(s2);
            Stations.Add(s3);
            list.AddRange(Stations);
            return list;
            //using (var context = new RailwaySystemModelContainer())
            //{
            //    /*foreach (var station in context.Stations)
            //        list.Add(station);*/
            //    list.AddRange(context.Stations);
            //    return list;
            //}
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
