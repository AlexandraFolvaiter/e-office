# e-office | Redis Hackathon on Dev

## Link to the application
[Link to the application](https://eofficeapp.azurewebsites.net/)

## Overview video 
[![Youtube](https://user-images.githubusercontent.com/17809789/187280074-fcc3ca59-bddc-435d-8137-a6b47761e516.png)](https://www.youtube.com/watch?v=ornpa9Fs8YU)

## Project description
eOffice is human resources platform that provides processes to onboard a new employee and to manage the benefits of the employees distributing the responsibilities between the different rolls.

Functionalities
* See all onboardings
* Create an onboarding
* See details of an onboarding
* See all system accounts requests
* Resolve a system account request

## Architecture and technologies
![a03d589d-d34d-403d-86fd-13e09f55e688](https://user-images.githubusercontent.com/17809789/187278724-3882c61c-9997-4c1c-bb58-1d3e054a28cc.png)

* Presentation project: Server Blazor Application using .Net 6.0
* Microservices: Web API using .Net 6.0
* Databases: SQL Server 
* Microservices communication: Redis pub/sub

Flow diagrams: 
1. Create the onboarding
![CreateOnboarding Flow](https://user-images.githubusercontent.com/17809789/187279055-87c56b43-0cde-4bdc-be9a-8d1d3d74ff3d.png)

3. Resolve a system account request
![resolve-sysytem-accounts-request-flow](https://user-images.githubusercontent.com/17809789/187279074-4f186016-9504-4c3d-9b8b-8172bbda0e76.png)

## How to run it locally?
### Prerequisites
1. .Net 6.0
2. 3 SQL server databases
3. A redis database

### Local installation
1. Add the connection strings in the appsettings.josn for each module for the databases
2. Set as startup projects: eOffice, eOffice.Onboardings.API, eOffice.Leave.API, eOffice.SystemAccounts.API
3. Run the projects

## How it works

### How the data is stored:

The microservices are communicating with each other using the pub/sub from redis, for each type of communication a different channel will be used.
3 channels
* SystemAccount_Channel 
    * Publisher: Onboardings Module
    * Subscriber:  SystemAccounts Module
* Leave_Channel
    * Publisher: Onboardings Module
    * Subscriber: LeaveBalance Module
* Onboarding_Channel
    * Publisher: SystemAccounts Module, LeaveBalance Module
    * Subscriber: Onboardings Module

Publis code

```
var modelAsString = JsonConvert.SerializeObject(model);
_pubSub.Publish("channel_name", modelAsString);
```

Subscribe code

```
connection.GetSubscriber()
    .Subscribe("channel_name", (channel, message) =>
    {
        // DO something
    });
```

## Deployment
The services are deployed in Azure in App Service.
The database are deployed in Azure.
The redis connection is created using Redis stack.


## More Information about Redis Stack

Here some resources to help you quickly get started using Redis Stack. If you still have questions, feel free to ask them in the [Redis Discord](https://discord.gg/redis) or on [Twitter](https://twitter.com/redisinc).

### Getting Started

1. Sign up for a [free Redis Cloud account using this link](https://redis.info/try-free-dev-to) and use the [Redis Stack database in the cloud](https://developer.redis.com/create/rediscloud).
1. Based on the language/framework you want to use, you will find the following client libraries:
    - [Redis OM .NET (C#)](https://github.com/redis/redis-om-dotnet)
        - Watch this [getting started video](https://www.youtube.com/watch?v=ZHPXKrJCYNA)
        - Follow this [getting started guide](https://redis.io/docs/stack/get-started/tutorials/stack-dotnet/)
    - [Redis OM Node (JS)](https://github.com/redis/redis-om-node)
        - Watch this [getting started video](https://www.youtube.com/watch?v=KUfufrwpBkM)
        - Follow this [getting started guide](https://redis.io/docs/stack/get-started/tutorials/stack-node/)
    - [Redis OM Python](https://github.com/redis/redis-om-python)
        - Watch this [getting started video](https://www.youtube.com/watch?v=PPT1FElAS84)
        - Follow this [getting started guide](https://redis.io/docs/stack/get-started/tutorials/stack-python/)
    - [Redis OM Spring (Java)](https://github.com/redis/redis-om-spring)
        - Watch this [getting started video](https://www.youtube.com/watch?v=YhQX8pHy3hk)
        - Follow this [getting started guide](https://redis.io/docs/stack/get-started/tutorials/stack-spring/)

The above videos and guides should be enough to get you started in your desired language/framework. From there you can expand and develop your app. Use the resources below to help guide you further:

1. [Developer Hub](https://redis.info/devhub) - The main developer page for Redis, where you can find information on building using Redis with sample projects, guides, and tutorials.
1. [Redis Stack getting started page](https://redis.io/docs/stack/) - Lists all the Redis Stack features. From there you can find relevant docs and tutorials for all the capabilities of Redis Stack.
1. [Redis Rediscover](https://redis.com/rediscover/) - Provides use-cases for Redis as well as real-world examples and educational material
1. [RedisInsight - Desktop GUI tool](https://redis.info/redisinsight) - Use this to connect to Redis to visually see the data. It also has a CLI inside it that lets you send Redis CLI commands. It also has a profiler so you can see commands that are run on your Redis instance in real-time
1. Youtube Videos
    - [Official Redis Youtube channel](https://redis.info/youtube)
    - [Redis Stack videos](https://www.youtube.com/watch?v=LaiQFZ5bXaM&list=PL83Wfqi-zYZFIQyTMUU6X7rPW2kVV-Ppb) - Help you get started modeling data, using Redis OM, and exploring Redis Stack
    - [Redis Stack Real-Time Stock App](https://www.youtube.com/watch?v=mUNFvyrsl8Q) from Ahmad Bazzi
    - [Build a Fullstack Next.js app](https://www.youtube.com/watch?v=DOIWQddRD5M) with Fireship.io
    - [Microservices with Redis Course](https://www.youtube.com/watch?v=Cy9fAvsXGZA) by Scalable Scripts on freeCodeCamp
