using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace SjonnieLoper.Core.ServiceRegistration
{
    public static partial class MyServices
    {
        public static void RegisterRedisServices(this IServiceCollection services,
            params string[] ports)
        {
            foreach (string aPort in ports)
            {
                var connection = new Lazy<ConnectionMultiplexer>(() =>
                    ConnectionMultiplexer.Connect(aPort));
                services.AddSingleton(connection);
            } 
        } 
    }

    public class RedisConnectionFactory
    {
        private Dictionary<string, Lazy<ConnectionMultiplexer>> _connections { get; set; }
        public string[] AvailableConnections() => _connections.Keys.ToArray();

        public RedisConnectionFactory(params (string, string)[] namedConnections)
        {
            foreach (var port in namedConnections)
            {
                CreateConnection( port.Item1, port.Item2);
            } 
        }

        public RedisConnectionFactory(string name, string port)
        {
           CreateConnection(name, port); 
        }

        private void CreateConnection(string name, string port)
        {
            _connections = new Dictionary<string, Lazy<ConnectionMultiplexer>>();
            var connection = new Lazy<ConnectionMultiplexer>(() =>
                ConnectionMultiplexer.Connect(port));
            _connections.Add(name, connection);
        }

        public IEnumerable<Lazy<ConnectionMultiplexer>> GetConnection()
        {
            foreach (var connection in _connections)
            {
                yield return connection.Value;
            }
        }
        
        public ConnectionMultiplexer SingleConnection(string nameConnection) =>
            _connections[nameConnection].Value;
    }
}