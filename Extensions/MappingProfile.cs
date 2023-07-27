using ApiNet7.DtoModels;
using ApiNet7.Models;
using AutoMapper;

namespace ApiNet7.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookReadDto>();            
            CreateMap<BookUpdateDto, Book>();
            CreateMap<BookCreateDto, Book>()
                .AfterMap((dto, entity) =>
                {
                    entity.Guid = Guid.NewGuid();
                });
        }
    }
}
