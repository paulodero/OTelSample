using ConsoleApp;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Diagnostics;

// Define some important constants to initialize tracing with
var serviceName = "SampleService";

// Configure important OpenTelemetry settings and the console exporter
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource(serviceName).SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName: serviceName))
    .AddConsoleExporter()
    .Build();

var MyActivitySource = new ActivitySource(serviceName);

using var activity = MyActivitySource.StartActivity("SayHello");

Greetings.SayHello(MyActivitySource);

activity?.SetTag("foo", 1);
activity?.SetTag("bar", "Hello Demo Friday!");
activity?.SetTag("baz", new int[] { 1, 2, 3 });