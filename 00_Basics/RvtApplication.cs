using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LearnAPI.Day02
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.UsingCommandData)]
    public class RvtApplication : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
  
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            List<string> data = new List<string>();
            data.Add(app.VersionNumber);
            data.Add(app.Username);
            data.Add(app.VersionBuild);
            data.Add(app.FamilyTemplatePath);
            MessageBox.Show(string.Join(Environment.NewLine, data));
            return Result.Succeeded;
            
        }
    }
}
