using System.Collections.Generic;

namespace WCFHttpClient.Library.Entity
{
    public class PokemonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PokemonTypes> Types { get; set; }

        public string GetTypesName() 
        {
            string temp = string.Empty;
            if(Types != null)
                foreach (var item in Types)
                {
                    temp += item.Type.Name;
                }

            return temp;
        }
        
        public string Error { get; set; }
    }
}
