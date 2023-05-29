using FactoryApp.Model.Button;
using FactoryApp.Model.Checbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryApp.Model.Factory
{
    internal interface IGuiFactory
    {
        public IButton CreateButton();
        public ICheckbox CreateCheckbox();
    }
}
