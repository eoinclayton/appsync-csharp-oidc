using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System;
using System.IO;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AwsDotnetCsharp
{
    public class Handler
    {
        public string Hello(Stream requestStream)
        {
            dynamic request = new JsonSerializer().Deserialize(new JsonTextReader(new StreamReader(requestStream)));
            Console.WriteLine($"Received request: {request.ToString()}");
            return (request.field == "helloWorld") ? "Hello World!" : "No hello for you :)";
        }
    }
}
