using LP.Core.Requests.Account;
using LP.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP.Core.Handlers
{
    public interface IAccountHandler
    {
        Task<Response<string>> LoginAsync(LoginCommand request);
        Task<Response<string>> RegisterAsync(RegisterCommand request);
        Task LogoutAsync();
    }
}
