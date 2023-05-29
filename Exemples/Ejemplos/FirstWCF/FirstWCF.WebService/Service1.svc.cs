using FirstWCF.WebService.Services;
using System;

namespace FirstWCF.WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private readonly IFooService _fooService;

        public Service1(IFooService fooService)
        {
            _fooService = fooService;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", _fooService.Get(value.ToString()));
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
