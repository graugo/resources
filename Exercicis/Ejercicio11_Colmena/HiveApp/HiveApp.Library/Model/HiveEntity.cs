using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HiveApp.Library.Model
{
    [XmlRoot("colmena")]
    public class HiveEntity
    {
        [XmlElement("abeja")]
        public List<BeeEntity> BeeList { get; set; }
        public HiveEntity()
        {
            BeeList = new List<BeeEntity>();
        }
        public void AddBee(BeeEntity bee)
        {
            BeeList.Add(bee);
        }

        public void AddBees(IEnumerable<BeeEntity> bees)
        {
            BeeList.AddRange(bees);
        }
    }
}
