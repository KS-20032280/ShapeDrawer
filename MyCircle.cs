using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle() : this(Color.Blue, 50)
        {
        }

        public MyCircle(Color color, int radius)
        {
            Color = color;
            _radius = radius;
        }

        public MyCircle(Color color, int x, int y, int radius)
        {
            Color = color;
            X = x;
            Y = y;
            _radius = radius;
        }

        #region properties
        public int Radius
        { get { return _radius; } set { _radius = value; } }
        #endregion

        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            //formula to calculate distance between 2 points
            float distanceBetween2Points = (float)Math.Sqrt(Math.Pow(X - pt.X, 2) + Math.Pow(Y - pt.Y, 2));
            return distanceBetween2Points <= _radius;
        }
    }
}
