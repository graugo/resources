# GIT
- Trabajar con comandos - Git bash
- https://git-scm.com/docs
    - init
        - Inicia un repositorio local de git
    - Clone
        - Primero de todo hemos de situarnos en la carpeta donde queremos realizar la descarga del repositorio.
        - para situarnos utilizamos el comando cd y navegamos hasta donde queramos
        - una vez situados, escribimos en la consola git clone <url> 
        - la url!! la podemos extraer del repositorio de codigo, vamos a ADOS y alli hay un boton que nos indica la url para hacer el clone
        - nos indicara en pantalla los que descarga y ya tendremos nuestro repositorio bajado
    - add
        - en nuestro repositorio realizaremos cambios, estos cambios seran detectados por git, pero no se añadiran para ser enviados
        - para añadir los ficheros podemos hacer git add <ruta> esto añadira el fichero en especifico
        - si lo que queremos es añadir todos los ficheros con una extension seria asi git add *.cs
        - otra opcion que podemos hacer mas a lo bruto es añadir todo lo modificado, para ello hacemos git add -A ó git add --all
    - status
        - nos muestra el estado de los cambios en nuestro repositorio local
        - si hacemos git status -v veremos los cambios que estan en staged, este estado es el que se da para los cambios que se quieren llevar al 
        repositorio de origen
        - si hacemos git status -u veremos los cambios que no estan en staged
    - commit
        - cuando lanzamos esta instruccion es para llevar nuestros cambios a origen
        - para lanzarla correctamente seria de la siguiente manera git commit -am firstcommit
        - -a indica que se tendran en cuenta todos los cambios en estado staged
        - -m nos permite escribir un mensaje en nuestro commit
    - branch
        - nos permite ver las ramas, crearlas o eliminarlas
        - manera de utilizarlo git branch -l, esto nos permite ver las ramas de nuestro repositorio
        - git branch -d <branchName>, esto nos permite eliminar la rama especifica
    - Checkout
        - nos permite situar nuestro codigo en una rama en expecifico
        - git checkout <branchName> nos situa en la rama del nombre
        - git checkout -b <branchname> genera una rama nueva y nos situa en ella
    - switch
        - nos permite cambiar de rama
        - git switch -c <branch> crea una rama nueva
    - merge
        - git merge nos permite hacer un merge a la rama master
        - cuidado con hacer merge con git pueden haber conflictos importantes
    - fetch
        - nos trae los cambios desde los origenes, pero no hace pull de ellos
        - git fetch -all para hacer un fetch de todo el repositorio
    - pull
        - nos actualiza las rama locales del remoto
        - git pull ya hace la funcion
    - push
        - git push ya hace la funcion es raro querer actualizar mas de una rama del mismo repositorio
    - cherry-pick
        - solo lleva los cambios de los commits existentes
        - no suelo utilizarlo, pero en ocasiones es util
- Uso de ADOS
    - Historial de cambios
    - Pull Request
    