using FactoryApp.Model.Button;
using FactoryApp.Model.Checbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryApp.Model.Factory
{
    internal class WinFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WinCheckbox();
        }
    }
}
