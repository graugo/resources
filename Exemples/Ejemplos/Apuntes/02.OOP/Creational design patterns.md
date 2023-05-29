Creational design patterns 
    - Estos tipos de patrones nos dicen como crear objetos en en ciertas situaciones. Los que abordaremos serán: 
        - Factory 
        - Builder 
        - Singleton 
        - Abstract Factory 

    - Factory --  
        - Se utiliza para crear implementaciones concretas de un tipo particular de abstraccion o interfaz. 
        - Este patron se utiliza cuando necesitamos escojer de manera condicional la implementacion de un objeto en concreto. 
        
        - Que debemos hacer para implementar el patron? 
            - Crear una clase o interfaz que nos proporcione la base de nuestros objetos. 
            - Crear una clase o interfaz base con las responsabilidad de crear la instancia del objeto especifico. 
            - Lo siguiente sera generar los objetos concretos que necesitemos. 
            - Crear los "Creadores" de los objetos especificos. 
            - Añadir al codigo la condicion de creacion de cada objeto. 

        - Beneficios de utilizar un Factory 
            - Nos ayuda a mantener el SRP, ya que cada objeto concreto contiene sus responsabilidades. 
            - Nos ayuda a mantener el codigo y que este sea mas testeable, ya que los casos estan mejor divididos y se 
                pueden evaluar mejor. 
            - Nos da la posibilidad de unicamente tener que crear 1 vez el objeto concreto y poder reutilizar en el  
                código. 

        - Explicación de porque hemos generado un creador. 
            - Esto nos ayuda a poder hacer una abstraccion de la factoria, ya que podemos utilizar el creador para  
                crear diferentes tipos. Esto lo veremos mejor en el Abstract Factory. 

    - Abstract Factory 
        - Lo utilizamos para generar multiples instancias de objetos concretos. 
        - En esencia es muy parecido al Factory, pero nos da la posibilidad de combinar varios Factory.

          - Que debemos hacer para implementar el patron? 
            - En este paso crearemos varias clases o interfaces como base de nuestros objetos. 
            - Crear objetos especificos que implementaran las interfaces anteriores. 
            - Generar el Creador que contendra un metodo para crear cada uno de los objetos de las abstracciones anteriores. 
            - Generar un Creador por cada objeto concreto que necesitemos. 
            - Integrar en nuestro código. 

        - Beneficios de utilizar un Abstract Factory 
            - Los beneficios son los mismo que teniamos para el Factory. 

        - Porque usarlo 
            - Creacion de familia de objetos, en el caso de necesitar crear un objeto paso a paso utilizar un builder. 

    - Builder 
        - Es util para cuando se quiere crear un objeto por partes. 
        - Se pueden generar depende que partes de manera condicional. 
        - Cuando el orden para añadir las partes no tiene importancia. 

        - Que debemos hacer para implementar el patron? 
            - Primero generamos el objeto a crear. 
            - Generamos una interfaz que sera nuestro builder. 
            - Implementamos la interfaz y en cada paso iniciamos o implementamos la funcionalidad esperada. 
            - Generamos un "Director" que sera el que cree construya el objeto. 
            - Integramos dentro del código. 

        - Beneficios de utilizar un Builder 
            - Nos ayuda a cumplir SRP. 
            - Nos ayuda a mantener mejor el código y que sea más testeable. 
            - Si hemos generado un Director, nos ayuda a generar diferentes representaciones del mismo objeto. 

        - Desventajas de usarlo 
            - Genera más complejidad en el código, algo que seguramente podriamos solucionar solo con un abstract Factory 
                puede complicarse demasiado utilizando un Builder. 

    - Singleton 

        - Nos permite crear una unica instancia de un objeto en particular para toda la aplicacion. 
        - Esto lo logramos gracias a un constructor privado y a un metodo estatico que nos permite acceder desde fuera. 
 
        - Que debemos hacer para implementar el patron? 
            - Generar un objeto con un constructor privado. 
            - Generar un metodo estatico publico que nos permita acceder a la instancia. 
            - Generar una propiedad privada que contenga el objeto creado. 
            - La información del objeto se genera en el metodo estatico. 
            - Integrar en el código. 
         
         - Beneficios de utilizar un Singleton 
            - El objeto solo se inicia 1 vez, la primera vez que se invoca. 
            - El patron te fuerza a utilizar la misma instancia para toda tu aplicacion. 
            - Es facil de entender y de generar. 

        - Desventajas 
            - Rompe SRP, ya que tiene la responsabilidad de iniciarse y de generar sus funcionalidades. 
            - Si trabajamos con una aplicación multiHilo podemos encontrar el problema de que cada  
                hilo genere una instancia propia del objeto. 
            - No es facil de testear, ya que los metodos estaticos no se pueden mockear de forma normal. 
            - Un singlenton solo se puede usar como single instance. 
            - Si aplicamos DI a un singleton estamos obligados a que su uso sea single instance, ya que el patron 
                no se podra construir como normalmente y para asegurar que funcione como tal es la unica opcion. 
 