using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            new Window("Shape Drawer", 800, 600);
            Drawing drawing = new Drawing();
            do
            {
                SplashKit.ProcessEvents();
                //draw a shape at the posistion where the mouse is clicked
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = new Shape();
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    drawing.AddShape(newShape);
                }

                //change background color of drawing object on space pressed
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                //select shape on right click
                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                //delete selected shape
                if(SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    List<Shape> selectedShape = drawing.SelectedShapes;
                    foreach(Shape shape in selectedShape)
                    {
                        drawing.RemoveShape(shape);
                    }
                }

                SplashKit.ClearScreen();
                drawing.Draw();
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
