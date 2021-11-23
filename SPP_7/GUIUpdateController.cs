using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SPP_7
{
    public class GUIUpdateController
    {
        AssembliesController assController;
        IEnumerable<DependencyObject> guiControls;
        MainWindow mainWindow;

        public GUIUpdateController(string assembliesFolderPath, IEnumerable<DependencyObject> controls, MainWindow mainWindow)
        {
            assController = new AssembliesController(assembliesFolderPath);
            guiControls = controls;
            this.mainWindow = mainWindow;
        }

        public void CheckNewElements()
        {
            assController.CheckAssemblies();
            try
            {
                while (assController.UserControlsQueue.Count > 0)
                {
                    PrepareNewGUIElement(assController.UserControlsQueue.Dequeue());
                }
            } catch (InvalidOperationException){}
        }

        private void PrepareNewGUIElement(UserControl userControl)
        {
            userControl.GetType().GetProperty("Browser").SetValue(userControl, mainWindow.browser);
            //userControl.SetCurrentValue(BrowserProperty, guiControls.ToList().First());
            (int left, int width, int top, int height) userControlPosition = GetPositionAttributesValues(userControl.GetType());

            userControl.SetCurrentValue(Grid.ColumnProperty, userControlPosition.left);
            userControl.SetCurrentValue(Grid.ColumnSpanProperty, userControlPosition.width);
            userControl.SetCurrentValue(Grid.RowProperty, userControlPosition.top);
            userControl.SetCurrentValue(Grid.RowSpanProperty, userControlPosition.height);

            bool heightChanged = false;
            bool widthChanged = false;
            foreach (DependencyObject control in guiControls)
            {
                MoveElement(control, userControlPosition.left, userControlPosition.width, userControlPosition.top, userControlPosition.height, ref widthChanged, ref heightChanged);
            }

            guiControls.Append(userControl);
            mainWindow.grid.Children.Add(userControl);
        }

        public (int left, int width, int top, int height) GetPositionAttributesValues(Type t)
        {
            IList<System.Reflection.CustomAttributeData> attrsData = t.GetCustomAttributesData();
            (int left, int width, int top, int height) result = (0,0,0,0);
            foreach(System.Reflection.CustomAttributeData data in attrsData)
            {
                switch (data.AttributeType.Name)
                {
                    case "LeftSpanInLinesAttribute":
                        result.left = (int)(data.ConstructorArguments.ElementAt(0).Value);
                        break;
                    case "WidthInLinesAttributes":
                        result.width = (int)(data.ConstructorArguments.ElementAt(0).Value);
                        break;
                    case "TopSpanInLinesAttribute":
                        result.top = (int)(data.ConstructorArguments.ElementAt(0).Value);
                        break;
                    case "HeightInLinesAttribute":
                        result.height = (int)(data.ConstructorArguments.ElementAt(0).Value);
                        break;
                }
            }
            return result;
        }

        private void MoveElement(DependencyObject control, int leftSpan, int width, int topSpan, int height, ref bool heightChanged, ref bool widthChanged)
        {
            int controlLeftSpan = (int)(control.GetValue(Grid.ColumnProperty));
            int controlWidth = (int)(control.GetValue(Grid.ColumnSpanProperty));
            int controlTopSpan = (int)(control.GetValue(Grid.RowProperty));
            int controlHeight = (int)(control.GetValue(Grid.RowSpanProperty));

            if (controlLeftSpan >= leftSpan && controlTopSpan < (topSpan+height) && controlWidth - width >= 0)
            {
                control.SetValue(Grid.ColumnProperty, controlLeftSpan + width);
                if (!widthChanged)
                {
                    control.SetValue(Grid.ColumnSpanProperty, controlWidth - width);
                    widthChanged = true;
                }
            }
            if(controlTopSpan >= topSpan && controlLeftSpan+controlWidth > leftSpan && controlHeight - height >= 0)
            {
                control.SetValue(Grid.RowProperty, controlTopSpan + height);
                if (!heightChanged)
                {
                    control.SetValue(Grid.RowSpanProperty, controlHeight - height);
                    heightChanged = true;
                }
            }
        }
    }
}
