using Homework2.Base.Response;
using Homework2.Base.Types;
using Homework2.BockAttribute;
using Homework2.Dto.Dto;
using Homework2.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Homework2.Controllers
{
    [AccountIdFilter]
    [Route("homework2/api/v1.0/[controller]")]
    [ApiController]
   
    public class PersonController : ControllerBase
    {
        private readonly IPersonService service;
        public PersonController(IPersonService service)
        {
            this.service = service;
        }


        [HttpGet]
      
        //[ResponseCache(CacheProfileName = "Duration45")]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public BaseResponse<List<PersonDto>> GetAll()
        {
            Log.Debug("PersonController.GetAll");
            var response = service.GetAll();
            return response;
        }


        [HttpGet("{id}")]
     
        //[Authorize]
        public BaseResponse<PersonDto> GetById(int id)
        {
            Log.Debug("PersonController.GetById");
            var response = service.GetById(id);
            return response;
        }

        [HttpPost]
        public BaseResponse<bool> Post([FromBody] PersonDto request)
        {
            Log.Debug("PersonController.Post");
            var response = service.Insert(request);
            return response;
        }

        [HttpPut("{id}")]
       
        public BaseResponse<bool> Put(int id, [FromBody] PersonDto request)
        {
            Log.Debug("PersonController.Put");
            request.Id = id;
            var response = service.Update(id, request);
            return response;
        }

        [HttpDelete("{id}")]
        public BaseResponse<bool> Delete(int id)
        {
            Log.Debug("PersonController.Delete");
            var response = service.Remove(id);
            return response;
        }
    }
}
