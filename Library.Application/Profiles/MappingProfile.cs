using AutoMapper;
using Library.Application.Features.DigitalEntities.Queries.GetDigitalEntitiesList;
using Library.Application.ViewModels;
using Library.Domain.Common;
using Library.Domain.Entities;
using System.Linq;

namespace Library.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Audiobook, DigitalEntitiesListVM>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(y => "Audiobook"))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(y => y.CompanyId))
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(y => y.AuthorId));

            CreateMap<Book, DigitalEntitiesListVM>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(y => "Book"))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(y => y.CompanyId))
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(y => y.AuthorId));

            CreateMap<Magazine, DigitalEntitiesListVM>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(y => "Magazine"))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(y => y.CompanyId))
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(y => 0));

            CreateMap<Film, DigitalEntitiesListVM>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(y => "Film"))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(y => y.CompanyId))
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(y => y.DirectorId));

            CreateMap<AudiobookDto, Audiobook>()
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<FilmDto, Film>()
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<MagazineDto, Magazine>()
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
