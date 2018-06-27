﻿using AppDbCore.Model;
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
        /// 
        /// [XmlIgnoreAttribute]
        /// </summary>
        /// <param name="data"></param>
        /// <param name="outFileName"></param>
        public static void Export(IExportableToXml data, string outFileName)
        {
            using (var outFileStream = File.Create(outFileName))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
                xmlSerializer.Serialize(outFileStream, data);
                xmlSerializer = null;
            }
        }
    }
}
