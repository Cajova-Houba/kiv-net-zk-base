using AppDbCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbCore.Service
{
    public class SVGExporter
    {
        public static string ExportToSvg(double width, double height, List<IExportableToSvg> elements)
        {
            string svg = $"<svg width=\"{width}\" height=\"{height}\">";
            foreach(IExportableToSvg svgElem in elements)
            {
                svg += svgElem.ToSvg();
            }
            svg += "</svg>";

            return svg;
        }
    }
}
