using NetflixConductorDemo;
using SuperSimpleConductor.ConductorWorker;

IHost host = Host.CreateDefaultBuilder(args)
                 .ConfigureServices((ctx, services) =>
                 {
                     services.AddConductorWorker(ctx.Configuration, new Uri("http://localhost:8080/api"));
                     services.AddWorkflowTasks("NetflixConductorDemo");
                 })
                 .Build()
                 .RegisterWorkflowTasks();

await host.RunAsync();