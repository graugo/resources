namespace Decorator.Model
{
    internal class Notifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Message Sent: {message}");
        }
    }
}
