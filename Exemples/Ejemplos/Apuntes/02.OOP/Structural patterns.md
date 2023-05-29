Structural patterns
- Esta tipologia de patrones nos ayuda a como estructurar nuestros objetos.
- Estos son los patrones que tocaremos:
    - Adapter
    - Bridge
    - Composite
    - Decorator
    - Facade
    - Flyweight
    - Proxy
- Adapter
    - Se utiliza cuando necesitamos acceder a un endpoint que no es compatible con nuestra aplicacion, y no tenemos manera de cambiarlo.
    - Podemos hacer una analogia con los conectores ingleses y los europeos. 

    - Como implementar el patron
        - Crearemos una interfaz que conectara nuestros servicios, esta vacia
        - Crearemos una interfaz que definira los metodos en comun de los servicios
        - Crearemos un interfaz con los metodos especificos de cada servicio que implementara la primera interfaz, vacia, creada
        - Generaremos una implementacion para esta interfaz.
        - Generar la implementacion de la tercera interfaz.
        - Crearemos una implementacion del servicio1 pero que funcione con el servicio2 internamente
        - En program generamos el codigo para crear un servicio1 y utilizamos el adapter para poder utilizar un service2 como 1.
        ```c#
        interface IBase{}
        interface IAdapterAction{ void SelectConcrete(IBase base); void ConnectToConcrete();}
        interface IConcreteA : IBase{ void DoConcreteA();}
        class ConcreteA : IConcreteA{ public void DoConcreteA(){CW("A");}}
        interface IConcreteB : IBase{ void DoConcreteB();}
        class ConcreteB : IConcreteB{ public void DoConcreteB(){CW("B");}}
        class ConcreteAAdapter : IAdapterAction{ private IConcreteA concreteA;
        public void ConnectToConcrete(){concreteA.DoConcreteA();}
        public void SelectConcrete(IBase base){if(base is not IConcreteA){throw("no works!");}
        concreteA = (IConcreteA)base;}}
        class ConcreteAdapter : IConcreteA, IAdapterAction{ private IConcreteB concreteB;
        public void ConnectToConcrete(){concreteB.DoConcreteB();}
        public void DoConcreteA(){CW("A connect to Adapter");}
        public void SelectConcrete(IBase base){if(base is not IConcreteB){throw("no works!");}
        concreteB = (IConcreteB)base;}}
        var adapterAction = new ConcreteAAdapter();
        adapterAction.SelectConcrete(new ConcreteA());
        adapterAction.ConnectToConcrete();
        var concreteAdapter = new ConcreteAdapter();
        concreteAdapter.SelectConcrete(new ConcreteB());
        concreteAdapter.ConnectToConcrete();
        adapterAction.SelectConcrete(concreteAdapter);
        adapterAction.ConnectToConcrete();
        ```
    - Beneficios
        - Te permite hacer que tu aplicacion funcione con servicios incompatibles
        sin modificar su logica.
        - Cualquier adaptacion para la api incompatible se encuentra en un unico 
        sitio, lo que hace el codigo mas mantenible.
        - Funciona bien para apis de terceros que no suelen tener cambios.
    - Desventajas
        - El ejemplo que hemos tratado es trivial lo que hace que no comprendamos
        el verdadero cambio que supone crear un Adapter, ya que los mapeos pueden
        ser muy duros. Por eso siempre es mejor modificar el servicio si es posible.
        Y utilizar el patron para casos en que la api depende de terceros extrictmente
        o que hay muchas dependecias con otras aplicaciones y hace que el cambio 
        sea "caro".

