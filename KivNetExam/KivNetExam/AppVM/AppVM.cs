using AppDbCore;
using AppDbCore.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KivNetExam.AppVM
{
    public class AppVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AppService appService;

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
                Database.SetInitializer(new ContextInit());
                appService = new AppService();
                LoadOnInit();
            }
        }

        private void LoadOnInit()
        {
            // nacist data z databaze pri spusteni
        }

        public string ExportToHtml()
        {
            return appService.ExportToHtml("", new Dictionary<string, List<AppDbCore.Model.IExportableToHtml>>());
        }

        public string ExportToSvg()
        {
            return appService.ExportToSvg(0, 0, new List<AppDbCore.Model.IExportableToSvg>());
        }
    }
}
