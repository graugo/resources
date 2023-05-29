using SaveApp.Model.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveApp.Services
{
    internal class SaveService
    {
        public SaveService() { }

        public void Initialize(object data)
        {
            Context context = new Context();

            context.SetStrategy(new FileSaveStrategy());
            context.ExecuteStrategy(data);

            context.SetStrategy(new DeliveryStrategy());
            context.ExecuteStrategy(data);

            context.SetStrategy(new MemorySaveStrategy());
            context.ExecuteStrategy(data);

            context.SetStrategy(new ConsoleSaveStrategy());
            context.ExecuteStrategy(data);
        }
    }
}
