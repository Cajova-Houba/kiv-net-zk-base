using AppDbCore;
using AppDbCore.Model;
using AppDbCore.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Meteostation> Meteostations { get; set; }

        public ObservableCollection<Report> Reports {
            get
            {
                if (SelectedMeteostation == null || appService == null)
                {
                    return new ObservableCollection<Report>();
                } else
                {
                    return new ObservableCollection<Report>(appService.GetReportsByMeteoStation(SelectedMeteostation));
                }
            }
        }

        public ObservableCollection<ReportDataLine> ReportData
        {
            get
            {
                if (SelectedReport == null || SelectedReport.ReportDataLines == null)
                {
                    return new ObservableCollection<ReportDataLine>();
                } else
                {
                    return new ObservableCollection<ReportDataLine>(SelectedReport.ReportDataLines);
                }
            }
        }

        public Meteostation SelectedMeteostation { get; set; }

        public Meteostation NewMeteostation { get; set; }

        public Report NewReport { get; set; }

        public Report SelectedReport { get; set; }
        
        public ObservableCollection<DataLineType> AvailableDataTypes { get; set; }

        public DataLineType NewReportDataType { get; set; }

        public String NewReportValue { get; set; }

        public bool CanAddReport
        {
            get
            {
                return SelectedMeteostation != null;
            }
        }

        public bool CanAddReportData
        {
            get
            {
                return SelectedReport != null;
            }
        }

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
            DefaultInit();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                // init to co ma byt pro normal view
                Meteostations = new ObservableCollection<Meteostation>(new List<Meteostation>()
                {
                    new Meteostation() {Id = 1, Latitude = "12.32", Longitude = "34.65", Name = "Meteostation 1"},
                    new Meteostation() {Id = 2, Latitude = "12.32", Longitude = "34.65", Name = "Meteostation 2"},
                });
            }
            else
            {
                // to co ma byt pro ok view
                Database.SetInitializer(new ContextInit());
                appService = new AppService();
                LoadOnInit();
            }
        }

        private void DefaultInit()
        {
            AvailableDataTypes = new ObservableCollection<DataLineType>(new List<DataLineType>()
            {
                DataLineType.RAIN,
                DataLineType.SNOW,
                DataLineType.TEMPERATURE,
                DataLineType.WIND
            });
            NewMeteostation = new Meteostation();
            SelectedMeteostation = null;
            SomeDate = DateTime.Now;

            ResetReportPanel();
            ResetReportPanel();
        }

        private void ResetReportPanel()
        {
            SelectedReport = null;
            NewReport = new Report() { ReportDate = DateTime.Now };
        }

        private void ResetReportDataPanel()
        {
            NewReportDataType = AvailableDataTypes.ElementAt(0);
        }

        private void LoadOnInit()
        {
            // nacist data z databaze pri spusteni
            Meteostations = new ObservableCollection<Meteostation>(appService.GetAllMeteostations());
        }

        public void AddMeteostation()
        {
            appService.AddMeteostation(NewMeteostation);
            Meteostations = new ObservableCollection<Meteostation>(appService.GetAllMeteostations());
            ResetReportPanel();
            ResetReportDataPanel();
            OnPropertyChanged("Meteostations");
            OnPropertyChanged("Reports");
            OnPropertyChanged("ReportData");
        }

        public void AddReport()
        {
            if (SelectedMeteostation == null) { throw new Exception("No meteostation selected!"); }
            appService.AddReport(NewReport, SelectedMeteostation);
            ResetReportDataPanel();
            ResetReportPanel();
            OnPropertyChanged("NewReport");
            OnPropertyChanged("SelectedReport");
            OnPropertyChanged("Reports");
            OnPropertyChanged("CanAddReportData");
        }

        public void AddReportData()
        {
            double res = 0;
            if (!Double.TryParse(NewReportValue, out res)) { throw new Exception($"'{NewReportValue}' is not correct double expression!"); }
            if (SelectedReport == null) { throw new Exception("No report selected!"); }

            appService.AddReportData(NewReportDataType, res, SelectedReport);
            OnPropertyChanged("ReportData");
        }

        public void RefreshReportPanel()
        {
            ResetReportDataPanel();
            if (SelectedMeteostation == null)
            {
                ResetReportPanel();
            }
            OnPropertyChanged("SelectedMeteostation");
            OnPropertyChanged("CanAddReport");
            OnPropertyChanged("CanAddReportData");
            OnPropertyChanged("ReportData");
            OnPropertyChanged("Reports");
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
            Meteodata meteodata = new Meteodata() { Meteostations = this.Meteostations.ToList() };
            appService.ExportToXml(meteodata, outFilePath);
        }
    }
}
