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
