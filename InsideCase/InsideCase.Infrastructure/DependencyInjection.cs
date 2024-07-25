using InsideCase.Data;
using InsideCase.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using InsideCase.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using InsideCase.Application.Services.OrderService;
using InsideCase.Application.Services.ProductService;
using InsideCase.Application.Services.OrderService.Interfaces;
using InsideCase.Application.Services.ProductService.Interfaces;
using InsideCase.Data.Command.ProductCommand;
using InsideCase.Data.Command.OrderCommand;
using InsideCase.Data.Command.ProductOrderCommand;

namespace InsideCase.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddHandler();
            services.AddServices();
            services.AddCommand();

            return services;
        }

        public static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddAutoMapper(Core.AssemblyReference.Assembly);
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IManageOrderService, ManageOrderService>();
            services.AddScoped<ISearchOrderService, SearchOrderService>();

            services.AddScoped<IManageProductService, ManageProductService>();
            services.AddScoped<ISearchProductService, SearchProductService>();

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IProductOrderRepository), typeof(ProductOrderRepository));

            services.AddScoped(typeof(DbContext), typeof(InsideCaseContext));

            return services;
        }

        public static IServiceCollection AddCommand(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISaveOrderCommand), typeof(SaveOrderCommand));
            services.AddScoped(typeof(IUpdateOrderCommand), typeof(UpdateOrderCommand));
            services.AddScoped(typeof(IRemoveOrderCommand), typeof(RemoveOrderCommand));

            services.AddScoped(typeof(ISaveProductCommand), typeof(SaveProductCommand));
            services.AddScoped(typeof(IUpdateProductCommand), typeof(UpdateProductCommand));
            services.AddScoped(typeof(IRemoveProductCommand), typeof(RemoveProductCommand));

            services.AddScoped(typeof(ISaveProductOrderCommand), typeof(SaveProductOrderCommand));

            return services;
        }
    }
}