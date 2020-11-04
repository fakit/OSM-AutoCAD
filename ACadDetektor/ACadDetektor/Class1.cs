using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;

namespace ACadDetektor
{
    public class PanReactor
    {
        private static Document _doc =

              Application.DocumentManager.MdiActiveDocument;

        private static ViewTableRecord initial;

        [CommandMethod("REACTOR")]

        static public void Reactor()

        { 
            _doc =

              Application.DocumentManager.MdiActiveDocument;

            initial = _doc.Editor.GetCurrentView();

            _doc.CommandWillStart += new CommandEventHandler(_docCommandWillStart);

        }

        static void _docCommandWillStart(object sender, CommandEventArgs e)
        {
            if (e.GlobalCommandName == "PAN")
            {
                _doc.CommandCancelled += new CommandEventHandler(_docCommandEndedPan);
                _doc.CommandFailed += new CommandEventHandler(_docCommandEndedPan);
                _doc.CommandEnded += new CommandEventHandler(_docCommandEndedPan);
            }

            if (e.GlobalCommandName == "ZOOM")
            {
                _doc.CommandCancelled += new CommandEventHandler(_docCommandEndedZoom);
                _doc.CommandFailed += new CommandEventHandler(_docCommandEndedZoom);
                _doc.CommandEnded += new CommandEventHandler(_docCommandEndedZoom);
            }
        }

        static void _docCommandEndedPan(object sender, CommandEventArgs e)
        {
            panToOrbit();
            removeEventHandlersPan();
        }

        static void _docCommandEndedZoom(object sender, CommandEventArgs e)
        {
            checkZoom(1.4141,15,60);
            removeEventHandlersZoom();
        }

        static void removeEventHandlersPan()
        {
            _doc.CommandCancelled -= new CommandEventHandler(_docCommandEndedPan);
            _doc.CommandFailed -= new CommandEventHandler(_docCommandEndedPan);
            _doc.CommandEnded -= new CommandEventHandler(_docCommandEndedPan);
        }

        static void removeEventHandlersZoom()
        {
            _doc.CommandCancelled -= new CommandEventHandler(_docCommandEndedZoom);
            _doc.CommandFailed -= new CommandEventHandler(_docCommandEndedZoom);
            _doc.CommandEnded -= new CommandEventHandler(_docCommandEndedZoom);
        }
        static void panToOrbit()
        {
            try
            {
                ViewTableRecord curView = _doc.Editor.GetCurrentView();
                Vector2d panVector = new Vector2d(curView.CenterPoint.X, curView.CenterPoint.Y);

                Point3d viewCenter = (Point3d)Application.GetSystemVariable("VIEWCTR");
                viewCenter = viewCenter.TransformBy(_doc.Editor.CurrentUserCoordinateSystem);

                Matrix3d matDcsToWcs = Matrix3d.PlaneToWorld(curView.ViewDirection)
                                                .PreMultiplyBy(Matrix3d.Displacement(viewCenter - Point3d.Origin))
                                                .PreMultiplyBy(Matrix3d.Rotation(-curView.ViewTwist, curView.ViewDirection, viewCenter));
                Vector3d wcsPanVector = new Vector3d(viewCenter.X, viewCenter.Y, viewCenter.Z);

                Vector3d orbitAxis = wcsPanVector.CrossProduct(curView.ViewDirection);
                _doc.Editor.SetCurrentView(initial);

                Orbit(orbitAxis,
                      lengthToAngle(wcsPanVector.Length,Math.Sqrt(
                                                        Math.Pow(curView.Width,2)+ Math.Pow(curView.Height, 2)
                                                        )
                                   )
                     );
                    initial = _doc.Editor.GetCurrentView();
            }
            catch
            {

            }
        }

        static void checkZoom(double zoom1, double zoom2,double zoom3)
        {
            ViewTableRecord curView = _doc.Editor.GetCurrentView();

            using (var tr = _doc.Database.TransactionManager.StartTransaction())

            {

                var lt = (LayerTable)tr.GetObject(_doc.Database.LayerTableId, OpenMode.ForRead);

                if (curView.Width < zoom1) //Zoomstufe 1: Am weitesten hereingezoomt (Alles sichtbar)
                {
                    foreach(var ltrId in lt)
                    {
                        if (ltrId != _doc.Database.Clayer &&  ltrId != _doc.Database.LayerZero)
                        {

                            var ltr = (LayerTableRecord)tr.GetObject(ltrId, OpenMode.ForWrite);

                            ltr.IsFrozen = false;
                            ltr.IsLocked = false;

                            ltr.IsOff = ltr.IsOff; 

                        }
                    }
                }
                else if (curView.Width < zoom2) //Zoomstufe 2: Ein weing herausgezoomt (Alles bis auf Gebaeude sichtbar sichtbar)
                {
                    foreach (var ltrId in lt)
                    {
                        var ltr = (LayerTableRecord)tr.GetObject(ltrId, OpenMode.ForWrite);
                        if (ltrId != _doc.Database.Clayer && ltrId != _doc.Database.LayerZero && ltr.Name == "building" )
                        {

                            ltr.IsFrozen = true;
                            ltr.IsLocked = true;

                            ltr.IsOff = ltr.IsOff;

                        }
                        else
                        {
                            ltr.IsFrozen = false;
                            ltr.IsLocked = false;

                            ltr.IsOff = ltr.IsOff;
                        }
                    }
                }
                else if (curView.Width < zoom3)//Zoomstufe 3: Weit herausgezoomt (Nur Autobahnen, Fluesse, Oder sichtbar)
                {
                    foreach (var ltrId in lt)
                    {
                        var ltr = (LayerTableRecord)tr.GetObject(ltrId, OpenMode.ForWrite);
                        if (ltrId != _doc.Database.Clayer && ltrId != _doc.Database.LayerZero && !(ltr.Name == "Oder" || ltr.Name == "waterway" || ltr.Name == "highway"))
                        {

                            ltr.IsFrozen = true;
                            ltr.IsLocked = true;

                            ltr.IsOff = ltr.IsOff;

                        }
                        else
                        {
                            ltr.IsFrozen = false;
                            ltr.IsLocked = false;

                            ltr.IsOff = ltr.IsOff;
                        }
                    }
                }
                else //Zoomstufe 4: Am weitesten Herausgezoomt (Nur Oder sichtbar)
                {
                    foreach (var ltrId in lt)
                    {
                        var ltr = (LayerTableRecord)tr.GetObject(ltrId, OpenMode.ForWrite);
                        if (ltrId != _doc.Database.Clayer && ltrId != _doc.Database.LayerZero && !(ltr.Name =="Oder")
                            )
                        {

                            ltr.IsFrozen = true;
                            ltr.IsLocked = true;

                            ltr.IsOff = ltr.IsOff;

                        }

                    }
                }

                tr.Commit();

            }

            _doc.Editor.ApplyCurDwgLayerTableChanges();

            _doc.Editor.Regen();

        }

        static double lengthToAngle(double length, double referenceLength)
        {
            double angle;
            return angle = length * 2 * Math.PI / referenceLength;
        }


        static public void Orbit(Vector3d axis, double angle)

        {

            // Adjust the ViewTableRecord

            ViewTableRecord _vtr = _doc.Editor.GetCurrentView();

            _vtr.ViewDirection =

              _vtr.ViewDirection.TransformBy(

                Matrix3d.Rotation(angle, axis, Point3d.Origin)

              );



            // Set it as the current view



            _doc.Editor.SetCurrentView(_vtr);

        }
  
    }

}
