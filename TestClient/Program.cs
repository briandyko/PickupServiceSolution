using Grpc.Core;
using Grpc.Net.Client;
using PickupService;
using System;

namespace TestClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Calling a GRPC Service");
            Console.WriteLine("Hit enter to call the service....");
            Console.ReadLine();

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Putintante" });

            Console.WriteLine($"Got the response - {reply.Message}");

            //Console.WriteLine("Hit enter to get directions..");
            //Console.ReadLine();
            //var clientRouting = new TurnByTurn.TurnByTurnClient(channel);

            //var destination = new Destination { DestinationName = "Taco Bell" };

            //var replyRoute = clientRouting.StartGuidance(destination);

            //await foreach(var step in replyRoute.ResponseStream.ReadAllAsync())
            //{
            //    Console.WriteLine($"Turn {step.Direction} at {step.Road}");
            //}

            //Console.WriteLine("You have arrived. Enjoy your tacos");

            Console.WriteLine("Hit enter to estimate your order pickup date");
            Console.ReadLine();

            var estimatorClient = new PickupEstimator.PickupEstimatorClient(channel);

            var pickupRequest = new PickupRequest
            {
                For = "Jeff",

            };
            pickupRequest.Items.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7 });

            var estimatorResponse = await estimatorClient.GetPickupTimeAsync(pickupRequest);
            Console.WriteLine($"That'll be ready on {estimatorResponse.PickupTime.ToDateTime().ToShortDateString()}");
        }
    }
}
