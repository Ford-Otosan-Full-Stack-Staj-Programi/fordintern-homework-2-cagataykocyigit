using Homework2.Base.Response;
using Homework2.Dto.Token;
using Homework2.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.TokenJobs
{

    [Route("ford/api/v1.0/[controller]")]
    [ApiController]

    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;
        public TokenController(ITokenManagementService tokenManagementService)
        {
            this.tokenManagementService = tokenManagementService;
        }


        [HttpPost]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenManagementService.GenerateToken(request);
            return response;
        }
    }
}
