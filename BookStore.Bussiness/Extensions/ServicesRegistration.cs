using BookStore.Bussiness.Abstract;
using BookStore.Bussiness.Concrete;
using BookStore.Bussiness.Mapping;
using BookStore.Bussiness.Validation;
using BookStore.Bussiness.Validation.Author;
using BookStore.Bussiness.Validation.Book;
using BookStore.Bussiness.Validation.Category;
using BookStore.Bussiness.Validation.User;
using BookStore.Core.DataAccess.Abstract;
using BookStore.Core.DataAccess.Concrete;
using BookStore.Core.Helpers.CloudinaryHelper;
using BookStore.Entities.DTOs.Author;
using BookStore.Entities.DTOs.Book;
using BookStore.Entities.DTOs.Category;
using BookStore.Entities.DTOs.Order;
using BookStore.Entities.DTOs.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;


namespace BookStore.Bussiness
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(AppRepository<>));

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IOrderService, OrderManager>();


            //MAPPINGS
            services.AddAutoMapper(
                typeof(AuthorProfile),
                typeof(CategoryProfile),
                typeof(BookProfile),
                typeof(UserProfile),
                typeof(RoleProfile),
                typeof(OrderProfile)
            );

            //VALIDATION
            services.AddTransient<IValidator<UserCreateDto>, UserCreateValidator>();

            services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();

            services.AddTransient<IValidator<AuthorUpdateDto>, AuthorUpdateValidator>();
            services.AddTransient<IValidator<AuthorCreateDto>, AuthorCreateValidator>();

            services.AddTransient<IValidator<BookUpdateDto>, BookUpdateValidator>();
            services.AddTransient<IValidator<BookCreateDto>, BookCreateValidator>();

            services.AddTransient<IValidator<OrderCreateDto>, OrderCreateValidator>();
            services.AddTransient<IValidator<OrderUpdateDto>, OrderUpdateValidator>();

            //CLOUDINARY
            services.AddScoped<IFileService, CloudinaryService>();

            //REDIS FOR BASKET
            services.AddSingleton<IConnectionMultiplexer>(opt =>
            {
                var configuration = ConfigurationOptions.Parse("127.0.0.1:6379", true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            return services;
        }
    }
}
