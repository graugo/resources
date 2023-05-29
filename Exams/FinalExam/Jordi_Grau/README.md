# **Vueling Sky Walker - On Boarding Passengers**

Trabajas como desarrollador de software para Vueling Sky Walker, y tu responsable, te solicita que diseñes e implementes una aplicación backend para ayudar a la tripulación de tierra del aeropuerto.

La aplicación debe devolver la siguiente información:
- Un listado con todos los pasajeros embarcados en cada vuelo de cada día e indicando si tienen maleta de mano (Max: 10kg).
- La suma total de pasajeros y equipaje embarcado de todos los vuelos por día.
- La media de kilogramos con dos decimales (pasajeros y equipaje) por número de vuelo.

Para esta tarea deberás crear una API, que devuelva los resultados en formato JSON o XML. 

Recursos a utilizar:
- Pasajeros: https://otd-exams-data.vueling.app/vueling-skywalker/passengers.json
- Equipaje por pasajero: https://otd-exams-data.vueling.app/vueling-skywalker/baggage.json
- Vuelos: https://otd-exams-data.vueling.app/vueling-skywalker/flights.json

**JSON SCHEMA PASSENGERS**
```
{
  "$schema": "http://json-schema.org/draft-04/schema#",
  "type": "object",
  "properties": {
    "name": {
      "type": "string"
    },
    "surname": {
      "type": "string"
    },
    "flightId": {
      "type": "string"
    },
    "passengerId": {
      "type": "integer"
    },
    "weight": {
      "type": "number"
    }
  },
  "required": [
    "name",
    "surname",
    "flightId",
    "passengerId",
    "weight"
  ]
}
```

**JSON SCHEMA BAGGAGE**
```
{
  "$schema": "http://json-schema.org/draft-04/schema#",
  "type": "array",
  "items": [
    {
      "type": "object",
      "properties": {
        "baggageId": {
          "type": "integer"
        },
        "passangerId": {
          "type": "integer"
        },
        "weight": {
          "type": "number"
        },
        "type": {
          "type": "string"
        }
      },
      "required": [
        "baggageId",
        "passangerId",
        "weight",
        "type"
      ]
    }
  ]
}
```

**JSON SCHEMA FLIGHTS**
```
{
  "$schema": "http://json-schema.org/draft-04/schema#",
  "type": "array",
  "items": [
    {
      "type": "object",
      "properties": {
        "flightId": {
          "type": "string"
        },
        "departure": {
          "type": "string"
        },
        "arrival": {
          "type": "string"
        },
        "flightDate": {
          "type": "string"
        }
      },
      "required": [
        "flightId",
        "departure",
        "arrival",
        "flightDate"
      ]
    }
  ]
}

```

Cómo el proceso de información es crítico necesitamos tener un plan de contigencia o plan B en el caso que no tengamos disponible la información desde los puntos de acceso de datos.
Para ellos, la aplicación deberá persistir la información cada vez que la obtengamos (eliminando y volviendo a insertar los nuevos datos). Puedes utilizar el sistema que prefieras para ello.

## **TIPS** 
* Estamos tratando con decimales, intenta no utilizar números con coma flotante.
* Después de cada cálculo, el resultado debe ser redondeado a dos decimales.
	
## **Como pistas te decimos lo que nos gustaría llegar a encontrar**
* Ver como separas por N capas el proyecto (Servicios distribuidos, capa de aplicación, capa de dominio, ...). 
* Ver como usas SOLID (separación de responsabilidades, Inversión de Dependencias, ...)
* Ver como controlas los errores y como los logueas.
* Ver si usas un correcto naming-convention y consistente.
* Ver como cubres el código con UnitTests.
	

  **Por favor, una vez finalizada la prueba simplemente debemos crear una petición de incorporación (Pull Request) hacía la rama de master del repositorio, y el último commit contenga en al descripción "Finished". Con esto podemos saber que la prueba ha sido finalizada.**