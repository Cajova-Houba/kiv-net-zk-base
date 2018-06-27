using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AppDbCore.Model
{
    public class ReportDataLine : AbstractEntity, IXmlSerializable
    {
        public DataLineType DataType { get; set; }

        public double Value { get; set; }

        [XmlIgnoreAttribute]
        public int ReportId { get; set; }

        [XmlIgnoreAttribute]
        public Report Report { get; set; }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            if (DataType == null) { throw new Exception("Data type is missing!"); }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("ReportDataLine");
            writer.WriteElementString("DataType", DataType == null ? "" : DataType.ToString());
            writer.WriteElementString("Value", Value.ToString());
            writer.WriteEndElement();
        }
    }

    public enum DataLineType
    {
        TEMPERATURE,
        RAIN,
        WIND,
        SNOW
    }
}
