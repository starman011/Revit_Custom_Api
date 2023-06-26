﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LearnAPI.Day04
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.UsingCommandData)]

    public class PickObjContains : IExternalCommand
    {
     
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            try
            {
                List<Reference> pickObjects = uidoc.Selection.PickObjects(ObjectType.Element,
                    new PickWallFilter(), "Select Walls").ToList();
                StringBuilder sb = new StringBuilder();
                foreach (Reference r in pickObjects)
                {
                    Element e = doc.GetElement(r);
                    sb.AppendLine($"{e.Name}-{e.Id}");
                }

                MessageBox.Show(sb.ToString(), "Information", MessageBoxButtons.OK);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return Result.Succeeded;
        }
    }

    /// <summary>
    /// Class Filters Wall
    /// </summary>
    public class PickWallFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            bool flag = elem is Wall;

            if (flag)
            {
                return true;
            }
            return false;
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

}