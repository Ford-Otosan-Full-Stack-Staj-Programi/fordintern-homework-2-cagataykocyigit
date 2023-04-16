using Homework2.Base.Response;
using Homework2.Dto.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Service.Abstract
{
    public interface ITokenManagementService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest request);
    }
}
