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

# ποΈ Layers

ποΈ Layers
π Entities Layer
It is the layer created to hold database objects to be used in the project.
It consists of three sub-folders.
  1.The Abstract folder has been moved to the Core layer to keep the abstract objects (Abstract folder has been moved to the Core layer since it contains common codes in the projects that will be developed later.),
  2.Concrete folder for holding concrete objects
  3.The folder DTOs is used to give different properties to objects and to combine tables in the database.

    πAbstract
        π IEntity
    π Concrete
        π Category
        π Product
        π ProductImages
    π DTOs
        π ProductDeailDto

π DataAccess Layer
Database is the data access layer established to perform CRUD operations.
It consists of two subfolders.
  1.Abstract folder to hold abstract objects,
  2.Concrete folder to hold concrete objects.


    πAbstract
        π ICategoryDal
        π IProductDal
        π IProductImagesDal
    π Concrete
       π EntityFrameWork
             π EfCategoryDal
             π EfProductDal
             π EfProductImagesDal
             π ProductDbContext

π Business Layer
It is the layer that processes the data captured by DataAccess from the database to the project. In other words, it is the layer on which workloads are written. It consists of four subfolders.
  1.Abstract folder to hold abstract objects,
  2.Concrete folder to hold concrete objects.
  4.Constants folder for the management of information messages as a result of the operation performed with user data,
  5.To create the DependecyResolvers folder instance,


    πAbstract
        π ICategoryService
        π IProductImagesService
        π IProductService
    πConcrete
        π CategoryManager
        π ProductImagesManager
        π ProductManager
    πConstants
        π Messages
    πDependecyResolvers
       π Autofac
             π AutofacBusinessModule

π Core Layer
It is a universal layer with common codes to be used in all projects.
It consists of seven sub-folders.
  1.Aspects folder,
  2.CrossCuttingConcerns folder,
  3.DataAccess folder,
  4.Entities folder,
  5.DependecyResolvers folder,
  6.Extensions folder,
  7.Utilities folder,


    πAspect
       π Autofac
          π Caching
             π CacheAspect
             π CacheRemoveAspect
          π Performance
             π PerformanceAspect
          π Transactional
             π TransactionScopeAspect
          π Validation
             π ValidationAspect
    πCrossCuttingConcerns
          π Caching
             π Microsoft
                π MemoryCacheManager
          π Validation
             π ValidationTool
    πDataAccess
          π EntityFramework
             π EfEntityRepositoryBase
    πDependecyResolvers
        π CoreModule
    πEntities
        π IDto
          πConcrete
             π OperationClaim
             π User
             π UserOperationClaim
    πExtensions
        π ClaimExtensions
        π ClaimsPrincipalExtensions
        π ServiceCollectionExtensions
    πUtilities
          πBusiness
             π BusinessRules
          πInterceptors
             π AspectInterceptorSelector
             π MethodInterception
             π MethodInterceptionBaseAttribute
          πIoC
             π ICoreModule
             π ServiceTool
          πResults
             π DataResult
             π ErrorDataResult
             π ErrorResult
             π IDataResult
             π IResult
             π Result
             π SuccessDataResult
             π SuccessResult
          πSecurity
             πEncryption
                π SecurityKeyHelper
                π SigningCredentialsHelper
             πHashing
                π HashingHelper
             πJWT
                π AccessToken
                π ITokenHelper
                π JwtHelper
                π TokenOptions

π WebAPI Layer
    πControllers
        π CategoriesController
        π ProductImagesController
        π ProductsController

Thank you for taking your time to read. You can contact me from my accounts below.
