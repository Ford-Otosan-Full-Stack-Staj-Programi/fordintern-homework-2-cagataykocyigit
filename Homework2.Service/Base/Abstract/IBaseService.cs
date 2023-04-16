using Homework2.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Service.Base.Abstract
{
    public interface IBaseService<Dto, TEntity>
    {
        BaseResponse<Dto> GetById(int id);
        BaseResponse<List<Dto>> GetAll();
        BaseResponse<bool> Insert(Dto insertResource);
        BaseResponse<bool> Update(int id, Dto updateResource);
        BaseResponse<bool> Remove(int id);
    }
}
