# Conceptos básicos
## Variables
Es algo que declaramos y que se almacena en la memoria con un valor y tipo definido, este puede tener diferentes estados
- normal      -> una declaracion del tipo var a = 0 ó int a = 0.
- estatica    -> una declaracion del tipo static var a = 0 ó static int a = 0, esta declaración hara que esta variable no sea relativa a la instancia en la que nos encontramos, puede variar su valor en run time.
- constante   -> una declaracion del tipo const var a = 0 ó const int a = 0, esta declaracion provoca que la variable no puede cambiar bajo ningun concepto.

## Tipos
[Documentación MSDN](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/)

Dentro de C# hay diferentes tipologias para las variables. Las basicas serian
- string
- int
- bool
- decimal

Hay mas tipos básicos pero por el momento solo trabajaremos con estos.

Tenemos tipos mas complejo como podrian ser
- DateTime
- List
- Enumerable

Estos tipos ya vienen dados por el propio lenguaje.

También podemos generar nuestros propios tipos, eso se lleva a cabo creando una clase. A esta le podemos definir propiedades y funciones propias.

### Tipos extra
Interfaces, nos sirven para definir el comportamiento de los objetos pero sin definir el qué.

Tipos genericos, nos sirve para crear código en el cual no tenga peso el tipo con el que se trabaja.

Tipos anonimos, Es una manera de definir un objeto sin especifiar el tipo de este.

## Operadores
Podemos utilizar diferentes tipos de operadores, estos sirve para juntar o realizar comparaciones.

[Lista de operadores](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/)
