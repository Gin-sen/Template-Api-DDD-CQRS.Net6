namespace My.DDD.CQRS.Temp6.Messaging.Configuration;

public class MessagingOptions
{
    public string? HostName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? VirtualHost { get; set; }

    public bool? SslEnabled { get; set; }

    public int? Port { get; set; }
}