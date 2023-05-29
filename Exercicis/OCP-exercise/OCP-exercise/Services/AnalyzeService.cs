using OCP_exercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_exercise.Services
{
    internal class AnalyzeService
    {
        public PlanetSystem[] SystemList;
        public AnalyzeService(PlanetSystem[] SystemList)
        {
            this.SystemList = SystemList;
        }

        public void Initialize(Component c)
        {
            foreach (PlanetSystem system in SystemList)
            {
                system.Analyze(c);
            }
        }
    }
}
