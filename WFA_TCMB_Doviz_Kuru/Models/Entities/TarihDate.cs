using System.Collections.Generic;
using System.Xml.Serialization;

namespace WFA_TCMB_Doviz_Kuru.Models.Entities
{
    [XmlRoot(ElementName = "Tarih_Date")]
    public class TarihDate
    {
        public TarihDate()
        {
            Currencies = new List<Currency>();
        }
        [XmlAttribute(AttributeName = "Tarih")]
        public string Tarih { get; set; }

        [XmlAttribute(AttributeName = "Date")]
        public string Date { get; set; }

        [XmlAttribute(AttributeName = "Bulten_No")]
        public string BultenNo { get; set; }

        [XmlElement(ElementName = "Currency")]
        public List<Currency> Currencies { get; set; }
    }
}