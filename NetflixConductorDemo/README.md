### Netflix conductor demo

This is a demo of the Netflix Conductor service.

### Requirements

* Docker
* Docker Compose
* Either WSL or if on Mac you're good to go
* .NET 6.0
* Gradle

## Installation

Get the latest version of [Netflix Conductor](https://conductor.netflix.com/).

```bash
git clone https://github.com/Netflix/conductor.git
```

Enter the conductor directory

```bash
cd conductor
```

Enter the docker directory

```bash
cd docker
```

Build the docker compose

```bash
docker-compose build
```

Run the docker compose

```bash
docker-compose up 
```

## Running the demo

Conductor server is running on port 8080.

```bash
http://localhost:8080
```

The condutor UI is available at the following URL.

```bash
http://localhost:5000/
```

Now we can create a task definition, note that the endpoint requires the tasks to be an array.

```bash
[
  {
    "name": "NetflixConductorDemoTask",
    "description": "A demo task definition",
    "timeoutSeconds": 0,
    "timeoutPolicy": "TIME_OUT_WF",
    "responseTimeoutSeconds": 3600,
    "ownerEmail": "callum.teesdale@ivendi.com"
  }
]
```

We can take the above definition and post it to the conductor server.

```bash
curl -X POST -H "Content-Type: application/json" -d @NetflixConductorDemoTask.json http://localhost:8080/api/metadata/taskdefs
```

After creating our task we can create a workflow definition.

```bash

{
  "name": "NetflixConductorDemoWorkflow",
  "description": "A demo workflow definition",
  "version": 1,
  "schemaVersion": 2,
  "workflowStatusListenerEnabled": true,
  "ownerEmail": "callum.teesdale@ivendi.com",
  "tasks": [
    {
      "name": "NetflixConductorDemoTask",
      "taskReferenceName": "netflixConductorDemoTask",
      "type": "SIMPLE"
    }
  ]
}
```

We can take the above definition and post it to the conductor server.

```bash
curl -X POST -H "Content-Type: application/json" -d @NetflixConductorDemoWorkflow.json http://localhost:8080/api/metadata/workflow
```

Now we can create a workflow instance.

```bash
curl -X POST -H "Content-Type: application/json" http://localhost:8080/api/workflow/NetflixConductorDemoWorkflow
```

Now we can run our .NET application.

```bash
dotnet run
```

