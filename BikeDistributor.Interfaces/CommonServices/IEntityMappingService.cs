namespace BikeDistributor.Interfaces.CommonServices
{
    public interface IEntityMappingService
    {
        TDestination Map<TSource, TDestination>(TSource source)
            where TDestination: class
            where TSource: class;

    }
}
