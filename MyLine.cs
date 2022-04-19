using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;

        public MyLine() : this(Color.Red, 0, 0, 100, 100)
        { }

        public MyLine(Color color, float startX, float startY, float endX, float endY)
        {
            Color = color;
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }

        #region properties
        public float EndX
        { get { return _endX; } set { _endX = value; } }

        public float EndY
        { get { return _endY; } set { _endY = value; } }
        #endregion

        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
        }

        public override void DrawOutline()
        {
            //draws 2 circles at the start and end of line respectively
            SplashKit.DrawCircle(Color.Black, X, Y, 5);
            SplashKit.DrawCircle(Color.Black, _endX, _endY, 5);
        }

        public override bool IsAt(Point2D pt)
        {
            //creates a new SplashKit line and point objects to use the SplashKit.PointOnLine() function
            //the SplashKit.PointOnLine function only accepts a Line object
            //Line object only accepts Point2D object
            //There is no non-default constructor for both Point2D and Line, thus the value has to be set manually.
            Point2D startPoint = new Point2D();
            startPoint.X = X;
            startPoint.Y = Y;
            Point2D endPoint = new Point2D();
            endPoint.X = _endX;
            endPoint.Y = _endY;
            Line line = new Line();
            line.StartPoint = startPoint;
            line.EndPoint = endPoint;
            return SplashKit.PointOnLine(pt, line, 1);
        }
    }
}
