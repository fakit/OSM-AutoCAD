using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsmSharp;

namespace Testprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            System.IO.Stream stream = System.IO.File.OpenRead(@"C:\Users\Maxim\Downloads\europe-latest.osm.pbf");
            OsmSharp.Osm.PBF.Streams.PBFOsmStreamSource source = new OsmSharp.Osm.PBF.Streams.PBFOsmStreamSource(stream);
            var filtered = from osmGeo in source where osmGeo.Type == OsmSharp.Osm.OsmGeoType.Node select osmGeo;
            Console.WriteLine(DateTime.Now);
            Console.ReadLine();
        }
    }
}
