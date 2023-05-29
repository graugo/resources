using Ejercicio_SRP.Services;
using Ejercicio_SRP.Model;

FightService combatService = new FightService();
Boss Ganon = new Boss(20, 3, 75, "Ganon");
Hero Groose = new Hero(10, 3, 20, false, "Groose");
Hero Link = new Hero(12, 5, 20, true, "Link");

combatService.Fight(new Hero(), new Boss());
combatService.Fight(Groose, Ganon);
combatService.Fight(Link, Ganon);