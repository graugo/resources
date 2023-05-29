# Ejercicio 12 Adventure

Los dioses caprichosos y jugotenos nos han encomendado la tarea de crear una aplicación con la tecnologia Windows communication foundation, que nos permita crear heroes y ver 
como progresan en un mundo de penurias y desencuentros.

Que información nos proporcionaran los dioses?
- Nombre
- Clase
- Palabra clave

Nuestro heroe a de vivir diferentes situaciones que le hagan crecer y fortalecerse. Este crecimiento a de ser observable por los dioses.

Que información mostraremos a los dioses?
- Id
- Nombre
- Clase
- Fuerza
- Destreza
- Inteligencia
- Armas (coleccion de armas)
- Pociones (coleccion de pociones)
- Dinero

## Detalles funcionales
- La clase determinara que estadistica es la más alta.
- Las estadisticas tendrán un crecimiento aleatorio, la semilla que utilizaremos para esto será la palabra clave.
- Las armas se van obteniendo cada 10 dias de viaje. Tan solo se podrán tener 3 armas, la que lleve más tiempo en nuestro inventario debera ser vendida.
- Las pociones se obtenien cada 2 dias de viaje. Solo dispondremos de 5, siempre venderemos las pociones menos poderosas.
- Como hemos comentado al principio el mundo esta lleno de penurias y desencuentros, tenedlo en cuento cuando hagais la parte de iniciar la aventura.

## Interfaz del servicio
- string CreateCharacter(Character character);
- CharacterDescription JourneyInformation(string id);
- bool IniciateJourney(string id, int daysToTravel);

## Detalles técnicos
- OOP
- SOLID
- Clean code
- WCF
- IOC
- Patrones de diseño