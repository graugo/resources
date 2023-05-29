using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ15.Tournament.ServiceLibrary.Impl.Configuration
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public int MaxValueRandom => _maxValueRandom;

        public int MinValueRandom => _minValueRandom;

        private int _maxValueRandom;
        private int _minValueRandom;

        public ServiceConfiguration()
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            _maxValueRandom = Convert.ToInt32(ConfigurationManager.AppSettings["MaxValueRandom"]);
            _minValueRandom = Convert.ToInt32(ConfigurationManager.AppSettings["MinValueRandom"]);
        }
    }
}
