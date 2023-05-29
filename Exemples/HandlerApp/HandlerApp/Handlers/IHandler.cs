using HandlerApp.Model;

namespace HandlerApp.Handlers
{
    internal interface IHandler
    {
        Worker Handle(Student student);
        IHandler SetNext(IHandler handler);
    }
}
