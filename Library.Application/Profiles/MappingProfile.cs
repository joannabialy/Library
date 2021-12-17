using AutoMapper;
using Library.Application.ViewModels;
using Library.Domain.Entities;

namespace Library.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // LIST
            
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

            // DETAILS

            CreateMap<Audiobook, DigitalEntityDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(y => y.PublicationDate))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(y => "Audiobook"))
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            CreateMap<DigitalEntityDto, Audiobook>()
                .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(y => y.Date))
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            CreateMap<Book, DigitalEntityDto>()
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.MapFrom(y => "Book"))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(y => y.PublicationDate));

            CreateMap<DigitalEntityDto, Book>()
                .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(y => y.Date))
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            CreateMap<Film, DigitalEntityDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(y => y.PremiereDate))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(y => "Film"))
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            CreateMap<DigitalEntityDto, Film>()
                .ForMember(dest => dest.PremiereDate, opt => opt.MapFrom(y => y.Date))
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            CreateMap<Magazine, DigitalEntityDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(y => y.Issue))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(y => "Magazine"))
                .ForMember(dest => dest.Tags, opt => opt.Ignore());
        }
    }
}
