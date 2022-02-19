## CarRental-Backend
It is the backend project provides car rental service.
This project strictly implements the **OOP**, **SOLID** and **AOP** principles. An objective approach was followed throughout the project. The project also has unit testing.
In addition to the backend project, the frontend part with Angular continues to be developed.

## Used Technologies And Principles
- ASP.NET Core 5.0
- Layered Architecture (Core, Entity, DataAccess, Business, API Layers)
- SQL Server 2019
- Entity Framework Core 5
- Generic Repository Pattern / Unit of Work Pattern / Adapter Pattern
- RESTful API
- OOP, AOP, SOLID
- JWT (JSON Web Token)
- Password Hashing / Salting
- Redis / InMemory Cache (As alternative to each other)
- IoC
- Autofac
- FluentValidation

# 🗂️ Layers

🗂️ Layers
📁 Entities Layer
It is the layer created to hold database objects to be used in the project.
It consists of three sub-folders.
  1.The Abstract folder has been moved to the Core layer to keep the abstract objects (Abstract folder has been moved to the Core layer since it contains common codes in the projects that will be developed later.),
  2.Concrete folder for holding concrete objects
  3.The folder DTOs is used to give different properties to objects and to combine tables in the database.

    📂Abstract
        📋 IEntity
    📂 Concrete
        📋 Category
        📋 Product
        📋 ProductImages
    📂 DTOs
        📋 ProductDeailDto

📁 DataAccess Layer
Database is the data access layer established to perform CRUD operations.
It consists of two subfolders.
  1.Abstract folder to hold abstract objects,
  2.Concrete folder to hold concrete objects.


    📂Abstract
        📋 ICategoryDal
        📋 IProductDal
        📋 IProductImagesDal
    📂 Concrete
       📂 EntityFrameWork
             📋 EfCategoryDal
             📋 EfProductDal
             📋 EfProductImagesDal
             📋 ProductDbContext

📁 Business Layer
It is the layer that processes the data captured by DataAccess from the database to the project. In other words, it is the layer on which workloads are written. It consists of four subfolders.
  1.Abstract folder to hold abstract objects,
  2.Concrete folder to hold concrete objects.
  4.Constants folder for the management of information messages as a result of the operation performed with user data,
  5.To create the DependecyResolvers folder instance,


    📂Abstract
        📋 ICategoryService
        📋 IProductImagesService
        📋 IProductService
    📂Concrete
        📋 CategoryManager
        📋 ProductImagesManager
        📋 ProductManager
    📂Constants
        📋 Messages
    📂DependecyResolvers
       📂 Autofac
             📋 AutofacBusinessModule

📁 Core Layer
It is a universal layer with common codes to be used in all projects.
It consists of seven sub-folders.
  1.Aspects folder,
  2.CrossCuttingConcerns folder,
  3.DataAccess folder,
  4.Entities folder,
  5.DependecyResolvers folder,
  6.Extensions folder,
  7.Utilities folder,


    📂Aspect
       📂 Autofac
          📂 Caching
             📋 CacheAspect
             📋 CacheRemoveAspect
          📂 Performance
             📋 PerformanceAspect
          📂 Transactional
             📋 TransactionScopeAspect
          📂 Validation
             📋 ValidationAspect
    📂CrossCuttingConcerns
          📂 Caching
             📂 Microsoft
                📋 MemoryCacheManager
          📂 Validation
             📋 ValidationTool
    📂DataAccess
          📂 EntityFramework
             📋 EfEntityRepositoryBase
    📂DependecyResolvers
        📋 CoreModule
    📂Entities
        📋 IDto
          📂Concrete
             📋 OperationClaim
             📋 User
             📋 UserOperationClaim
    📂Extensions
        📋 ClaimExtensions
        📋 ClaimsPrincipalExtensions
        📋 ServiceCollectionExtensions
    📂Utilities
          📂Business
             📋 BusinessRules
          📂Interceptors
             📋 AspectInterceptorSelector
             📋 MethodInterception
             📋 MethodInterceptionBaseAttribute
          📂IoC
             📋 ICoreModule
             📋 ServiceTool
          📂Results
             📋 DataResult
             📋 ErrorDataResult
             📋 ErrorResult
             📋 IDataResult
             📋 IResult
             📋 Result
             📋 SuccessDataResult
             📋 SuccessResult
          📂Security
             📂Encryption
                📋 SecurityKeyHelper
                📋 SigningCredentialsHelper
             📂Hashing
                📋 HashingHelper
             📂JWT
                📋 AccessToken
                📋 ITokenHelper
                📋 JwtHelper
                📋 TokenOptions

📁 WebAPI Layer
    📂Controllers
        📋 CategoriesController
        📋 ProductImagesController
        📋 ProductsController

Thank you for taking your time to read. You can contact me from my accounts below.
