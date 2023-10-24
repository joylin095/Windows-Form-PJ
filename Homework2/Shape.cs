using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Homework2
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        // 通知Binding資料改變
        public void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // 形狀位置
        public abstract string GetLocation();

        // 更新座標
        public abstract void UpdateLocation(Point firstPoint, Point newPoint);

        // 畫圖
        public abstract void Draw(IGraphics graphics);

        // 形狀資訊
        public string[] GetInformation()
        {
            string[] data = { Name, GetLocation() };
            return data;
        }
    }
}
