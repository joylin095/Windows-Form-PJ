using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsPractice
{
    public class ToolBarChecked : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool _value;
        const string MOUSE = "選取";
        public string Key
        {
            get;
            set;
        }
        public bool Value
        {
            get
            { 
                return _value;
            }
            set
            {
                _value = value;
                NotifyPropertyChanged();
            }
        }
        public ToolBarChecked(string key, bool value)
        {
            this.Key = key;
            this._value = value;
        }

        // 按下後更改checked 值
        public void SetCheckedValue(string shapeName)
        {
            if (Key == shapeName)
            {
                if (Key == MOUSE)
                {
                    Value = true;
                }
                else
                {
                    Value = !Value;
                }       
            }
            else
            {
                Value = false;
            }
        }

        // 判斷要不要變drawing state
        public bool IsDrawingState()
        {
            if (Key != MOUSE && Value)
            {
                return true;
            }
            return false;
        }

        // 更新通知
        public void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
