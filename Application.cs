using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.IO;


namespace FINAL_PIPE
{
    public class Application : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("Md Saqlain Khan"); // Create Tab Name
            RibbonPanel panelInitializer = application.CreateRibbonPanel("Md Saqlain Khan", "Pipe Create");
      

            CreateButton(application, "Pipe", "FINAL_PIPE.FINAL_PIPE", panelInitializer, "pipe.ico");

            return Result.Succeeded;





        }

        public void CreateButton(UIControlledApplication application, string ButtonName, string className, RibbonPanel panel, string icon)
        {
            String path = Assembly.GetExecutingAssembly().Location; // get Current Path

            PushButtonData buttonData =
                new PushButtonData(ButtonName, ButtonName, path, className); //Create New Button data

            RibbonPanel ribbonpanel = panel;

            PushButton pushButton = ribbonpanel.AddItem(buttonData) as PushButton;

            Uri uri = new Uri(Path.Combine(Path.GetDirectoryName(path), "Resources", icon));
            BitmapImage bitmapImage = new BitmapImage(uri);
            pushButton.LargeImage = bitmapImage;
        }
    }
}