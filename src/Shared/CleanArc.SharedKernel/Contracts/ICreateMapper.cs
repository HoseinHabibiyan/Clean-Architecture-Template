using AutoMapper;

namespace CleanArc.SharedKernel.Contracts;

public interface ICreateMapper<TSource>
{
	void Map(Profile profile)
	{
		profile.CreateMap(typeof(TSource), GetType()).ReverseMap();
	}
}