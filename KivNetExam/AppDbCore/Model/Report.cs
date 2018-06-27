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
    [Serializable]
    public class Report : AbstractEntity, IXmlSerializable
    {
        public DateTime ReportDate { get; set; }

        public string Summary { get; set; }

        [XmlIgnoreAttribute]
        public int MeteostationId { get; set; }

        [XmlIgnoreAttribute]
        public Meteostation Meteostation { get; set;}

        [XmlIgnoreAttribute]
        public List<ReportDataLine> ReportDataLines { get; set; }

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
            if (ReportDate == null) { throw new Exception("ReportDate is missing!"); }

            if (String.IsNullOrEmpty(Summary)) { throw new Exception("Summary is missing!"); }
        }

        public void WriteXml(XmlWriter writer)
        {
            //writer.WriteStartAttribute(GetType().ToString());
            writer.WriteElementString("Summary", Summary);
            writer.WriteElementString("ReportDate", ReportDate == null ? "" : ReportDate.ToString());
            writer.WriteStartElement("ReportDataLines");
            ReportDataLines.ForEach(rdl => rdl.WriteXml(writer));
            writer.WriteEndElement();
            //writer.WriteEndAttribute();
        }
    }
}
