using AppDbCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppDbCore.Service
{
    public class XMLExporter
    {
        /// <summary>
        /// http://www.jonasjohn.de/snippets/csharp/xmlserializer-example.htm
        /// </summary>
        /// <param name="data"></param>
        /// <param name="outFileName"></param>
        public static void Export(IExportableToXml data, string outFileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
            TextWriter tw = new StreamWriter(@"out.xml");
            xmlSerializer.Serialize(tw, data);
            tw.Close();
        }
    }
}
