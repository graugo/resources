# Ejercicio de repaso
Estareis felices porque os habeis instalado ya en la isla, 
haceis una visita al ayuntamiento para ver que hay de nuevas y Canela (Isabelle) 
os comenta que teneis que hablar con Tom Nook sobre algo de una deuda por la instalación y la vivienda.

Apurados solicitais una cita. Al día siguiente descubris que no era gratis el tener una casa y 
un terrenito para ti. Tom Nook te solicita que le pagues una cuantia igual a 100.096.000 bayas.

Os veis en un apuro ya que actualmente no tienes esas bayas, asi que le preguntais cual seria la mejor manera
de conseguir esa cuantia. Os sugiere que recolecteis peces, insectos y criaturas marinas, ya que podreis venderlos
y asi obtener las bayas para pagar.

Llegais a vuestra nueva casa llorando, pero os surge una idea. Porque no crear una aplicacion que os ayude
a calcular la cantidad que necesitais para suplir la deuda.

Recordais que Tom Nook os dijo que solo acepta comprar 3 tipos de cada uno, eso quiere decir que solo 3 tipos de peces, 
3 tipos de insectos y 3 tipos de criaturas marinas. Podriais liaros a buscar cual es el mas eficiente a nivel de venta de cada uno
pero eso os quitaria un tiempo precioso. Asi que simplemente generais un aleatorio para obtener 3 de cada.

Tom Nook os comento que solo hay 80 tipos de peces, 80 tipos de insectos y 40 tipos de criaturas marinas. Tambien
os dijo que cuidado con el tiempo, ya que no todos los tipos estan disponibles en todas las epocas. Esto quiere decir
que tenemos que tener en cuenta la fecha en la que queremos realizar los trabajos de recoleccion.

En resumen, la api a crear deberia solicitar:
- Cuantia del prestamos
- Fecha de recoleccion
- Idioma

Y respondera lo siguiente:
- Idioma de respuesta
- Total de ganacias
- Deuda restante
- Insectos
  - Nombre
  - precio unidad
  - Total capturados
  - precio total
  - precio unidad especial
  - total precio especial
  - Frase de captura
  - Url de icono
- Peces
  - Nombre
  - precio unidad
  - Total capturados
  - precio total
  - precio unidad especial
  - total precio especial
  - Frase de captura
  - Url de icono
- Criaturas marinas
  - Nombre
  - precio unidad
  - Total capturados
  - precio total
  - Frase de captura
  - Url de icono

- En el caso de no informar de la Cuantia se tomara la que os dio Tom Nook.
- En el caso de no informar la fecha se obtendra la del día que se realice la petición.
- En el caso de no informar del idioma se usara inglés.