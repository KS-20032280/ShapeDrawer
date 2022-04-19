using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected;

        //constructor
        public Shape() : this(Color.Yellow)
        {
            _x = 0;
            _y = 0;
        }

        public Shape(Color color)
        {
            _color = color;
        }

        #region properties
        public Color Color
        { get { return _color; } set { _color = value; } }

        public float X
        { get { return _x; } set { _x = value; } }

        public float Y
        { get { return _y; } set { _y = value; } }

        public bool Selected
        { get { return _selected; } set { _selected = value; } }
        #endregion

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);

        public abstract void DrawOutline();
    }
}
