namespace Decorator.Model.Decorator
{
    internal class SMSDecorator : BaseDecorator
    {
        public SMSDecorator(INotifier notifier) : base(notifier) { }
        public override void Send(string message)
        {
            base.Send(message);
            SendSMS(message);
            
        }
        void SendSMS(string message)
        {
            Console.WriteLine($"Sent through SMS: {message}");
        }
    }
}
