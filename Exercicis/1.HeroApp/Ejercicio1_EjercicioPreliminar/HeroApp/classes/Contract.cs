using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroApp.classes
{
    // Potential use class to save name of client and relate to hero
    //TODO
    internal class Contract
    {
        private string client{ get; set; }
        private Hero hero { get; set; }
        public Contract(string client, Hero hero)
        {
            this.client = client;  
            this.hero = hero;
        }

    }
}
