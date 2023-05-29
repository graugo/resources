using System;
using System.Xml.Serialization;

namespace HiveApp.Library.Model
{
    [Serializable]
    public class BeeEntity
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("nombre")]
        public  string Name { get; set; }
        [XmlElement("recoleccion")]
        public decimal Recollection { get; set; }
        [XmlElement("tiempo")]
        public long Time { get; set; }
        [XmlElement("estado")]
        public bool State { get; set; }
        [XmlElement("incidentes")]
        public int Incidents { get; set; }

        public BeeEntity() { }
        public BeeEntity(int id, string name, decimal recollection, long time, bool state, int incidents) 
        {
            Id = id;
            Name = name;
            Recollection = recollection;
            Time = time;
            State = state;
            Incidents = incidents;
        }
    }   
}
