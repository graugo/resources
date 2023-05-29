Logging
- El logging nos sirve para registrar errores e informacion funcional de nuestra aplicacion mientras esta esta en ejecucion
- Podemos declarar un log en casi cualquier punto de la aplicacion
- Reportar errores es util para visualizar rapido problemas en nuestra aplicacion
- Reportar comportamientos de negocio puede ser util para hacer estadisticas o ver cuantas veces ocurre
    - utilizar Log4Net
        - Instalar Log4Net en nuestra solucion
        - Agregar la linea [assembly: log4net.Config.XmlConfigurator] a AssemblyInfo
        - Se ha de poner al final del fichero
        - Añadir el siguiente bloque en el web.config | app.config
            - <configSections>
                <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,log4net" />
              </configSections>
            - Este bloque nos esta indicando que necesitaremos log4net
            - Despues añadiremos este otro bloque dentro de los tags de configuration
            - <log4net>
                <appender name="TestAppender" type="log4net.Appender.RollingFileAppender">
                 <file value="C:\Logs\logs.log" />
                 <encoding value="utf-8" />
                 <appendToFile value="true" />
                 <rollingStyle value="Date" />
                 <datePattern value="yyyyMMdd-HHmm" />
                 <layout type="log4net.Layout.PatternLayout">
                    <conversionPattern value="%date > [%logger]{%method} > %level:: %message%n" />
                 </layout>
                </appender>
                <root>
                 <level value="All" />
                 <appender-ref ref="TestAppender" />
                </root>
             </log4net>
            - La parte de appender nos indica como vamos a registrar los logs, en este caso haremos que el reporte se reparta por fechas o peso
            - Podemos utilizar otros tipos de appenders, fichero simple, bbdd, buffering (este nos da la posibilidad de hacer que la escritura sea cada X registros)
            - El tag file nos informa donde se guardaran los logs
            - appendtoFile, rollingStyle y el pattern nos indican si queremos ir añadiendo la informacion de manera continua al log, el ordenado que queremos y el estilo de la fecha
            - En la parte del Layout, indicaremos el patron a utilizar dentro de los logs
            - https://logging.apache.org/log4net/log4net-1.2.13/release/sdk/log4net.Layout.PatternLayout.html
            - Dentro del root, podemos especificar el nivel de log que se quiere escribir en el log
        - Una vez realizado lo anterior crearemos una clase para alojar Log4Net
        - Dentro de esta añadiremos lo siguiente
            - public static class Log4NetConfiguration
              {
                public static ILog GetLogger([CallerFilePath] string filename = "")
                {
                    return LogManager.GetLogger(filename);
                }
              }
        - Esta clase nos servira para establecer desde donde invocamos al log
        - Ahora cada vez que tengamos que invocar al logger deberemos añadir la siguiente linea a nuestra clase
            - private static  readonly ILog _log = Log4NetConfiguration.GetLogger();
        - Y utilizarlo donde lo necesitemos de la siguiente manera
            - _log.Error("Error");
- https://docs.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line
- https://blog.junglacode.org/memorias/tutoriales/log4net-c-instalacion-y-guia-rapida-para-vs2019/
