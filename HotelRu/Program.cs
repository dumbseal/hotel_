using Microsoft.EntityFrameworkCore;
using BusinessLogic.Services;
using Domian.Models;
using DataAccess.Wrapper;
using Microsoft.OpenApi.Models;
using System.Reflection;
namespace HotelRu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<HotelRusBookingContext>(
              options => options.UseSqlServer(
                  "Server=TAZIK;Database=HotelRus;User ID=sa;Password=Nikolaj77;TrustServerCertificate=True;"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Сайт бронирования отелей по Россиии",
                    Description = "Данный сайт поможет вам забронировать отель на любой вкус в любой части России",
                    Contact = new OpenApiContact
                    {
                        Name = "8800553535",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Лицензия",
                        Url = new Uri("https://hotel.d-mayakovka.ru/images/agreement/license-agreement.pdf")
                    }

                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

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
            app.MapControllers();

            app.Run();
        }
    }
}
