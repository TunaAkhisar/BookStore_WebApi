namespace WebApi;

public class DbLogger : ILoggerService
{
    public void Write(string message){
        Console.WriteLine("Db Logger Mesagge + ",message);
    }
}