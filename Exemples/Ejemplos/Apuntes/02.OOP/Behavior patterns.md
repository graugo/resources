Behavior patterns
- Nos dicen como los objetos deberian comportarse.
    - Chain of responsability
    - Visitor
    - Strategy
    - Command
    - Iterator
    - Mediator
    - Memento
    - Observer
    - State
    - Template Method

- Strategy
    - Nos permite construir un codigo mantenible en situaciones donde necesitamos aplicar condiciones logicas.
    - A diferencia de lo que se hace normalmente que es generar la pieza de logica y escribir su condicion especifica, lo que hacemos es extraer esa logica en un servicio.
    - Todas las clases implementan la misma interfaz, lo que posibilita que solo hay que llamar a una implemtacion especifica con la condicion especifica.
    
    - Como lo implementamos
        - Generamos una interfaz de la cual implementaran todos nuestros servicios con la logica.
        - La interfaz unicamente contendra el metodo que definira la accion este podra devolder o no valores.
        - Generar las implementaciones de nuestra interfaz.
        - Generamos un objeto de contexto que encapsulara la interfaz.
        - El objeto de contexto llamara al codigo para ejecutar la accion de la implementacion actual.
        - la implementacion esta en el contexto basada por alguna condicion logica.

        interface IStrategy{string ChangeLetters(string line);}
        class ReverseStrategy : IStrategy{ public string ChangeLetters(string line){return string.Reverse();}}
        class RandomStrategy : IStrategy{ public string ChangeLetters(string line){return string.Random();}}
        class OrderedStrategy : IStrategy{ public string ChangeLetters(string line){return string.Order();}}
        class StrategyContext{ private IStrategy strategy;
        public void SetStrategy(IStrategy strategy){ this.strategy = strategy;} public string ChangeLetters(string line){return strategy.ChangeLetters(line);}}

        var context = new StrategyContext();
        switch(input){case "Reverse": context.SetStrategy(new ReverseStrategy()); break;
        case "Random": context.SetStrategy(new RandomStrategy()); break;
        case "Ordered": context.SetStrategy(new OrderedStrategy()); break;
        default: break;}
        CW(context.ChangeLetters(inputToChange));
    - Beneficions
        - Reducimos la complejidad condicional de la logica del codigo y cada comportamiento esta en su propia Strategy.
        - se pueden cambiar los algoritmos facilmente durante el tiempo de ejecucion.
        - Como el contexto mantiene la Strategy, se puede ejecutar la logica de nuevo sin tener que evaluar la condicion.
        - el SRP y OCP se mantienen correctamente.
    - Desventajas
        - Puedes encontrar situaciones en que sea mas facil y rapido simplemente aplicar la logica de la condicion que crear todo el strategy.
        - C# nos proporcionas muchas herramientas que pueden generar el no tener que utilizar este patron. delegates, anonymous actions, etc.

- Chain of responsability
    - Este patron nos permite procesar multiples pasos para una accion.
    - algunos de los pass del proceso pueden tener una condiciones para añadirse y otros podran hacer que el acabe y no se ejecuten mas pasos.
    
    - Como lo implementamos
        - Crearemos una clase que represente el handler object
        - El Handler tendra un metodo que asigne su Successor, que sera otra instancia de Handler
        - El Handler tendra tambien una definicion del metodo actual que representa el paso que se esta ejecutando.
        - Cada implementacion concreta del Handler tendra alguna logica dentro de ese metodo que ejecutara su proceso y despues llamara al metodo del successor, si tiene uno.
        - Este metodo puede tener una condicion que detenga el proceso y devuelva algo.

        class Student{ public string Name {get; set;}
        public int Knowledge {get; set;}}
        class Worker{public string Name {get;}
        public bool Success {get;}
        public Worker(bool success, string name){
            Success = success;
            Name = name;
        }}
        abstract class StudentHandler{protected RequestHandler successor;
        public abstract Worker HandlerStudent(Student student);
        public void SetNext(StudentHandler successor){ this.successor = successor;}}
        class Week1 : StudentHandler{public override HandlerStudent(Student student){if(student.Name.Contains("a")) student.Knowledge++; else student.Knowledge--; if(student.Knowlegde == 0) return new Worker(student.Name, false); if(successor is not null) return successor.HandlerStudent(student); return new Worker(student.Name, true);}}
        Week2
        Week3
        Week4
        Exam1
        Week5
        Week6
        Week7
        Week8
        Exam2
        var handler1 = new Week1();
        var handler2 = new Week2();
        ...
        var student1 = new Student {Name = "Adrian", Knowledge = 0}
        var student2 = new Student {Name = "Pepe", Knowledge = 9}

        var worker1 = handler1.HandlerStudent(student1);
        var worker2 = handler1.HandlerStudent(student2);

        cw(worker1.Name + worker1.Success);
        cw(worker2.Name + worker2.Success);

    - Beneficios
        - los pasos a procesar pueden ser añadidos y elminados como quieras.
        - SRP esta bien implementado.
        - OCP esta bien implementado.
    - Desventajas
        - No tiene muchas desventajas
        - Puedes provocar que las peticiones no se respondan si tu cadena es muy compleja.
        - El orden es un factor importante, en el caso que no se pueda generar el patron sin tener en cuenta el orden de los pasos asegurate de documentarlo correctamente.

