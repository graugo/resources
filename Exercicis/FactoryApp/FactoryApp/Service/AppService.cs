using FactoryApp.Model.Button;
using FactoryApp.Model.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryApp.Service
{
    internal class AppService
    {
        private IGuiFactory _factory;
        private IButton _button = new WinButton();

        public AppService(IGuiFactory factory)
        {
            _factory = factory;
        }

        public void CreateUI()
        {
            this._button = _factory.CreateButton();
        }

        public void Paint()
        {
            _button.Paint();
        }

        public void Initialize()
        {
            CreateUI();
            Paint();
        }
    }
}
