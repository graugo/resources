ASP.NET web app development
- ASP.NET Application Lifecycle
    - Nuestra aplicaciones ASP.NET estaran alojadas en IIS en modo Integrated
    - Nuestras request pasaran por 3 estados, el mapeo de la request, el Log de la llamada y el log posterior de la llamada.
    - tendremos bloques de codigo nativo y administrado que podran configurar nuestro web service, web site o web application.
    - en la parte de codigo administrado estan los modulos para la sesion, formularios de autenticacion, perfiles y gestion de roles.
    - la parte de codigo administrado se puede activar o desactivar para todas las request
    - el codigo administrado se puede invocar en cualquier punto, esto quiere decir que puede ocurrir antes del procesado de la request, despues del procesado o durante.
    - se puede habilitar o dehasabilitar los modulos desde el web.config de la aplicacion.
    - [image01](https://docs.microsoft.com/en-us/previous-versions/aspnet/images/bb470252.apppipeover(en-us,vs.100).png)
    - Estados del ciclo de vida
        - una peticion es realizada por una aplicacion
            - Se nos hace una peticion desde un navegador.
            - Recibimos la peticion a traves del RequestNotification, es la parte que nos permite capturar la request.
        - El proceso recibe la primera peticion
            - Se crea una instancia de ApplicationManager, esto nos crea la dominio de la aplicacion que procesara la request.
            - dentro del dominio se creara una instancia de hostingEnvironment que nos da la informacion de sobre nuestra aplicacion. Por ejemplo donde se almacena la aplicacion
            - durante este paso los elementos de alto nivel de la aplicacion se compilan si son necesarios.
        - Se crea una respuesta para cada peticion
            - despues de crear el domino de la palicacion y de que se intancie hostingEnvironment, se genera un httpContext, httpRequest y HttpResponse.
            - HttpContext contiene que especifica la peticion a la aplicacion actual, asi como los objetos HttpRequest y HttpResponse.
            - HttpRequest contiene la informacion de la peticion actual, esto incluye la informacion de las cookies y del navegador.
            - HttpResponse contiene la informacion que se devolvera el cliente, esto incluye la informacion y las cookies.
            - Podemos modificar el status de nuestra response para indicar fallos.
            - podemos modificar los headers de nuestra respuesta.
        - Un objeto httpAplication se asigna a la peticion
            - despues de que todos los objetos se hayan inicializado, se genera una instancia de httpApplication.
            - si la aplicacion contiene un global.asax, se crea una intancia de este que deriba de httpApplication y se utiliza el deribado.
            - Se reutiliza la instancia de httpApplication para multiples request para aumentar la performance.
            - Se cargaran los modulos, esto depende de los modulos administrados que se hayan seleccionado y definido en el web.config.
        - la peticion se procesa por httpApplication
            - Las siguientes tareas se realizan por httpApplication mientras la peticion se procesa.
                1. Validacion de la request, se examina que la infromacion dada por el navegador es correcta y no contienen nada raro.
                2. Se realiza el mapeo de la url, si se creo uno en web.config
                3. se lanza el evento BeginRequest
                4. se lanza el evento AuthenticateRequest
                5. se lanza el evento PostAuthenticateRequest
                6. se lanza el evento AuthorizeRequest
                7. se lanza el evento PostAuthorizeRequest
                8. se lanza el evento ResolveRequestCache
                9. se lanza el evento PostResolveRequestCache
                10. se lanza el evento MapRequestHandler
                11. se lanza el evento PostMapRequestHandler
                12. se lanza el evento AcquireRequestState
                13. se lanza el evento PostAcquireRequestState
                14. se lanza el evento PreRequestHandlerExecute
                15. se llama a ProcessRequest para el IHandler apropiado, por ejemplo si es una pagina se llamara a la pagina seleccionada.
                16. se lanza el evento PostRequestHandlerExecute
                17. se lanza el evento ReleaseRequestState
                18. se lanza el evento PostReleaseRequestState
                19. Se ejecuta el filtrado de la response, si se ha definido
                20. se lanza el evento UpdateRequestCache
                21. se lanza el evento PostUpdateRequestCache
                22. se lanza el evento LogResquest
                23. se lanza el evento PostLogRequest
                24. se lanza el evento EndRequest
                25. se lanza el evento PreSendRequestHeaders
                26. se lance el evento PreSendRequestContent
- ASP .NET MVC
    - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started
    - Lifecycle
        - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/lifecycle-of-an-aspnet-mvc-5-application
        - teniendo en cuenta lo anteriormente explicado ampliar añadiendo peculiaridades de MVC
        - [image](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/lifecycle-of-an-aspnet-mvc-5-application/_static/image1.jpg)
    - Testing
        - Ejecutar aplicacion y hacer debug
- ASP .NET Web API
    - https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
    - Lifecycle
        - seccion anterior
    - Testing
        - crear aplicacion y ejecutarla
    - Versioning
        - Esto se genera cuando se quieren manter algo en el tiempo se ha de modificar
        - hacer ejemplo
    - Documentation (Swagger / swashbuckle)
        - https://www.c-sharpcorner.com/article/swagger-for-net-mvc-web-api/
        - https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0
        - Del proyecto que hemos generado para la parte anterior
        - Añadir nugets Swashbuclke y swashbuclke.Core
        - marcar que se cree la documentacion XML
        - cambiar la url de inicio
        - eliminar morraya del archivo de config de swagger
- ASP .NET HTTP
    - Headers
        - https://en.wikipedia.org/wiki/List_of_HTTP_header_fields
        - Informacion que se incluye en la peticion para indicar formatos u otros valores utiles.
        - La respuesta tambien incluye headers.
    - Request
        - peticion que se envia
    - Response
        - respuesta de la api
    - Querystring
        - https://docs.microsoft.com/en-us/dotnet/api/system.web.httprequest.querystring?view=netframework-4.8
        - Esto se lleva a cabo cuando se incluyen valores en la URL y son capturados por nuestro servicio
    - Verb based routing (GET,POST,PUT,etc..)
        - https://www.w3schools.com/tags/ref_httpmethods.asp
            - GET
            - POST
            - PUT
            - HEAD
                - Es igual que GET pero sin dar respuesta al cliente
            - DELETE
            - PATCH
                - para indicar modificaciones parciales
            - OPTIONS
            - CONNECT
                - Para iniciar una comunicacion a 2 bandas
            - TRACE
                - Para hacer debug
    - CORS / Crossdomain
        - https://docs.microsoft.com/es-es/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api