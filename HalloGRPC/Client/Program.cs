using Grpc.Net.Client;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello gRPC!");


            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new HalloGRPC.Greeter.GreeterClient(channel);

          var result =   client.SayHello(new HalloGRPC.HelloRequest()
            {
                Vorname = "Fred",
                Nachname = "Feuerstein"
            });

            Console.WriteLine(result.Message);

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
