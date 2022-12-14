// See https://aka.ms/new-console-template for more information

using StackExchange.Redis;

Console.WriteLine("Hello, World!");


ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

Console.WriteLine("Start Listen");
// Subscribe to a Redis channel
ISubscriber sub = redis.GetSubscriber();
sub.Subscribe("channel", (channel, message) =>
{
    // Print the received message to the console
    Console.WriteLine(message);
});

// Keep the program running so that we can receive messages
Console.WriteLine("Started");
Console.ReadLine();