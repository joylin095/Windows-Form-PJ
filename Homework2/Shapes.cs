using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Homework2
{
    public class Shapes
    {
        BindingList<Shape> _shapesList;
        Shape _shape;
        Factory _factory;
        public Shapes()
        {
            _shapesList = new BindingList<Shape>();
            _factory = new Factory();
        }

        public bool IsDrawing
        {
            get;
            set;
        }

        public BindingList<Shape> ShapeList
        {
            get 
            { 
                return _shapesList; 
            }
        }

        // 呼叫factory來創建shape
        public void CreateShape(string shapeName)
        {
            _shape = _factory.CreateShape(shapeName);
        }

        // 家shape到list
        public void AddShape()
        {
            _shapesList.Add(_shape);
        }

        // 獲取shape 資訊
        public string[] GetInformation()
        {
            return _shape.GetInformation();
        }

        // 刪除shape
        public void DeleteData(int deleteRowIndex)
        {
            _shapesList.RemoveAt(deleteRowIndex);
        }

        // 把形狀畫出來
        public void DrawAll(IGraphics graphics)
        {
            foreach (Shape shape in _shapesList)
            {
                shape.Draw(graphics);
            }
            if (IsDrawing)
            {
                _shape.Draw(graphics);
            }
        }

        // 更新座標
        public void UpdateLocation(Point firstPoint, Point newPoint)
        {
            _shape.UpdateLocation(firstPoint, newPoint);
        }
    }
}
