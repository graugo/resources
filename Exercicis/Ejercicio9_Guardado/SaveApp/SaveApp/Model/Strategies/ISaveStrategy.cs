using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveApp.Model.Strategies
{
    public interface ISaveStrategy
    {
        public void SaveData(object data);
    }
}
