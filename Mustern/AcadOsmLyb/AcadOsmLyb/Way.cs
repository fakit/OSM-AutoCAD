using System.Collections.Generic;
using Autodesk.AutoCAD.Geometry;




namespace AcadOsmLyb
{
    public class Way
    {
        static public List<string> WayArt = new List<string> { "Building", "railway", "highway", "footway", "living_street", "waterway", "Oder" };
         Point3d[] Nods;
        // geben Sie für jede Straße einen Namen und eine Prioritaet
        string Name = null;
        string Art;
        Point3d AnP;
        Point3d EndP;
        string WayID;
         Node[] InterNodes;
       
        public Way(Node[] ArrayOf_Nodes, string WayID, string Name, string Art)
        {
            List<Point3d> lip = new List<Point3d>();
            foreach (var item in ArrayOf_Nodes)
            {
                lip.Add(AcadZeichner.RechneToPoint3d(item));
            }
            Nods = lip.ToArray();
           this.Name = Name;
            this.Art = Art;
            AnP = Nods[0];
            EndP = Nods[Nods.Length - 1];
            this.WayID = WayID;
        }
        public Way(Node[] ArrayOf_Nodes, string Osm_WayID, string Name, string Art, string Seize)
        {
            this.InterNodes = ArrayOf_Nodes;
            this.WayID = Osm_WayID;
            this.Art = Art;
            this.Name = Name;
        }
        public Way() { }
        public Way(object ArrayOf_Point3d, string WayID, string Name, string Art)
        {
            try
            {
                Nods = (Point3d[])ArrayOf_Point3d;
            }
            catch (System.Exception)
            {


            }

            this.Name = Name;
            this.Art = Art;
            AnP = Nods[0];
            EndP = Nods[Nods.Length - 1];
            this.WayID = WayID;
        }
        #region Propertys
        public string Name_
        {
            get { return this.Name; }
            set { Name = value; }
        }
        public string Art_
        {
            get { return this.Art; }
            set { Art = value; }
        }
        public Point3d AnfangsPunkt
        {
            get { return AnP; }
            set { AnP = value; }
        }
        public Point3d EndPunkt
        {
            get { return EndP; }
            set { EndP = value; }
        }
        public string Way_ID
        {
            get { return WayID; }
            set { WayID = value; }
        }
        public Point3d[] Nodes
        {
            get { return Nods; }
            set { Nods = value; }//???
        }
        public Node[] Osm_Nodes
        {
            get { return InterNodes; }
            set { InterNodes = value; }//???
        }
        #endregion

    }

}

