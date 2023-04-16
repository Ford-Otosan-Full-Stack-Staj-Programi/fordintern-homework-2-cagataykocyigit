using AutoMapper;
using Homework2.Data.Model;
using Homework2.Data.Repository.Abstract;
using Homework2.Data.UnitOfWork.Abstract;
using Homework2.Dto.Dto;
using Homework2.Service.Abstract;
using Homework2.Service.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Service.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IAccountService accountService;
        public PersonService(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IGenericRepository<Person> genericRepository) : base(unitOfWork, mapper, genericRepository)
        {
            this.accountService = accountService;
        }
    }
}
