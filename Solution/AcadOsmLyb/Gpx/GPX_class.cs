using System;

using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Text;

using F = System.Windows.Forms;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;




namespace AcadOsmLyb
{
    class GPX_class
    {

        public static List<string> myP_Ids = new List<string>();
        public static List<string> myW_Ids = new List<string>();
        static Document doc = Application.DocumentManager.MdiActiveDocument;
        static  Database db = doc.Database;
        static Editor ed = doc.Editor;
        static PromptEntityResult result;

        /// <summary>
        /// make a new id
        /// </summary>
        /// <returns> a new Id für die Bearbeitung </returns>
        /// Pfad, damit die Ids nicht doppelt werden!!!
        /// dto für erzeuge_W_ID
        static public string erzeuge_P_ID()
        {
           
           
            string id = "fb" + new Random().Next(1000000000, 1999999999);
            if (myP_Ids.Contains(id)) erzeuge_P_ID();
            else myP_Ids.Add(id);

            return id;

        }
        static public string erzeuge_W_ID()
        {


           
            string id = "f" + new Random().Next(1000000000, 1999999999) + "b";
            if (myW_Ids.Contains(id)) erzeuge_W_ID();
            else myW_Ids.Add(id);

            return id;
        }


        static public GpxSave_Form SaveAnzeige;
        public void GpxSave()
        {
            doc = Application.DocumentManager.MdiActiveDocument;

            // Prompt the user to select a polyline segment.
            PromptEntityOptions options =
                   new PromptEntityOptions("\nPick a 3DPolyline:");
            options.SetRejectMessage("Select 3DPolyline only" + "\n");
            options.AddAllowedClass(typeof(Polyline3d), true);
            PromptEntityResult _result = ed.GetEntity(options);
            result = _result;
            if (result.Status != PromptStatus.OK)
            {
                doc.Editor.WriteMessage("Nichts gewählt!!! \n please Select a polyline segment:}");
                return;
            }


            // If the selected entity is a polyline.
            if (result.ObjectId.ObjectClass.Name == "AcDb3dPolyline"|| result.ObjectId.ObjectClass.Name == "AcDb3dPolylineVertex")
            {

                F.Application.Run(SaveAnzeige = new GpxSave_Form());



            }
        }

        static Point3d[] points = new Point3d[] { };
        static Polyline3d pline = new Polyline3d();
        static string ID = "";
        static string Name = "";
        static string Art = "";
        // in dem Gpx schreiben
        static public void _save()
        {
            string Pfad = GpxSave_Form.p + ".gpx";
            if (File.Exists(Pfad))
            {
                FileStream fs = File.Open(Pfad, FileMode.Open);
                XmlTextReader reader = new XmlTextReader(fs);
                while (reader.Read())
                {

                    //lesen
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "Way")
                        {

                            myW_Ids.Add(reader.GetAttribute("W_id"));


                        }
                        if (reader.Name == "Nodes")
                        {
                            myP_Ids.Add(reader.GetAttribute("Id"));
                        }
                    }
                }
                reader.Close();
            }
          Name = GpxSave_Form.N;
          Art = GpxSave_Form.A;


            // Start a transaction to open the selected polyline.
            Transaction tr = db.TransactionManager.StartTransaction();

         
           // 
            Document doc = Application.DocumentManager.MdiActiveDocument;
            
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            // Open the polyline.
           
            try
            {
                
                pline = tr.GetObject(result.ObjectId, OpenMode.ForRead) as Polyline3d;
            }
            catch (System.Exception ex)
            {
                
                    ed.WriteMessage(ex.ToString());
                    goto Ende;
             
            }
            if (AcadZeichner.PolylineID.ContainsKey(pline.ObjectId))
                {
                    List<string> Liste = AcadZeichner.PolylineID[pline.ObjectId];
                    Liste.Add(ID=erzeuge_W_ID());
                    AcadZeichner.PolylineID.Remove(pline.ObjectId);
                    AcadZeichner.PolylineID.Add(pline.ObjectId, Liste);
                }
                else
                {
                    ID = erzeuge_W_ID();
                    AcadZeichner.PolylineID.Add(pline.ObjectId, new List<string>() {ID });
                }



            List<Point3d> p = new List<Point3d>();

            foreach (ObjectId item in pline)
            {
                PolylineVertex3d v3d =
                     (PolylineVertex3d)tr.GetObject(
                       item,
                       OpenMode.ForRead
                     );
                p.Add(v3d.Position);
            }
          points=  p.ToArray();
         

