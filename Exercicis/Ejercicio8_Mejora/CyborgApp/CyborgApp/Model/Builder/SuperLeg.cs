using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model.Builder
{
    internal class SuperLeg : Leg
    {
        private List<string> _parts = new List<string>();
        private string _materials;
        private string _finishes;

        public void SetMaterial(string material)
        {
            _materials = material;
        }
        public void SetFinihes(string finihes)
        {
            _finishes = finihes;
        }
        public void AddPart(string part) 
        { 
            _parts.Add(part);
        }
        public override void Move()
        {
            Console.WriteLine($"Moving leg made of {_materials} and a {_finishes} finish.");
            Console.WriteLine(GetAttributes());
        }

        public string GetAttributes()
        {
            
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
            
        }
    }
}
