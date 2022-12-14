using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Logic0ne.Controllers;

public class DebugExt : Controller
{
    private readonly IHostingEnvironment _hostingEnvironment;

    public DebugExt(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    // /DebugExt/GetDockerMode
    public bool GetDockerMode()
    {
        return _hostingEnvironment.IsDocker();
    }
    
    // /DebugExt/SendMessageRedis
    public string SendMessageRedis()
    {
        var configuration = "localhost:6379";
        if (_hostingEnvironment.IsDocker())
        {
            configuration = "redis_server:6379";
        }
            
        var connection = ConnectionMultiplexer.Connect(configuration);

// Get the Redis subscriber
        var subscriber = connection.GetSubscriber();

// Send a message
        subscriber.Publish("channel", "hello world 123 456 789");

        return $"item-sent";
    }
}