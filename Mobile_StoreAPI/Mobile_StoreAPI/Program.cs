
using Microsoft.EntityFrameworkCore;
using Mobile_StoreAPI.Models;
using Mobile_StoreAPI.Repository.IRepository;
using Mobile_StoreAPI.Services.OrderService;
using Mobile_StoreAPI.Services.OrderService.IOrderService;
namespace Mobile_StoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IDealService, DealService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<ILedgerService, LedgerService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //builder.Services.AddScoped(typeof(IBrandService<>), typeof(BrandService<>));
            //builder.Services.AddScoped(typeof(IDealService<>), typeof(DealService<>));

            builder.Services.AddDbContext<MobilePhoneStoreProjectContext>(opt =>
            {
                opt.UseSqlServer("Data Source=LAPTOP-T8OUTPA6;Initial Catalog=MobilePhoneStoreProject;Integrated Security=True;Trust Server Certificate=True;");
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}