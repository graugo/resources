using Decorator.Model;
using Decorator.Model.Decorator;

INotifier notifier = new Notifier();

notifier = new FacebookDecorator(notifier);
notifier = new SlackDecorator(notifier);
notifier = new SMSDecorator(notifier);

while (true)
{
    notifier.Send(Console.ReadLine());
}

