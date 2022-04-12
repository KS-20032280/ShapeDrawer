using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        #region constructors
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this (Color.White)
        {

        }
        #endregion

        #region properties

        public Color Background 
        { 
            get { return _background; }
            set { _background = value; }
        }

        public int ShapeCount
        { get { return _shapes.Count; } }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape shape in _shapes)
                {
                    if (shape.Selected)
                    {
                        result.Add(shape);
                    }
                }
                return result;
            }
        }
        #endregion

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach(Shape s in _shapes)
            {
                s.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach(Shape s in _shapes)
            {
                s.Selected = s.IsAt(pt);
            }
        }

        public void RemoveShape(Shape s)
        { 
            _shapes.Remove(s);
        }
    }
}
