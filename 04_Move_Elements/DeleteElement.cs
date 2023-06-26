﻿using System;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LearnAPI.Day06
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.UsingCommandData)]
    public class DeleteElement : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            try
            {
                Element element = doc.GetElement(uidoc.Selection.PickObject(ObjectType.Element));
                using (Transaction tran = new Transaction(doc))
                {
                    tran.Start("Delete Element");
                    doc.Delete(element.Id);
                    MessageBox.Show("Element Deleted","Information",MessageBoxButtons.OK);
                    tran.Commit();
                }
            }
            catch(Autodesk.Revit.Exceptions.OperationCanceledException){}
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return Result.Succeeded;
        }
    }
}
