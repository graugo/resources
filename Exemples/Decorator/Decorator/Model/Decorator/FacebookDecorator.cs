namespace Decorator.Model.Decorator
{
    internal class FacebookDecorator : BaseDecorator
    {
        public FacebookDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            SendFacebook(message);
        }

        void SendFacebook(string message)
        {
            Console.WriteLine($"Sent through Facebook: {message}");
        }
    }
}
