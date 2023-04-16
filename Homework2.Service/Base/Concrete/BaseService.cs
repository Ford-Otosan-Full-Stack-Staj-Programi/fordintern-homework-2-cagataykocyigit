using AutoMapper;
using Homework2.Base.Response;
using Homework2.Data.Repository.Abstract;
using Homework2.Data.UnitOfWork.Abstract;
using Homework2.Service.Base.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Service.Base.Concrete
{
    public abstract class BaseService<Dto, TEntity> : IBaseService<Dto, TEntity> where TEntity : class
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IGenericRepository<TEntity> genericRepository;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<TEntity> genericRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.genericRepository = genericRepository;
        }
        public BaseResponse<List<Dto>> GetAll()
        {
            var entityList = genericRepository.GetAll();
            var mapped = mapper.Map<List<TEntity>, List<Dto>>(entityList);
            return new BaseResponse<List<Dto>>(mapped);
        }

        public BaseResponse<Dto> GetById(int id)
        {
            var entity = genericRepository.GetById(id);
            var mapped = mapper.Map<TEntity, Dto>(entity);
            return new BaseResponse<Dto>(mapped);   
        }

        public BaseResponse<bool> Insert(Dto insertResource)
        {
            try
            {
                var entity = mapper.Map<Dto, TEntity>(insertResource);

                genericRepository.Post(entity);
                unitOfWork.Complete();

                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "BaseService_Insert");
                return new BaseResponse<bool>(ex.StackTrace);
            }
        }

        public BaseResponse<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<bool> Update(int id, Dto updateResource)
        {
            throw new NotImplementedException();
        }
    }
}
