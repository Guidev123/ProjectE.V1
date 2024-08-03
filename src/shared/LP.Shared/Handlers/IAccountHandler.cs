using LP.Shared.Responses;
using LP.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP.Shared.Handlers
{
    public interface IAccountHandler
    {
        Task<Response<string>> LoginAsync(LoginCommand request);
        Task<Response<string>> RegisterAsync(RegisterCommand request);
        Task LogoutAsync();
    }
}
