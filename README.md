# e-office | Redis Hackathon on Dev

### Table of contents

[Description](#project-description)



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