            if (!File.Exists(Pfad))
            {
                FileStream fs = File.Create(Pfad);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                //  settings.NewLineOnAttributes = true;
                settings.Encoding = Encoding.UTF8;
                
                XmlWriter wr = XmlWriter.Create(fs, settings);
                wr.WriteStartDocument(); //Schreiben in Document beginnen


                wr.WriteStartElement("gpx");
                wr.WriteStartElement("metadata");
                wr.WriteStartElement("Dataname");//Dateiname
                wr.WriteString(Pfad);
                wr.WriteEndElement();
                wr.WriteStartElement("desc");//description
                wr.WriteString("Datei für das Projekt OSM-AutoCAD");
                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteStartElement("wpt");//way
                //ID
                wr.WriteStartAttribute("W_id");
                ID = erzeuge_W_ID();
                myW_Ids.Add(ID);
                wr.WriteValue(ID);
                wr.WriteEndAttribute();
                //Typ
                wr.WriteStartElement("type");
                wr.WriteString(Art);
                wr.WriteEndElement();
                //Name
                wr.WriteStartElement("name");
                wr.WriteValue(Name);
                wr.WriteEndElement();
                //ID

                //Nodes

                foreach (Point3d P in points)
                {
                    wr.WriteStartElement("rtept");

                    wr.WriteStartAttribute("Id");
                    string Ip = erzeuge_P_ID();
                    myP_Ids.Add(Ip);
                    wr.WriteValue(Ip);
                    wr.WriteEndAttribute();

                    wr.WriteStartAttribute("lon");
                    wr.WriteValue(AcadZeichner.RechneToNode(P).Longitude.ToString());
                    wr.WriteEndAttribute();

                    wr.WriteStartAttribute("lat");
                    wr.WriteValue(AcadZeichner.RechneToNode(P).Latitude.ToString());
                    wr.WriteEndAttribute();

                    wr.WriteEndElement();
                    
                }
                //
                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteEndDocument();
                wr.Close();
                fs.Close();
            }


            else
            {

                XDocument docc = XDocument.Load(Pfad);
                XElement root = new XElement("wpt");
                ID = erzeuge_W_ID();
                myW_Ids.Add(ID);
                root.Add(new XAttribute("W_id", ID));

                root.Add(new XElement("type", Art));
                root.Add(new XElement("name", Name));

                //Nodes

                foreach (Point3d P in points)
                {
                    XElement noeuds = new XElement("rtept");
                    string Ip = erzeuge_P_ID();
                    myP_Ids.Add(Ip);
                    noeuds.Add(new XAttribute("Id", Ip));

                    noeuds.Add(new XAttribute("lon", AcadZeichner.RechneToNode(P).Longitude.ToString()));
                    noeuds.Add(new XAttribute("lat", AcadZeichner.RechneToNode(P).Latitude.ToString()));
                    root.Add(noeuds);

                }
                docc.Element("gpx").Add(root);
                docc.Save(Pfad);
                
            }
           pline= (Polyline3d)tr.GetObject(result.ObjectId, OpenMode.ForWrite) ;
            pline.Erase(true);
            AcadZeichner.Zum_anzeigen.Add(Art);
            AcadZeichner.Zeichne3D(new Way(points, ID, Name, Art));
            Ende:
            tr.Commit();

            SaveAnzeige.Close();

        }



        static public Gpx_Load LoadAnzeige;
        public void ReadGPX()
        {


            F.Application.Run(LoadAnzeige = new Gpx_Load());
            AcadZeichner.Lade = false;
        }

        internal static void _ReadGPX(object sender, EventArgs e)
        {



            XmlTextReader reader = new XmlTextReader(sender.ToString());

            string m_Art = "";
            string _Name = "";
            string W_id = "";
            string Id = "";
            double Long = 0.0;
            double Latt = 0.0;
            List<Point3d> lip = new List<Point3d>();
            #region Read Xml
            r: while (reader.Read())
            {

                //lesen
                if (reader.NodeType == XmlNodeType.Element)
                {


                    if (reader.Name == "type")
                    {
                        m_Art = reader.ReadInnerXml();
                    }
                    if (reader.Name == "name")
                    {
                        _Name = reader.ReadInnerXml();
                    }
                    if (reader.Name == "wpt")
                    {

                        W_id = reader.GetAttribute("W_id");


                    }


                    if (reader.Name == "rtept")
                    {
                        Id = reader.GetAttribute("Id");
                        /// ich muss noch hier umrechnen damit alles stimmt ich meine Dami die Entfernung mit den AutoCAD coodinaten
                        Long = double.Parse(reader.GetAttribute("lon"));
                        Latt = double.Parse(reader.GetAttribute("lat"));

                        lip.Add(AcadZeichner.RechneToPoint3d(new Node(Long, Latt, Id)));



                        goto r;
                    }

                }
                if (reader.NodeType == XmlNodeType.EndElement && lip.Count > 1                     )
                {
                    if (!AcadZeichner.geloescht.Contains(W_id) && Anzeige_Manager.Zum_anzeigen.Contains(m_Art))
                    {


                        Point3d[] P = new Point3d[lip.Count];
                        for (int i = 0; i < lip.Count; i++)
                        {
                            P[i] = lip[i];
                        }

                          

                        AcadZeichner.Zeichne3D(new Way(P, W_id, _Name, m_Art));
                    }
                    lip.Clear();

                }




            }          //while end  
            #endregion

            reader.Close();


        }
        

    }

  
}
