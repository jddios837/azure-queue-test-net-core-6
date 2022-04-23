namespace QueueTest3.Core;

public interface IQueueService
{ 
    void SendMessage(string queueName, string message);
}