using AppDbCore.Model;
using KivNetExam.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbCore.Service
{
    // nezapomenout netAppContext.saveChanges();
    public class AppService
    {
        private NetAppContext netAppContext;

        public AppService()
        {
            netAppContext = new NetAppContext();
        }

        public List<Meteostation> GetAllMeteostations()
        {
            return netAppContext.Meteostations
                .Include("Reports.ReportDataLines")
                .OrderBy(m => m.Id)
                .ToList();
        }

        public List<Report> GetReportsByMeteoStation(Meteostation meteostation)
        {
            return netAppContext.Reports
                .Where(r => r.MeteostationId == meteostation.Id)
                .OrderBy(r => r.ReportDate)
                .ToList();
        }

        public List<ReportDataLine> GetReportDataByReport(Report report)
        {
            return netAppContext.ReportDataLines
                .Where(rdl => rdl.ReportId == report.Id)
                .OrderBy(rdl => rdl.Id)
                .ToList();
        }

        public Meteostation AddMeteostation(Meteostation meteostation)
        {
            meteostation.Validate();
            meteostation = netAppContext.Meteostations.Add(meteostation);
            netAppContext.SaveChanges();
            return meteostation;
        }

        public Report AddReport(Report report, Meteostation meteostation)
        {
            report.Validate();
            report.MeteostationId = meteostation.Id;
            report = netAppContext.Reports.Add(report);
            netAppContext.SaveChanges();
            return report;
        }

        public ReportDataLine AddReportData(DataLineType type, double value, Report report)
        {
            ReportDataLine reportDataLine = new ReportDataLine()
            {
                DataType = type,
                Value = value,
                ReportId = report.Id
            };
            reportDataLine.Validate();
            reportDataLine = netAppContext.ReportDataLines.Add(reportDataLine);
            netAppContext.SaveChanges();
            return reportDataLine;
        }

        public void ExportToXml(IExportableToXml data, string outFilePath)
        {
            XMLExporter.Export(data, outFilePath);
        }

        public void ExportToHtml(string title, Dictionary<string, List<IExportableToHtml>> data, string outFilePath)
        {
            HTMLExporter.Export(title, data, outFilePath);
        }

        public void ExportToSvg(double width, double height, List<IExportableToSvg> data, string outFilePath)
        {
            SVGExporter.Export(width, height, data, outFilePath);
        }
    }
}