- Composite
    - Nos permite crear de manera eficiente estructuras de arbol. Esto puede ser
    util en varias situaciones. Por ejemplo trabajando con ficheros y carpetas.

    - Como se implementar
        - Generamos una interfaz con la funcionalidad comun de todos nuestros objetos.
        - Generamos class1 que implementara la interfaz y nada mas.
        - Generaremos el Composite que implementara la interfaz y tendra funcionalidades para añadir objetos, eliminarlos y mostrarlos.
        - En Program instanciamos nuestro composite y le añadimos elementos.
        - Podemos generar otro con class1 ya que implementa la interfaz comun.
        ```c#
        interface IConcrete{string A {get;} void Do();}
        class ConcreteA : IConcrete{public ConcreteA(string a){A=a}
        public string A {get;}
        void Do(){CW("1"+A);}}
        class ConcreteB : IConcrete { private readonly List<IConcrete> concretes;
        public ConcreteB(string a){A=a; concretes= new ();}
        public string A {get;}
        void Do(){CW("2"+A);}
        void Add(IConcrete concrete){concretes.Add(concrete);}
        void Remove(string a){var concreteToRemove = concretes.FirstOrDefault(_=>_.A==a);
        if(concreteToRemove is not null) concretes.Remove(concreteToRemove);}
        void DoMore(string p){foreach(var i in concretes){i.Do();
        if(i is ConcreteB concreteB){concreteB.DoMore("3"+A);}}}}

        var concreteB = new ConcreteB("potato");
        concreteB.Add(new ConcreteB("subPotato"));
        concreteB.Add(new ConcreteB("subsubPotato"))
        var otherConcrete = new ConcreteB("Onion");
        otherConcrete.Add(new ConcreteB("subOnion"));
        otherConcrete.Add(new ConcreteA("OnionA"));
        otherConcrete.Add(new ConcreteA("OnionAA"));

        concreteB.Add(otherConcrete);
        concreteB.DoMore(string.Empty);
        ```
    - Beneficios
        - Es la mejor manera de trabajar con estructuras de arbol.
        - te fuerza a utilizar OCP.
    - Desventajas
        - muchos tipos de objetos diferentes puede provocar que no sea mantenible el codigo

- Decorator
    - Nos proporciona la posibilidad de modificar la funcionalidad de un objeto sin modificar el objeto
    como tal. Es parecido al adapter, nos proporciona un wrapper del objeto existente.
    - A diferencia del adapter utilizamos la misma interfaz que implementa el objeto original.
    - Esto nos da la posibilidad de añadir procesos nuevos si modificar el original.

    -Como se implementa.
        - Generamos la interfaz original y la implementacion original.
        - Generamos el Decorador, este implementa la interfaz original.
        - Generamos tantas implementaciones como necesitemos heredamos del decorador.
        - En program instanciamos el objeto original y los vamos sustituyendo por los decoradores.

        ```c#
        interface IFooService{bool Foo(); void Faa();}
        class FooService : IFooService{private string fuu = "fuu";
        void Faa(){fuu = "faa";}
        bool Foo(){if(fuu != "foo"){CW(fuu); fuu=="foo"; return true;}
        CW(fuu); return false;}}
        abstract class FooDecorator : IFooService{private IFooService foo;
        void SetFoo(IFooService foo){this.foo = foo;}
        virtual void Faa(){if(foo is not null){foo.Faa();}}
        virtual bool Foo(){if(foo is not null){return foo.Foo();}return false;}}
        class FooService1 : FooDecorator{override bool Foo(){if(base.Foo()){CW("FooService1");
        return true;}return false;}}
        class FooService2 : FooDecorator{private string fee = "fee";
        override void Faa(){base.Faa(); fee="faa";}
        override bool Foo(){if(!base.Foo()){if(fee == "faa"){CW(fee); fee = "foo"; return true;}return false;}return true;}}
        
        var fooService = new FooService();
        fooService.Faa();
        fooService.Foo();

        CW("FooService1");
        var fooService1 = new FooService1();
        fooService1.SetFoo(fooService);
        fooService1.Foo();

        CW("FooService2");
        var fooService2 = new FooService2();
        fooService2.SetFoo(fooService1);
        fooService2.Faa();
        fooService2.Foo();
        ```
    - Beneficios
        - Modificamos objetos sin acceder a su funcionalidad interna.
        - Respetamos OCP.
        - Respetamos SRP.
        - Es facil de testear cada uno de los Decorators que se generan.
    - Desventajas
        - Generar muchos Decorators puede complicar la mantenibilidad.
        - Lo que complica el eliminar alguno si fuese necesario.
        - En el caso que hemos tratado al añadir nuevas funcionalidades hemos perdido
        las anteriores, tenemos que pensar una manera de que esto no ocurra.
        - En el caso que no necesitemos modificar una funcionalidad de manera especifica
        puede ser mas util utilizar un Adapter.

