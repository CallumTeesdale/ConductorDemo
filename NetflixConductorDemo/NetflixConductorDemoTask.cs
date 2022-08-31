using SuperSimpleConductor.ConductorClient.Models;
using SuperSimpleConductor.ConductorWorker.WorkflowTasks;

namespace NetflixConductorDemo;

public class NetflixConductorDemoTask: WorkflowTask<NetflixConductorDemoTask>
{
    /// <inheritdoc />
    public NetflixConductorDemoTask(ILogger<NetflixConductorDemoTask> logger) : base(logger)
    {
    }

    /// <inheritdoc />
    protected override Task<ConductorTaskData> OnExecute()
    {
        Logger.LogInformation(@"
  _    _      _ _         ____             _                  _    _____       _ _     _ 
 | |  | |    | | |       |  _ \           | |                | |  / ____|     (_) |   | |
 | |__| | ___| | | ___   | |_) | __ _  ___| | _____ _ __   __| | | |  __ _   _ _| | __| |
 |  __  |/ _ \ | |/ _ \  |  _ < / _` |/ __| |/ / _ \ '_ \ / _` | | | |_ | | | | | |/ _` |
 | |  | |  __/ | | (_) | | |_) | (_| | (__|   <  __/ | | | (_| | | |__| | |_| | | | (_| |
 |_|  |_|\___|_|_|\___/  |____/ \__,_|\___|_|\_\___|_| |_|\__,_|  \_____|\__,_|_|_|\__,_|
");
        var result = new ConductorTaskData(new Dictionary<string, object>()
        {
            {"message", "Hello from the Netflix Conductor Demo!"}
        });
        return Task.FromResult(result);
    }
}