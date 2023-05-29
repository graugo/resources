# Ejercicio 15 Torneo

## ChangeLog
### 0.0.0.0
- Se creara una solución WebApi con arquitectura N Layer basandonos en DDD
- En la capa de presentacion/servicios distribuidos situaremos el proyecto de WebApi en Net Framework 4.7.2
- En la capa de Dominio utilizaremos 2 niveles, aplicacion y dominio.
    - Aplicacion contendra las logicas del codigo.
    - Dominio contendra los modelos de dominio.
- En la capa de infrastructura se situara toda la comunicacion hacia el exterior.
### 1.0.0.0
- Se añadiran los siguientes controllers al proyecto de WebApi
    - TrainerController
    - TeamController
    - PokemonController
    - CombatController
- Añadir Swagger
- Añadir Autofac
### 1.0.0.1
- Añadir dependecias de Dominio a PokemonController
- Crear Modelos de PokemonController, Request y Response
- Crear Modelos de Dominio, entidades, de la parte de Pokemon (PokemonService)
- Crear DTOs de infrastructura de PokemonRepository
### 1.0.0.2
- Crear un ApiCaller en infrastructura.
- Crear un servicio de escritura y lectura en infrastructura.
- Devolver informacion en los metodos generados en infrastructura.
### 1.0.0.3
- Cacheado de datos de Pokemon.
### 1.1.0.0
- Implementar funcionalidades de Moves
### 2.0.0.0
- Generar endpoint creacion trainer
- Añadir dependencia con Dominio
- Generar TrainerService y sus dependencias
### 2.0.0.1
- Guardado de Trainer
### 2.1.0.0
- Logica de Trainer completa
## Descripción
Queremos ser el mejor entrenador pokemon, somo programadores y tenemos 10 años. Ya que nuestros conocimientos nos lo permiten hemos pensado crear una aplicación que nos ayude con los entrenamientos. 

**SOLO USAR LOS PRIMEROS 151 Pokemons**

Que necesitamos?
## Generacion de entrenador
- Necesitamos crear un entrenador aleatorio con un equipo de 3 pokemons.
- Cada pokemon tan solo ha de tener 4 movimientos.
- En este caso priorizaremos los movimientos ofensivos.
- Hemos de guardar los entrenadores para usos posteriores una vez generados.
- Se ha de tener en cuenta el orden.
### Entrada de datos
- No hay.
### Salida de datos
- Se mostrara el Id del entrenador.
- El formato utilizado para el id sera con GUID
```JSON
{
    "trainnerId":"0000-0000-0000-0000"
}
```

## Generacion de nuestro equipo
- Necesitamos poder seleccionar los 6 pokemons que utilizaremos en los combates.
- Cada pokemon tan solo ha de tener 4 movimientos.
- En este caso priorizameros los movimientos ofensivos.
- Podemos tener diferentes configuraciones del equipo.
- Se ha de tener en cuenta el orden.
### Entrada de datos
- Se podra introducir una coleccion de pokemons con los movimientos necesarios.
```JSON
[
    {
        "id": 1,
        "order": 1,
        "moves":[
            {
                "id":1
            },
            {
                "id":2
            },
            {
                "id":3
            }
        ]
    }
]
```
- Tambien se da la posibilidad de no informar nada y crear un equipo vacio.
### Salida de datos
- Se mostrara el Id del equipo.
- el formato utilizado para el ide sera con GUID.
```JSON
{
    "teamId":"0000-0000-0000-0000"
}
```

## Combate
- Hemos de tener en cuenta los tipos de nuestros pokemons a la hora de combatir.
- Hemos de tener en cuenta las estadisticas de nuestros pokemons.
- No tenemos que aplicar pociones ni potenciadores.
- El orden de los pokemons es importante
### Entrada de datos
- Solo se introducira el Id del Team que utilizaremos.
```JSON
{
    "teamId":"0000-0000-0000-0000"
}
```
### Salida de datos
- Se mostrara que entrenador gano.
- Se mostrara el estado de los Pokemons de cada equipo.
- El numero de turnos transcurrido en el combate.
```JSON
{
    "winnerId":"0000-0000-0000-0000",
    "turn" : 15,
    "trainerPokemons": [
        {
            "id": 9,
            "state": 0
        },
        {
            "id": 34,
            "state": 67
        }
    ],
    "teamPokemons":[
        {
            "id": 8,
            "state" : 100
        }
    ]
}
```

## Modificacion del equipo
- Hemos de ser capaces de modificar el orden, los pokemons o sus movimientos.

## Eliminar equipo
- Hemos de poder eliminar una configuracion de equipo.

## Eliminar entrenador
- Hemos de poder eliminar un entrenador generado, puede que se generen entrenadores demasiado poderosos o debiles.

## Metodos genericos
- Se necesitara un método de consulta de datos para:
    - Pokemon
    - Movimientos
    - Tipos
    - Entrenadores
    - Equipos

## Especificaciones Técnicas
- OOP
- SOLID
- Clean Code
- IOC
- DDD
- Patrones de diseño, si son necesarios
- Testing
- Control de errores
- Logging
- Los datos se han de guardar.
- Swagger