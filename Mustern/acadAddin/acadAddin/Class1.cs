using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;


namespace acadAddin
{
    public class Class1
    {
        [CommandMethod("HelloWorld")]
        public void HelloWorld()
        {
            Editor mm_aced = AcadApp.DocumentManager.MdiActiveDocument.Editor;
            mm_aced.WriteMessage("Hallo Welt, es tut!");
        }

        #region asdasd

        [CommandMethod("crl")]
        public void CreateLayer()
        {

            string abc = "x y z";
            string[] sstr = abc.Split('\t');
            Database dwg = AcadApp.DocumentManager.MdiActiveDocument.Database;

            //dwg ist eine Database einer AutoCAD-Datei
            Transaction trans = dwg.TransactionManager.StartTransaction();
            try
            {
                LayerTableRecord mm_ltr = null;
                LayerTable mm_ltbl = null;
                mm_ltbl = (LayerTable)trans.GetObject(dwg.LayerTableId, OpenMode.ForWrite);
                //Wenn der Zugriff auf den Layer fehlschlägt, in catch neuen Layer
                if (!mm_ltbl.Has("Paule"))
                {
                    mm_ltr = new LayerTableRecord();
                    mm_ltr.Name = "Paule";

                    Autodesk.AutoCAD.Colors.Color col = mm_ltr.Color;
                    col = Autodesk.AutoCAD.Colors.Color.FromColorIndex(Autodesk.AutoCAD.Colors.ColorMethod.ByAci, 3);
                    mm_ltr.Color = col;
                    //LTR zum Layertable hinzufügen...
                    mm_ltbl.Add(mm_ltr);
                    //LTR zur Transkation hinzufügen...
                    trans.AddNewlyCreatedDBObject(mm_ltr, true);

                    trans.Commit();
                }
            }
            finally
            {
                trans.Dispose();
            }
        }
        #endregion

    }
}
