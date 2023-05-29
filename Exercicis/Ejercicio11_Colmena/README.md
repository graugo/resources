# Ejercicio 11 Colmena

Hemos conseguido desarrollar unos pequeños microchips que podemos abderir a las abejas de nuestras colmenas para controlar la cantidad de polen recogido, el tiempo de actividad, si se encuentra activas y si han tenido algun incidente.

Lo que pasa es que recibimos los datos en 2 formatos diferentes JSON y XML, esto ocurreda por la versión de firmware de los chips, algunos estan desfasados.

Hemos de desarrollar una aplicacion de consola, nuestros equipos no dan para más :(, que nos permita ver la cantidad de polen por hora que es recogido.

Este método tambien nos ha de permitir filtrar por el estado de la abeja y los incidentes.


### JSON de datos
```Json
{
  "colmena": [
    {
      "id": 88364,
      "nombre": "abeja1",
      "recoleccion": 15888079.4545,
      "tiempo": 38497738984893946,
      "estado": true,
      "incidentes": 3
    },
    {
      "id": 88846,
      "nombre": "abeja45",
      "recoleccion": 9999877388.80,
      "tiempo": 345678987654567,
      "estado": false,
      "incidentes": 0
    }
  ]
}
```

### XML de datos
```XML
<colmena>
    <abeja>
        <id>8888860</id>
        <nombre>abeja67</nombre>
        <recoleccion>98765678765434.877</recoleccion>
        <tiempo>8854464647774</tiempo>
        <estado>false</estado>
        <incidentes>9</incidentes>
    </abeja>
    <abeja>
        <id>45678609</id>
        <nombre>abeja12</nombre>
        <recoleccion>770000974734.89743</recoleccion>
        <tiempo>56734340706066066</tiempo>
        <estado>true</estado>
        <incidentes>6</incidentes>
    </abeja>
</colmena>
```

## Detalle de los datos

- Recoleccion esta en microgramos
- Tiempo en segundos
- la salida se espera en gramos/hora

## Detalle técnico

- OOP
- DDD
- SOLID
- Clean code