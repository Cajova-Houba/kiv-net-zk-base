using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbCore.Model
{
    [Serializable]
    public class Meteostation : AbstractEntity, IExportableToXml
    {
        public string Name { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public List<Report> Reports { get; set; }

        public override void Validate()
        {
            if (Name == null || Name.Length == 0) { throw new Exception("Name is empty!"); }

            if (Latitude == null || Latitude.Length == 0) { throw new Exception("Latitude is empty!"); }

            if (String.IsNullOrEmpty(Longitude)) { throw new Exception("Longitude is empty!"); }
        }
        
    }
}
