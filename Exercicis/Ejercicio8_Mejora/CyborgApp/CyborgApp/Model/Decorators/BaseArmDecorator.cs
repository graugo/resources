using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model.Decorators
{
    internal class BaseArmDecorator : IExtremity
    {
        private IExtremity _extremity;
        public BaseArmDecorator(IExtremity extremity)
        {
            _extremity = extremity;
        }
        public virtual void Move()
        {
            
            _extremity.Move();
        }
    }
}
