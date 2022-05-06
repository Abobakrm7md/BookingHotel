using BookingHotel.api.Application.CostomMeddileWares;
using BookingHotel.api.Configurations;
using BookingHotel.BLL.Intrefaces;
using BookingHotel.BLL.Services;
using BookingHotel.DAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using BookingHotel.api.Application.Validations.RoomValidator;

namespace BookingHotel.api
{
    public class Startup
    {
        public BookingHotelSettings  BookingHotelSettings { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            BookingHotelSettings = configuration.Get<BookingHotelSettings>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            services.AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
                fv.RegisterValidatorsFromAssemblyContaining<RoomRequestValidation>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookingHotel.api", Version = "v1" });
            });
            services.AddEntityFrameworkSqlServer();
            services.AddDbContextPool<BookingHotelContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(BookingHotelSettings.ConnectionString);
                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });


           
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoomService, RoomService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookingHotel.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
