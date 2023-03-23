namespace WebApi;

public class ConsoleLogger : ILoggerService
{
    public void Write(string message){
        Console.WriteLine("Console Logger Mesagge + ",message);
    }
}