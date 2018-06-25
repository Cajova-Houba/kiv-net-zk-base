using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KivNetExam.AppVM
{
    public class AppVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


        public AppVM()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                // init to co ma byt pro normal view
            }
            else
            {
                // to co ma byt pro ok view
                LoadOnInit();
            }
        }

        private void LoadOnInit()
        {
            // nacist data z databaze pri spusteni
        }
    }
}
