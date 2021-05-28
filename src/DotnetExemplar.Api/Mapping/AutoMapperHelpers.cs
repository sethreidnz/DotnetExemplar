using AutoMapper;

namespace DotnetExemplar.Api
{
  public static class AutoMapperHelpers
  {
    public static MapperConfiguration GetMapperConfiguration()
    {
      return new MapperConfiguration(cfg => cfg.AddMaps(typeof(Startup)));
    }
    
    public static IMapper GetMapper()
    {
      return GetMapperConfiguration().CreateMapper();
    }
  }
}