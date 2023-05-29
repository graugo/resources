# SOLID
Que es SOLID?

Son un conjunto de principios que nos ayudan a diseñar y realizar el código de una manera más eficiente, estable y mantenible en el tiempo.

## Principio de responsabilidad única
Este principio cosiste en mantener una única responsabilidad dentro de la ejecución del método/servicio, esta responsabilidad se puede ser funcional o técnica.
Por ejemplo, en el caso de realizar una obtención y datos y después un guardado, si están juntos, puede darse el caso que más adelante se quiera hacer consulta de esos datos de nuevo lo que nos lleva a tener que escribir de nuevo el código de consulta, si este está en un servicio propio o en un método propio lo podemos consumir las veces necesarias sin duplicar código.

## Ejercicio de ejemplo
Teniendo el siguiente código que describe un combate entre un heroe y un jefe como podriamos hacer que cumpliese este principio?
```c#
Hero hero = new Hero();
Boss boss = new Boss();

hero.Combat(boss);
boss.Combat(hero);
hero.Combat(boss);
boss.Combat(hero);

if (hero.Health <= 0) Console.WriteLine("Hero is dead!");
else Console.WriteLine("Hero heath" + hero.Health);
if (boss.Health <= 0) Console.WriteLine("Boss is dead!");
else Console.WriteLine("Boss health" + boss.Health);

public class Hero
{
    public Hero()
    {

    }

    public Hero(int damage, int defense, int health, bool buyScrolls)
    {
        _damage = damage;
        _defense = defense;
        _health = health;
        _buyScrolls = buyScrolls;
    }

    public int Health { get => _health; set { _health = value; } }

    private int _damage = 10;
    private int _defense = 3;
    private int _health = 20;
    private int _healthPotion = 0;
    private int _defenseScroll = 0;
    private int _damageScroll = 0;
    private bool _buyScrolls;

    public void Combat(Boss boss)
    {
        //buy fase
        if (_buyScrolls)
        {
            _defenseScroll++;
            _damageScroll++;
            _healthPotion++;
        }
        //hero power up
        if (boss.Health > 50 && (_defenseScroll > 0 && _damageScroll > 0))
        {
            _defense = _defense + 30;
            _damage = _damage + 50;
            _defenseScroll--;
            _damageScroll--;
        }
        //hero attack
        boss.Health = boss.Health - _damage;
        //hero defense
        if (_health < 10)
        {
            _health = _health + _defense;
        }
        //hero healing
        if (_health < 5 && _healthPotion != 0)
        {
            _health = _health + 25;
            _healthPotion--;
        }
    }
}

public class Boss
{
    public int Health { get => _health; set { _health = value; } }

    private int _damage = 20;
    private int _defense = 3;
    private int _health = 50;

    public Boss() { }

    public Boss(int damage, int defense, int health)
    {
        _damage = damage;
        _defense = defense;
        _health = health;
    }

    public void Combat(Hero hero)
    {
        //Boss defense
        _defense = _health + _defense;
        //Boss damage
        hero.Health -= _damage;
    }
}
```

## Principio de Abierto - Cerrado

## Principio de substitucion de Liskov

## Principio de segregacion de interfaces

## Principio de inversion de dependencias


# Ejercicio 4 OCP

Bienvenidos al mercado galactico dentro de nuestros servicios ofrecemos la posibilidad de conocer el valor de la mercancia en diferentes monedas y diferentes tipos de componentes segun el sistema.
Problema! hay sistemas anticuados o xenofobos que no quieren conocer las monedas de los otros sistemas o que necesitan informacion extra para algunos componentes.

Crear una aplicacion que utilizando OCP nos permita modificar esto sin alterar el comportamiento.