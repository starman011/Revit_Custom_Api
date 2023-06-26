using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.ComponentModel;

namespace FINAL_PIPE
{
    [DisplayName("Create Pipe")]
    [Designer("/UIFrameworkRes;component/ribbon/images/pipe_create.ico")]
    [Transaction(TransactionMode.Manual)]
    public class FINAL_PIPE : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;
            Document document = uiapp.ActiveUIDocument.Document;

            var levels = new FilteredElementCollector(document)
                .OfClass(typeof(Level));
            var levelId = levels.FirstElementId();

            var pipeTypes = new FilteredElementCollector(document)
                .OfClass(typeof(PipeType));
            var pipeTypeId = pipeTypes.FirstElementId();

            var pipeSystemTypes = new FilteredElementCollector(document)
                .OfClass(typeof(PipingSystemType));
            var pipeSystemTypeId = pipeSystemTypes.FirstElementId();

            XYZ startPoint = new XYZ(0, 0, 0);
            XYZ endPoint = new XYZ(5, 0, 0);

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Create Pipe");
                //Pipe.Create(document, pipeSystemTypeId, pipeTypeId, levelId, XYZ.Zero, 10 * XYZ.BasisX);
                Pipe.Create(document, pipeSystemTypeId, pipeTypeId, levelId, startPoint, endPoint);
                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }

}
