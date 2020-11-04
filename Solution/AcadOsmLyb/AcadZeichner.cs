




using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;



using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;







/// <summary>
/// von aussen
/// </summary>



namespace AcadOsmLyb
{
    //mein Way bei der Zeichnung



    public class AcadZeichner
    {
        #region Kommandos
        public static void zoom()
        {
            //using InvokeMember to support .NET 3.5
            Object acadObject = Application.AcadApplication;
            acadObject.GetType().InvokeMember("ZoomExtents",
                        BindingFlags.InvokeMethod, null, acadObject, null);
        }
        [CommandMethod("OSMload")]
        public void OSMload_()
        {

            Reactor();
            OsmLayer();
            OSM_Read.ReadOsm();
            zoom();
        }

        [CommandMethod("Distance_Way")]
        public void Distance_Way_()
        {
            Reactor();
            PromptEntityResult result;
           // doc = Application.DocumentManager.MdiActiveDocument;

            // Prompt the user to select a polyline segment.
            PromptEntityOptions options =
                   new PromptEntityOptions("\nPick a Way:");
            options.SetRejectMessage("Select Way only" + "\n");
            options.AddAllowedClass(typeof(Polyline3d), true);
            PromptEntityResult _result = ed.GetEntity(options);
            result = _result;
            if (result.Status != PromptStatus.OK)
            {
                doc.Editor.WriteMessage("Nichts gewählt!!! \n please Select a Way :}");
                return;
            }


            // If the selected entity is a polyline.
            if (result.ObjectId.ObjectClass.Name == "AcDb3dPolyline" || result.ObjectId.ObjectClass.Name == "AcDb3dPolylineVertex")
            {
                Transaction tr = db.TransactionManager.StartTransaction();
                Polyline3d pline = tr.GetObject(result.ObjectId, OpenMode.ForRead) as Polyline3d;
                ed.WriteMessage("\nDie Entfernung ist von " + Calc_Point_Distance(pline.StartPoint, pline.EndPoint) + " Km");
                tr.Commit();
            }
        }

        [CommandMethod("Gpxload")]
        public void Gpxload_()
        {
            Reactor();
            OsmLayer();
            new GPX_class().ReadGPX();
            zoom();
        }



        [CommandMethod("Gpxsave")]

        public void Gpxsave_()
        {
            Reactor();
            OsmLayer();
            doc.CommandWillStart += doc_CommandWillStart;
            new GPX_class().GpxSave();
             
        }

        public static Cache_Manager Cache;

        [CommandMethod("GPXRestore")]
        public void GPXRestore_()
        {

            System.Windows.Forms.Application.Run(Cache = new Cache_Manager());
        }
        [CommandMethod("Distance_2Points")]
        public void Distance_2Points_()
        {
            
            Reactor();
            PromptPointResult pPtRes;
            PromptPointOptions pPtOpts = new PromptPointOptions("");

            // Prompt für der startpoint
            pPtOpts.Message = "\nEnter the start point";
            pPtRes = doc.Editor.GetPoint(pPtOpts);
            Point3d ptStart = pPtRes.Value;

            // Exit wenn esc
            if (pPtRes.Status == PromptStatus.Cancel) return;

            // Prompt für der Endpoint
            pPtOpts.Message = "\nEnter the end point ";
            pPtOpts.UseBasePoint = true;
            pPtOpts.BasePoint = ptStart;
            pPtRes = doc.Editor.GetPoint(pPtOpts);
            Point3d ptEnd = pPtRes.Value;

            ed.WriteMessage("\nDie Entfernung ist von " + Calc_Point_Distance(ptStart, ptEnd) + " Km");
        }
       

       

      

        #endregion


        // const double R_lat = 6378.1370;//???? werde ich das brauchen? ich guke mir das noch mal an
        static double R_lon = 6356.7523;
        // Priorität von Wege in Autocad
        static public Dictionary<string, short> priori;
        // Autocad Id und mm_Id koppeln
        static public Dictionary<ObjectId, List<string>> PolylineID;
        static public List<string> geloescht;
        static public List<string> New_geloescht;


        public static Document doc;
        public static Database db;
        public static Editor ed;
        
         
        static  LayerTableRecord mm_ltr;      
       

        //bestimmt ob wir gerade beim laden oder beim Bearbeiten sind...
        static public bool Lade;

        static double Deg2RadFactor = Math.PI / 180;
        static double Rad2DegFactor = (180 / Math.PI);

