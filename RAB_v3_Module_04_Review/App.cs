#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Windows.Markup;

#endregion

namespace RAB_v3_Module_04_Review
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            // 0. Set tab name
            string tabName = "Revit Add-in Bootcamp";

            // 1. Create ribbon tab
            try
            {
                app.CreateRibbonTab(tabName);
            }
            catch (Exception)
            {
                Debug.Print("Tab already exists.");
            }

            // 2. Create ribbon panel 
            RibbonPanel panel = Utils.CreateRibbonPanel(app, tabName, "Revit Tools");
            RibbonPanel panel2 = Utils.CreateRibbonPanel(app, tabName, "More Revit Tools");

            // 3. Create button data instances
            ButtonDataClass myButtonData1 = new ButtonDataClass("btn1", "Tool 1", Command1.GetMethod(), Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 1");
            ButtonDataClass myButtonData2 = new ButtonDataClass("btn2", "Tool 2", Command2.GetMethod(), Properties.Resources.Red_32, Properties.Resources.Red_16, "Tooltip 2");
            ButtonDataClass myButtonData3 = new ButtonDataClass("btn3", "Tool 3", Command1.GetMethod(), Properties.Resources.Yellow_32, Properties.Resources.Yellow_16, "Tooltip 3");
            ButtonDataClass myButtonData4 = new ButtonDataClass("btn4", "Tool 4", Command2.GetMethod(), Properties.Resources.Green_32, Properties.Resources.Green_16, "Tooltip 4");
            ButtonDataClass myButtonData5 = new ButtonDataClass("btn5", "Tool 5", Command1.GetMethod(), Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 5");
            ButtonDataClass myButtonData6 = new ButtonDataClass("btn6", "Tool 6", Command2.GetMethod(), Properties.Resources.Red_32, Properties.Resources.Red_16, "Tooltip 6");
            ButtonDataClass myButtonData7 = new ButtonDataClass("btn7", "Tool 7", Command1.GetMethod(), Properties.Resources.Yellow_32, Properties.Resources.Yellow_16, "Tooltip 7");
            ButtonDataClass myButtonData8 = new ButtonDataClass("btn8", "Tool 8", Command2.GetMethod(), Properties.Resources.Green_32, Properties.Resources.Green_16, "Tooltip 8");
            ButtonDataClass myButtonData9 = new ButtonDataClass("btn9", "Tool 9aa", Command1.GetMethod(), Properties.Resources.tool_box_32x32, Properties.Resources.tool_box_16x16, "Tooltip 9");
            ButtonDataClass myButtonData10 = new ButtonDataClass("btn10", "Tool 10", Command2.GetMethod(), Properties.Resources.Red_32, Properties.Resources.Red_16, "Tooltip 10");

            SplitButtonData mySplitButtonData = new SplitButtonData("split1", "Split Button");
            PulldownButtonData myPullDownButtonData = new PulldownButtonData("pulldown1", "More Tools");

            myPullDownButtonData.LargeImage = ButtonDataClass.BitmapToImageSource(Properties.Resources.Yellow_32);
            myPullDownButtonData.Image = ButtonDataClass.BitmapToImageSource(Properties.Resources.Yellow_16);

            // 4. Create buttons
            PushButton myButton1 = panel.AddItem(myButtonData1.Data) as PushButton;
            PushButton myButton2 = panel.AddItem(myButtonData2.Data) as PushButton;

            // 5. create stacked buttons
            panel2.AddStackedItems(myButtonData3.Data, myButtonData4.Data, myButtonData5.Data);

            // 6. add split button
            SplitButton mySplit = panel.AddItem(mySplitButtonData) as SplitButton;
            mySplit.AddPushButton(myButtonData6.Data);
            mySplit.AddPushButton(myButtonData7.Data);

            // 7. pull-down button
            PulldownButton myPulldown = panel2.AddItem(myPullDownButtonData) as PulldownButton;
            myPulldown.AddPushButton(myButtonData8.Data);
            myPulldown.AddPushButton(myButtonData9.Data);
            myPulldown.AddSeparator();
            myPulldown.AddPushButton(myButtonData10.Data);

            // NOTE:
            // To create a new tool, copy lines 35 and 39 and rename the variables to "myButtonData3" and "myButton3". 
            // Change the name of the tool in the arguments of line 

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }


    }
}
