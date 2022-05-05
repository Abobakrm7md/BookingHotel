using Autofac;
using BookingHotel.BLL.Intrefaces;
using BookingHotel.BLL.Services;
using MediatR;
using System.Linq;
using System.Reflection;

namespace BookingHotel.api.IOC
{
    public static class DependencyRegistrar 
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HotelService>().As<IHotelService>().InstancePerDependency();
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(BookingHotel.BLL)))
                .Where(x => x.Namespace.Contains("Intrefaces")).As(x => x.GetInterfaces().FirstOrDefault(x => x.Name == "I" + x.Name));
            return builder.Build();
        }
    }
}
