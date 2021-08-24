##  Project Architecture


### Clean.API
API application

<b>Dependency</b>
- Clean.Infrastructure.Data
- Clean.Infrastructure.IoC

### Clean.Application

- Interfaces
- Services
- Business Roles 

<b>Dependency</b>
- Clean.Domain

### Clean.Domain 
Application domain entities (Entidades do domínio da aplicação)

<b>Dependency</b>
There is not.

### Clean.Infrastructure.Data
Responsible for data access (Responsável pelo acesso aos dados)

<b>Dependency</b>
- Clean.Domain

### Clean.Infrastructure.IoC
Responsible for centralizing dependency injections

<b>Dependency</b>
- Clean.Domain
- Clean.Application
- Clean.Infrastructure.Data




#####Diego Armando - 2021



