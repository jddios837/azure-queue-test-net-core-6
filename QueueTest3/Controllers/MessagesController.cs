using Microsoft.AspNetCore.Mvc;
using QueueTest3.Core;
using QueueTest3.Core.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace QueueTest3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : Controller
{
    // QUEUE Name in your emulator
    private string _queueName = "test";
    private readonly IQueueService _queueService;

    public MessagesController(IQueueService queueService)
    {
        this._queueService = queueService ?? throw new ArgumentNullException(nameof(queueService));
    }

    [HttpPost]
    public IActionResult Send([FromBody] Message queueMessage)
    {
        var message = JsonSerializer.Serialize(queueMessage);
        _queueService.SendMessage(_queueName, message);
        return Ok();
    }
}