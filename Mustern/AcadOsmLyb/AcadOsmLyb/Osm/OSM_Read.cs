using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;



namespace AcadOsmLyb
{
    class OSM_Read
    {
        static public System.IO.StreamReader stream;

        static public OSM_Load LoadAnzeige;
        static public void ReadOsm()
        {


            System.Windows.Forms.Application.Run(LoadAnzeige = new OSM_Load());
            AcadZeichner.Lade = false;
        }

        static public void Load_Map_OSM()
        {


            if (OSM_Load.Pfad.Length < 3)
            {
                try
                {
                    Node N = new Node(Osm_Manager.lon, Osm_Manager.lat, "");
                    List<Node> Positions = Osm_Net.RechneDaten(N, Osm_Manager.Umf);
                    int i = Positions.Count;
                    for (int j = 0; j < i; j++)
                    {
                        string Name = "Ort_Nr_" + j + "%" + i + ".osm";

                        Osm_Net.ToFile(Osm_Net.erzeugeURL(Positions[j]), Name);
                        OSM_Load.Pfad = Name;
                        Load_Osm();
                        File.Delete(Name);
                        double Prozentage = 100 * j / i;
                        AcadZeichner.ed.WriteMessage("Loading... " + (int)Prozentage + " / 100");
                    }

                }
                catch (Exception)
                {

                    return;
                }

            }
            else
            {
                if (OSM_Load.Pfad.EndsWith(".pbf")) Load_Pbf();
                else Load_Osm();
            }
        }
        // falls wir ein Pbf File laden wollen
        static public void Load_Pbf()
        {
            List<Way> LW = new List<Way>();

            Dictionary<string, string> D = new Dictionary<string, string>
#region Elemente in Dictinary
            {{ "motorway","highway" },
             { "trunk" ,"highway"},
             { "primary" ,"highway"},
             { "secondary" ,"highway"},
             { "tertiary" ,"highway"},
             { "unclassified" ,"highway"},
             { "residential" ,"highway"},
             { "service" ,"highway"},
             { "footway" ,"highway"},
             { "lane" ,"cycleway"},
             { "opposite" ,"cycleway"},
             { "track" ,"cycleway"},
             { "river" ,"waterway"},
             { "riverbank" ,"waterway"},
             { "stream" ,"waterway"},
             { "canal" ,"waterway"},
             { "dock" ,"waterway"},
             { "construction" ,"railway"},
             { "disused" ,"railway"},
             { "light_rail" ,"railway"},
             { "narrow_gauge" ,"railway"},
             { "rail" ,"railway"},
             { "subway" ,"railway"},
             { "tram" ,"railway"}};
            #endregion 
            OSM_Reader r = new OSM_Reader(OSM_Load.Pfad,D );


            foreach (var Prio in r.tagWayNodes)
            {


                if (Prio.Value != null)
                {
                    try
                    {


                        foreach (OsmSharp.Complete.CompleteWay item in Prio.Value)
                        {

                            List<Node> LN = new List<Node>();
                            foreach (OsmSharp.Node N_ in item.Nodes)
                            {
                                Node n = new Node((double)N_.Longitude, (double)N_.Latitude, N_.Id.ToString());
                                LN.Add(n);
                            }
                            AcadZeichner.Zeichne3D(new Way(LN.ToArray(), item.Id.ToString(), "", Prio.Key.Value));
                        }
                    }
                    catch (Exception)
                    {


                    }
                }
            }

            AcadZeichner.ed.WriteMessage("Ende__Ende__Ende");
        }

        // im casse einer Osm file
        static public void Load_Osm()
        {
            List<AcadOsmLyb.Node> NodeList = new List<AcadOsmLyb.Node>();
            try
            {

                XmlSerializer XmlS = new XmlSerializer(typeof(osm));

                stream = new StreamReader(OSM_Load.Pfad);
                osm my_Ways = (osm)XmlS.Deserialize(stream);
                stream.Close();
                Dictionary<string, double[]> di = new Dictionary<string, double[]>();
                foreach (var item in my_Ways.node)
                {
                    double[] Coordinaten = new double[3];
                    Coordinaten[0] = item.lon;
                    Coordinaten[1] = item.lat;
                    Coordinaten[2] = item.id;
                    di.Add(item.id.ToString(), Coordinaten);
                }




                foreach (var item in my_Ways.way)
                {
                    foreach (var _nd in item.nd)
                    {
                        double[] Coord = new double[2];
                        di.TryGetValue(_nd.@ref.ToString(), out Coord);
                        AcadOsmLyb.Node N = new AcadOsmLyb.Node(Coord[0], Coord[1], _nd.@ref.ToString());
                        NodeList.Add(N);
                    }
                    AcadOsmLyb.Way mm_way = new AcadOsmLyb.Way();
                    try
                    {
                        mm_way = new AcadOsmLyb.Way(NodeList.ToArray(), item.id.ToString(), item.tag[0].k, item.tag[0].k);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            mm_way = new AcadOsmLyb.Way(NodeList.ToArray(), item.id.ToString(), "", item.tag[0].v);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                mm_way = new AcadOsmLyb.Way(NodeList.ToArray(), item.id.ToString(), item.tag[0].k, "Oder");
                            }
                            catch (Exception)
                            {

                                mm_way = new AcadOsmLyb.Way(NodeList.ToArray(), item.id.ToString(), "kein", "Oder");
                            }

                        }

                    }


                    AcadOsmLyb.AcadZeichner.Zeichne3D(mm_way);

                    NodeList.Clear();

                }


            }
            catch (Exception)
            {

                NodeList.Clear();
                return;
            }
        }

    }
}
