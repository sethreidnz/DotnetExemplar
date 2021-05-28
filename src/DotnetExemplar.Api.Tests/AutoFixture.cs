using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoMapper;

namespace DotnetExemplar.Api.Tests
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(GetDefaultFixture)
        {
        }

        private static IFixture GetDefaultFixture()
        {
            var autoMoqCustomization = new AutoMoqCustomization();
            var fixture = new Fixture().Customize(autoMoqCustomization);

            // register objects which should omit recursion
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
              .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            // register the real IMapper implementation used by the API for use in unit tests
            fixture.Register(AutoMapperHelpers.GetMapper);

            return fixture;
        }
    }
}