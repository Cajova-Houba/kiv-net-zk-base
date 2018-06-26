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

        public DateTime SomeDate { get; set; }

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
            SomeDate = DateTime.Now;
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

        public void ExportToHtml(string outFilePath)
        {
            appService.ExportToHtml("", new Dictionary<string, List<AppDbCore.Model.IExportableToHtml>>(), outFilePath);
        }

        public void ExportToSvg(string outFilePath)
        {
            appService.ExportToSvg(0, 0, new List<AppDbCore.Model.IExportableToSvg>(), outFilePath);
        }

        public void ExportToXml(string outFilePath)
        {
            appService.ExportToXml(null, outFilePath);
        }
    }
}
