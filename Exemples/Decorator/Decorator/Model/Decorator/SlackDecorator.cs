namespace Decorator.Model.Decorator
{
    internal class SlackDecorator : BaseDecorator
    {
        public SlackDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            SendSlack(message);
        }

        void SendSlack(string message)
        {
            Console.WriteLine($"Sent through Slack: {message}");
        }
    }
}
