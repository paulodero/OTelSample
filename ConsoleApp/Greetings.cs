namespace ConsoleApp;

using System.Diagnostics;

internal class Greetings
{
    internal static void SayHello(ActivitySource source)
    {
        var activity = source.StartActivity("Greetings");

        activity?.Start();

        Console.WriteLine("do Something");

        activity?.Stop();
    }
}
