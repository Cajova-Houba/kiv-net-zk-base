using AppDbCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KivNetExam.Service
{
    public class HTMLExporter
    {
        private static void DataToHtmlTable(String tableTitle, ICollection<IExportableToHtml> dataToExport, StringBuilder stringBuilder)
        {
            // title
            stringBuilder.Append("<h2>")
                .Append(tableTitle)
                .Append("</h2>");

            // table header
            stringBuilder.Append("<table>")
                .Append("<thead>")
                .Append("<tr>");
            if (dataToExport.Count() > 0)
            {
                foreach (String fieldName in dataToExport.ElementAt(0).GetFieldNames())
                {
                    stringBuilder.Append("<th>")
                        .Append(fieldName)
                        .Append("</th>");
                }
            }
            stringBuilder.Append("</tr>");
            stringBuilder.Append("</thead>");

            // table data
            stringBuilder.Append("<tbody>");
            if (dataToExport.Count() > 0)
            {
                foreach (IExportableToHtml exportable in dataToExport)
                {
                    stringBuilder.Append("<tr>");
                    foreach (string fValue in exportable.GetFieldValues())
                    {
                        stringBuilder.Append("<td>")
                            .Append(fValue)
                            .Append("</td>");
                    }
                    stringBuilder.Append("</tr>");
                }
            }
            stringBuilder.Append("</tbody>");

            // end table
            stringBuilder.Append("</table>");
        }

        public static string Export(String title, Dictionary<String, List<IExportableToHtml>> htmlData)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("<html>")
                .Append("<head>")
                .Append("<title>").Append(title).Append("</title>")
                .Append("</head>")
                .Append("<body>")
                .Append("<h1>").Append(title).Append("</h1>");

            foreach (string tableTitle in htmlData.Keys)
            {
                DataToHtmlTable(tableTitle, htmlData[tableTitle], sb);
            }

            sb.Append("</body>")
                .Append("</html>");

            return sb.ToString();
        }
    }
}