        //rechne ein Koodinatenpunnk in Ein Punkt in Autocad
        static public Point3d RechneToPoint3d(Node N)
        {
            double X;
            double Y;
            double Z;
            X= R_lon * Math.Cos(N.Longitude * Deg2RadFactor) * Math.Cos(N.Latitude * Deg2RadFactor);
            Y = R_lon * Math.Sin(N.Longitude * Deg2RadFactor) * Math.Cos(N.Latitude * Deg2RadFactor);
            Z = R_lon * Math.Sin(N.Latitude * Deg2RadFactor);
            return new Point3d(X, Y, Z);
        }

        //erzeug von einem Punkt in Autocag ein zugehöriger Node
        static public Node RechneToNode(Point3d P)
        {

           
            double lon = 0;
            if (P.X> 0)
            {
                lon = Math.Atan(P.Y / P.X) * Rad2DegFactor;
            }
            else if (P.X == 0)
            {
                lon = Math.Sign(P.Y) * Rad2DegFactor * Math.PI / 2;
            }
            else if (P.X < 0 && P.Y >= 0)
            {
                lon = (Math.Atan(P.Y / P.X) + Math.PI) * Rad2DegFactor;
            }
            else if (P.X< 0 && P.Y < 0)
            {
                lon =( Math.Atan(P.Y / P.X) - Math.PI) * Rad2DegFactor;
            }
             double lat = Math.Acos(P.X /( R_lon*Math.Cos(lon* Deg2RadFactor))) / Deg2RadFactor;
          
         
            return new Node(lon, lat, GPX_class.erzeuge_P_ID());
        }
        //Berechne die Entfernung in Km von zwei Punkte
        static public double Calc_Point_Distance(Point3d p1, Point3d p2)
        {
            double lat1 = GetRAD(RechneToNode(p1).Latitude);
            double lat2 = GetRAD(RechneToNode(p2).Latitude);

            double lon1 = GetRAD(RechneToNode(p1).Longitude);
            double lon2 = GetRAD(RechneToNode(p2).Longitude);

            return R_lon * Math.Acos(
                Math.Sin(lat1) * Math.Sin(lat2) +
                Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1));
        }
        //Berechne die Entfernung in Km von zwei Node
        public static double Calc_Node_Distance(Node N1, Node N2)
        {
            double lat1 = GetRAD(N1.Latitude);
            double lat2 = GetRAD(N2.Latitude);

            double lon1 = GetRAD(N1.Longitude);
            double lon2 = GetRAD(N2.Longitude);

            return AcadZeichner.R_lon * Math.Acos(
                Math.Sin(lat1) * Math.Sin(lat2) +
                Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1));
        }
        private static double GetRAD(double deg)
        {
            return deg / 180.0 * Math.PI;
        }
        private static double GetDEG(double rad)
        {
            return rad * 180.0 / Math.PI;
        }
        // eine Liste von alle >Punkte, die gezeichnet worden sind
        static public List<Node> MeinNodesliste = new List<Node>();
        

        // eine Listen von element die eingezeigt werden
        public static List<string> Zum_anzeigen = new List<string>();

        // Liste der Linnien, die gezeichnet worden sind
        static public List<string> BereitsDa;

        // Hauptfunktion, die alle Way in Autocad Zeichnet
        static public void Zeichne3D(Way mm_Way)
        {
          
            if (!geloescht.Contains(mm_Way.Way_ID) &&!BereitsDa.Contains(mm_Way.Way_ID)
                && Zum_anzeigen.Contains(mm_Way.Art_.ToString()))
            {

                Transaction tr = db.TransactionManager.StartTransaction();


                using ( tr)
                    {
                        BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead, false);
                        BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite, false);
                        Point3dCollection points = new Point3dCollection(mm_Way.Nodes);
                        Polyline3d poly = new Polyline3d(Poly3dType.SimplePoly, points, false);



                        btr.AppendEntity(poly);

                    tr.AddNewlyCreatedDBObject(poly, true);

                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    try
                        {
                            if (lt.Has(mm_Way.Art_) && priori.ContainsKey(mm_Way.Art_.ToString()))
                            {
                                poly.ColorIndex = priori[mm_Way.Art_];

                            }
                            else
                            {
                                ed.WriteMessage("\nLayer not found in current drawing.");
                                poly.ColorIndex = priori[Way.WayArt[Way.WayArt.Count - 1]]; // way's name "Oder"
                            }
                        }
                        finally
                        {


                            try
                            {

                                List<string> Liste = AcadZeichner.PolylineID[poly.ObjectId];
                                Liste.Add(mm_Way.Way_ID);
                                PolylineID.Remove(poly.ObjectId);
                                PolylineID.Add(poly.ObjectId, Liste);
                            }
                            catch (System.Exception)
                            {

                                AcadZeichner.PolylineID.Add(poly.ObjectId, new List<string>() { mm_Way.Way_ID });

                            }

                        tr.Commit();
                        }

                    }
                // wenn die Linie schon gezeichnet worden ist dann...
                BereitsDa.Add(mm_Way.Way_ID);
                tr.Dispose();

                }
            }
        // Erzeug layer von Priotitaet
        static public void OsmLayer()
        {

            // ich bekomme hier eine Liste/Array von Prio mit der ich arbeiten kann...
            // standartmäßig vergebe ich hier einige Waysarten


            Dictionary<string, short> prioritaet = new Dictionary<string, short>() {

                { "building", 245},
                { "railway", 120 },
                { "highway", 21},
                { "footway", 12 },
                { "living_street", 255 },
                { "waterway", 140 },
                { "cycleway", 170 },
                { "Oder", 33 } };

            

            priori = prioritaet;


           
            Transaction trans;
            LayerTableRecord mm_ltr;
            LayerTable mm_ltbl;
            foreach (KeyValuePair<string, short> item in prioritaet)
            {
                trans = db.TransactionManager.StartTransaction();
                mm_ltbl = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForWrite);

                try
                {


                    //Wenn der Zugriff auf den Layer fehlschlägt, in catch neuen Layer
                    if (!mm_ltbl.Has(item.Key))
                    {
                        mm_ltr = new LayerTableRecord();
                        mm_ltr.Name = item.Key;
                        try
                        {

                            // mm_ltr.Color = Autodesk.AutoCAD.Colors.Color.FromRgb(255, 0, 0);
                            mm_ltr.Color = Autodesk.AutoCAD.Colors.Color.FromColorIndex(Autodesk.AutoCAD.Colors.ColorMethod.ByAci, item.Value);
                            //LTR zum Layertable hinzufügen...
                            mm_ltbl.Add(mm_ltr);
                            //LTR zur Transkation hinzufügen...
                            trans.AddNewlyCreatedDBObject(mm_ltr, true);

                            trans.Commit();
                        }
                        catch (SystemException)
                        {

                        }
                    }
                }
                finally
                {

                    trans.Dispose();

                }
            }
            


        }

        private static ObjectIdCollection _ids =
          new ObjectIdCollection();
        private static Point3dCollection _pts =
          new Point3dCollection();
       
        // setz die Componente Bereit
        static public void Reactor()


        {
            AcadZeichner.Lade = true;

            doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            db = doc.Database;
            ed = doc.Editor;
         
            
            mm_ltr = new LayerTableRecord();

           
            if (!File.Exists("geloescht.txt")) File.Create("geloescht.txt");
            geloescht = new List<string>(File.ReadAllLines("geloescht.txt"));
            New_geloescht = new List<string>();
            doc.CommandWillStart +=
              new CommandEventHandler(doc_CommandWillStart);
       
            try
            {
                int a = AcadZeichner.BereitsDa.Count;
                int i = AcadZeichner.PolylineID.Count;
            }
            catch (System.Exception)
            {
                AcadZeichner.BereitsDa = new List<string>();
                AcadZeichner.PolylineID = new Dictionary<ObjectId, List<string>>();
            }


        }


        // verbergende elemente der Funktion delete_Way wieder freigeben
        public static void loeschen()
        {
            File.AppendAllLines("geloescht.txt", New_geloescht);
            geloescht = new List<string>(File.ReadAllLines("geloescht.txt"));
        }

        static void doc_CommandWillStart(object sender, CommandEventArgs e)
        {


            if (e.GlobalCommandName == "ERASE" || e.GlobalCommandName == "DROPGEOM"
                || e.GlobalCommandName == "GRIP_STRETCH")
            {
               

                doc.Database.ObjectOpenedForModify += new ObjectEventHandler(delete_Way);

            }

        }
        /// <summary>
        /// wenn ein Way geschoben oder gelöscht wird...
        /// element in der Liste der zu verbergende Elemente hinzufügen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         
        static void delete_Way(object sender, ObjectEventArgs e)
        {
            if (!Lade)
            {


                try
                {
                    Polyline3d pline = e.DBObject as Polyline3d;



                    if (!pline.Id.IsNull)
                    {

                        foreach (var item in PolylineID[pline.Id])
                        {
                            if (!geloescht.Contains(item) && !New_geloescht.Contains(item))
                            {
                                New_geloescht.Add(item);
                            }
                        }
                        if (New_geloescht.Count > 0)

                        {
                            loeschen();
                            New_geloescht.Clear();
                            ed.WriteMessage("Die Änderungen müssen gespeichert werden");
                        }
                    }

                }
                catch (System.Exception)
                {

                }


            }
        }
    }


}