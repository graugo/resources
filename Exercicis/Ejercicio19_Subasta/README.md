# Ejercicio 19 Subasta

## New Features
### Nivel
- Tener en cuenta el nivel para el precio, para saber el nivel de nuestro pokemon hemos de sacarlo de la zona donde se capturo
- Este afectara al precio de la siguiente manera, precio = (Peso*Altura)+Nivel(ProbabilidadCaptura+IdLocalizacion)
- El nivel se ha de mostrar en la lista y en cuando se vea la subasta especifica
### Listado de pujas
- Ver el listado de pujas de una subasta especifica.
- Se ha de mostrar ordenado por fecha por defecto.
- Se ha de mostrar el incremento del precio.
    - Valor origen  
    - Incremento    
    - Valor final   

## MVP
1. Listado de Pokemons
    1. Mostrar un listado de pokemons segun la cantidad demandada, ej. 10 ó 10/20
    2. Información que ha de devolver el listado
        - ID de la subasta
        - Nombre
        - Precio de salida
2. Objeto de subasta
    1. Mostrar los datos especificos del Pokemon especifico
        - Peso
        - Altura
        - Localización de donde se atrapo
        - Probabilidad de captura
        - Shinny
        - Nombre
        - Precio de salida
        - Precio actual
        - Numero de pujas
3. Registro de subasta
    1. El registro de subasta es aleatorio o eso intentaremos
    2. Para que no sea una locura solo utilizaremos 10 pokemons a vuestra eleccion
    3. La cantidad de pokemons registrados como maximo puede ser de 50.
    4. El precio de salida se calcula con la siguiente formula
        - precio = (Peso*Altura)+(ProbabilidadCaptura+IdLocalizacion)
        - Si es shinny el precio anterior se multiplica por 20
        - La probabilidad de que un pokemon sea shinny hemos de calcularlo nosotros y es de 1/64
    5. Este registro tiene que quedar en BBDD
    6. La subasta estara viva un total de 5 min. 
4. Puja
    1. Hemos de poder incrementar el valor de la subasta aportando el ID y un valor
    2. Esto tiene que quedar reflejado como transacciones en BBDD
5. Historico
    1. Hemos de poder ver un registro de las subastas que han sido vendidas y cuales no.

## Casos de uso

1. Empezamos creando una una subasta con el endpoint:

	- `Register()` *Este enpoint crea la subasta para un pokemon a partir de un id extraido al azar de la primera generacion de pokemons. Una vez creada, esta subasta empezara inmediatamente y los usuarios podran empezar a hacer sus pujas. Para dar feedback de la subasta creada, el endpoint devuelve true/false segun si se ha podido crear la subasta*.

2. Mientras la subasta esta en funcionamiento los usuarios pueden hacer sus pujas con :

	- `PutBid(auctionId, value)` *Este endpoint crea una puja para una subasta. Para ello, se comprueba que la subasta este en funcionamiento y que la cantidad pujada supere el precio actual de la subasta. Si todo es correcto, devuelve true, indicando que la puja ha tenido exito*.

3. Para saber que pujas se estan llevando a cabo, los usuarios pueden consultar las subastas activas con:

	- `GetActiveAuctions()` *Este endpoint devuelve la lista de subastas activas. Para cada subasta, se devuelve el nombre de la subasta, el precio de entrada de la subasta y el propio Id de la subasta*.

4. Para poder ver en detalle una subasta activa, se puede consultar:

	- 'GetAuctionById(autionId)' *Este endpoint nos devolvera los detalles actuales de la subasta indicada*.

5. Si en algun momento se quiere conocer el historial de subastas realizadas, se puede consultar con:

	- `GetHistory()` *Este endpoint devuelve una lista con todas las subastas que se han realizado hasta el momento*.

6. Si se quiere ver el desarrollo que ha tenido una subasta, se puede consultar el endpoint:

	- 'GetTransactionsByAuctionId(auctionId)' *Este endpoint devuleve todas las transacciones que se han realizado sobre la subasta indicada con el Id proporcionado*.
