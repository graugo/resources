using OCP_exercise.Model;
using OCP_exercise.Services;

PlanetSystem[] systemList =
    {
        new OpenSystem("SolarSystem"),
        new OpenSystem("AteneosSystem", 3),
        new OpenSystem("DwarfSystem", 21),
        new ClosedSystem("UmbraSystem"),
        new ClosedSystem("EruSystem", 2.2M),
        new ClosedSystem("IlluvitarSystem", 100)
    };
AnalyzeService analyzeService = new AnalyzeService(systemList);
Component c = new Component("WarpDrive", "A driver for warp travel", 1000000);
analyzeService.Initialize(c);

