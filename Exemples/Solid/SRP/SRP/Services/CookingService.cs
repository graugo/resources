using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Services
{
    internal class CookingService
    {
        public PreparingService PreparingService = new();
        public FryingService FryingService = new();
        public ServingService ServingService = new();
        public EatingService EatingService = new();
        public CookingService() { }
        public void Initialize() 
        {
            string potatos = "potatos";
            string eggs = "egg";
            string onions = "onions";

            PreparingService.Peel(potatos);
            PreparingService.Clean(potatos);
            PreparingService.Cut(potatos);
            PreparingService.Peel(onions);
            PreparingService.Cut(onions);
            PreparingService.Beat(eggs);

            FryingService.Fry(onions);
            FryingService.Fry(potatos);

            string onionsAndPotatos = PreparingService.Combine(onions, potatos);
            FryingService.Fry(onionsAndPotatos);

            ServingService.Serve();
            EatingService.Eat();
        }
    }
}
