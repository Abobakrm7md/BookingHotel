using Autofac;

namespace BookingHotel.BLL.IOC
{
    public interface IDependancyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}