using AutoMapper;
using Homework2.Data.Model;
using Homework2.Dto.Dto;

namespace Homework2.Service.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
        }
       

    }
      
        
}
