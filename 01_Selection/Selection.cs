﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LearnAPI.Day03
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.UsingCommandData)]
    public class Selection : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region Init

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            #endregion

            try
            {
                ICollection<ElementId> selectedElements = uidoc.Selection.GetElementIds();
                List<string> EleInfo = new List<string>();
                foreach (ElementId re in selectedElements)
                {
                    Element element = doc.GetElement(re);
                    EleInfo.Add($"Element Name: {element.Name}");
                    EleInfo.Add($"Element Id: {element.Name}");
                    EleInfo.Add($"UniqueId: {element.UniqueId}");
                    EleInfo.Add($"Category: {element.Category.Name}");
                }
                MessageBox.Show(string.Join(Environment.NewLine, EleInfo),"Info",MessageBoxButtons.OK);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException e)
            {
                MessageBox.Show($"You Has Press Esc\n{e}","Warning",MessageBoxButtons.OK);
                return Result.Cancelled;
                //Pressed Esc
            }

            return Result.Succeeded;
        }
    }
}