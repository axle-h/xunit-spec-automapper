using System;
using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;

namespace Xunit.Spec.AutoMapper.Tests
{
    public class PocoSource
    {
        public string String { get; set; }

        public int Int { get; set; }
    }

    public class PocoDestination
    {
        public string String { get; set; }

        public int Int { get; set; }
    }

    public class PocoProfile : Profile
    {
        public PocoProfile()
        {
            CreateMap<PocoSource, PocoDestination>();
        }
    }

    /// <summary>
    /// The unit test project should define an application mapping spec that registers a type from each assembly where AutoMapper profiles are stored.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    /// <seealso cref="MappingSpec{TSource, TDestination}" />
    public abstract class ApplicationMappingSpec<TSource, TDestination> : MappingSpec<TSource, TDestination>
    {
        protected override ICollection<Type> ProfileTypes { get; } = new[] { typeof(PocoProfile) };
    }


    /// <summary>
    /// Then each mapping in each profile should have a specification class defined like this.
    /// Note that test data is generated automatically by AutoFixture.
    /// </summary>
    /// <seealso cref="ApplicationMappingSpec{PocoSource, PocoDestination}" />
    public class When_mapping_from_PocoSource_to_PocoDestination : ApplicationMappingSpec<PocoSource, PocoDestination>
    {
        [Fact] public void It_should_map_String() => Destination.String.Should().Be(Source.String);

        [Fact] public void It_should_map_Int() => Destination.Int.Should().Be(Source.Int);
    }
}
