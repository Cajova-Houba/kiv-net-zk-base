using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbCore.Model
{
    [Serializable()]
    public class Meteodata : IExportableToXml
    {
        public List<Meteostation> Meteostations { get; set; }
    }
}
