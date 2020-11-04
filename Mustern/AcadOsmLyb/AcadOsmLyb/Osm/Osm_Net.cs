
using System.Collections.Generic;

using System.Net.Http;



namespace AcadOsmLyb
{
    class Osm_Net
    {


        static double Maxlat = 0;
        static double Minlat = 0;
        static double Maxlon = 0;
        static double Minlon = 0;

        //erzeuge ein Url mit einen Bundary
        static public string erzeugeURL(Node N)
        {

            Maxlat = N.Latitude + 0.007;
            Minlat = N.Latitude - 0.007;


            Maxlon = N.Longitude + 0.007;
            Minlon = N.Longitude - 0.007;

            return "http://api.openstreetmap.org/api/0.6/map?bbox=" + (Minlon.ToString()).Replace(",", ".") + "," + (Minlat.ToString()).Replace(",", ".") + "," + (Maxlon.ToString()).Replace(",", ".") + "," + (Maxlat.ToString()).Replace(",", ".");
        }
        // Das File herunterladen
        static public void ToFile(string url, string localFile)
        {
            var client = new HttpClient();
            var content = (StreamContent)client.GetAsync(url).Result.Content;
            using (var output = System.IO.File.Create(localFile))
            {
                content.ReadAsStreamAsync().Result.CopyTo(output);
                output.Close();
            }
        }
        static List<Node> Nodelist = new List<Node>();

        //berechne die dazu nötigen Bondarys
        static public List<Node> RechneDaten(Node N, double Umfang)
        {
            Nodelist.Clear();
            double Lon2minus = N.Longitude;
            double Lon2Plus = N.Longitude;
            double Lat_P = N.Latitude;
            double Lat_M = N.Latitude;


            
            while (AcadZeichner.Calc_Node_Distance(N, new Node(Lon2minus, Lat_P, "")) < Umfang)
            {
                int i = 0;

                while (AcadZeichner.Calc_Node_Distance(N, new Node(Lon2minus, Lat_P, "")) < Umfang)
                {


                    if (i != 0)
                    {
                        Lat_P += 0.014;
                        Lat_M -= 0.014;
                        if (Lon2Plus != Lon2minus)
                        {
                            Nodelist.Add(new Node(Lon2Plus, Lat_P, ""));
                            Nodelist.Add(new Node(Lon2Plus, Lat_M, ""));
                        }


                        Nodelist.Add(new Node(Lon2minus, Lat_P, ""));
                    }

                   
                    if (Lon2Plus != Lon2minus && i==0)
                    {
                        Nodelist.Add(new Node(Lon2Plus, Lat_P, ""));
                    }

                    Nodelist.Add(new Node(Lon2minus, Lat_M, ""));
                    i = 1;
                }
                if (Lon2Plus != Lon2minus)
                {
                    Nodelist.Add(new Node(Lon2Plus, Lat_P, ""));
                    Nodelist.Add(new Node(Lon2minus, Lat_M, ""));
                }
                Lon2Plus += 0.014;
                Lon2minus -= 0.014;
                Lat_P = N.Latitude;
                Lat_M = N.Latitude;

            }
            
            return Nodelist;
        }

    }
}