- Iterator
    - Permite al desarrollador encapsular una coleccion de cualquier complejidad interna de un objeto con una interfaz simple.
    - El consumidor de la interfaz podra iterar entro los elementos de la coleccion sin conocer los detalles de la implementacion.

    - Como implementarlo
        - Tendremos un objeto conocido como Aggregate o Collection. Este guardara la coleccion de objetos actual.
        - Esta coleccion podra tener cualquier tipo de estructura o complejidad.
        - Tendremos un objeto llamado Iterator, su funcion sera leer los objetos de la coleccion y exponerlos al mundo 1 a 1.
        - Iterator lee los objetos en un orden especifico y sabe siempre cual es.

        interface Iterator{ bool MoveNext(); int GetCurrent();}
        interface IAggregate{ Iterator CreateIterator(); void Insert(int value);}
        ListAggregate : IAggregate{private List<int> collection; 
        public ListAggregate(){collection = new List<int>();} 
        public IIterator CreateIterator(){return new ListIterator(this);} public int Count{get{return collection.Count;}} 
        public int this[int index]{ get {return collection[index];} set{ collection.Insert(index, value);}}
        public void Insert(int value){collection.Add(value);}} 
        class ListIterator : IIterator{ 
            private ListAggregate aggregate; 
            private int currentIndex; 
        public ListIterator(ListAggregate aggregate){ 
            this.aggregate = aggregate; currentIndex=-1;}
        public bool MoveNext(){ 
            if(currentIndex +1 < aggregate.Count){currentIndex++; return true;}return false;}
        public int GetCurrent(){
            return aggregate[current.Index];}}
        class Node{public Node(int value){Value = value;} 
        public int Value {get; set;} public Node Left {get; set;}
        public Node Right {get; set;} public Node Parent {get; set;}}
        class SortedBinaryTreeCollection : IAggregate{ 
            private Node root;
        public SortedBinaryTreeCollection(){ root = null;} 
        public Iterator CreateIterator(){ return new SortedBinaryTreeIterator(this);}
        public Node GetFirst(){ 
            var current = root; while(true){if(current?.Left is not null){current = current.Left;}else{return current;}}}
        public void Insert(int value){Node newNode = new Node(value);
        if(root is null){root = newNode;}else{Node parent; var temp = root;while(true){parent = temp; if(value < temp.Value){temp = temp.Left;if(temp is null){parent.Left = newNode; newNode.Parent = parent; return;}}else{temp= temp.Right; if(temp is null){parent.Right = newNode; newNode Parent = parent; return;}}}}}}
        class SortedBinaryTreeIterator : IIterator{ private readonly SortedBinaryTreeCollection aggregate; private Node current;
        public SortedBinaryTreeIterator(SortedBinaryTreeCollection aggregate){ this.aggregate = aggregate; current= null;}
        public int GetCurrent(){return current.Value;}
        public bool MoveNext(){ if(current is null){current = aggregate.GetFirst(); return true;} if(current.Right is not null){current = current.Right; while(true){if(current.Left is null){break;}current= current.Left;}return true;}else{ var originalValue = current.Value; while(true){if(current.Parent is not null){current = current.Parent; if(current.Value > originalValue){return true;}}else{return false;}}}}}

        var listOfValues = new List<int>{8,19,25,2,4};
        var listAggregate = new ListAggregate();

        foreach(var value in listOfValues)
        {
            listAggregate.Insert(value);
        }
        varlistIterator = listAggregate.CreateIterator();
        CW("");
        while(listIterator.MoveNext()){ CW(listIterator.GetCurrent());}

        var treeAggregate = new SortedBinaryTreeCollection();
        foreach(var value in listOfValues){treeAggregate.Insert(value);}

        var treeIterator = treeAggregate.CreateIterator();
        CW("");

        while(treeIterator.MoveNext()){ CW(treeIterator.GetCurrent());}

    -Beneficios
        - SRP se mantiene ya que cada manera de iterar esta separada.
        - si tienes que iterar en estructuras complejas de datos se simplifica mucho.
        - Puedes crear muchos Iterators por cada Aggregate, te da la posibilidad de iterarlos en paralelo.
    - Desventajas
        - Si trabajas con listas simples no lo apliques, ya se complica demasiado y C# ya provee de muchos mecanismos internos, tiene un Iterator propio para ellas.
        - Solo podemos atravesar la coleccion en 1 sentido y algunos casos esto no tiene porque ser lo mas eficiente.
        
