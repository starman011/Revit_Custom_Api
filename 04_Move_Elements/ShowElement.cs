using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Library;

namespace LearnAPI.Day06
{
    [Transaction(TransactionMode.Manual)]
    class ShowElement : RevitCommand
    {
       
        public override void Action()
        {
            Autodesk.Revit.DB.Reference pickObject = UIDoc.Selection.PickObject(ObjectType.Element);
            Autodesk.Revit.DB.Element element = Doc.GetElement(pickObject);
            UIDoc.ShowElements(element);
        }
    }
}
