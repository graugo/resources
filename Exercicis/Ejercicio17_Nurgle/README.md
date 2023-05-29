# Ejercicio 17 Nurgle Registry
Como hábiles servidores del Nurgle, padre de la plaga, nos dedicamos a predicar con sus maravillosos dones, pero también nos gusta llevar un registro de lo que conseguimos.

 Por ello hemos de registrar cada uno de los efectos nuevos que generan los ingredientes que añadimos a nuestros calderos de plaga.

Llevamos a cabo 2 tipos de registro
	
- Ingredientes
- Efectos

### Ingredientes

Dentro de ingredientes los hemos identificado de manera única con un número, este se incrementa cada vez que introducimos uno nuevo.
También hemos de vincular el ingrediente con el efecto que genera.

En conclusión Ingrediente contiene un identificador, el nombre del ingrediente, el efecto y rareza.

### Efectos

Dentro de efectos también los identificamos de manera única, de la misma manera que ingredientes.

Efecto contiene un identificador, nombre del efecto, descripción del efecto y mortalidad.

Hay ingredientes que pueden generar efectos nuevos y estos han de ser añadidos al mismo tiempo que el ingrediente nuevo.


## Nos gustaría ver en la Web Api

- Método para introducir ingrediente + efecto	
- Método para mostrar ingredientes según rareza
- Método para mostrar efecto según mortalidad
- Método para actualizar efecto
- Método para eliminar ingrediente si la mortalidad del efecto es inferior a la indicada

## Especificaciones técnicas
- OOP
- SOLID
- IOC
- Design Patterns
- Testing
- Logging
- DB with EF
- Swagger