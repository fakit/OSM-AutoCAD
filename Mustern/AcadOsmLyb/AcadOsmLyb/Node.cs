using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOsmLyb
{
    public class Node
    {
        double lon;
        double lat;
        string Id;
        public Node() { }
        public Node(double lon, double lat, string Id)
        {
            this.lon = lon;
            this.lat = lat;
            this.Id = Id;
        }
        public double Longitude
        {
            get { return lon; }
        }
        public double Latitude
        {
            get { return lat; }
        }
        public string _ID
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
