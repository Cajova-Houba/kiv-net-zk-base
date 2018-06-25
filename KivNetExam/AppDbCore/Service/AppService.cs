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

        public string ExportToHtml(string title, Dictionary<string, List<IExportableToHtml>> data)
        {
            return HTMLExporter.Export(title, data);
        }

        public string ExportToSvg(double width, double height, List<IExportableToSvg> data)
        {
            return SVGExporter.Export(width, height, data);
        }
    }
}
