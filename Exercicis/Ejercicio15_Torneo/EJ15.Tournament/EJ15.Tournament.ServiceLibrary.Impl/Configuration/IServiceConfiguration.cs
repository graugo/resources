using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ15.Tournament.ServiceLibrary.Impl.Configuration
{
    public interface IServiceConfiguration
    {
        int MaxValueRandom { get; }
        int MinValueRandom { get; }
    }
}
