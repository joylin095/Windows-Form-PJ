using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Homework2
{
    public class Model
    {
        Shapes _shapes;
        Pen _pen;
        Point _firstPoint;
        public Model()
        {
            _shapes = new Shapes();
            _pen = new Pen(Color.Green);
        }

        public BindingList<Shape> GetBindingShapeList
        {
            get 
            { 
                return _shapes.ShapeList; 
            }
        }

        public bool IsDrawing
        {
            get;
            set;
        }
        
        // 創建shape
        public void CreateShapes(string shapeName)
        {
            _shapes.CreateShape(shapeName);
        }

        // 加入shape到list
        public void AddShape()
        {
            _shapes.AddShape();
        }

        // 獲取shape資訊
        public string[] GetInformation()
        {
            return _shapes.GetInformation();
        }

        // 刪除shape
        public void DeleteData(int deleteRowIndex)
        {
            _shapes.DeleteData(deleteRowIndex);
        }

        // 畫圖
        public void Draw(Graphics graphics)
        {
            _shapes.DrawAll(new WindowsFormsGraphicsAdaptor(graphics, _pen));
            _shapes.IsDrawing = IsDrawing;
        }

        // 紀錄第一個按下去的點
        public void SetShapeFirstPoint(Point point)
        {
            _firstPoint = point;
        }

        // 更新座標
        public void UpdateLocation(Point newPoint)
        {
            _shapes.UpdateLocation(_firstPoint, newPoint);
        }
    }
}
