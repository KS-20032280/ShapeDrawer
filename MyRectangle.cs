using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {
            
        }

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        #region properties
        public int Width
        { get { return _width; } set { _width = value; } }

        public int Height
        { get { return _height; } set { _height = value; } }
        #endregion

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, X, Y, _width, _height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            bool pointIsBetweenShapeWidth = pt.X <= X + _width && pt.X >= X;
            bool pointIsBetweenShapeHeight = pt.Y <= Y + _height && pt.Y >= Y;
            return pointIsBetweenShapeHeight && pointIsBetweenShapeWidth;
        }
    }
}
